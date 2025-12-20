using LiveCharts;
using LiveCharts.Wpf;
using Medical.Helper;
using Medical.Models;
using Medical.Models.BusinessLogic;
using Medical.Models.EntitiesForView;
using Medical.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Medical.ViewModels
{
    public class KosztyKaretekViewModel : WorkspaceViewModel
    {
        #region Baza Danych

        private readonly MedicalEntities medicalEntities;
        #endregion

        #region Konstruktor
        public KosztyKaretekViewModel()
        {
            base.DisplayName = "Koszty Utrzymania Karetek";
            medicalEntities = new MedicalEntities();

            DataOd = DateTime.Now.AddMonths(-24);
            DataDo = DateTime.Now;
            SortOrder = SortCostEnum.LaczneKosztyMalejaco;
        }

        #endregion
        #region Właściwości - Pola

        private DateTime _DataOd;
        public DateTime DataOd
        {
            get => _DataOd;
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
            get => _DataDo;
            set
            {
                if (_DataDo != value)
                {
                    _DataDo = value;
                    OnPropertyChanged(() => DataDo);
                }
            }
        }
        private int _IdPlacowki;
        public int IdPlacowki
        {
            get => _IdPlacowki;
            set
            {
                if (_IdPlacowki != value)
                {
                    _IdPlacowki = value;
                    OnPropertyChanged(() => IdPlacowki);
                }
            }
        }

        private SortCostEnum _SortOrder;
        public SortCostEnum SortOrder
        {
            get => _SortOrder;
            set
            {
                if (_SortOrder != value)
                {
                    _SortOrder = value;
                    OnPropertyChanged(() => SortOrder);
                }
            }
        }

        public IEnumerable<KeyAndValue> SortOrderItems
        {
            get
            {
                return EnumHelper.GetEnumKeyAndValues<SortCostEnum>();
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

        private ObservableCollection<KosztyKaretkiForView> _KosztyPlacowek;
        public ObservableCollection<KosztyKaretkiForView> KosztyPlacowek
        {
            get { return _KosztyPlacowek; }
            set
            {
                if (_KosztyPlacowek != value)
                {
                    _KosztyPlacowek = value;
                    OnPropertyChanged(() => KosztyPlacowek);
                    OnPropertyChanged(() => BrakDanych);
                }
            }
        }

        public bool BrakDanych
        {
            get
            {
                return KosztyPlacowek == null || KosztyPlacowek.Count == 0;
            }
        }

        #endregion

        #region Właściwości  - wykres

        private SeriesCollection _ChartSeries;
        public SeriesCollection ChartSeries
        {
            get { return _ChartSeries; }
            set
            {
                if (_ChartSeries != value)
                {
                    _ChartSeries = value;
                    OnPropertyChanged(() => ChartSeries);
                }
            }
        }

        private string[] _ChartLabels;
        public string[] ChartLabels
        {
            get { return _ChartLabels; }
            set
            {
                if (_ChartLabels != value)
                {
                    _ChartLabels = value;
                    OnPropertyChanged(() => ChartLabels);
                }
            }
        }

        public Func<double, string> ChartFormatter => value => $"{value:C0}";

        private bool _PokazWykres;
        public bool PokazWykres
        {
            get { return _PokazWykres; }
            set
            {
                if (_PokazWykres != value)
                {
                    _PokazWykres = value;
                    OnPropertyChanged(() => PokazWykres);
                }
            }
        }
        #endregion

        #region Komendy
        private BaseCommand _GenerujRankingCommand;
        public ICommand GenerujRaportCommand
        {
            get
            {
                if (_GenerujRankingCommand == null)
                {
                    _GenerujRankingCommand = new BaseCommand(() => GenerujRaport());
                }
                return _GenerujRankingCommand;
            }
        }

        private BaseCommand _ResetujCommand;
        public ICommand ResetujCommand
        {             get
            {
                if (_ResetujCommand == null)
                {
                    _ResetujCommand = new BaseCommand(() => ResetujClick());
                }
                return _ResetujCommand;
            }
        }
        private BaseCommand _EksportujCommand;
        public ICommand EksportujCommand
        {           get
            {
                if (_EksportujCommand == null)
                {
                    _EksportujCommand = new BaseCommand(() => EksportujDoExcel());
                }
                return _EksportujCommand;
            }
        }

        private void GenerujRaport()
        {
            try
            {
                var kosztyB = new KosztyKaretekB(medicalEntities);
                var wyniki = kosztyB.GenerujRaportKosztow(DataOd, DataDo, IdPlacowki, SortOrder);

                KosztyPlacowek = new ObservableCollection<KosztyKaretkiForView>(wyniki);

                PrzygotujDaneDoWykresu();

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
                    $"Wystąpił błąd podczas generowania raportu: {ex.Message}",
                    "Błąd",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Error);
            }
        }

        #endregion

        #region Methods - Chart

        private void PrzygotujDaneDoWykresu()
        {
            if (KosztyPlacowek == null || KosztyPlacowek.Count == 0)
            {
                PokazWykres = false;
                ChartSeries = null;
                ChartLabels = null;
                return;
            }

            var topPlacowki = KosztyPlacowek.Take(15).ToList();

            ChartSeries = new SeriesCollection();

            var columnSeries = new ColumnSeries
            {
                Title = "Łączne Koszty",
                Values = new ChartValues<decimal>(topPlacowki.Select(x => x.LaczneKoszty))
            };

            ChartSeries.Add(columnSeries);

            ChartLabels = topPlacowki.Select(x => x.NazwaPlacowki).ToArray();

            PokazWykres = true;
        }

        private void ResetujClick()
        {
            DataOd = DateTime.Now.AddMonths(-24);
            DataDo = DateTime.Now;
            IdPlacowki = 0;
            SortOrder = SortCostEnum.LaczneKosztyMalejaco;
            KosztyPlacowek = new ObservableCollection<KosztyKaretkiForView>();
            ChartSeries = null;
            ChartLabels = null;
            PokazWykres = false;
        }

        private void EksportujDoExcel()
        {
            // TODO: Jak starczy czasu!!
            System.Windows.MessageBox.Show(
                "Funkcja eksportu zostanie wkrótce dodana.",
                "Informacja",
                System.Windows.MessageBoxButton.OK,
                System.Windows.MessageBoxImage.Information);
        }

        #endregion
    }
}
