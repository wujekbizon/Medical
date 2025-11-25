using Medical.Models;
using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.ViewModels
{
    public class NowaPlacowkaViewModel : JedenViewModel<Placowka>
    {
        #region Konstruktor
        public NowaPlacowkaViewModel()
           : base()
        {
            base.DisplayName = "Placowka";
            item = new Placowka();
        }
        #endregion

        #region Wlasciwosci
        public string NazwaPlacowki
        {
            get
            {
                return item.NazwaPlacowki;
            }
            set
            {
                if (item.NazwaPlacowki != value)
                {
                    item.NazwaPlacowki = value;
                    OnPropertyChanged(() => NazwaPlacowki);
                }
            }
        }

        public string Adres
        {
            get
            {
                return item.Adres;
            }
            set
            {
                if (item.Adres != value)
                {
                    item.Adres = value;
                    OnPropertyChanged(() => Adres);
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

        public string Telefon
        {
            get
            {
                return item.Telefon;
            }
            set
            {
                if (item.Telefon != value)
                {
                    item.Telefon = value;
                    OnPropertyChanged(() => Telefon);
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

        public string TypPlacowki
        {
            get
            {
                return item.TypPlacowki;
            }
            set
            {
                if (item.TypPlacowki != value)
                {
                    item.TypPlacowki = value;
                    OnPropertyChanged(() => TypPlacowki);
                }
            }
        }

        public string GodzinyPracy
        {
            get
            {
                return item.GodzinyPracy;
            }
            set
            {
                if (item.GodzinyPracy != value)
                {
                    item.GodzinyPracy = value;
                    OnPropertyChanged(() => GodzinyPracy);
                }
            }
        }

        public int? LiczbaKaretek
        {
            get
            {
                return item.LiczbaKaretek;
            }
            set
            {
                if (item.LiczbaKaretek != value)
                {
                    item.LiczbaKaretek = value;
                    OnPropertyChanged(() => LiczbaKaretek);
                }
            }
        }

        public int? LiczbaZespolow
        {
            get
            {
                return item.LiczbaZespolow;
            }
            set
            {
                if (item.LiczbaZespolow != value)
                {
                    item.LiczbaZespolow = value;
                    OnPropertyChanged(() => LiczbaZespolow);
                }
            }
        }

        public int? PojemnoscGarazu
        {
            get
            {
                return item.PojemnoscGarazu;
            }
            set
            {
                if (item.PojemnoscGarazu != value)
                {
                    item.PojemnoscGarazu = value;
                    OnPropertyChanged(() => PojemnoscGarazu);
                }
            }
        }

        public DateTime? DataOtwarcia
        {
            get
            {
                return item.DataOtwarcia;
            }
            set
            {
                if (item.DataOtwarcia != value)
                {
                    item.DataOtwarcia = value;
                    OnPropertyChanged(() => DataOtwarcia);
                }
            }
        }

        public DateTime? DataOstatniejInspekcji
        {
            get
            {
                return item.DataOstatniejInspekcji;
            }
            set
            {
                if (item.DataOstatniejInspekcji != value)
                {
                    item.DataOstatniejInspekcji = value;
                    OnPropertyChanged(() => DataOstatniejInspekcji);
                }
            }
        }

        public string Region
        {
            get
            {
                return item.Region;
            }
            set
            {
                if (item.Region != value)
                {
                    item.Region = value;
                    OnPropertyChanged(() => Region);
                }
            }
        }

        public decimal? Budzet
        {
            get
            {
                return item.Budzet;
            }
            set
            {
                if (item.Budzet != value)
                {
                    item.Budzet = value;
                    OnPropertyChanged(() => Budzet);
                }
            }
        }

        public string ObszarZasieguRatunkowego
        {
            get
            {
                return item.ObszarZasieguRatunkowego;
            }
            set
            {
                if (item.ObszarZasieguRatunkowego != value)
                {
                    item.ObszarZasieguRatunkowego = value;
                    OnPropertyChanged(() => ObszarZasieguRatunkowego);
                }
            }
        }

        public bool CzyMaAkredytacje
        {
            get
            {
                return item.CzyMaAkredytacje;
            }
            set
            {
                if (item.CzyMaAkredytacje != value)
                {
                    item.CzyMaAkredytacje = value;
                    OnPropertyChanged(() => CzyMaAkredytacje);
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

            medicalEntities.Placowka.Add(item);
            medicalEntities.SaveChanges();
        }
        #endregion
    }
}