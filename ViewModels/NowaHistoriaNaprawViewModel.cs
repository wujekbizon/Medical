using GalaSoft.MvvmLight.Messaging;
using Medical.Helper;
using Medical.Models;
using Medical.Models.EntitiesForView;
using Medical.ViewModels.Abstract;
using System;
using System.Linq;
using System.Windows.Input;

namespace Medical.ViewModels
{
    public class NowaHistoriaNaprawViewModel : JedenViewModel<HistoriaNapraw>
    {
        #region Pola
        private readonly UserForAllView _currentUser;
        #endregion

        #region Konstruktor
        public NowaHistoriaNaprawViewModel(UserForAllView currentUser)
             : base()
        {
            base.DisplayName = "Historia Napraw";
            item = new HistoriaNapraw();
            _currentUser = currentUser;

            DataRozpoczecia = DateTime.Now;

            Messenger.Default.Register<KaretkaForAllView>(this, getWybranaKaretka);
            Messenger.Default.Register<FakturaForAllView>(this, getWybranaFaktura);
            Messenger.Default.Register<KontrahentForAllView>(this, getWybranyKontrahent);
        }
        #endregion

        #region Komendy

        private BaseCommand _ShowKaretki;
        public ICommand ShowKaretki
        {
            get
            {
                if (_ShowKaretki == null)
                {
                    _ShowKaretki = new BaseCommand(() =>
                    {
                        Messenger.Default.Send("KaretkiShow");
                    });
                }
                return _ShowKaretki;
            }
        }

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

        private BaseCommand _ShowKontrahenci;
        public ICommand ShowKontrahenci
        {
            get
            {
                if (_ShowKontrahenci == null)
                {
                    _ShowKontrahenci = new BaseCommand(() =>
                    {
                        Messenger.Default.Send("KontrahenciShow");
                    });
                }
                return _ShowKontrahenci;
            }
        }

        #endregion

        #region Właściwości

        public string RodzajNaprawy
        {
            get
            {
                return item.RodzajNaprawy;
            }
            set
            {
                if (item.RodzajNaprawy != value)
                {
                    item.RodzajNaprawy = value;
                    OnPropertyChanged(() => RodzajNaprawy);
                }
            }
        }

        public string OpisNaprawy
        {
            get
            {
                return item.OpisNaprawy;
            }
            set
            {
                if (item.OpisNaprawy != value)
                {
                    item.OpisNaprawy = value;
                    OnPropertyChanged(() => OpisNaprawy);
                }
            }
        }

        public DateTime DataRozpoczecia
        {
            get
            {
                return item.DataRozpoczecia;
            }
            set
            {
                if (item.DataRozpoczecia != value)
                {
                    item.DataRozpoczecia = value;
                    OnPropertyChanged(() => DataRozpoczecia);
                }
            }
        }

        public DateTime? DataZakonczenia
        {
            get
            {
                return item.DataZakonczenia;
            }
            set
            {
                if (item.DataZakonczenia != value)
                {
                    item.DataZakonczenia = value;
                    OnPropertyChanged(() => DataZakonczenia);
                }
            }
        }

        public decimal KosztNaprawy
        {
            get
            {
                return item.KosztNaprawy;
            }
            set
            {
                if (item.KosztNaprawy != value)
                {
                    item.KosztNaprawy = value;
                    OnPropertyChanged(() => KosztNaprawy);
                }
            }
        }

        public decimal? CzasTrwaniaNaprawy
        {
            get
            {
                return item.CzasTrwaniaNaprawy;
            }
            set
            {
                if (item.CzasTrwaniaNaprawy != value)
                {
                    item.CzasTrwaniaNaprawy = value;
                    OnPropertyChanged(() => CzasTrwaniaNaprawy);
                }
            }
        }

        public int? GwarancjaMiesiecy
        {
            get
            {
                return item.GwarancjaMiesiecy;
            }
            set
            {
                if (item.GwarancjaMiesiecy != value)
                {
                    item.GwarancjaMiesiecy = value;
                    OnPropertyChanged(() => GwarancjaMiesiecy);
                }
            }
        }

        public string StanKaretkiPrzedNaprawa
        {
            get
            {
                return item.StanKaretkiPrzedNaprawa;
            }
            set
            {
                if (item.StanKaretkiPrzedNaprawa != value)
                {
                    item.StanKaretkiPrzedNaprawa = value;
                    OnPropertyChanged(() => StanKaretkiPrzedNaprawa);
                }
            }
        }

        public string StanKaretkiPoNaprawie
        {
            get
            {
                return item.StanKaretkiPoNaprawie;
            }
            set
            {
                if (item.StanKaretkiPoNaprawie != value)
                {
                    item.StanKaretkiPoNaprawie = value;
                    OnPropertyChanged(() => StanKaretkiPoNaprawie);
                }
            }
        }

        public int IdKaretki
        {
            get
            {
                return item.IdKaretki;
            }
            set
            {
                if (item.IdKaretki != value)
                {
                    item.IdKaretki = value;
                    OnPropertyChanged(() => IdKaretki);
                }
            }
        }

        private string _KaretkaNumerRejestracyjny;
        public string KaretkaNumerRejestracyjny
        {
            get
            {
                return _KaretkaNumerRejestracyjny;
            }
            set
            {
                if (_KaretkaNumerRejestracyjny != value)
                {
                    _KaretkaNumerRejestracyjny = value;
                    OnPropertyChanged(() => KaretkaNumerRejestracyjny);
                }
            }
        }

        private string _KaretkaTyp;
        public string KaretkaTyp
        {
            get
            {
                return _KaretkaTyp;
            }
            set
            {
                if (_KaretkaTyp != value)
                {
                    _KaretkaTyp = value;
                    OnPropertyChanged(() => KaretkaTyp);
                }
            }
        }

        private string _KaretkaStatus;
        public string KaretkaStatus
        {
            get
            {
                return _KaretkaStatus;
            }
            set
            {
                if (_KaretkaStatus != value)
                {
                    _KaretkaStatus = value;
                    OnPropertyChanged(() => KaretkaStatus);
                }
            }
        }
        public int? IdFaktury
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

        private string _FakturaKategoriaKosztu;
        public string FakturaKategoriaKosztu
        {
            get
            {
                return _FakturaKategoriaKosztu;
            }
            set
            {
                if (_FakturaKategoriaKosztu != value)
                {
                    _FakturaKategoriaKosztu = value;
                    OnPropertyChanged(() => FakturaKategoriaKosztu);
                }
            }
        }

        public int? IdKontrahenta
        {
            get
            {
                return item.IdKontrahenta;
            }
            set
            {
                if (item.IdKontrahenta != value)
                {
                    item.IdKontrahenta = value;
                    OnPropertyChanged(() => IdKontrahenta);
                }
            }
        }

        private string _KontrahentNazwa;
        public string KontrahentNazwa
        {
            get
            {
                return _KontrahentNazwa;
            }
            set
            {
                if (_KontrahentNazwa != value)
                {
                    _KontrahentNazwa = value;
                    OnPropertyChanged(() => KontrahentNazwa);
                }
            }
        }

        private string _KontrahentNIP;
        public string KontrahentNIP
        {
            get
            {
                return _KontrahentNIP;
            }
            set
            {
                if (_KontrahentNIP != value)
                {
                    _KontrahentNIP = value;
                    OnPropertyChanged(() => KontrahentNIP);
                }
            }
        }

        private string _KontrahentAdres;
        public string KontrahentAdres
        {
            get
            {
                return _KontrahentAdres;
            }
            set
            {
                if (_KontrahentAdres != value)
                {
                    _KontrahentAdres = value;
                    OnPropertyChanged(() => KontrahentAdres);
                }
            }
        }
        #endregion
        #region Helpers

        public override void Save()
        {
            item.CzyAktywny = true;
            item.CzyZatwierdzona = true;
            item.KiedyDodal = DateTime.Now;
            item.KtoDodal = _currentUser.Name + " " + _currentUser.LastName ?? "System Admin";
            item.WersjaDanych = 1;

            medicalEntities.HistoriaNapraw.Add(item);
            medicalEntities.SaveChanges();
        }

        private void getWybranaKaretka(KaretkaForAllView karetka)
        {
            if (karetka != null)
            {
                IdKaretki = karetka.IdKaretki;
                KaretkaNumerRejestracyjny = karetka.NumerRejestracyjny;
                KaretkaTyp = karetka.TypKaretki;
                KaretkaStatus = karetka.Status;
            }
        }

        private void getWybranaFaktura(FakturaForAllView faktura)
        {
            if (faktura != null)
            {
                IdFaktury = faktura.IdFaktury;
                FakturaNumer = faktura.Numer;
                FakturaDataWystawienia = faktura.DataWystawienia;
                FakturaKategoriaKosztu = faktura.KategoriaKosztu;
            }
        }

        // Receiver method for Kontrahent selection
        private void getWybranyKontrahent(KontrahentForAllView kontrahent)
        {
            if (kontrahent != null)
            {
                IdKontrahenta = kontrahent.IdKontrahenta;
                KontrahentNazwa = kontrahent.Nazwa;
                KontrahentNIP = kontrahent.NIP;
                KontrahentAdres = kontrahent.Adres;
            }
        }

        #endregion
    }
}
