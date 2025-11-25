using Medical.Models;
using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.ViewModels
{
    public class NowyKontrahentViewModel : JedenViewModel<Kontrahent>
    {
        #region Konstruktor
        public NowyKontrahentViewModel()
           : base()
        {
            base.DisplayName = "Kontrahent";
            item = new Kontrahent();
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

        public string Typ
        {
            get
            {
                return item.Typ;
            }
            set
            {
                if (item.Typ != value)
                {
                    item.Typ = value;
                    OnPropertyChanged(() => Typ);
                }
            }
        }

        public string OsobaKontaktowa
        {
            get
            {
                return item.OsobaKontaktowa;
            }

            set
            {
                if (item.OsobaKontaktowa != value)
                {
                    item.OsobaKontaktowa = value;
                    OnPropertyChanged(() => OsobaKontaktowa);
                }
            }
        }

        public string TelefonKontaktowy
        {
            get
            {
                return item.TelefonKontaktowy;
            }
            set
            {
                if (item.TelefonKontaktowy != value)
                {
                    item.TelefonKontaktowy = value;
                    OnPropertyChanged(() => TelefonKontaktowy);
                }
            }
        }

        public string AdresEmail
        {
            get
            {
                return item.AdresEmail;
            }
            set
            {
                if (item.AdresEmail != value)
                {
                    item.AdresEmail = value;
                    OnPropertyChanged(() => AdresEmail);
                }
            }
        }

        public string AdresSiedziby
        {
            get
            {
                return item.AdresSiedziby;
            }
            set
            {
                if (item.AdresSiedziby != value)
                {
                    item.AdresSiedziby = value;
                    OnPropertyChanged(() => AdresSiedziby);
                }
            }
        }

        public string Miasto
        {
            get
            {
                return item.Miasto;
            }
            set
            {
                if (item.Miasto != value)
                {
                    item.Miasto = value;
                    OnPropertyChanged(() => Miasto);
                }
            }
        }

        public string KodPocztowy
        {
            get
            {
                return item.KodPocztowy;
            }
            set
            {
                if (item.KodPocztowy != value)
                {
                    item.KodPocztowy = value;
                    OnPropertyChanged(() => KodPocztowy);
                }
            }
        }

        public string NIP
        {
            get
            {
                return item.NIP;
            }
            set
            {
                if (item.NIP != value)
                {
                    item.NIP = value;
                    OnPropertyChanged(() => NIP);
                }
            }
        }

        public string NumerKontaBankowego
        {
            get
            {
                return item.NumerKontaBankowego;
            }
            set
            {
                if (item.NumerKontaBankowego != value)
                {
                    item.NumerKontaBankowego = value;
                    OnPropertyChanged(() => NumerKontaBankowego);
                }
            }
        }

        public string KategoriaBiznesowa
        {
            get
            {
                return item.KategoriaBiznesowa;
            }
            set
            {
                if (item.KategoriaBiznesowa != value)
                {
                    item.KategoriaBiznesowa = value;
                    OnPropertyChanged(() => KategoriaBiznesowa);
                }
            }
        }

        public DateTime? DataRozpoczeciaWspolpracy
        {
            get
            {
                return item.DataRozpoczeciaWspolpracy;
            }
            set
            {
                if (item.DataRozpoczeciaWspolpracy != value)
                {
                    item.DataRozpoczeciaWspolpracy = value;
                    OnPropertyChanged(() => DataRozpoczeciaWspolpracy);
                }
            }
        }

        public DateTime? DataZakonczeniaUmowy
        {
            get
            {
                return item.DataZakonczeniaUmowy;
            }
            set
            {
                if (item.DataZakonczeniaUmowy != value)
                {
                    item.DataZakonczeniaUmowy = value;
                    OnPropertyChanged(() => DataZakonczeniaUmowy);
                }
            }
        }

        public string WarunkiPlatnosci
        {
            get
            {
                return item.WarunkiPlatnosci;
            }
            set
            {
                if (item.WarunkiPlatnosci != value)
                {
                    item.WarunkiPlatnosci = value;
                    OnPropertyChanged(() => WarunkiPlatnosci);
                }
            }
        }

        public bool CzyPreferowany
        {
            get
            {
                return item.CzyPreferowany;
            }
            set
            {
                if (item.CzyPreferowany != value)
                {
                    item.CzyPreferowany = value;
                    OnPropertyChanged(() => CzyPreferowany);
                }
            }
        }

        public decimal? LacznaWartoscTransakcji
        {
            get
            {
                return item.LacznaWartoscTransakcji;
            }
            set
            {
                if (item.LacznaWartoscTransakcji != value)
                {
                    item.LacznaWartoscTransakcji = value;
                    OnPropertyChanged(() => LacznaWartoscTransakcji);
                }
            }
        }

        public string StatusWspolpracy
        {
            get
            {
                return item.StatusWspolpracy;
            }
            set
            {
                if (item.StatusWspolpracy != value)
                {
                    item.StatusWspolpracy = value;
                    OnPropertyChanged(() => StatusWspolpracy);
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
        #endregion

        #region Komendy
        public override void Save()
        {
            item.CzyAktywny = true;
            item.KiedyDodal = DateTime.Now;
            item.KtoDodal = "AdminSystem";
            item.WersjaDanych = 1;

            medicalEntities.Kontrahent.Add(item);
            medicalEntities.SaveChanges();
        }
        #endregion
    }
}
