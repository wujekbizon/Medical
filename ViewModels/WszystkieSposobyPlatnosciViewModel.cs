using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Medical.ViewModels.Abstract;

namespace Medical.ViewModels
{
    public class WszystkieSposobyPlatnosciViewModel : WszystkieViewModel<dynamic>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<dynamic>
            (
                medicalEntities.SposobPlatnosci.Where(s => s.CzyAktywny == true).ToList()
            );
        }
        #endregion
        #region Konstruktor
        public WszystkieSposobyPlatnosciViewModel()
            :base()
        {
            base.DisplayName = "SposobyPlatnosci";
        }
        #endregion

    }
}
