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
    public class WszystkieOcenyZespoluViewModel : WszystkieViewModel<OcenaZespoluForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<OcenaZespoluForAllView>
                (
                   medicalEntities.OcenaZespolu
                   .Where(ocena => ocena.CzyAktywny == true)
                   .Select(ocena => new OcenaZespoluForAllView
                   {
                       Ocena = ocena.Ocena,
                       DataOceny = ocena.DataOceny,
                       Komentarz = ocena.Komentarz,
                       KryteriumOceny = ocena.KryteriumOceny,
                       WagaOceny = ocena.WagaOceny,
                       OcenaCzasuReakcji = ocena.OcenaCzasuReakcji,
                       OcenaProfesjonalizmu = ocena.OcenaProfesjonalizmu,
                       OcenaSkutecznosci = ocena.OcenaSkutecznosci,
                       PacjentDalOpinie = (bool)(ocena.CzyOtrzymanoFeedbackOdPacjenta) ? "TAK" : "NIE",
                       SugerowaneUlepszenia = ocena.SugerowaneUlepszenia,
                       OcenaStosowaniaStandardow = ocena.OcenaStosowaniaStandardow,
                       NazwaZespolu = ocena.ZespolRatunkowy.NazwaZespolu,
                       Oceniajacy = ocena.Pracownik.Imie + " " + ocena.Pracownik.Nazwisko,
                       AdresZdarzenia = ocena.ZlecenieWyjazdu.AdresZdarzenia
                   })
                   .ToList()
                );
        }
        #endregion

        #region Konstruktor
        public WszystkieOcenyZespoluViewModel()
        {
            base.DisplayName = "Oceny Zespolow";
        }
        #endregion

        #region Sortowanie i Filtrowanie
        public override List<string> getComboBoxSortList()
        {
            return new List<string>
    {
        "dataOceny",
        "ocena",
        "nazwaZespolu",
        "kryteriumOceny",
        "wagaOceny",
        "ocenaCzasuReakcji",
        "ocenaProfesjonalizmu",
        "ocenaSkutecznosci",
        "ocenaStosowaniaStandardow",
        "oceniajacy"
    };
        }

        public override List<string> getComboBoxFindList()
        {
            return new List<string>
    {
        "nazwaZespolu",
        "kryteriumOceny",
        "oceniajacy",
        "adresZdarzenia",
        "pacjentDalOpinie",
        "komentarz",
        "sugerowaneUlepszenia"
    };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "dataOceny":
                    List = new ObservableCollection<OcenaZespoluForAllView>(List.OrderBy(item => item.DataOceny));
                    break;
                case "ocena":
                    List = new ObservableCollection<OcenaZespoluForAllView>(List.OrderBy(item => item.Ocena));
                    break;
                case "nazwaZespolu":
                    List = new ObservableCollection<OcenaZespoluForAllView>(List.OrderBy(item => item.NazwaZespolu));
                    break;
                case "kryteriumOceny":
                    List = new ObservableCollection<OcenaZespoluForAllView>(List.OrderBy(item => item.KryteriumOceny));
                    break;
                case "wagaOceny":
                    List = new ObservableCollection<OcenaZespoluForAllView>(List.OrderBy(item => item.WagaOceny));
                    break;
                case "ocenaCzasuReakcji":
                    List = new ObservableCollection<OcenaZespoluForAllView>(List.OrderBy(item => item.OcenaCzasuReakcji));
                    break;
                case "ocenaProfesjonalizmu":
                    List = new ObservableCollection<OcenaZespoluForAllView>(List.OrderBy(item => item.OcenaProfesjonalizmu));
                    break;
                case "ocenaSkutecznosci":
                    List = new ObservableCollection<OcenaZespoluForAllView>(List.OrderBy(item => item.OcenaSkutecznosci));
                    break;
                case "ocenaStosowaniaStandardow":
                    List = new ObservableCollection<OcenaZespoluForAllView>(List.OrderBy(item => item.OcenaStosowaniaStandardow));
                    break;
                case "oceniajacy":
                    List = new ObservableCollection<OcenaZespoluForAllView>(List.OrderBy(item => item.Oceniajacy));
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
                    List = new ObservableCollection<OcenaZespoluForAllView>(List.Where(item =>
                        item.NazwaZespolu != null && item.NazwaZespolu.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "kryteriumOceny":
                    List = new ObservableCollection<OcenaZespoluForAllView>(List.Where(item =>
                        item.KryteriumOceny != null && item.KryteriumOceny.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "oceniajacy":
                    List = new ObservableCollection<OcenaZespoluForAllView>(List.Where(item =>
                        item.Oceniajacy != null && item.Oceniajacy.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "adresZdarzenia":
                    List = new ObservableCollection<OcenaZespoluForAllView>(List.Where(item =>
                        item.AdresZdarzenia != null && item.AdresZdarzenia.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "pacjentDalOpinie":
                    List = new ObservableCollection<OcenaZespoluForAllView>(List.Where(item =>
                        item.PacjentDalOpinie != null && item.PacjentDalOpinie.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "komentarz":
                    List = new ObservableCollection<OcenaZespoluForAllView>(List.Where(item =>
                        item.Komentarz != null && item.Komentarz.Contains(FindTextBox)));
                    break;
                case "sugerowaneUlepszenia":
                    List = new ObservableCollection<OcenaZespoluForAllView>(List.Where(item =>
                        item.SugerowaneUlepszenia != null && item.SugerowaneUlepszenia.Contains(FindTextBox)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}