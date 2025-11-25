using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.ViewModels
{
    public class WszyscyKontrahenciViewModel :  WszystkieViewModel<dynamic>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<dynamic>
            (
                medicalEntities.Kontrahent.Where(s => s.CzyAktywny == true).ToList()
            );
        }
        #endregion
        #region Konstruktor
        public WszyscyKontrahenciViewModel()
            : base()
        {
            base.DisplayName = "Kontrahenci";
        }
        #endregion

    }
}
