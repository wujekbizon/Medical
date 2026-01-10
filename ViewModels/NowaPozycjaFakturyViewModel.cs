using GalaSoft.MvvmLight.Messaging;
using Medical.Helper;
using Medical.Models;
using Medical.Models.EntitiesForView;
using Medical.ViewModels.Abstract;
using System;
using System.Windows.Input;

namespace Medical.ViewModels
{
    
    public class NowaPozycjaFakturyViewModel : JedenViewModel<PozycjaFaktury>
    {
        #region Pola
        private readonly UserForAllView _currentUser;
        #endregion
        #region Konstruktor
        public NowaPozycjaFakturyViewModel(UserForAllView currentUser)
            : base()
        {
            base.DisplayName = "Pozycja Faktury";
            item = new PozycjaFaktury();
            _currentUser = currentUser;

            Ilosc = 1;
            StawkaVAT = 23;

            Messenger.Default.Register<FakturaForAllView>(this, getWybranaFaktura);
        }
        #endregion

        #region Komendy

        private BaseCommand _ShowFaktury;
        public ICommand ShowFaktury
        {
            get
            {
                if (_ShowFaktury == null)
                {
                    _ShowFaktury = new BaseCommand(() =>
                    {
                        Messenger.Default.Send("FakturyShow");
                    });
                }
                return _ShowFaktury;
            }
        }

        #endregion

        #region Właściwości
        public string NazwaUslugi
        {
            get
            {
                return item.NazwaUslugi;
            }
            set
            {
                if (item.NazwaUslugi != value)
                {
                    item.NazwaUslugi = value;
                    OnPropertyChanged(() => NazwaUslugi);
                }
            }
        }

        public decimal Ilosc
        {
            get
            {
                return item.Ilosc;
            }
            set
            {
                if (item.Ilosc != value)
                {
                    item.Ilosc = value;
                    OnPropertyChanged(() => Ilosc);
                    RecalculateAmounts();
                }
            }
        }

        public decimal CenaJednostkowaNetto
        {
            get
            {
                return item.CenaJednostkowaNetto;
            }
            set
            {
                if (item.CenaJednostkowaNetto != value)
                {
                    item.CenaJednostkowaNetto = value;
                    OnPropertyChanged(() => CenaJednostkowaNetto);
                    RecalculateAmounts();
                }
            }
        }

        public decimal StawkaVAT
        {
            get
            {
                return item.StawkaVAT;
            }
            set
            {
                if (item.StawkaVAT != value)
                {
                    item.StawkaVAT = value;
                    OnPropertyChanged(() => StawkaVAT);
                    RecalculateAmounts();
                }
            }
        }

        public decimal KwotaNetto
        {
            get
            {
                return item.KwotaNetto;
            }
            set
            {
                if (item.KwotaNetto != value)
                {
                    item.KwotaNetto = value;
                    OnPropertyChanged(() => KwotaNetto);
                }
            }
        }

        public decimal KwotaVAT
        {
            get
            {
                return item.KwotaVAT;
            }
            set
            {
                if (item.KwotaVAT != value)
                {
                    item.KwotaVAT = value;
                    OnPropertyChanged(() => KwotaVAT);
                }
            }
        }

        public decimal KwotaBrutto
        {
            get
            {
                return item.KwotaBrutto;
            }
            set
            {
                if (item.KwotaBrutto != value)
                {
                    item.KwotaBrutto = value;
                    OnPropertyChanged(() => KwotaBrutto);
                }
            }
        }

        public string JednostkaMiary
        {
            get
            {
                return item.JednostkaMiary;
            }
            set
            {
                if (item.JednostkaMiary != value)
                {
                    item.JednostkaMiary = value;
                    OnPropertyChanged(() => JednostkaMiary);
                }
            }
        }

        public string Kod
        {
            get
            {
                return item.Kod;
            }
            set
            {
                if (item.Kod != value)
                {
                    item.Kod = value;
                    OnPropertyChanged(() => Kod);
                }
            }
        }

        public string KategoriaPozycji
        {
            get
            {
                return item.KategoriaPozycji;
            }
            set
            {
                if (item.KategoriaPozycji != value)
                {
                    item.KategoriaPozycji = value;
                    OnPropertyChanged(() => KategoriaPozycji);
                }
            }
        }

        public int IdFaktury
        {
            get
            {
                return item.IdFaktury;
            }
            set
            {
                if (item.IdFaktury != value)
                {
                    item.IdFaktury = value;
                    OnPropertyChanged(() => IdFaktury);
                }
            }
        }

        private string _FakturaNumer;
        public string FakturaNumer
        {
            get
            {
                return _FakturaNumer;
            }
            set
            {
                if (_FakturaNumer != value)
                {
                    _FakturaNumer = value;
                    OnPropertyChanged(() => FakturaNumer);
                }
            }
        }

        private DateTime? _FakturaDataWystawienia;
        public DateTime? FakturaDataWystawienia
        {
            get
            {
                return _FakturaDataWystawienia;
            }
            set
            {
                if (_FakturaDataWystawienia != value)
                {
                    _FakturaDataWystawienia = value;
                    OnPropertyChanged(() => FakturaDataWystawienia);
                }
            }
        }

        private string _FakturaKontrahent;
        public string FakturaKontrahent
        {
            get
            {
                return _FakturaKontrahent;
            }
            set
            {
                if (_FakturaKontrahent != value)
                {
                    _FakturaKontrahent = value;
                    OnPropertyChanged(() => FakturaKontrahent);
                }
            }
        }

        #endregion
        #region Helpers

        private void RecalculateAmounts()
        {
            KwotaNetto = Ilosc * CenaJednostkowaNetto;
            KwotaVAT = KwotaNetto * (StawkaVAT / 100);
            KwotaBrutto = KwotaNetto + KwotaVAT;
        }

        public override void Save()
        {
            item.CzyAktywny = true;
            item.KiedyDodal = DateTime.Now;
            item.KtoDodal = _currentUser?.Username ?? "System Admin";
            item.WersjaDanych = 1;

            medicalEntities.PozycjaFaktury.Add(item);
            medicalEntities.SaveChanges();
        }

        private void getWybranaFaktura(FakturaForAllView faktura)
        {
            if (faktura != null)
            {
                IdFaktury = faktura.IdFaktury;
                FakturaNumer = faktura.Numer;
                FakturaDataWystawienia = faktura.DataWystawienia;
                FakturaKontrahent = faktura.NazwaFirmy;
            }
        }

        #endregion
    }
}
