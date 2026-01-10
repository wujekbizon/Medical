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
    public class WszystkieZleceniaWyjazduViewModel : WszystkieViewModel<ZleceniaWyjazduForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<ZleceniaWyjazduForAllView>
                (
                   medicalEntities.ZlecenieWyjazdu
                   .Where(zlecenie => zlecenie.CzyAktywny == true)
                   .Select(zlecenie => new ZleceniaWyjazduForAllView
                   {
                       IdWyjazdu = zlecenie.IdWyjazdu,
                       DataCzasZgloszenia = zlecenie.DataCzasZgloszenia,
                       AdresZdarzenia = zlecenie.AdresZdarzenia,
                       TypZdarzenia = zlecenie.TypZdarzenia,
                       Priorytet = zlecenie.Priorytet,
                       StatusZlecenia = zlecenie.StatusZlecenia,
                       OpisZdarzenia = zlecenie.OpisZdarzenia,
                       CzasWyjazdu = zlecenie.CzasWyjazdu,
                       CzasPrzyjazduNaMiejsce = zlecenie.CzasPrzyjazduNaMiejsce,
                       CzasPowrotuDoBazy = zlecenie.CzasPowrotuDoBazy,
                       TelefonDzwoniacego = zlecenie.TelefonDzwoniacego,
                       CzasReakcjiSekundy = zlecenie.CzasReakcjiSekundy,
                       Dystans = zlecenie.DystansKm,
                       LiczbaPacjentow = zlecenie.LiczbaPacjentow,
                       WarunkiPogodowe = zlecenie.WarunkiPogodowe,
                       WymaganeDodatkoweWsparcie = zlecenie.WymaganeDodatkoweWsparcie,
                       Dyspozytor = zlecenie.Pracownik.Imie + " " + zlecenie.Pracownik.Nazwisko,
                       NazwaZespolu = zlecenie.ZespolRatunkowy.NazwaZespolu,
                       NumerRejestracyjnyKaretki = zlecenie.Karetka.NumerRejestracyjny
                   })
                   .ToList()
                );
        }
        #endregion

        #region Właściwosci
        private ZleceniaWyjazduForAllView _WybranyWyjazd;
        public ZleceniaWyjazduForAllView WybranyWyjazd
        {
            get { return _WybranyWyjazd; }
            set
            {
                if (_WybranyWyjazd != value)
                {
                    _WybranyWyjazd = value;
                    Messenger.Default.Send(_WybranyWyjazd);
                    OnRequestClose();
                }
            }
        }
        #endregion

        #region Konstruktor
        public WszystkieZleceniaWyjazduViewModel()
        {
            base.DisplayName = "Wyjazdy";
        }
        #endregion
        #region Sortowanie i Filtrowanie
        public override List<string> getComboBoxSortList()
        {
            return new List<string>
    {
        "dataCzasZgloszenia",
        "priorytet",
        "statusZlecenia",
        "typZdarzenia",
        "czasWyjazdu",
        "czasPrzyjazduNaMiejsce",
        "czasPowrotuDoBazy",
        "czasReakcjiSekundy",
        "dystans",
        "liczbaPacjentow",
        "nazwaZespolu",
        "numerRejestracyjnyKaretki",
        "dyspozytor"
    };
        }

        public override List<string> getComboBoxFindList()
        {
            return new List<string>
    {
        "adresZdarzenia",
        "typZdarzenia",
        "priorytet",
        "statusZlecenia",
        "nazwaZespolu",
        "numerRejestracyjnyKaretki",
        "dyspozytor",
        "telefonDzwoniacego",
        "opisZdarzenia",
        "warunkiPogodowe"
    };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "dataCzasZgloszenia":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.OrderBy(item => item.DataCzasZgloszenia));
                    break;
                case "priorytet":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.OrderBy(item => item.Priorytet));
                    break;
                case "statusZlecenia":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.OrderBy(item => item.StatusZlecenia));
                    break;
                case "typZdarzenia":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.OrderBy(item => item.TypZdarzenia));
                    break;
                case "czasWyjazdu":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.OrderBy(item => item.CzasWyjazdu));
                    break;
                case "czasPrzyjazduNaMiejsce":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.OrderBy(item => item.CzasPrzyjazduNaMiejsce));
                    break;
                case "czasPowrotuDoBazy":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.OrderBy(item => item.CzasPowrotuDoBazy));
                    break;
                case "czasReakcjiSekundy":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.OrderBy(item => item.CzasReakcjiSekundy));
                    break;
                case "dystans":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.OrderBy(item => item.Dystans));
                    break;
                case "liczbaPacjentow":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.OrderBy(item => item.LiczbaPacjentow));
                    break;
                case "nazwaZespolu":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.OrderBy(item => item.NazwaZespolu));
                    break;
                case "numerRejestracyjnyKaretki":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.OrderBy(item => item.NumerRejestracyjnyKaretki));
                    break;
                case "dyspozytor":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.OrderBy(item => item.Dyspozytor));
                    break;
                default:
                    break;
            }
        }

        public override void Find()
        {
            switch (FindField)
            {
                case "adresZdarzenia":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.Where(item =>
                        item.AdresZdarzenia != null && item.AdresZdarzenia.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "typZdarzenia":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.Where(item =>
                        item.TypZdarzenia != null && item.TypZdarzenia.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "priorytet":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.Where(item =>
                        item.Priorytet != null && item.Priorytet.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "statusZlecenia":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.Where(item =>
                        item.StatusZlecenia != null && item.StatusZlecenia.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "nazwaZespolu":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.Where(item =>
                        item.NazwaZespolu != null && item.NazwaZespolu.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "numerRejestracyjnyKaretki":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.Where(item =>
                        item.NumerRejestracyjnyKaretki != null && item.NumerRejestracyjnyKaretki.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "dyspozytor":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.Where(item =>
                        item.Dyspozytor != null && item.Dyspozytor.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "telefonDzwoniacego":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.Where(item =>
                        item.TelefonDzwoniacego != null && item.TelefonDzwoniacego.Contains(FindTextBox)));
                    break;
                case "opisZdarzenia":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.Where(item =>
                        item.OpisZdarzenia != null && item.OpisZdarzenia.Contains(FindTextBox)));
                    break;
                case "warunkiPogodowe":
                    List = new ObservableCollection<ZleceniaWyjazduForAllView>(List.Where(item =>
                        item.WarunkiPogodowe != null && item.WarunkiPogodowe.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}