using Medical.Models.EntitiesForView;
using Medical.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.BusinessLogic
{
    public class KosztyKaretekB : DatabaseClass
    {
        #region Konstruktor
        public KosztyKaretekB(MedicalEntities medicalEntities)
            : base(medicalEntities)
        {
        }
        #endregion

        #region Funkcje biznesowe
        public List<KosztyKaretkiForView> GenerujRaportKosztow(
            DateTime dataOd,
            DateTime dataDo,
            int idPlacowki,
            SortCostEnum sortOrder)
        {
            var query = from karetka in medicalEntities.Karetka
                        where karetka.CzyAktywny == true
                        select new
                        {
                            Karetka = karetka,
                            Koszty = karetka.KosztUtrzymania
                                .Where(k => k.CzyAktywny == true
                                        && k.DataKosztu >= dataOd
                                        && k.DataKosztu <= dataDo)
                        };

            if (idPlacowki > 0)
            {
                query = query.Where(x => x.Karetka.IdPlacowki == idPlacowki);
            }

            var wyniki = query.ToList()
                .GroupBy(x => x.Karetka.IdPlacowki)
                .Select(g => new
                {
                    IdPlacowki = g.Key,
                    NazwaPlacowki = g.First().Karetka.Placowka.NazwaPlacowki,
                    LiczbaKaretek = g.Count(),
                    LaczneKoszty = g.SelectMany(x => x.Koszty).Sum(k => k.Kwota),
                    LiczbaKosztow = g.SelectMany(x => x.Koszty).Count(),
                    SredniKosztNaKaretke = g.Count() > 0
                        ? g.SelectMany(x => x.Koszty).Sum(k => k.Kwota) / g.Count()
                        : 0
                })
                .Where(x => x.LiczbaKosztow > 0)
                .ToList();

            var sortedQuery = SortujWyniki(wyniki, sortOrder);

            var kosztyWyniki = new List<KosztyKaretkiForView>();
            int pozycja = 1;

            foreach (var item in sortedQuery)
            {
                var kategoria = OkreslKategorieKosztow(item.LaczneKoszty);

                kosztyWyniki.Add(new KosztyKaretkiForView
                {
                    Pozycja = pozycja++,
                    IdPlacowki = item.IdPlacowki,
                    NazwaPlacowki = item.NazwaPlacowki,
                    LiczbaKaretek = item.LiczbaKaretek,
                    LaczneKoszty = item.LaczneKoszty,
                    LiczbaKosztow = item.LiczbaKosztow,
                    SredniKosztNaKaretke = item.SredniKosztNaKaretke,
                    KategoriaKosztow = kategoria,
                    KolorKategorii = OkreslKolorKategorii(kategoria)
                });
            }

            return kosztyWyniki;
        }
        private IEnumerable<dynamic> SortujWyniki(IEnumerable<dynamic> wyniki, SortCostEnum sortOrder)
        {
            switch (sortOrder)
            {
                case SortCostEnum.LaczneKosztyMalejaco:
                    return wyniki.OrderByDescending(x => x.LaczneKoszty);
                case SortCostEnum.LaczneKosztyRosnaco:
                    return wyniki.OrderBy(x => x.LaczneKoszty);
                case SortCostEnum.LaczneLiczbaKosztowMalejaco:
                    return wyniki.OrderByDescending(x => x.LiczbaKosztow);
                default:
                    return wyniki.OrderByDescending(x => x.LaczneKoszty);
            }
        }

        private string OkreslKategorieKosztow(decimal laczneKoszty)
        {
            if (laczneKoszty >= 100000)
                return "Wysokie";
            else if (laczneKoszty >= 50000)
                return "Średnie";
            else
                return "Niskie";
        }

        private string OkreslKolorKategorii(string kategoria)
        {
            switch (kategoria)
            {
                case "Wysokie":
                    return "Red";
                case "Średnie":
                    return "Orange";
                case "Niskie":
                    return "Green";
                default:
                    return "Gray";
            }
        }
        #endregion
    }
}
