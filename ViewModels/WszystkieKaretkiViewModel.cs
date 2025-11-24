using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.ViewModels
{
    public class WszystkieKaretkiViewModel: WszystkieViewModel<dynamic>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<dynamic>
                (
                medicalEntities.Karetka.Where((k) => k.CzyAktywny == true).ToList()
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
