using Medical.Models;
using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.ViewModels
{
    public class NowaRolaPracownikaViewModel : JedenViewModel<RolaPracownika>
    {
        #region Konstruktor
        public NowaRolaPracownikaViewModel()
           : base()
        {
            base.DisplayName = "Rola";
            item = new RolaPracownika();
        }
        #endregion

        #region Wlasciwosci
        public string NazwaRoli
        {
            get
            {
                return item.NazwaRoli;
            }
            set
            {
                if (item.NazwaRoli != value)
                {
                    item.NazwaRoli = value;
                    OnPropertyChanged(() => NazwaRoli);
                }
            }
        }

        public int PoziomUprawnien
        {
            get
            {
                return item.PoziomUprawnien;
            }
            set
            {
                if (item.PoziomUprawnien != value)
                {
                    item.PoziomUprawnien = value;
                    OnPropertyChanged(() => PoziomUprawnien);
                }
            }
        }

        public string OpisObowiazkow
        {
            get
            {
                return item.OpisObowiazkow;
            }
            set
            {
                if (item.OpisObowiazkow != value)
                {
                    item.OpisObowiazkow = value;
                    OnPropertyChanged(() => OpisObowiazkow);
                }
            }
        }

        public string MinimalneWyksztalcenie
        {
            get
            {
                return item.MinimalneWyksztalcenie;
            }
            set
            {
                if (item.MinimalneWyksztalcenie != value)
                {
                    item.MinimalneWyksztalcenie = value;
                    OnPropertyChanged(() => MinimalneWyksztalcenie);
                }
            }
        }

        public string WymaganeSzkolenia
        {
            get
            {
                return item.WymaganeSzkolenia;
            }
            set
            {
                if (item.WymaganeSzkolenia != value)
                {
                    item.WymaganeSzkolenia = value;
                    OnPropertyChanged(() => WymaganeSzkolenia);
                }
            }
        }

        public bool CzyWymagaLicencji
        {
            get
            {
                return item.CzyWymagaLicencji;
            }
            set
            {
                if (item.CzyWymagaLicencji != value)
                {
                    item.CzyWymagaLicencji = value;
                    OnPropertyChanged(() => CzyWymagaLicencji);
                }
            }
        }

        public int? MaksymalnaLiczbaGodzinTygodniowo
        {
            get
            {
                return item.MaksymalnaLiczbaGodzinTygodniowo;
            }
            set
            {
                if (item.MaksymalnaLiczbaGodzinTygodniowo != value)
                {
                    item.MaksymalnaLiczbaGodzinTygodniowo = value;
                    OnPropertyChanged(() => MaksymalnaLiczbaGodzinTygodniowo);
                }
            }
        }

        public decimal? SredniaPlaca
        {
            get
            {
                return item.SredniaPlaca;
            }
            set
            {
                if (item.SredniaPlaca != value)
                {
                    item.SredniaPlaca = value;
                    OnPropertyChanged(() => SredniaPlaca);
                }
            }
        }

        public string Benefity
        {
            get
            {
                return item.Benefity;
            }
            set
            {
                if (item.Benefity != value)
                {
                    item.Benefity = value;
                    OnPropertyChanged(() => Benefity);
                }
            }
        }

        public DateTime? DataOstatniejAktualizacji
        {
            get
            {
                return item.DataOstatniejAktualizacji;
            }
            set
            {
                if (item.DataOstatniejAktualizacji != value)
                {
                    item.DataOstatniejAktualizacji = value;
                    OnPropertyChanged(() => DataOstatniejAktualizacji);
                }
            }
        }

        public string NazwaDzialu
        {
            get
            {
                return item.NazwaDzialu;
            }
            set
            {
                if (item.NazwaDzialu != value)
                {
                    item.NazwaDzialu = value;
                    OnPropertyChanged(() => NazwaDzialu);
                }
            }
        }

        public bool CzyJestLideremZespolu
        {
            get
            {
                return item.CzyJestLideremZespolu;
            }
            set
            {
                if (item.CzyJestLideremZespolu != value)
                {
                    item.CzyJestLideremZespolu = value;
                    OnPropertyChanged(() => CzyJestLideremZespolu);
                }
            }
        }

        public int? LimitZatrudnienia
        {
            get
            {
                return item.LimitZatrudnienia;
            }
            set
            {
                if (item.LimitZatrudnienia != value)
                {
                    item.LimitZatrudnienia = value;
                    OnPropertyChanged(() => LimitZatrudnienia);
                }
            }
        }

        public string WymaganeUmiejetnosci
        {
            get
            {
                return item.WymaganeUmiejetnosci;
            }
            set
            {
                if (item.WymaganeUmiejetnosci != value)
                {
                    item.WymaganeUmiejetnosci = value;
                    OnPropertyChanged(() => WymaganeUmiejetnosci);
                }
            }
        }

        public string RolaNastepnegoEtapuKariery
        {
            get
            {
                return item.RolaNastepnegoEtapuKariery;
            }
            set
            {
                if (item.RolaNastepnegoEtapuKariery != value)
                {
                    item.RolaNastepnegoEtapuKariery = value;
                    OnPropertyChanged(() => RolaNastepnegoEtapuKariery);
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

            medicalEntities.RolaPracownika.Add(item);
            medicalEntities.SaveChanges();
        }
        #endregion
    }
}