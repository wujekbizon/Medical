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
    public class WszystkieZespolyRatunkoweViewModel : WszystkieViewModel<ZespolRatunkowyForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<ZespolRatunkowyForAllView>
                (
                   medicalEntities.ZespolRatunkowy
                   .Where(zespol => zespol.CzyAktywny == true)
                   .Select(zespol => new ZespolRatunkowyForAllView
                   {
                       NazwaZespolu = zespol.NazwaZespolu,
                       LiczbaCzlonkow = zespol.LiczbaCzlonkow,
                       Specjalizacja = zespol.Specjalizacja,
                       DataUtworzenia = zespol.DataUtworzenia,
                       StatusZespolu = zespol.StatusZespolu,
                       TelefonKontaktowy = zespol.TelefonKontaktowy,
                       Zmiana = zespol.Zmiana,
                       DataOstatniegoSzkolenia = zespol.DataOstatniegoSzkolenia,
                       SredniaOcena = zespol.SredniaOcena,
                       DataOstatniegoWyjazdu = zespol.DataOstatniegoWyjazdu,
                       LiczbaWszystkichWyjazdow = zespol.LiczbaWszystkichWyjazdow,
                       Certyfikaty = zespol.Certyfikaty,
                       Karetka = zespol.Karetka.NumerRejestracyjny,
                       NazwaPlacowki = zespol.Placowka.NazwaPlacowki
                   })
                   .ToList()
                );
        }
        #endregion

        #region Konstruktor
        public WszystkieZespolyRatunkoweViewModel()
        {
            base.DisplayName = "Zespoly Ratunkowe";
        }
        #endregion
    }
}