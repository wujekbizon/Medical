using GalaSoft.MvvmLight.Messaging;
using Medical.Models;
using Medical.Models.EntitiesForView;
using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Medical.ViewModels
{
    public class WszystkiePlacowkiViewModel : WszystkieViewModel<PlacowkaForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<PlacowkaForAllView>
            (
                from placowka in medicalEntities.Placowka
                where placowka.CzyAktywny == true
                select new PlacowkaForAllView
                { 
                        IdPlacowki = placowka.IdPlacowki,
                        NazwaPlacowki = placowka.NazwaPlacowki,
                        Adres = placowka.Adres,
                        Miasto = placowka.Miasto,
                        KodPocztowy = placowka.KodPocztowy,
                        Telefon = placowka.Telefon,
                        AdresEmail = placowka.AdresEmail,
                        TypPlacowki = placowka.TypPlacowki,
                        GodzinyPracy = placowka.GodzinyPracy,
                        LiczbaKaretek = placowka.LiczbaKaretek,
                        LiczbaZespolow = placowka.LiczbaZespolow,
                        PojemnoscGarazu = placowka.PojemnoscGarazu,
                        DataOtwarcia = placowka.DataOtwarcia,
                        DataOstatniejInspekcji = placowka.DataOstatniejInspekcji,
                        Region = placowka.Region,
                        Budzet = placowka.Budzet,
                        ObszarZasieguRatunkowego = placowka.ObszarZasieguRatunkowego,
                        CzyMaAkredytacje = placowka.CzyMaAkredytacje
                }
            );
        }
        #endregion
        #region Konstruktor
        public WszystkiePlacowkiViewModel()
            : base()
        {
            base.DisplayName = "Placowki";
        }
        #endregion

        #region Właściwosci
        private PlacowkaForAllView _WybranaPlacowka;
        public PlacowkaForAllView WybranaPlacowka
        {
            get
            {
                return _WybranaPlacowka;
            }
            set
            {
                if (_WybranaPlacowka != value)
                {
                    _WybranaPlacowka = value;
                    Messenger.Default.Send(_WybranaPlacowka);
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
        "nazwaPlacowki",
        "typPlacowki",
        "miasto",
        "region",
        "dataOtwarcia",
        "dataOstatniejszInspekcji",
        "liczbaKaretek",
        "liczbaZespolow",
        "pojemnoscGarazu",
        "godzinyPracy",
        "budżet",
        "obszarZasieguRatunkowego"
    };
        }

        public override List<string> getComboBoxFindList()
        {
            return new List<string>
    {
        "nazwaPlacowki",
        "typPlacowki",
        "miasto",
        "kodPocztowy",
        "region",
        "adres",
        "telefon",
        "adresEmail",
        "obszarZasieguRatunkowego"
    };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "nazwaPlacowki":
                    List = new ObservableCollection<PlacowkaForAllView>(List.OrderBy(item => item.NazwaPlacowki));
                    break;
                case "typPlacowki":
                    List = new ObservableCollection<PlacowkaForAllView>(List.OrderBy(item => item.TypPlacowki));
                    break;
                case "miasto":
                    List = new ObservableCollection<PlacowkaForAllView>(List.OrderBy(item => item.Miasto));
                    break;
                case "region":
                    List = new ObservableCollection<PlacowkaForAllView>(List.OrderBy(item => item.Region));
                    break;
                case "dataOtwarcia":
                    List = new ObservableCollection<PlacowkaForAllView>(List.OrderBy(item => item.DataOtwarcia));
                    break;
                case "dataOstatniejszInspekcji":
                    List = new ObservableCollection<PlacowkaForAllView>(List.OrderBy(item => item.DataOstatniejInspekcji));
                    break;
                case "liczbaKaretek":
                    List = new ObservableCollection<PlacowkaForAllView>(List.OrderBy(item => item.LiczbaKaretek));
                    break;
                case "liczbaZespolow":
                    List = new ObservableCollection<PlacowkaForAllView>(List.OrderBy(item => item.LiczbaZespolow));
                    break;
                case "pojemnoscGarazu":
                    List = new ObservableCollection<PlacowkaForAllView>(List.OrderBy(item => item.PojemnoscGarazu));
                    break;
                case "godzinyPracy":
                    List = new ObservableCollection<PlacowkaForAllView>(List.OrderBy(item => item.GodzinyPracy));
                    break;
                case "budżet":
                    List = new ObservableCollection<PlacowkaForAllView>(List.OrderBy(item => item.Budzet));
                    break;
                case "obszarZasieguRatunkowego":
                    List = new ObservableCollection<PlacowkaForAllView>(List.OrderBy(item => item.ObszarZasieguRatunkowego));
                    break;
                default:
                    break;
            }
        }

        public override void Find()
        {
            switch (FindField)
            {
                case "nazwaPlacowki":
                    List = new ObservableCollection<PlacowkaForAllView>(List.Where(item =>
                        item.NazwaPlacowki != null && item.NazwaPlacowki.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "typPlacowki":
                    List = new ObservableCollection<PlacowkaForAllView>(List.Where(item =>
                        item.TypPlacowki != null && item.TypPlacowki.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "miasto":
                    List = new ObservableCollection<PlacowkaForAllView>(List.Where(item =>
                        item.Miasto != null && item.Miasto.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "kodPocztowy":
                    List = new ObservableCollection<PlacowkaForAllView>(List.Where(item =>
                        item.KodPocztowy != null && item.KodPocztowy.StartsWith(FindTextBox)));
                    break;
                case "region":
                    List = new ObservableCollection<PlacowkaForAllView>(List.Where(item =>
                        item.Region != null && item.Region.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "adres":
                    List = new ObservableCollection<PlacowkaForAllView>(List.Where(item =>
                        item.Adres != null && item.Adres.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "telefon":
                    List = new ObservableCollection<PlacowkaForAllView>(List.Where(item =>
                        item.Telefon != null && item.Telefon.Contains(FindTextBox)));
                    break;
                case "adresEmail":
                    List = new ObservableCollection<PlacowkaForAllView>(List.Where(item =>
                        item.AdresEmail != null && item.AdresEmail.Contains(FindTextBox)));
                    break;
                case "obszarZasieguRatunkowego":
                    List = new ObservableCollection<PlacowkaForAllView>(List.Where(item =>
                        item.ObszarZasieguRatunkowego != null && item.ObszarZasieguRatunkowego.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
