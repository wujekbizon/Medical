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
    public class WszystkieZleceniaWyjazduViewModel : WszystkieViewModel<ZleceniaWyjazduForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<ZleceniaWyjazduForAllView>
                (
                   medicalEntities.ZlecenieWyjazdu
                   .Where(zlecenie => zlecenie.CzyAktywny == true)
                   .Select(zlecenie => new ZleceniaWyjazduForAllView
                   {
                       DataCzasZgloszenia = zlecenie.DataCzasZgloszenia,
                       AdresZdarzenia = zlecenie.AdresZdarzenia,
                       TypZdarzenia = zlecenie.TypZdarzenia,
                       Priorytet = zlecenie.Priorytet,
                       StatusZlecenia = zlecenie.StatusZlecenia,
                       OpisZdarzenia = zlecenie.OpisZdarzenia,
                       CzasWyjazdu = zlecenie.CzasWyjazdu,
                       CzasPrzyjazduNaMiejsce = zlecenie.CzasPrzyjazduNaMiejsce,
                       CzasPowrotuDoBazy = zlecenie.CzasPowrotuDoBazy,
                       TelefonDzwoniacego = zlecenie.TelefonDzwoniacego,
                       CzasReakcjiSekundy = zlecenie.CzasReakcjiSekundy,
                       Dystans = zlecenie.DystansKm,
                       LiczbaPacjentow = zlecenie.LiczbaPacjentow,
                       WarunkiPogodowe = zlecenie.WarunkiPogodowe,
                       WymaganeDodatkoweWsparcie = zlecenie.WymaganeDodatkoweWsparcie,
                       Dyspozytor = zlecenie.Pracownik.Imie + " " + zlecenie.Pracownik.Nazwisko,
                       NazwaZespolu = zlecenie.ZespolRatunkowy.NazwaZespolu,
                       NumerRejestracyjnyKaretki = zlecenie.Karetka.NumerRejestracyjny
                   })
                   .ToList()
                );
        }
        #endregion

        #region Konstruktor
        public WszystkieZleceniaWyjazduViewModel()
        {
            base.DisplayName = "Wyjazdy";
        }
        #endregion
    }
}