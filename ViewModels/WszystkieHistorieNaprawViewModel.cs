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
    public class WszystkieHistorieNaprawViewModel : WszystkieViewModel<HistoriaNaprawForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<HistoriaNaprawForAllView>
                (
                   medicalEntities.HistoriaNapraw
                   .Where(naprawa => naprawa.CzyAktywny == true)
                   .Select(naprawa => new HistoriaNaprawForAllView
                   {
                       RodzajNaprawy = naprawa.RodzajNaprawy,
                       OpisNaprawy = naprawa.OpisNaprawy,
                       DataRozpoczecia = naprawa.DataRozpoczecia,
                       DataZakonczenia = naprawa.DataZakonczenia,
                       KosztNaprawy = naprawa.KosztNaprawy,
                       CzasTrwaniaNaprawy = naprawa.CzasTrwaniaNaprawy,
                       GwarancjaMiesiecy = naprawa.GwarancjaMiesiecy,
                       StanKaretkiPrzedNaprawa = naprawa.StanKaretkiPrzedNaprawa,
                       StanKaretkiPoNaprawie = naprawa.StanKaretkiPoNaprawie,
                       CzyZatwierdzona = naprawa.CzyZatwierdzona ? "TAK" : "NIE",
                       Karetka = naprawa.Karetka.NumerRejestracyjny,
                       NumerFaktury = naprawa.Faktura.Numer,
                       NazwaFirmy = naprawa.Kontrahent.Nazwa
                   })
                   .ToList()
                );
        }
        #endregion

        #region Konstruktor
        public WszystkieHistorieNaprawViewModel()
        {
            base.DisplayName = "Historie Napraw";
        }
        #endregion

        #region Sortowanie i Filtrowanie
        public override List<string> getComboBoxSortList()
        {
            return new List<string>
            {
                "dataRozpoczecia",
                "dataZakonczenia",
                "karetka",
                "rodzajNaprawy",
                "kosztNaprawy",
                "czasTrwaniaNaprawy",
                "czyZatwierdzona",
                "nazwaFirmy",
                "gwarancjaMiesiecy",
                "stanKaretkiPoNaprawie"
            };
        }

        public override List<string> getComboBoxFindList()
        {
            return new List<string>
            {
                "karetka",
                "rodzajNaprawy",
                "nazwaFirmy",
                "numerFaktury",
                "czyZatwierdzona",
                "stanKaretkiPoNaprawie",
                "opisNaprawy"
            };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "dataRozpoczecia":
                    List = new ObservableCollection<HistoriaNaprawForAllView>(List.OrderBy(item => item.DataRozpoczecia));
                    break;
                case "dataZakonczenia":
                    List = new ObservableCollection<HistoriaNaprawForAllView>(List.OrderBy(item => item.DataZakonczenia));
                    break;
                case "karetka":
                    List = new ObservableCollection<HistoriaNaprawForAllView>(List.OrderBy(item => item.Karetka));
                    break;
                case "rodzajNaprawy":
                    List = new ObservableCollection<HistoriaNaprawForAllView>(List.OrderBy(item => item.RodzajNaprawy));
                    break;
                case "kosztNaprawy":
                    List = new ObservableCollection<HistoriaNaprawForAllView>(List.OrderBy(item => item.KosztNaprawy));
                    break;
                case "czasTrwaniaNaprawy":
                    List = new ObservableCollection<HistoriaNaprawForAllView>(List.OrderBy(item => item.CzasTrwaniaNaprawy));
                    break;
                case "czyZatwierdzona":
                    List = new ObservableCollection<HistoriaNaprawForAllView>(List.OrderBy(item => item.CzyZatwierdzona));
                    break;
                case "nazwaFirmy":
                    List = new ObservableCollection<HistoriaNaprawForAllView>(List.OrderBy(item => item.NazwaFirmy));
                    break;
                case "gwarancjaMiesiecy":
                    List = new ObservableCollection<HistoriaNaprawForAllView>(List.OrderBy(item => item.GwarancjaMiesiecy));
                    break;
                case "stanKaretkiPoNaprawie":
                    List = new ObservableCollection<HistoriaNaprawForAllView>(List.OrderBy(item => item.StanKaretkiPoNaprawie));
                    break;
                default:
                    break;
            }
        }

        public override void Find()
        {
            switch (FindField)
            {
                case "karetka":
                    List = new ObservableCollection<HistoriaNaprawForAllView>(List.Where(item =>
                        item.Karetka != null && item.Karetka.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "rodzajNaprawy":
                    List = new ObservableCollection<HistoriaNaprawForAllView>(List.Where(item =>
                        item.RodzajNaprawy != null && item.RodzajNaprawy.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "nazwaFirmy":
                    List = new ObservableCollection<HistoriaNaprawForAllView>(List.Where(item =>
                        item.NazwaFirmy != null && item.NazwaFirmy.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "numerFaktury":
                    List = new ObservableCollection<HistoriaNaprawForAllView>(List.Where(item =>
                        item.NumerFaktury != null && item.NumerFaktury.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "czyZatwierdzona":
                    List = new ObservableCollection<HistoriaNaprawForAllView>(List.Where(item =>
                        item.CzyZatwierdzona != null && item.CzyZatwierdzona.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "stanKaretkiPoNaprawie":
                    List = new ObservableCollection<HistoriaNaprawForAllView>(List.Where(item =>
                        item.StanKaretkiPoNaprawie != null && item.StanKaretkiPoNaprawie.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "opisNaprawy":
                    List = new ObservableCollection<HistoriaNaprawForAllView>(List.Where(item =>
                        item.OpisNaprawy != null && item.OpisNaprawy.Contains(FindTextBox)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}