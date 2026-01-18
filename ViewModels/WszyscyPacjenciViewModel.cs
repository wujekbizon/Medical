using GalaSoft.MvvmLight.Messaging;
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
    public class WszyscyPacjenciViewModel : WszystkieViewModel<PacjentForAllView>
    {
        #region Lista
        public override void Load()
        {
                List = new ObservableCollection<PacjentForAllView>(
                from pacjent in medicalEntities.Pacjent
                where pacjent.CzyAktywny == true
                select new PacjentForAllView
                {
                    IdPacjenta = pacjent.IdPacjenta,
                    Imie = pacjent.Imie,
                    Nazwisko = pacjent.Nazwisko,
                    DataUrodzenia = pacjent.DataUrodzenia,
                    AdresZamieszkania = pacjent.AdresZamieszkania,
                    Miasto = pacjent.Miasto,
                    KodPocztowy = pacjent.KodPocztowy,
                    TelefonKontaktowy = pacjent.TelefonKontaktowy,
                    AdresEmail = pacjent.AdresEmail,
                    Pesel = pacjent.Pesel,
                    Plec = pacjent.Plec,
                    NumerKartyPacjenta = pacjent.NumerKartyPacjenta,
                    GrupaKrwi = pacjent.GrupaKrwi,
                    InformacjeAlergie = pacjent.InformacjeAlergie,
                    UbezpieczenieZdrowotne = pacjent.UbezpieczenieZdrowotne,
                    UwagiDodatkowe = pacjent.UwagiDodatkowe,
                    KontaktAwaryjnyImieNazwisko = pacjent.KontaktAwaryjnyImieNazwisko,
                    KontaktAwaryjnyTelefon = pacjent.KontaktAwaryjnyTelefon,
                    ChorobyPrzewlekle = pacjent.ChorobyPrzewlekle,
                    RodzajNiepełnosprawności = pacjent.RodzajNiepełnosprawności
                }
                );
        }
        #endregion
        #region Konstruktor
        public WszyscyPacjenciViewModel()
           : base()
        {
            base.DisplayName = "Pacjenci";
        }
        #endregion

        #region Właściwości
        private PacjentForAllView _WybranyPacjent;
        public PacjentForAllView WybranyPacjent
        {
            get
            {
                return _WybranyPacjent;
            }
            set
            {
                if (_WybranyPacjent != value)
                {
                    _WybranyPacjent = value;
                    Messenger.Default.Send(_WybranyPacjent);
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
        "nazwisko",
        "dataUrodzenia",
        "pesel",
        "numerKartyPacjenta",
        "miasto",
        "kodPocztowy",
        "grupaKrwi"
    };
        }

        public override List<string> getComboBoxFindList()
        {
            return new List<string>
    {
        "nazwisko",
        "pesel",
        "numerKartyPacjenta",
        "miasto",
        "kodPocztowy",
        "telefonKontaktowy",
        "adresEmail"
    };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "nazwisko":
                    List = new ObservableCollection<PacjentForAllView>(List.OrderBy(item => item.Nazwisko));
                    break;
                case "dataUrodzenia":
                    List = new ObservableCollection<PacjentForAllView>(List.OrderBy(item => item.DataUrodzenia));
                    break;
                case "pesel":
                    List = new ObservableCollection<PacjentForAllView>(List.OrderBy(item => item.Pesel));
                    break;
                case "numerKartyPacjenta":
                    List = new ObservableCollection<PacjentForAllView>(List.OrderBy(item => item.NumerKartyPacjenta));
                    break;
                case "miasto":
                    List = new ObservableCollection<PacjentForAllView>(List.OrderBy(item => item.Miasto));
                    break;
                case "kodPocztowy":
                    List = new ObservableCollection<PacjentForAllView>(List.OrderBy(item => item.KodPocztowy));
                    break;
                case "grupaKrwi":
                    List = new ObservableCollection<PacjentForAllView>(List.OrderBy(item => item.GrupaKrwi));
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
                    List = new ObservableCollection<PacjentForAllView>(List.Where(item =>
                        item.Nazwisko != null && item.Nazwisko.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "pesel":
                    List = new ObservableCollection<PacjentForAllView>(List.Where(item =>
                        item.Pesel != null && item.Pesel.StartsWith(FindTextBox)));
                    break;
                case "numerKartyPacjenta":
                    List = new ObservableCollection<PacjentForAllView>(List.Where(item =>
                        item.NumerKartyPacjenta != null && item.NumerKartyPacjenta.StartsWith(FindTextBox)));
                    break;
                case "miasto":
                    List = new ObservableCollection<PacjentForAllView>(List.Where(item =>
                        item.Miasto != null && item.Miasto.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "kodPocztowy":
                    List = new ObservableCollection<PacjentForAllView>(List.Where(item =>
                        item.KodPocztowy != null && item.KodPocztowy.StartsWith(FindTextBox)));
                    break;
                case "telefonKontaktowy":
                    List = new ObservableCollection<PacjentForAllView>(List.Where(item =>
                        item.TelefonKontaktowy != null && item.TelefonKontaktowy.Contains(FindTextBox)));
                    break;
                case "adresEmail":
                    List = new ObservableCollection<PacjentForAllView>(List.Where(item =>
                        item.AdresEmail != null && item.AdresEmail.Contains(FindTextBox)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
