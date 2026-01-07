using Medical.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Medical.ViewModels.Abstract;

namespace Medical.ViewModels
{
    public class WszystkiePlacowkiViewModel : WszystkieViewModel<dynamic>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<dynamic>
            (
                medicalEntities.Placowka
                    .Where(s => s.CzyAktywny == true)
                    .Select(p => new
                    {
                        p.NazwaPlacowki,
                        p.Adres,
                        p.Miasto,
                        p.KodPocztowy,
                        p.Telefon,
                        p.AdresEmail,
                        p.TypPlacowki,
                        p.GodzinyPracy,
                        p.LiczbaKaretek,
                        p.LiczbaZespolow,
                        p.PojemnoscGarazu,
                        p.DataOtwarcia,
                        p.DataOstatniejInspekcji,
                        p.Region,
                        p.Budzet,
                        p.ObszarZasieguRatunkowego,
                        CzyMaAkredytacje = p.CzyMaAkredytacje ? "TAK" : "NIE",
                    })
                    .ToList()
            );
        }
        #endregion
        public WszystkiePlacowkiViewModel()
            :base()
        {
            base.DisplayName = "Placowki";
        }

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
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.NazwaPlacowki));
                    break;
                case "typPlacowki":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.TypPlacowki));
                    break;
                case "miasto":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.Miasto));
                    break;
                case "region":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.Region));
                    break;
                case "dataOtwarcia":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.DataOtwarcia));
                    break;
                case "dataOstatniejszInspekcji":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.DataOstatniejszInspekcji));
                    break;
                case "liczbaKaretek":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.LiczbaKaretek));
                    break;
                case "liczbaZespolow":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.LiczbaZespolow));
                    break;
                case "pojemnoscGarazu":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.PojemnoscGarazu));
                    break;
                case "godzinyPracy":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.GodzinyPracy));
                    break;
                case "budżet":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.Budżet));
                    break;
                case "obszarZasieguRatunkowego":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.ObszarZasieguRatunkowego));
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
                    List = new ObservableCollection<dynamic>(List.Where(item =>
                        item.NazwaPlacowki != null && item.NazwaPlacowki.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "typPlacowki":
                    List = new ObservableCollection<dynamic>(List.Where(item =>
                        item.TypPlacowki != null && item.TypPlacowki.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "miasto":
                    List = new ObservableCollection<dynamic>(List.Where(item =>
                        item.Miasto != null && item.Miasto.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "kodPocztowy":
                    List = new ObservableCollection<dynamic>(List.Where(item =>
                        item.KodPocztowy != null && item.KodPocztowy.StartsWith(FindTextBox)));
                    break;
                case "region":
                    List = new ObservableCollection<dynamic>(List.Where(item =>
                        item.Region != null && item.Region.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "adres":
                    List = new ObservableCollection<dynamic>(List.Where(item =>
                        item.Adres != null && item.Adres.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "telefon":
                    List = new ObservableCollection<dynamic>(List.Where(item =>
                        item.Telefon != null && item.Telefon.Contains(FindTextBox)));
                    break;
                case "adresEmail":
                    List = new ObservableCollection<dynamic>(List.Where(item =>
                        item.AdresEmail != null && item.AdresEmail.Contains(FindTextBox)));
                    break;
                case "obszarZasieguRatunkowego":
                    List = new ObservableCollection<dynamic>(List.Where(item =>
                        item.ObszarZasieguRatunkowego != null && item.ObszarZasieguRatunkowego.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
