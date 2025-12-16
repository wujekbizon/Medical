using Medical.Helper;
using Medical.Models;
using Medical.Models.BusinessLogic;
using Medical.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Medical.ViewModels
{
    public class RankingEfektywnosciZespolowMedycznychViewModel : WorkspaceViewModel
    {
        #region Baza Danych
        private readonly MedicalEntities medicalEntities;
        #endregion

        #region Konstruktor
        public RankingEfektywnosciZespolowMedycznychViewModel()
        {
            base.DisplayName = "Ranking Efektywności";
            medicalEntities = new MedicalEntities();

            DataOd = DateTime.Now.AddMonths(-24);
            DataDo = DateTime.Now;
            MinSredniaOcena = 7.0m;
            IdZespolu = 0;
            SortOrder = 0;
            RankingZespolow = new ObservableCollection<RankingZespolowForView>();
            LiczbaZespolow = 0;
            OgolnaSredniaOcena = 0;
            LacznaLiczbaOcen = 0;
            NajlepszyWynik = 0;
        }
        #endregion

        #region Właściwości - Filtry

        private DateTime _DataOd;
        public DateTime DataOd
        {
            get { return _DataOd; }
            set
            {
                if (_DataOd != value)
                {
                    _DataOd = value;
                    OnPropertyChanged(() => DataOd);
                }
            }
        }

        private DateTime _DataDo;
        public DateTime DataDo
        {
            get { return _DataDo; }
            set
            {
                if (_DataDo != value)
                {
                    _DataDo = value;
                    OnPropertyChanged(() => DataDo);
                }
            }
        }

        private decimal _MinSredniaOcena;
        public decimal MinSredniaOcena
        {
            get { return _MinSredniaOcena; }
            set
            {
                if (_MinSredniaOcena != value)
                {
                    _MinSredniaOcena = value;
                    OnPropertyChanged(() => MinSredniaOcena);
                }
            }
        }

        private int? _IdZespolu;
        public int? IdZespolu
        {
            get { return _IdZespolu; }
            set
            {
                if (_IdZespolu != value)
                {
                    _IdZespolu = value;
                    OnPropertyChanged(() => IdZespolu);
                }
            }
        }

        private int _SortOrder;
        public int SortOrder
        {
            get { return _SortOrder; }
            set
            {
                if (_SortOrder != value)
                {
                    _SortOrder = value;
                    OnPropertyChanged(() => SortOrder);
                }
            }
        }

        public IQueryable<KeyAndValue> ZespolyComboBoxItems
        {
            get
            {
                return new ZespolRatunkowyB(medicalEntities).GetZespolyKeyAndValueItems();
            }
        }

        #endregion

        #region Właściwości - Wyniki

        private ObservableCollection<RankingZespolowForView> _RankingZespolow;
        public ObservableCollection<RankingZespolowForView> RankingZespolow
        {
            get { return _RankingZespolow; }
            set
            {
                if (_RankingZespolow != value)
                {
                    _RankingZespolow = value;
                    OnPropertyChanged(() => RankingZespolow);
                    OnPropertyChanged(() => BrakDanych);
                }
            }
        }

        public bool BrakDanych
        {
            get { return RankingZespolow == null || RankingZespolow.Count == 0; }
        }

        #endregion

        #region Właściwości - Statystyki

        private int _LiczbaZespolow;
        public int LiczbaZespolow
        {
            get { return _LiczbaZespolow; }
            set
            {
                if (_LiczbaZespolow != value)
                {
                    _LiczbaZespolow = value;
                    OnPropertyChanged(() => LiczbaZespolow);
                }
            }
        }

        private decimal _OgolnaSredniaOcena;
        public decimal OgolnaSredniaOcena
        {
            get { return _OgolnaSredniaOcena; }
            set
            {
                if (_OgolnaSredniaOcena != value)
                {
                    _OgolnaSredniaOcena = value;
                    OnPropertyChanged(() => OgolnaSredniaOcena);
                }
            }
        }

        private int _LacznaLiczbaOcen;
        public int LacznaLiczbaOcen
        {
            get { return _LacznaLiczbaOcen; }
            set
            {
                if (_LacznaLiczbaOcen != value)
                {
                    _LacznaLiczbaOcen = value;
                    OnPropertyChanged(() => LacznaLiczbaOcen);
                }
            }
        }

        private decimal _NajlepszyWynik;
        public decimal NajlepszyWynik
        {
            get { return _NajlepszyWynik; }
            set
            {
                if (_NajlepszyWynik != value)
                {
                    _NajlepszyWynik = value;
                    OnPropertyChanged(() => NajlepszyWynik);
                }
            }
        }

        #endregion

        #region Komendy

        private BaseCommand _GenerujRankingCommand;
        public ICommand GenerujRankingCommand
        {
            get
            {
                if (_GenerujRankingCommand == null)
                {
                    _GenerujRankingCommand = new BaseCommand(() => GenerujRankingClick());
                }
                return _GenerujRankingCommand;
            }
        }

        private void GenerujRankingClick()
        {
            try
            {
                var query = from zespol in medicalEntities.ZespolRatunkowy
                            where zespol.CzyAktywny == true
                            select new
                            {
                                Zespol = zespol,
                                Oceny = zespol.OcenaZespolu
                                    .Where(o => o.CzyAktywny == true
                                            && o.DataOceny >= DataOd
                                            && o.DataOceny <= DataDo)
                            };

                if (IdZespolu.HasValue && IdZespolu.Value > 0)
                {
                    query = query.Where(x => x.Zespol.IdZespolu == IdZespolu.Value);
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
                    .Where(x => x.SredniaOcena >= MinSredniaOcena)
                    .ToList();

                IEnumerable<dynamic> sortedQuery = null;
                switch (SortOrder)
                {
                    case 0:
                        sortedQuery = wyniki.OrderByDescending(x => x.SredniaOcena);
                        break;
                    case 1:
                        sortedQuery = wyniki.OrderBy(x => x.SredniaOcena);
                        break;
                    case 2:
                        sortedQuery = wyniki.OrderByDescending(x => x.LiczbaOcen);
                        break;
                    case 3:
                        sortedQuery = wyniki.OrderBy(x => x.NazwaZespolu);
                        break;
                    default:
                        sortedQuery = wyniki.OrderByDescending(x => x.SredniaOcena);
                        break;
                }

                var rankingWyniki = new ObservableCollection<RankingZespolowForView>();
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

                RankingZespolow = rankingWyniki;

                ObliczStatystyki(rankingWyniki);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Błąd podczas generowania rankingu: {ex.Message}",
                    "Błąd",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Error);
            }
        }

        private BaseCommand _ResetujCommand;
        public ICommand ResetujCommand
        {
            get
            {
                if (_ResetujCommand == null)
                {
                    _ResetujCommand = new BaseCommand(() => ResetujClick());
                }
                return _ResetujCommand;
            }
        }

        private void ResetujClick()
        {
            DataOd = DateTime.Now.AddMonths(-6);
            DataDo = DateTime.Now;
            MinSredniaOcena = 7.0m;
            IdZespolu = 0;
            SortOrder = 0;
            RankingZespolow = new ObservableCollection<RankingZespolowForView>();
            LiczbaZespolow = 0;
            OgolnaSredniaOcena = 0;
            LacznaLiczbaOcen = 0;
            NajlepszyWynik = 0;
        }

        private BaseCommand _EksportujCommand;
        public ICommand EksportujCommand
        {
            get
            {
                if (_EksportujCommand == null)
                {
                    _EksportujCommand = new BaseCommand(() => EksportujClick());
                }
                return _EksportujCommand;
            }
        }

        private void EksportujClick()
        {
            // TODO: Implementacja eksportu do Excel
            System.Windows.MessageBox.Show(
                "Funkcja eksportu zostanie wkrótce dodana.",
                "Informacja",
                System.Windows.MessageBoxButton.OK,
                System.Windows.MessageBoxImage.Information);
        }

        #endregion

        #region Metody pomocnicze

        private void ObliczStatystyki(ObservableCollection<RankingZespolowForView> wyniki)
        {
            if (wyniki == null || wyniki.Count == 0)
            {
                LiczbaZespolow = 0;
                OgolnaSredniaOcena = 0;
                LacznaLiczbaOcen = 0;
                NajlepszyWynik = 0;
                return;
            }

            LiczbaZespolow = wyniki.Count;
            OgolnaSredniaOcena = wyniki.Average(x => x.SredniaOcena);
            LacznaLiczbaOcen = wyniki.Sum(x => x.LiczbaOcen);
            NajlepszyWynik = wyniki.Max(x => x.SredniaOcena);
        }

        private string OkreslStatus(decimal sredniaOcena)
        {
            if (sredniaOcena >= 9.0m)
                return "Wybitny";
            else if (sredniaOcena >= 8.0m)
                return "Bardzo dobry";
            else if (sredniaOcena >= 7.0m)
                return "Dobry";
            else
                return "Zadowalający";
        }

        private string OkreslStatusKolor(decimal sredniaOcena)
        {
            if (sredniaOcena >= 9.0m)
                return "Green";
            else if (sredniaOcena >= 8.0m)
                return "Green";
            else if (sredniaOcena >= 7.0m)
                return "Orange";
            else
                return "Red";
        }

        #endregion
    }
}