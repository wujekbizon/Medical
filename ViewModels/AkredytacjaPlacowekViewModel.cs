using Medical.Helper;
using Medical.Models;
using Medical.Models.BusinessLogic;
using Medical.Models.EntitiesForView;
using Medical.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Medical.ViewModels
{
    public class AkredytacjaPlacowekViewModel : WorkspaceViewModel
    {
        #region Baza Danych
        private readonly MedicalEntities medicalEntities;
        #endregion

        #region Konstruktor
        public AkredytacjaPlacowekViewModel()
        {
            base.DisplayName = "Akredytacja Placówek";
            medicalEntities = new MedicalEntities();

            DataOd = DateTime.Now.AddMonths(-24);
            DataDo = DateTime.Now;
            MinimalnaLiczbaOcen = 10;
            IdPlacowki = 0;
            SortPoints = SortPointsEnum.LacznePunktyMalejaco;
            WynikiAkredytacji = new ObservableCollection<AkredytacjaPlacowkiForView>();
            LiczbaPlacowek = 0;
            LiczbaAkredytowanych = 0;
            ProcentAkredytowanych = 0;
            SredniaPunktow = 0;
        }
        #endregion

        #region Właściwości - Pola

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

        private int _MinimalnaLiczbaOcen;
        public int MinimalnaLiczbaOcen
        {
            get { return _MinimalnaLiczbaOcen; }
            set
            {
                if (_MinimalnaLiczbaOcen != value)
                {
                    _MinimalnaLiczbaOcen = value;
                    OnPropertyChanged(() => MinimalnaLiczbaOcen);
                }
            }
        }

        private int? _IdPlacowki;
        public int? IdPlacowki
        {
            get { return _IdPlacowki; }
            set
            {
                if (_IdPlacowki != value)
                {
                    _IdPlacowki = value;
                    OnPropertyChanged(() => IdPlacowki);
                }
            }
        }

        private SortPointsEnum _SortPoints;
        public SortPointsEnum SortPoints
        {
            get { return _SortPoints; }
            set
            {
                if (_SortPoints != value)
                {
                    _SortPoints = value;
                    OnPropertyChanged(() => SortPoints);
                }
            }
        }

        public IEnumerable<KeyAndValue> SortPointsItems
        {
            get
            {
                return EnumHelper.GetEnumKeyAndValues<SortPointsEnum>();
            }
        }

        public IQueryable<KeyAndValue> PlacowkiComboBoxItems
        {
            get
            {
                return new PlacowkaB(medicalEntities).GetPlacowkiKeyAndValueItems();
            }
        }

        #endregion

        #region Właściwości - Wyniki

        private ObservableCollection<AkredytacjaPlacowkiForView> _WynikiAkredytacji;
        public ObservableCollection<AkredytacjaPlacowkiForView> WynikiAkredytacji
        {
            get { return _WynikiAkredytacji; }
            set
            {
                if (_WynikiAkredytacji != value)
                {
                    _WynikiAkredytacji = value;
                    OnPropertyChanged(() => WynikiAkredytacji);
                    OnPropertyChanged(() => BrakDanych);
                }
            }
        }
        public bool BrakDanych
        {
            get { return WynikiAkredytacji == null || WynikiAkredytacji.Count == 0; }
        }

        #endregion

        #region Właściwości - Statystyki

        private int _LiczbaPlacowek;
        public int LiczbaPlacowek
        {
            get { return _LiczbaPlacowek; }
            set
            {
                if (_LiczbaPlacowek != value)
                {
                    _LiczbaPlacowek = value;
                    OnPropertyChanged(() => LiczbaPlacowek);
                }
            }
        }

        private int _LiczbaAkredytowanych;
        public int LiczbaAkredytowanych
        {
            get { return _LiczbaAkredytowanych; }
            set
            {
                if (_LiczbaAkredytowanych != value)
                {
                    _LiczbaAkredytowanych = value;
                    OnPropertyChanged(() => LiczbaAkredytowanych);
                }
            }
        }

        private decimal _ProcentAkredytowanych;
        public decimal ProcentAkredytowanych
        {
            get { return _ProcentAkredytowanych; }
            set
            {
                if (_ProcentAkredytowanych != value)
                {
                    _ProcentAkredytowanych = value;
                    OnPropertyChanged(() => ProcentAkredytowanych);
                }
            }
        }

        private decimal _SredniaPunktow;
        public decimal SredniaPunktow
        {
            get { return _SredniaPunktow; }
            set
            {
                if (_SredniaPunktow != value)
                {
                    _SredniaPunktow = value;
                    OnPropertyChanged(() => SredniaPunktow);
                }
            }
        }
        #endregion

        #region Komendy

        private BaseCommand _OcenAkredytacjeCommand;
        public ICommand OcenAkredytacjeCommand
        {
            get
            {
                if (_OcenAkredytacjeCommand == null)
                {
                    _OcenAkredytacjeCommand = new BaseCommand(() => OcenAkredytacjeClick());
                }
                return _OcenAkredytacjeCommand;
            }
        }

        private void OcenAkredytacjeClick()
        {
            try
            {
                var akredytacjaB = new AkredytacjaPlacowekB(medicalEntities);
                var wyniki = akredytacjaB.OcenAkredytacje(
                    DataOd,
                    DataDo,
                    MinimalnaLiczbaOcen,
                    IdPlacowki,
                    SortPoints);

                WynikiAkredytacji = new ObservableCollection<AkredytacjaPlacowkiForView>(wyniki);
                ObliczStatystykiOgolne(WynikiAkredytacji);

                if (BrakDanych)
                {
                    System.Windows.MessageBox.Show(
                        "Brak danych dla wybranych kryteriów.",
                        "Informacja",
                        System.Windows.MessageBoxButton.OK,
                        System.Windows.MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Błąd podczas oceny akredytacji: {ex.Message}",
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
            DataOd = DateTime.Now.AddMonths(-24);
            DataDo = DateTime.Now;
            IdPlacowki = 0;
            MinimalnaLiczbaOcen = 10;
            SortPoints = SortPointsEnum.LacznePunktyMalejaco;
            WynikiAkredytacji = new ObservableCollection<AkredytacjaPlacowkiForView>();
            LiczbaPlacowek = 0;
            LiczbaAkredytowanych = 0;
            ProcentAkredytowanych = 0;
            SredniaPunktow = 0;
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

        #endregion

        #region Metody pomocnicze

        private void ObliczStatystykiOgolne(ObservableCollection<AkredytacjaPlacowkiForView> wyniki)
        {
            if (wyniki == null || wyniki.Count == 0)
            {
                LiczbaPlacowek = 0;
                LiczbaAkredytowanych = 0;
                ProcentAkredytowanych = 0;
                SredniaPunktow = 0;
                return;
            }

            LiczbaPlacowek = wyniki.Count;
            LiczbaAkredytowanych = wyniki.Count(w => w.CzyAkredytowana);
            ProcentAkredytowanych = (decimal)LiczbaAkredytowanych / LiczbaPlacowek * 100;
            SredniaPunktow = (decimal)wyniki.Average(w => w.LacznePunkty);
        }
        private void EksportujClick()
        {
            System.Windows.MessageBox.Show(
                "Funkcja eksportu zostanie wkrótce dodana.",
                "Informacja",
                System.Windows.MessageBoxButton.OK,
                System.Windows.MessageBoxImage.Information);
        }
        #endregion
    }
}