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
    public class WszystkieZespolPracownikViewModel : WszystkieViewModel<ZespolPracownikForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<ZespolPracownikForAllView>
                (
                   medicalEntities.ZespolPracownik
                   .Where(zp => zp.CzyAktywny == true)
                   .Select(zp => new ZespolPracownikForAllView
                   {
                       NazwaZespolu = zp.ZespolRatunkowy.NazwaZespolu,
                       Pracownik = zp.Pracownik.Imie + " " + zp.Pracownik.Nazwisko,
                       RolaWZespole = zp.RolaWZespole,
                       DataDolaczenia = zp.DataDolaczenia,
                       DataOpuszczenia = zp.DataOpuszczenia,
                       PowodZmiany = zp.PowodZmiany,
                       DataPrzypisania = zp.DataPrzypisania
                   })
                   .ToList()
                );
        }
        #endregion

        #region Konstruktor
        public WszystkieZespolPracownikViewModel()
        {
            base.DisplayName = "Skład Zespołów";
        }
        #endregion
        #region Sortowanie i Filtrowanie
        public override List<string> getComboBoxSortList()
        {
            return new List<string>
    {
        "nazwaZespolu",
        "pracownik",
        "rolaWZespole",
        "dataDolaczenia",
        "dataOpuszczenia",
        "dataPrzypisania"
    };
        }

        public override List<string> getComboBoxFindList()
        {
            return new List<string>
    {
        "nazwaZespolu",
        "pracownik",
        "rolaWZespole",
        "powodZmiany"
    };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "nazwaZespolu":
                    List = new ObservableCollection<ZespolPracownikForAllView>(List.OrderBy(item => item.NazwaZespolu));
                    break;
                case "pracownik":
                    List = new ObservableCollection<ZespolPracownikForAllView>(List.OrderBy(item => item.Pracownik));
                    break;
                case "rolaWZespole":
                    List = new ObservableCollection<ZespolPracownikForAllView>(List.OrderBy(item => item.RolaWZespole));
                    break;
                case "dataDolaczenia":
                    List = new ObservableCollection<ZespolPracownikForAllView>(List.OrderBy(item => item.DataDolaczenia));
                    break;
                case "dataOpuszczenia":
                    List = new ObservableCollection<ZespolPracownikForAllView>(List.OrderBy(item => item.DataOpuszczenia));
                    break;
                case "dataPrzypisania":
                    List = new ObservableCollection<ZespolPracownikForAllView>(List.OrderBy(item => item.DataPrzypisania));
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
                    List = new ObservableCollection<ZespolPracownikForAllView>(List.Where(item =>
                        item.NazwaZespolu != null && item.NazwaZespolu.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "pracownik":
                    List = new ObservableCollection<ZespolPracownikForAllView>(List.Where(item =>
                        item.Pracownik != null && item.Pracownik.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "rolaWZespole":
                    List = new ObservableCollection<ZespolPracownikForAllView>(List.Where(item =>
                        item.RolaWZespole != null && item.RolaWZespole.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "powodZmiany":
                    List = new ObservableCollection<ZespolPracownikForAllView>(List.Where(item =>
                        item.PowodZmiany != null && item.PowodZmiany.Contains(FindTextBox)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}