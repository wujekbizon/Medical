using GalaSoft.MvvmLight.Messaging;
using Medical.Models.EntitiesForView;
using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.ViewModels
{
    public class WszystkieZespolyRatunkoweViewModel : WszystkieViewModel<ZespolRatunkowyForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<ZespolRatunkowyForAllView>
                (
                   medicalEntities.ZespolRatunkowy
                   .Where(zespol => zespol.CzyAktywny == true)
                   .Select(zespol => new ZespolRatunkowyForAllView
                   {
                       IdZespolu = zespol.IdZespolu,
                       NazwaZespolu = zespol.NazwaZespolu,
                       LiczbaCzlonkow = zespol.LiczbaCzlonkow,
                       Specjalizacja = zespol.Specjalizacja,
                       DataUtworzenia = zespol.DataUtworzenia,
                       StatusZespolu = zespol.StatusZespolu,
                       TelefonKontaktowy = zespol.TelefonKontaktowy,
                       Zmiana = zespol.Zmiana,
                       DataOstatniegoSzkolenia = zespol.DataOstatniegoSzkolenia,
                       SredniaOcena = zespol.SredniaOcena,
                       DataOstatniegoWyjazdu = zespol.DataOstatniegoWyjazdu,
                       LiczbaWszystkichWyjazdow = zespol.LiczbaWszystkichWyjazdow,
                       Certyfikaty = zespol.Certyfikaty,
                       Karetka = zespol.Karetka.NumerRejestracyjny,
                       NazwaPlacowki = zespol.Placowka.NazwaPlacowki
                   })
                   .ToList()
                );
        }
        #endregion

        #region Konstruktor
        public WszystkieZespolyRatunkoweViewModel()
        {
            base.DisplayName = "Zespoly Ratunkowe";
        }
        #endregion
        #region Właściwosci
        private ZespolRatunkowyForAllView _WybranyZespol;
        public ZespolRatunkowyForAllView WybranyZespol
        {
            get { return _WybranyZespol; }
            set
            {
                if (_WybranyZespol != value)
                {
                    _WybranyZespol = value;
                    Messenger.Default.Send(_WybranyZespol);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Sortowanie i Filtrowanie
        public override List<string> getComboBoxSortList()
        {
            return new List<string>
    {
        "nazwaZespolu",
        "liczbaCzlonkow",
        "specjalizacja",
        "dataUtworzenia",
        "statusZespolu",
        "zmiana",
        "dataOstatniegoSzkolenia",
        "sredniaOcena",
        "dataOstatniegoWyjazdu",
        "liczbaWszystkichWyjazdow",
        "nazwaPlacowki",
        "karetka"
    };
        }

        public override List<string> getComboBoxFindList()
        {
            return new List<string>
    {
        "nazwaZespolu",
        "specjalizacja",
        "statusZespolu",
        "zmiana",
        "nazwaPlacowki",
        "karetka",
        "telefonKontaktowy",
        "certyfikaty"
    };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "nazwaZespolu":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.OrderBy(item => item.NazwaZespolu));
                    break;
                case "liczbaCzlonkow":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.OrderBy(item => item.LiczbaCzlonkow));
                    break;
                case "specjalizacja":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.OrderBy(item => item.Specjalizacja));
                    break;
                case "dataUtworzenia":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.OrderBy(item => item.DataUtworzenia));
                    break;
                case "statusZespolu":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.OrderBy(item => item.StatusZespolu));
                    break;
                case "zmiana":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.OrderBy(item => item.Zmiana));
                    break;
                case "dataOstatniegoSzkolenia":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.OrderBy(item => item.DataOstatniegoSzkolenia));
                    break;
                case "sredniaOcena":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.OrderBy(item => item.SredniaOcena));
                    break;
                case "dataOstatniegoWyjazdu":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.OrderBy(item => item.DataOstatniegoWyjazdu));
                    break;
                case "liczbaWszystkichWyjazdow":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.OrderBy(item => item.LiczbaWszystkichWyjazdow));
                    break;
                case "nazwaPlacowki":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.OrderBy(item => item.NazwaPlacowki));
                    break;
                case "karetka":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.OrderBy(item => item.Karetka));
                    break;
                default:
                    break;
            }
        }

        public override void Find()
        {
            switch (FindField)
            {
                case "nazwaZespolu":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.Where(item =>
                        item.NazwaZespolu != null && item.NazwaZespolu.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "specjalizacja":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.Where(item =>
                        item.Specjalizacja != null && item.Specjalizacja.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "statusZespolu":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.Where(item =>
                        item.StatusZespolu != null && item.StatusZespolu.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "zmiana":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.Where(item =>
                        item.Zmiana != null && item.Zmiana.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "nazwaPlacowki":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.Where(item =>
                        item.NazwaPlacowki != null && item.NazwaPlacowki.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "karetka":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.Where(item =>
                        item.Karetka != null && item.Karetka.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "telefonKontaktowy":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.Where(item =>
                        item.TelefonKontaktowy != null && item.TelefonKontaktowy.Contains(FindTextBox)));
                    break;
                case "certyfikaty":
                    List = new ObservableCollection<ZespolRatunkowyForAllView>(List.Where(item =>
                        item.Certyfikaty != null && item.Certyfikaty.Contains(FindTextBox)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}