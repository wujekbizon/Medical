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
using System.Windows.Documents;

namespace Medical.ViewModels
{
    public class WszystkieSposobyPlatnosciViewModel : WszystkieViewModel<SposobPlatnosciForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<SposobPlatnosciForAllView>(
                from sposob in medicalEntities.SposobPlatnosci
                where sposob.CzyAktywny == true
                select new SposobPlatnosciForAllView
                {
                    IdSposobuPlatnosci = sposob.IdSposobuPlatnosci,
                    Nazwa = sposob.Nazwa,
                    Opis = sposob.Opis,
                    CzyWymagaPotwierdzenia = sposob.CzyWymagaPotwierdzenia,
                    RodzajTransakcji = sposob.RodzajTransakcji
                }
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
        #region Właściwosci
        private SposobPlatnosciForAllView _WybranySposobPlatnosci;
        public SposobPlatnosciForAllView WybranySposobPlatnosci
        {
            get
            {
                return _WybranySposobPlatnosci;
            }
            set
            {
                if (_WybranySposobPlatnosci != value)
                {
                    _WybranySposobPlatnosci = value;
                    Messenger.Default.Send(_WybranySposobPlatnosci);
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
                    List = new ObservableCollection<SposobPlatnosciForAllView>(List.OrderBy(item => item.Nazwa));
                    break;
                case "rodzajTransakcji":
                    List = new ObservableCollection<SposobPlatnosciForAllView>(List.OrderBy(item => item.RodzajTransakcji));
                    break;
                case "czyWymagaPotwierdzenia":
                    List = new ObservableCollection<SposobPlatnosciForAllView>(List.OrderBy(item => item.CzyWymagaPotwierdzenia));
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
                    List = new ObservableCollection<SposobPlatnosciForAllView>(List.Where(item =>
                        item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "rodzajTransakcji":
                    List = new ObservableCollection<SposobPlatnosciForAllView>(List.Where(item =>
                        item.RodzajTransakcji != null && item.RodzajTransakcji.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "opis":
                    List = new ObservableCollection<SposobPlatnosciForAllView>(List.Where(item =>
                        item.Opis != null && item.Opis.Contains(FindTextBox)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
