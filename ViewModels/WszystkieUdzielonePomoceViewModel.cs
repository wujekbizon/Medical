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
    public class WszystkieUdzielonePomoceViewModel : WszystkieViewModel<UdzielonaPomocForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<UdzielonaPomocForAllView>
                (
                   medicalEntities.UdzielonaPomoc
                   .Where(pomoc => pomoc.CzyAktywny == true)
                   .Select(pomoc => new UdzielonaPomocForAllView
                   {
                       DataPomocy = pomoc.DataPomocy,
                       CzasRozpoczecia = pomoc.CzasRozpoczecia,
                       CzasZakonczenia = pomoc.CzasZakonczenia,
                       OpisPomocy = pomoc.OpisPomocy,
                       ProceduryMedyczne = pomoc.ProceduryMedyczne,
                       WynikInterwencji = pomoc.WynikInterwencji,
                       CzasTrwaniaMinuty = pomoc.CzasTrwaniaMinuty,
                       LokalizacjaInterwencji = pomoc.LokalizacjaInterwencji,
                       WymaganySprzet = pomoc.WymaganySprzet,
                       PacjentWymagalTransportu = pomoc.CzyWymagalTransportu == true ? "TAK" : "NIE",
                       PriorytetInterwencji = pomoc.PriorytetInterwencji,
                       KodDiagnozyICD10 = pomoc.KodDiagnozyICD10,
                       SzpitalTransportu = pomoc.SzpitalTransportu,
                       StanPacjentaPrzyPrzekazaniu = pomoc.StanPacjentaPrzyPrzekazaniu,
                       UdziałPolicji = pomoc.CzyBylWymaganyUdziałPolicji == true ? "TAK" : "NIE",
                       Pacjent = pomoc.Pacjent.Imie + " " + pomoc.Pacjent.Nazwisko,
                       NazwaZespolu = pomoc.ZespolRatunkowy.NazwaZespolu,
                       Karetka = pomoc.Karetka.NumerRejestracyjny,
                       AdresZdarzenia = pomoc.ZlecenieWyjazdu.AdresZdarzenia,
                       AutorRaportu = pomoc.Pracownik.Imie + " " + pomoc.Pracownik.Nazwisko
                   })
                   .ToList()
                );
        }
        #endregion

        #region Konstruktor
        public WszystkieUdzielonePomoceViewModel()
        {
            base.DisplayName = "Udzielone Pomoce";
        }
        #endregion
        #region Sortowanie i Filtrowanie
        public override List<string> getComboBoxSortList()
        {
            return new List<string>
    {
        "dataPomocy",
        "czasRozpoczecia",
        "czasZakonczenia",
        "czasTrwaniaMinuty",
        "priorytetInterwencji",
        "wynikInterwencji",
        "pacjent",
        "nazwaZespolu",
        "karetka",
        "lokalizacjaInterwencji",
        "kodDiagnozyICD10",
        "szpitalTransportu"
    };
        }

        public override List<string> getComboBoxFindList()
        {
            return new List<string>
    {
        "pacjent",
        "nazwaZespolu",
        "karetka",
        "lokalizacjaInterwencji",
        "adresZdarzenia",
        "kodDiagnozyICD10",
        "szpitalTransportu",
        "priorytetInterwencji",
        "wynikInterwencji",
        "autorRaportu",
        "opisPomocy",
        "proceduryMedyczne"
    };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "dataPomocy":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.OrderBy(item => item.DataPomocy));
                    break;
                case "czasRozpoczecia":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.OrderBy(item => item.CzasRozpoczecia));
                    break;
                case "czasZakonczenia":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.OrderBy(item => item.CzasZakonczenia));
                    break;
                case "czasTrwaniaMinuty":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.OrderBy(item => item.CzasTrwaniaMinuty));
                    break;
                case "priorytetInterwencji":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.OrderBy(item => item.PriorytetInterwencji));
                    break;
                case "wynikInterwencji":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.OrderBy(item => item.WynikInterwencji));
                    break;
                case "pacjent":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.OrderBy(item => item.Pacjent));
                    break;
                case "nazwaZespolu":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.OrderBy(item => item.NazwaZespolu));
                    break;
                case "karetka":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.OrderBy(item => item.Karetka));
                    break;
                case "lokalizacjaInterwencji":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.OrderBy(item => item.LokalizacjaInterwencji));
                    break;
                case "kodDiagnozyICD10":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.OrderBy(item => item.KodDiagnozyICD10));
                    break;
                case "szpitalTransportu":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.OrderBy(item => item.SzpitalTransportu));
                    break;
                default:
                    break;
            }
        }

        public override void Find()
        {
            switch (FindField)
            {
                case "pacjent":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.Where(item =>
                        item.Pacjent != null && item.Pacjent.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "nazwaZespolu":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.Where(item =>
                        item.NazwaZespolu != null && item.NazwaZespolu.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "karetka":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.Where(item =>
                        item.Karetka != null && item.Karetka.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "lokalizacjaInterwencji":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.Where(item =>
                        item.LokalizacjaInterwencji != null && item.LokalizacjaInterwencji.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "adresZdarzenia":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.Where(item =>
                        item.AdresZdarzenia != null && item.AdresZdarzenia.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "kodDiagnozyICD10":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.Where(item =>
                        item.KodDiagnozyICD10 != null && item.KodDiagnozyICD10.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "szpitalTransportu":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.Where(item =>
                        item.SzpitalTransportu != null && item.SzpitalTransportu.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "priorytetInterwencji":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.Where(item =>
                        item.PriorytetInterwencji != null && item.PriorytetInterwencji.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "wynikInterwencji":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.Where(item =>
                        item.WynikInterwencji != null && item.WynikInterwencji.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "autorRaportu":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.Where(item =>
                        item.AutorRaportu != null && item.AutorRaportu.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "opisPomocy":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.Where(item =>
                        item.OpisPomocy != null && item.OpisPomocy.Contains(FindTextBox)));
                    break;
                case "proceduryMedyczne":
                    List = new ObservableCollection<UdzielonaPomocForAllView>(List.Where(item =>
                        item.ProceduryMedyczne != null && item.ProceduryMedyczne.Contains(FindTextBox)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}