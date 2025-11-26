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
    }
}