using Medical.Models;
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
    public class WszyscyPracownicyViewModel : WszystkieViewModel<PracownikForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<PracownikForAllView>
                (
                   medicalEntities.Pracownik
                   .Where(pracownik => pracownik.CzyAktywny == true)
                   .Select(pracownik => new PracownikForAllView
                   {
                       Imie = pracownik.Imie,
                       Nazwisko = pracownik.Nazwisko,
                       Pesel = pracownik.Pesel,
                       DataUrodzenia = pracownik.DataUrodzenia,
                       AdresZamieszkania = pracownik.AdresZamieszkania,
                       Miasto = pracownik.Miasto,
                       KodPocztowy = pracownik.KodPocztowy,
                       TelefonSluzbowy = pracownik.TelefonSluzbowy,
                       AdresEmailSluzbowy = pracownik.AdresEmailSluzbowy,
                       NumerKontaBankowego = pracownik.NumerKontaBankowego,
                       DataZatrudnienia = pracownik.DataZatrudnienia,
                       StatusZatrudnienia = pracownik.StatusZatrudnienia,
                       NumerPrawaWykonywaniaZawodu = pracownik.NumerPrawaWykonywaniaZawodu,
                       KwalifikacjeDodatkowe = pracownik.KwalifikacjeDodatkowe,
                       DataWaznosciBadanLekarskich = pracownik.DataWaznosciBadanLekarskich,
                       StawkaGodzinowa = pracownik.StawkaGodzinowa,
                       TypUmowy = pracownik.TypUmowy,
                       LiczbaDniUrlopu = pracownik.LiczbaDniUrlopu,
                       PreferowanaZmiana = pracownik.PreferowanaZmiana,
                       DataOstatniegoSzkolenia = pracownik.DataOstatniegoSzkolenia,
                       NazwaRoli = pracownik.RolaPracownika.NazwaRoli,
                       NazwaPlacowki = pracownik.Placowka.NazwaPlacowki
                   })
                   .ToList()
                );
        }
        #endregion

        #region Konstruktor
        public WszyscyPracownicyViewModel()
        {
            base.DisplayName = "Pracownicy";
        }
        #endregion

        #region Sortowanie i Filtrowanie
        public override List<string> getComboBoxSortList()
        {
            return new List<string>
    {
        "nazwisko",
        "imie",
        "dataZatrudnienia",
        "statusZatrudnienia",
        "stawkaGodzinowa",
        "dataUrodzenia",
        "numerPrawaWykonywaniaZawodu",
        "dataWaznosciBadanLekarskich",
        "miasto",
        "dataOstatniegoSzkolenia"
    };
        }

        public override List<string> getComboBoxFindList()
        {
            return new List<string>
    {
        "nazwisko",
        "imie",
        "pesel",
        "numerPrawaWykonywaniaZawodu",
        "statusZatrudnienia",
        "miasto",
        "telefonSluzbowy",
        "adresEmailSluzbowy",
        "numerKontaBankowego"
    };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "nazwisko":
                    List = new ObservableCollection<PracownikForAllView>(List.OrderBy(item => item.Nazwisko));
                    break;
                case "imie":
                    List = new ObservableCollection<PracownikForAllView>(List.OrderBy(item => item.Imie));
                    break;
                case "dataZatrudnienia":
                    List = new ObservableCollection<PracownikForAllView>(List.OrderBy(item => item.DataZatrudnienia));
                    break;
                case "statusZatrudnienia":
                    List = new ObservableCollection<PracownikForAllView>(List.OrderBy(item => item.StatusZatrudnienia));
                    break;
                case "stawkaGodzinowa":
                    List = new ObservableCollection<PracownikForAllView>(List.OrderBy(item => item.StawkaGodzinowa));
                    break;
                case "dataUrodzenia":
                    List = new ObservableCollection<PracownikForAllView>(List.OrderBy(item => item.DataUrodzenia));
                    break;
                case "numerPrawaWykonywaniaZawodu":
                    List = new ObservableCollection<PracownikForAllView>(List.OrderBy(item => item.NumerPrawaWykonywaniaZawodu));
                    break;
                case "dataWaznosciBadanLekarskich":
                    List = new ObservableCollection<PracownikForAllView>(List.OrderBy(item => item.DataWaznosciBadanLekarskich));
                    break;
                case "miasto":
                    List = new ObservableCollection<PracownikForAllView>(List.OrderBy(item => item.Miasto));
                    break;
                case "dataOstatniegoSzkolenia":
                    List = new ObservableCollection<PracownikForAllView>(List.OrderBy(item => item.DataOstatniegoSzkolenia));
                    break;
                default:
                    break;
            }
        }

        public override void Find()
        {
            switch (FindField)
            {
                case "nazwisko":
                    List = new ObservableCollection<PracownikForAllView>(List.Where(item =>
                        item.Nazwisko != null && item.Nazwisko.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "imie":
                    List = new ObservableCollection<PracownikForAllView>(List.Where(item =>
                        item.Imie != null && item.Imie.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "pesel":
                    List = new ObservableCollection<PracownikForAllView>(List.Where(item =>
                        item.Pesel != null && item.Pesel.StartsWith(FindTextBox)));
                    break;
                case "numerPrawaWykonywaniaZawodu":
                    List = new ObservableCollection<PracownikForAllView>(List.Where(item =>
                        item.NumerPrawaWykonywaniaZawodu != null && item.NumerPrawaWykonywaniaZawodu.StartsWith(FindTextBox)));
                    break;
                case "statusZatrudnienia":
                    List = new ObservableCollection<PracownikForAllView>(List.Where(item =>
                        item.StatusZatrudnienia != null && item.StatusZatrudnienia.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "miasto":
                    List = new ObservableCollection<PracownikForAllView>(List.Where(item =>
                        item.Miasto != null && item.Miasto.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "telefonSluzbowy":
                    List = new ObservableCollection<PracownikForAllView>(List.Where(item =>
                        item.TelefonSluzbowy != null && item.TelefonSluzbowy.Contains(FindTextBox)));
                    break;
                case "adresEmailSluzbowy":
                    List = new ObservableCollection<PracownikForAllView>(List.Where(item =>
                        item.AdresEmailSluzbowy != null && item.AdresEmailSluzbowy.Contains(FindTextBox)));
                    break;
                case "numerKontaBankowego":
                    List = new ObservableCollection<PracownikForAllView>(List.Where(item =>
                        item.NumerKontaBankowego != null && item.NumerKontaBankowego.Contains(FindTextBox)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}