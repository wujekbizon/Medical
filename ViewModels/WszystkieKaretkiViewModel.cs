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
    public class WszystkieKaretkiViewModel: WszystkieViewModel<KaretkaForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<KaretkaForAllView>
                (
                   from karetka in medicalEntities.Karetka
                   where karetka.CzyAktywny == true
                   select new KaretkaForAllView
                   {
                       NumerRejestracyjny = karetka.NumerRejestracyjny,
                       TypKaretki = karetka.TypKaretki,
                       Status = karetka.Status,
                       PlacowkaZarzadzajaca = karetka.Placowka.NazwaPlacowki
                   }
                );
        }
        #endregion

        #region Konstruktor
        public WszystkieKaretkiViewModel()
        {
            base.DisplayName = "Karetki";
        }
        #endregion
        #region Sortowanie i Filtrowanie
        public override List<string> getComboBoxSortList()
        {
            return new List<string>
    {
        "numerRejestracyjny",
        "typKaretki",
        "status",
        "placowkaZarzadzajaca"
    };
        }

        public override List<string> getComboBoxFindList()
        {
            return new List<string>
    {
        "numerRejestracyjny",
        "typKaretki",
        "status",
        "placowkaZarzadzajaca"
    };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "numerRejestracyjny":
                    List = new ObservableCollection<KaretkaForAllView>(List.OrderBy(item => item.NumerRejestracyjny));
                    break;
                case "typKaretki":
                    List = new ObservableCollection<KaretkaForAllView>(List.OrderBy(item => item.TypKaretki));
                    break;
                case "status":
                    List = new ObservableCollection<KaretkaForAllView>(List.OrderBy(item => item.Status));
                    break;
                case "placowkaZarzadzajaca":
                    List = new ObservableCollection<KaretkaForAllView>(List.OrderBy(item => item.PlacowkaZarzadzajaca));
                    break;
                default:
                    break;
            }
        }

        public override void Find()
        {
            switch (FindField)
            {
                case "numerRejestracyjny":
                    List = new ObservableCollection<KaretkaForAllView>(List.Where(item =>
                        item.NumerRejestracyjny != null && item.NumerRejestracyjny.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "typKaretki":
                    List = new ObservableCollection<KaretkaForAllView>(List.Where(item =>
                        item.TypKaretki != null && item.TypKaretki.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "status":
                    List = new ObservableCollection<KaretkaForAllView>(List.Where(item =>
                        item.Status != null && item.Status.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "placowkaZarzadzajaca":
                    List = new ObservableCollection<KaretkaForAllView>(List.Where(item =>
                        item.PlacowkaZarzadzajaca != null && item.PlacowkaZarzadzajaca.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
