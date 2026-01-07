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
    public class WszystkieKosztyUtrzymaniaViewModel : WszystkieViewModel<KosztyUtrzymaniaForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<KosztyUtrzymaniaForAllView>
                (
                   medicalEntities.KosztUtrzymania
                   .Where(koszt => koszt.CzyAktywny == true)
                   .Select( koszt => new KosztyUtrzymaniaForAllView
                   {
                       RodzajKosztu = koszt.RodzajKosztu,
                       Kwota = koszt.Kwota,
                       DataKosztu = koszt.DataKosztu,
                       OpisSzczegolowy = koszt.OpisSzczegolowy,
                       DataKsiegowania = koszt.DataKsiegowania,
                       Zaksiegowana = koszt.CzyZaksiegowany ? "TAK" : "NIE",  
                       OkresRozliczeniowy = koszt.OkresRozliczeniowy,
                       NumerDowoduZakupu = koszt.NumerDowoduZakupu,
                       CentrumKosztowe = koszt.CentrumKosztowe,
                       Cyklczna = (bool)koszt.CzyJestCyklczny? "TAK" : "NIE",  
                       KwotaBudzetowa = koszt.KwotaBudzetowa,
                       UwagiKsięgowe = koszt.UwagiKsięgowe,
                       Karetka = koszt.Karetka.NumerRejestracyjny,
                       NumerFaktury = koszt.Faktura.Numer,
                       NazwaFirmy = koszt.Kontrahent.Nazwa,
                       NazwaSposobuPlatnosci = koszt.SposobPlatnosci.Nazwa
                   })
                );
        }
        #endregion

        #region Konstruktor
        public WszystkieKosztyUtrzymaniaViewModel()
        {
            base.DisplayName = "Koszty Utrzymania";
        }
        #endregion
        #region Sortowanie i Filtrowanie
        public override List<string> getComboBoxSortList()
        {
            return new List<string>
    {
        "dataKosztu",
        "kwota",
        "rodzajKosztu",
        "karetka",
        "dataKsiegowania",
        "zaksiegowana",
        "okresRozliczeniowy",
        "centrumKosztowe",
        "cykliczna",
        "nazwaFirmy",
        "kwotaBudzetowa"
    };
        }

        public override List<string> getComboBoxFindList()
        {
            return new List<string>
    {
        "karetka",
        "rodzajKosztu",
        "numerFaktury",
        "numerDowoduZakupu",
        "nazwaFirmy",
        "zaksiegowana",
        "okresRozliczeniowy",
        "centrumKosztowe",
        "cykliczna",
        "opisSzczegolowy"
    };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "dataKosztu":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.OrderBy(item => item.DataKosztu));
                    break;
                case "kwota":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.OrderBy(item => item.Kwota));
                    break;
                case "rodzajKosztu":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.OrderBy(item => item.RodzajKosztu));
                    break;
                case "karetka":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.OrderBy(item => item.Karetka));
                    break;
                case "dataKsiegowania":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.OrderBy(item => item.DataKsiegowania));
                    break;
                case "zaksiegowana":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.OrderBy(item => item.Zaksiegowana));
                    break;
                case "okresRozliczeniowy":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.OrderBy(item => item.OkresRozliczeniowy));
                    break;
                case "centrumKosztowe":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.OrderBy(item => item.CentrumKosztowe));
                    break;
                case "cykliczna":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.OrderBy(item => item.Cyklczna));
                    break;
                case "nazwaFirmy":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.OrderBy(item => item.NazwaFirmy));
                    break;
                case "kwotaBudzetowa":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.OrderBy(item => item.KwotaBudzetowa));
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
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.Where(item =>
                        item.Karetka != null && item.Karetka.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "rodzajKosztu":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.Where(item =>
                        item.RodzajKosztu != null && item.RodzajKosztu.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "numerFaktury":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.Where(item =>
                        item.NumerFaktury != null && item.NumerFaktury.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "numerDowoduZakupu":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.Where(item =>
                        item.NumerDowoduZakupu != null && item.NumerDowoduZakupu.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "nazwaFirmy":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.Where(item =>
                        item.NazwaFirmy != null && item.NazwaFirmy.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "zaksiegowana":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.Where(item =>
                        item.Zaksiegowana != null && item.Zaksiegowana.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "okresRozliczeniowy":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.Where(item =>
                        item.OkresRozliczeniowy != null && item.OkresRozliczeniowy.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "centrumKosztowe":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.Where(item =>
                        item.CentrumKosztowe != null && item.CentrumKosztowe.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "cykliczna":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.Where(item =>
                        item.Cyklczna != null && item.Cyklczna.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "opisSzczegolowy":
                    List = new ObservableCollection<KosztyUtrzymaniaForAllView>(List.Where(item =>
                        item.OpisSzczegolowy != null && item.OpisSzczegolowy.Contains(FindTextBox)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}