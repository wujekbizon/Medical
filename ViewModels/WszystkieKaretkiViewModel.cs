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

    }
}
