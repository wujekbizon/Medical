using Medical.Helper;
using Medical.Models;
using Medical.Models.EntitiesForView;
using Medical.Models.Enums;
using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.ViewModels
{
    public class NowySposobPlatnosciViewModel : JedenViewModel<SposobPlatnosci>
    {
        #region Konstruktor
        public NowySposobPlatnosciViewModel()
           : base()
        {
            base.DisplayName = "Sposób Płatności";
            item = new SposobPlatnosci();
        }
        #endregion

        #region Wlasciwosci
        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                if (item.Nazwa != value)
                {
                    item.Nazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }

        public string Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                if (item.Opis != value)
                {
                    item.Opis = value;
                    OnPropertyChanged(() => Opis);
                }
            }
        }

        public bool CzyWymagaPotwierdzenia
        {
            get
            {
                return item.CzyWymagaPotwierdzenia;
            }
            set
            {
                if (item.CzyWymagaPotwierdzenia != value)
                {
                    item.CzyWymagaPotwierdzenia = value;
                    OnPropertyChanged(() => CzyWymagaPotwierdzenia);
                }
            }
        }

        public string RodzajTransakcji
        {
            get
            {
                return item.RodzajTransakcji;
            }
            set
            {
                if (item.RodzajTransakcji != value)
                {
                    item.RodzajTransakcji = value;
                    OnPropertyChanged(() => RodzajTransakcji);
                }
            }
        }

        public bool CzyAktywny
        {
            get
            {
                return item.CzyAktywny;
            }
            set
            {
                if (item.CzyAktywny != value)
                {
                    item.CzyAktywny = value;
                    OnPropertyChanged(() => CzyAktywny);
                }
            }
        }

        public IEnumerable<KeyAndValue> RodzajTransakcjiItems
        {
            get
            {
                return EnumHelper.GetEnumKeyAndValues<RodzajTransakcjiEnum>();
            }
        }
        #endregion

        #region Komendy
        public override void Save()
        {
            item.CzyAktywny = true;
            item.KiedyDodal = DateTime.Now;
            item.KtoDodal = "AdminSystem";
            item.WersjaDanych = 1;

            medicalEntities.SposobPlatnosci.Add(item);
            medicalEntities.SaveChanges();
        }
        #endregion
    }
}