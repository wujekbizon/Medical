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
    public class WszyscyKontrahenciViewModel :  WszystkieViewModel<Kontrahent>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<Kontrahent>
            (
                medicalEntities.Kontrahent.Where(s => s.CzyAktywny == true).ToList()
            );
        }
        #endregion
        #region Konstruktor
        public WszyscyKontrahenciViewModel()
            : base()
        {
            base.DisplayName = "Kontrahenci";
        }
        #endregion

        #region Sortowanie i Filtrowanie

        public override List<string> getComboBoxSortList()
        {
            return new List<string>
            {
                "nazwa",
                "nip",
                "kategoriaBiznesowa",
                "status",
                "typ",
                "miasto",
                "kodPocztowy",
                "dataRozpoczeciaWspolpracy",
                "dataZakonczeniaUmowy",
                "warunkiPlatnosci",
                "numerKontaBankowego"
            };
        }

        public override List<string> getComboBoxFindList()
        {
            return new List<string> 
            {
                "nazwa",
                "nip",
                "miasto",
                "kodPocztowy",
                "adresEmail",
                "telefonKontaktowy",
                "numerKontaBankowego",
                "kategoriaBiznesowa"
            };
        }
        public override void Sort()
        {
            switch (SortField)
            {
                case "nazwa":
                    List = new ObservableCollection<Kontrahent>(List.OrderBy(item => item.Nazwa));
                    break;
                case "nip":
                    List = new ObservableCollection<Kontrahent>(List.OrderBy(item => item.NIP));
                    break;
                case "kategoriaBiznesowa":
                    List = new ObservableCollection<Kontrahent>(List.OrderBy(item => item.KategoriaBiznesowa));
                    break;
                case "status":
                    List = new ObservableCollection<Kontrahent>(List.OrderBy(item => item.StatusWspolpracy));
                    break;
                case "typ":
                    List = new ObservableCollection<Kontrahent>(List.OrderBy(item => item.Typ));
                    break;
                case "miasto":
                    List = new ObservableCollection<Kontrahent>(List.OrderBy(item => item.Miasto));
                    break;
                case "kodPocztowy":
                    List = new ObservableCollection<Kontrahent>(List.OrderBy(item => item.KodPocztowy));
                    break;
                case "dataRozpoczeciaWspolpracy":
                    List = new ObservableCollection<Kontrahent>(List.OrderBy(item => item.DataRozpoczeciaWspolpracy));
                    break;
                case "dataZakonczeniaUmowy":
                    List = new ObservableCollection<Kontrahent>(List.OrderBy(item => item.DataZakonczeniaUmowy));
                    break;
                case "warunkiPlatnosci":
                    List = new ObservableCollection<Kontrahent>(List.OrderBy(item => item.WarunkiPlatnosci));
                    break;
                case "numerKontaBankowego":
                    List = new ObservableCollection<Kontrahent>(List.OrderBy(item => item.NumerKontaBankowego));
                    break;
                default:
                    break;
            }
        }

        public override void Find()
        {
            switch (FindField)
            {
                case "nazwa":
                    List = new ObservableCollection<Kontrahent>(List.Where(item =>
                        item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "nip":
                    List = new ObservableCollection<Kontrahent>(List.Where(item =>
                        item.NIP != null && item.NIP.StartsWith(FindTextBox)));
                    break;
                case "miasto":
                    List = new ObservableCollection<Kontrahent>(List.Where(item =>
                        item.Miasto != null && item.Miasto.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "kodPocztowy":
                    List = new ObservableCollection<Kontrahent>(List.Where(item =>
                        item.KodPocztowy != null && item.KodPocztowy.StartsWith(FindTextBox)));
                    break;
                case "adresEmail":
                    List = new ObservableCollection<Kontrahent>(List.Where(item =>
                        item.AdresEmail != null && item.AdresEmail.Contains(FindTextBox)));
                    break;
                case "telefonKontaktowy":
                    List = new ObservableCollection<Kontrahent>(List.Where(item =>
                        item.TelefonKontaktowy != null && item.TelefonKontaktowy.Contains(FindTextBox)));
                    break;
                case "numerKontaBankowego":
                    List = new ObservableCollection<Kontrahent>(List.Where(item =>
                        item.NumerKontaBankowego != null && item.NumerKontaBankowego.Contains(FindTextBox)));
                    break;
                case "kategoriaBiznesowa":
                    List = new ObservableCollection<Kontrahent>(List.Where(item =>
                        item.KategoriaBiznesowa != null && item.KategoriaBiznesowa.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}
