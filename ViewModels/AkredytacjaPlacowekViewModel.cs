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
            SortOrder = 0;
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
                var placowkiQuery = from placowka in medicalEntities.Placowka
                                    where placowka.CzyAktywny == true
                                    select placowka;

                if (IdPlacowki.HasValue && IdPlacowki.Value > 0)
                {
                    placowkiQuery = placowkiQuery.Where(p => p.IdPlacowki == IdPlacowki.Value);
                }

                var placowki = placowkiQuery.ToList();
                var wyniki = new List<AkredytacjaPlacowkiForView>();

                foreach (var placowka in placowki)
                {
                    var zespoly = placowka.ZespolRatunkowy
                        .Where(z => z.CzyAktywny == true)
                        .ToList();

                    var oceny = zespoly
                        .SelectMany(z => z.OcenaZespolu)
                        .Where(o => o.CzyAktywny == true
                                && o.DataOceny >= DataOd
                                && o.DataOceny <= DataDo)
                        .ToList();

                    decimal sredniaOcena = oceny.Any() ? (decimal)oceny.Average(o => o.Ocena) : 0;
                    int liczbaOcen = oceny.Count;

                    var interwencje = zespoly
                        .SelectMany(z => z.UdzielonaPomoc)
                        .Where(u => u.CzyAktywny == true
                                && u.DataPomocy >= DataOd
                                && u.DataPomocy <= DataDo)
                        .ToList();

                    int liczbaInterwencji = interwencje.Count;

                    int liczbaAktywnychZespolow = zespoly.Count;
                    int liczbaAktywnychKaretek = placowka.Karetka
                        .Count(k => k.CzyAktywny == true && k.Status == "Sprawna");

                    int punktyOceny = ObliczPunktyZaOceny(sredniaOcena, liczbaOcen);
                    int punktyInterwencje = ObliczPunktyZaInterwencje(liczbaInterwencji);
                    int punktyKaretki = ObliczPunktyZaKaretki(liczbaAktywnychZespolow, liczbaAktywnychKaretek);
                    int lacznePunkty = punktyOceny + punktyInterwencje + punktyKaretki;

                    bool czyAkredytowana = OkreslStatusAkredytacji(lacznePunkty);

                    if (liczbaOcen < MinimalnaLiczbaOcen)
                        continue;

                    var wynik = new AkredytacjaPlacowkiForView
                    {
                        IdPlacowki = placowka.IdPlacowki,
                        NazwaPlacowki = placowka.NazwaPlacowki,
                        SredniaOcenaZespolow = sredniaOcena,
                        LiczbaOcen = liczbaOcen,
                        PunktyZaOceny = punktyOceny,
                        LiczbaInterwencji = liczbaInterwencji,
                        PunktyZaInterwencje = punktyInterwencje,
                        LiczbaAktywnychZespolow = liczbaAktywnychZespolow,
                        LiczbaAktywnychKaretek = liczbaAktywnychKaretek,
                        PunktyZaKaretki = punktyKaretki,
                        LacznePunkty = lacznePunkty,
                        CzyAkredytowana = czyAkredytowana,
                        StatusAkredytacji = OkreslStatusTekst(czyAkredytowana),
                        KolorStatusu = OkreslKolorStatusu(czyAkredytowana)
                    };

                    wynik.Rekomendacje = GenerujRekomendacje(wynik);
                    wyniki.Add(wynik);
                }

                IEnumerable<AkredytacjaPlacowkiForView> sortedQuery = null;
                switch (SortOrder)
                {
                    case 0:
                        sortedQuery = wyniki.OrderByDescending(x => x.LacznePunkty);
                        break;
                    case 1:
                        sortedQuery = wyniki.OrderBy(x => x.LacznePunkty);
                        break;
                    case 2:
                        sortedQuery = wyniki.OrderByDescending(x => x.CzyAkredytowana)
                                            .ThenByDescending(x => x.LacznePunkty);
                        break;
                    default:
                        sortedQuery = wyniki.OrderByDescending(x => x.LacznePunkty);
                        break;
                }

                var wynikiFinalne = new ObservableCollection<AkredytacjaPlacowkiForView>();
                int pozycja = 1;
                foreach (var item in sortedQuery)
                {
                    item.Pozycja = pozycja++;
                    wynikiFinalne.Add(item);
                }

                WynikiAkredytacji = wynikiFinalne;
                ObliczStatystykiOgolne(wynikiFinalne);
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
            SortOrder = 0;
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

        private int ObliczPunktyZaOceny(decimal sredniaOcena, int liczbaOcen)
        {
            int punkty = 0;

            if (sredniaOcena >= 9.0m)
                punkty += 25;
            else if (sredniaOcena >= 8.0m)
                punkty += 20;
            else if (sredniaOcena >= 7.0m)
                punkty += 15;
            else if (sredniaOcena >= 6.0m)
                punkty += 10;
            else if (sredniaOcena >= 5.0m)
                punkty += 5;

            if (liczbaOcen >= 50)
                punkty += 15;
            else if (liczbaOcen >= 30)
                punkty += 12;
            else if (liczbaOcen >= 20)
                punkty += 9;
            else if (liczbaOcen >= 10)
                punkty += 6;
            else if (liczbaOcen >= 5)
                punkty += 3;

            return Math.Min(punkty, 40);
        }

        private int ObliczPunktyZaInterwencje(int liczbaInterwencji)
        {
            if (liczbaInterwencji >= 200)
                return 40;
            else if (liczbaInterwencji >= 150)
                return 35;
            else if (liczbaInterwencji >= 100)
                return 30;
            else if (liczbaInterwencji >= 75)
                return 25;
            else if (liczbaInterwencji >= 50)
                return 20;
            else if (liczbaInterwencji >= 30)
                return 15;
            else if (liczbaInterwencji >= 20)
                return 10;
            else if (liczbaInterwencji >= 10)
                return 5;
            else
                return 0;
        }

        private int ObliczPunktyZaKaretki(int liczbaZespolow, int liczbaKaretek)
        {
            int punkty = 0;

            if (liczbaZespolow >= 5)
                punkty += 10;
            else if (liczbaZespolow >= 4)
                punkty += 8;
            else if (liczbaZespolow >= 3)
                punkty += 6;
            else if (liczbaZespolow >= 2)
                punkty += 4;
            else if (liczbaZespolow >= 1)
                punkty += 2;

            if (liczbaKaretek >= 8)
                punkty += 10;
            else if (liczbaKaretek >= 6)
                punkty += 8;
            else if (liczbaKaretek >= 4)
                punkty += 6;
            else if (liczbaKaretek >= 3)
                punkty += 4;
            else if (liczbaKaretek >= 2)
                punkty += 2;

            return Math.Min(punkty, 20);
        }

        private bool OkreslStatusAkredytacji(int lacznePunkty)
        {
            const int PROG_AKREDYTACJI = 25;
            return lacznePunkty >= PROG_AKREDYTACJI;
        }

        private string OkreslStatusTekst(bool czyAkredytowana)
        {
            return czyAkredytowana ? "Akredytowana" : "Nieakredytowana";
        }

        private string OkreslKolorStatusu(bool czyAkredytowana)
        {
            return czyAkredytowana ? "Green" : "Red";
        }

        private string GenerujRekomendacje(AkredytacjaPlacowkiForView wynik)
        {
            var rekomendacje = new List<string>();

            if (wynik.PunktyZaOceny < 20)
                rekomendacje.Add("Poprawa ocen zespołów");

            if (wynik.LiczbaOcen < 10)
                rekomendacje.Add("Zbieranie większej liczby ocen");

            if (wynik.PunktyZaInterwencje < 20)
                rekomendacje.Add("Zwiększenie liczby interwencji");

            if (wynik.LiczbaAktywnychZespolow < 3)
                rekomendacje.Add("Rozbudowa zespołów ratunkowych");

            if (wynik.LiczbaAktywnychKaretek < 4)
                rekomendacje.Add("Zwiększenie floty karetek");

            if (rekomendacje.Count == 0)
                return wynik.CzyAkredytowana ? "Brak - placówka spełnia wszystkie kryteria" : "Wymaga poprawy w wielu obszarach";

            return string.Join(", ", rekomendacje);
        }

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