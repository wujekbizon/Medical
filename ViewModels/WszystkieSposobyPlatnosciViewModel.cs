using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Medical.Models;
using Medical.ViewModels.Abstract;

namespace Medical.ViewModels
{
    public class WszystkieSposobyPlatnosciViewModel : WszystkieViewModel<SposobPlatnosci>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<SposobPlatnosci>
            (
                medicalEntities.SposobPlatnosci.Where(s => s.CzyAktywny == true).ToList()
            );
        }
        #endregion
        #region Konstruktor
        public WszystkieSposobyPlatnosciViewModel()
            :base()
        {
            base.DisplayName = "SposobyPlatnosci";
        }
        #endregion
        #region Sortowanie i Filtrowanie
        public override List<string> getComboBoxSortList()
        {
            return new List<string>
    {
        "nazwa",
        "rodzajTransakcji",
        "czyWymagaPotwierdzenia"
    };
        }

        public override List<string> getComboBoxFindList()
        {
            return new List<string>
    {
        "nazwa",
        "rodzajTransakcji",
        "opis"
    };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "nazwa":
                    List = new ObservableCollection<SposobPlatnosci>(List.OrderBy(item => item.Nazwa));
                    break;
                case "rodzajTransakcji":
                    List = new ObservableCollection<SposobPlatnosci>(List.OrderBy(item => item.RodzajTransakcji));
                    break;
                case "czyWymagaPotwierdzenia":
                    List = new ObservableCollection<SposobPlatnosci>(List.OrderBy(item => item.CzyWymagaPotwierdzenia));
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
                    List = new ObservableCollection<SposobPlatnosci>(List.Where(item =>
                        item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "rodzajTransakcji":
                    List = new ObservableCollection<SposobPlatnosci>(List.Where(item =>
                        item.RodzajTransakcji != null && item.RodzajTransakcji.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "opis":
                    List = new ObservableCollection<SposobPlatnosci>(List.Where(item =>
                        item.Opis != null && item.Opis.Contains(FindTextBox)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
