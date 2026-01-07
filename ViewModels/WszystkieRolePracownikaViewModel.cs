using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.ViewModels
{
    public class WszystkieRolePracownikaViewModel : WszystkieViewModel<dynamic>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<dynamic>
            (
                 medicalEntities.RolaPracownika
                    .Where(s => s.CzyAktywny == true)
                    .Select(p => new
                    {
                        p.NazwaRoli,
                        p.PoziomUprawnien,
                        p.OpisObowiazkow,
                        p.MinimalneWyksztalcenie,
                        p.WymaganeSzkolenia,
                        CzyWymagaLicencji = p.CzyWymagaLicencji ? "TAK" : "NIE",
                        p.MaksymalnaLiczbaGodzinTygodniowo,
                        p.SredniaPlaca,
                        p.Benefity,
                        p.DataOstatniejAktualizacji,
                        p.NazwaDzialu,
                        CzyJestLideremZespolu = p.CzyJestLideremZespolu ? "TAK" : "NIE",
                        p.LimitZatrudnienia,
                        p.WymaganeUmiejetnosci,
                        p.RolaNastepnegoEtapuKariery,
                    })
                    .ToList()
            );
        }
        #endregion
        #region Konstruktor
        public WszystkieRolePracownikaViewModel()
            :base()
        {
            base.DisplayName = "Role";
        }
        #endregion
        #region Sortowanie i Filtrowanie
        public override List<string> getComboBoxSortList()
        {
            return new List<string>
    {
        "nazwaRoli",
        "poziomUprawnienia",
        "sredniaPlaca",
        "minimalneWyksztalcenie",
        "maksymalnaLiczbaGodzinTygodniowo",
        "limitZatrudnienia",
        "dataOstatniejszAktualizacji",
        "wymaganeUmiejetnosci",
        "wymaganeSzkolenia"
    };
        }

        public override List<string> getComboBoxFindList()
        {
            return new List<string>
    {
        "nazwaRoli",
        "poziomUprawnienia",
        "minimalneWyksztalcenie",
        "wymaganeUmiejetnosci",
        "wymaganeSzkolenia",
        "nazwaDzialu",
        "opisObowiazkan",
        "benefity"
    };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "nazwaRoli":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.NazwaRoli));
                    break;
                case "poziomUprawnienia":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.PoziomUprawnienia));
                    break;
                case "sredniaPlaca":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.SredniaPlaca));
                    break;
                case "minimalneWyksztalcenie":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.MinimalneWyksztalcenie));
                    break;
                case "maksymalnaLiczbaGodzinTygodniowo":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.MaksymalnaLiczbaGodzinTygodniowo));
                    break;
                case "limitZatrudnienia":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.LimitZatrudnienia));
                    break;
                case "dataOstatniejszAktualizacji":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.DataOstatniejszAktualizacji));
                    break;
                case "wymaganeUmiejetnosci":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.WymaganeUmiejetnosci));
                    break;
                case "wymaganeSzkolenia":
                    List = new ObservableCollection<dynamic>(List.OrderBy(item => item.WymaganeSzkolenia));
                    break;
                default:
                    break;
            }
        }

        public override void Find()
        {
            switch (FindField)
            {
                case "nazwaRoli":
                    List = new ObservableCollection<dynamic>(List.Where(item =>
                        item.NazwaRoli != null && ((string)item.NazwaRoli).StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "poziomUprawnienia":
                    List = new ObservableCollection<dynamic>(List.Where(item =>
                        item.PoziomUprawnienia != null && ((string)item.PoziomUprawnienia).StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "minimalneWyksztalcenie":
                    List = new ObservableCollection<dynamic>(List.Where(item =>
                        item.MinimalneWyksztalcenie != null && ((string)item.MinimalneWyksztalcenie).StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "wymaganeUmiejetnosci":
                    List = new ObservableCollection<dynamic>(List.Where(item =>
                        item.WymaganeUmiejetnosci != null && ((string)item.WymaganeUmiejetnosci).Contains(FindTextBox)));
                    break;
                case "wymaganeSzkolenia":
                    List = new ObservableCollection<dynamic>(List.Where(item =>
                        item.WymaganeSzkolenia != null && ((string)item.WymaganeSzkolenia).Contains(FindTextBox)));
                    break;
                case "nazwaDzialu":
                    List = new ObservableCollection<dynamic>(List.Where(item =>
                        item.NazwaDzialu != null && ((string)item.NazwaDzialu).StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "opisObowiazkan":
                    List = new ObservableCollection<dynamic>(List.Where(item =>
                        item.OpisObowiazkan != null && ((string)item.OpisObowiazkan).Contains(FindTextBox)));
                    break;
                case "benefity":
                    List = new ObservableCollection<dynamic>(List.Where(item =>
                        item.Benefity != null && ((string)item.Benefity).Contains(FindTextBox)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
