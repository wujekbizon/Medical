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
    public class WszystkieZespolPracownikViewModel : WszystkieViewModel<ZespolPracownikForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<ZespolPracownikForAllView>
                (
                   medicalEntities.ZespolPracownik
                   .Where(zp => zp.CzyAktywny == true)
                   .Select(zp => new ZespolPracownikForAllView
                   {
                       NazwaZespolu = zp.ZespolRatunkowy.NazwaZespolu,
                       Pracownik = zp.Pracownik.Imie + " " + zp.Pracownik.Nazwisko,
                       RolaWZespole = zp.RolaWZespole,
                       DataDolaczenia = zp.DataDolaczenia,
                       DataOpuszczenia = zp.DataOpuszczenia,
                       PowodZmiany = zp.PowodZmiany,
                       DataPrzypisania = zp.DataPrzypisania
                   })
                   .ToList()
                );
        }
        #endregion

        #region Konstruktor
        public WszystkieZespolPracownikViewModel()
        {
            base.DisplayName = "Skład Zespołów";
        }
        #endregion
    }
}