using Medical.Models;
using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.ViewModels
{
    public class WszyscyPacjenciViewModel : WszystkieViewModel<Pacjent>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<Pacjent>
            (
                medicalEntities.Pacjent.Where(s => s.CzyAktywny == true).ToList()
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
                    List = new ObservableCollection<Pacjent>(List.OrderBy(item => item.Nazwisko));
                    break;
                case "dataUrodzenia":
                    List = new ObservableCollection<Pacjent>(List.OrderBy(item => item.DataUrodzenia));
                    break;
                case "pesel":
                    List = new ObservableCollection<Pacjent>(List.OrderBy(item => item.Pesel));
                    break;
                case "numerKartyPacjenta":
                    List = new ObservableCollection<Pacjent>(List.OrderBy(item => item.NumerKartyPacjenta));
                    break;
                case "miasto":
                    List = new ObservableCollection<Pacjent>(List.OrderBy(item => item.Miasto));
                    break;
                case "kodPocztowy":
                    List = new ObservableCollection<Pacjent>(List.OrderBy(item => item.KodPocztowy));
                    break;
                case "grupaKrwi":
                    List = new ObservableCollection<Pacjent>(List.OrderBy(item => item.GrupaKrwi));
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
                    List = new ObservableCollection<Pacjent>(List.Where(item =>
                        item.Nazwisko != null && item.Nazwisko.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "pesel":
                    List = new ObservableCollection<Pacjent>(List.Where(item =>
                        item.Pesel != null && item.Pesel.StartsWith(FindTextBox)));
                    break;
                case "numerKartyPacjenta":
                    List = new ObservableCollection<Pacjent>(List.Where(item =>
                        item.NumerKartyPacjenta != null && item.NumerKartyPacjenta.StartsWith(FindTextBox)));
                    break;
                case "miasto":
                    List = new ObservableCollection<Pacjent>(List.Where(item =>
                        item.Miasto != null && item.Miasto.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "kodPocztowy":
                    List = new ObservableCollection<Pacjent>(List.Where(item =>
                        item.KodPocztowy != null && item.KodPocztowy.StartsWith(FindTextBox)));
                    break;
                case "telefonKontaktowy":
                    List = new ObservableCollection<Pacjent>(List.Where(item =>
                        item.TelefonKontaktowy != null && item.TelefonKontaktowy.Contains(FindTextBox)));
                    break;
                case "adresEmail":
                    List = new ObservableCollection<Pacjent>(List.Where(item =>
                        item.AdresEmail != null && item.AdresEmail.Contains(FindTextBox)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
