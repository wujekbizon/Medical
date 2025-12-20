using Medical.Models.EntitiesForView;
using Medical.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.BusinessLogic
{
    public class RankingZespolowB : DatabaseClass
    {
        public RankingZespolowB(MedicalEntities medicalEntities) 
            : base(medicalEntities)
        {
        }

        #region Funkcje biznesowe

        public List<RankingZespolowForView> GenerujRanking(
           DateTime dataOd,
           DateTime dataDo,
           decimal minSredniaOcena,
           int? idZespolu,
           SortOrderEnum sortOrder)
        {
            var query = from zespol in medicalEntities.ZespolRatunkowy
                        where zespol.CzyAktywny == true
                        select new
                        {
                            Zespol = zespol,
                            Oceny = zespol.OcenaZespolu
                                .Where(o => o.CzyAktywny == true
                                        && o.DataOceny >= dataOd
                                        && o.DataOceny <= dataDo)
                        };

            if (idZespolu.HasValue && idZespolu.Value > 0)
            {
                query = query.Where(x => x.Zespol.IdZespolu == idZespolu.Value);
            }

            var wyniki = query.ToList()
                .Where(x => x.Oceny.Any())
                .Select(x => new
                {
                    IDZespolu = x.Zespol.IdZespolu,
                    NazwaZespolu = x.Zespol.NazwaZespolu,
                    SredniaOcena = (decimal)x.Oceny.Average(o => o.Ocena),
                    LiczbaOcen = x.Oceny.Count(),
                    SumaOcen = (decimal)x.Oceny.Sum(o => o.Ocena)
                })
                .Where(x => x.SredniaOcena >= minSredniaOcena)
                .ToList();

            var sortedQuery = SortujWyniki(wyniki, sortOrder);

            var rankingWyniki = new List<RankingZespolowForView>();
            int pozycja = 1;

            foreach (var item in sortedQuery)
            {
                rankingWyniki.Add(new RankingZespolowForView
                {
                    Pozycja = pozycja++,
                    IDZespolu = item.IDZespolu,
                    NazwaZespolu = item.NazwaZespolu,
                    SredniaOcena = item.SredniaOcena,
                    LiczbaOcen = item.LiczbaOcen,
                    SumaOcen = item.SumaOcen,
                    Status = OkreslStatus(item.SredniaOcena),
                    StatusKolor = OkreslStatusKolor(item.SredniaOcena)
                });
            }

            return rankingWyniki;
        }
        #endregion

        #region Funkcje Pomocnicze

        private IEnumerable<dynamic> SortujWyniki(IEnumerable<dynamic> wyniki, SortOrderEnum sortOrder)
        {
            switch (sortOrder)
            {
                case SortOrderEnum.SredniaOcenaMalejaco:
                    return wyniki.OrderByDescending(x => x.SredniaOcena);
                case SortOrderEnum.SredniaOcenaRosnaco:
                    return wyniki.OrderBy(x => x.SredniaOcena);
                case SortOrderEnum.LiczbaOcenMalejaco:
                    return wyniki.OrderByDescending(x => x.LiczbaOcen);
                case SortOrderEnum.NazwaZespoluAZ:
                    return wyniki.OrderBy(x => x.NazwaZespolu);
                default:
                    return wyniki.OrderByDescending(x => x.SredniaOcena);
            }
        }

        private string OkreslStatus(decimal sredniaOcena)
        {
            if (sredniaOcena >= 9.0m) return "Wybitny";
            if (sredniaOcena >= 8.0m) return "Bardzo dobry";
            if (sredniaOcena >= 7.0m) return "Dobry";
            return "Zadowalający";
        }

        private string OkreslStatusKolor(decimal sredniaOcena)
        {
            if (sredniaOcena >= 9.0m) return "Gold";
            if (sredniaOcena >= 8.0m) return "Green";
            if (sredniaOcena >= 7.0m) return "Orange";
            return "Red";
        }
        #endregion
    }
}
