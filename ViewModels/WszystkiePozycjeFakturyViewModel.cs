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
    public class WszystkiePozycjeFakturyViewModel : WszystkieViewModel<PozycjaFakturyForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<PozycjaFakturyForAllView>
                (
                   medicalEntities.PozycjaFaktury
                   .Where(pozycja => pozycja.CzyAktywny == true)
                   .Select(pozycja => new PozycjaFakturyForAllView
                   {
                       NumerFaktury = pozycja.Faktura.Numer,
                       NazwaUslugi = pozycja.NazwaUslugi,
                       Ilosc = pozycja.Ilosc,
                       CenaJednostkowaNetto = pozycja.CenaJednostkowaNetto,
                       StawkaVAT = pozycja.StawkaVAT,
                       KwotaNetto = pozycja.KwotaNetto,
                       KwotaVAT = pozycja.KwotaVAT,
                       KwotaBrutto = pozycja.KwotaBrutto,
                       JednostkaMiary = pozycja.JednostkaMiary,
                       Kod = pozycja.Kod,
                       KategoriaPozycji = pozycja.KategoriaPozycji
                   })
                   .ToList()
                );
        }
        #endregion

        #region Konstruktor
        public WszystkiePozycjeFakturyViewModel()
        {
            base.DisplayName = "Pozycje Faktur";
        }
        #endregion
    }
}