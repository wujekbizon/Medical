using GalaSoft.MvvmLight.Messaging;
using Medical.Helper;
using Medical.Models;
using Medical.Models.EntitiesForView;
using Medical.ViewModels.Abstract;
using System;
using System.Windows.Input;

namespace Medical.ViewModels
{
    public class NowyZespolRatunkowyViewModel : JedenViewModel<ZespolRatunkowy>
    {
        #region Pola
        private readonly UserForAllView _currentUser;
        #endregion
        #region Konstruktor

        public NowyZespolRatunkowyViewModel(UserForAllView currentUser)
            : base()
        {
            base.DisplayName = "Zespół Ratunkowy";
            item = new ZespolRatunkowy();
            _currentUser = currentUser;

            DataUtworzenia = DateTime.Now;
            StatusZespolu = "Aktywny";
            LiczbaCzlonkow = 0;

            Messenger.Default.Register<KaretkaForAllView>(this, getWybranaKaretka);
            Messenger.Default.Register<PlacowkaForAllView>(this, getWybranaPlacowka);
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

        private BaseCommand _ShowPlacowki;
        public ICommand ShowPlacowki
        {
            get
            {
                if (_ShowPlacowki == null)
                {
                    _ShowPlacowki = new BaseCommand(() =>
                    {
                        Messenger.Default.Send("PlacowkiShow");
                    });
                }
                return _ShowPlacowki;
            }
        }

        #endregion

        #region Właściwości

        public string NazwaZespolu
        {
            get { return item.NazwaZespolu; }
            set
            {
                if (item.NazwaZespolu != value)
                {
                    item.NazwaZespolu = value;
                    OnPropertyChanged(() => NazwaZespolu);
                }
            }
        }

        public int LiczbaCzlonkow
        {
            get { return item.LiczbaCzlonkow; }
            set
            {
                if (item.LiczbaCzlonkow != value)
                {
                    item.LiczbaCzlonkow = value;
                    OnPropertyChanged(() => LiczbaCzlonkow);
                }
            }
        }

        public string Specjalizacja
        {
            get { return item.Specjalizacja; }
            set
            {
                if (item.Specjalizacja != value)
                {
                    item.Specjalizacja = value;
                    OnPropertyChanged(() => Specjalizacja);
                }
            }
        }

        public DateTime DataUtworzenia
        {
            get { return item.DataUtworzenia; }
            set
            {
                if (item.DataUtworzenia != value)
                {
                    item.DataUtworzenia = value;
                    OnPropertyChanged(() => DataUtworzenia);
                }
            }
        }

        public string StatusZespolu
        {
            get { return item.StatusZespolu; }
            set
            {
                if (item.StatusZespolu != value)
                {
                    item.StatusZespolu = value;
                    OnPropertyChanged(() => StatusZespolu);
                }
            }
        }

        public string TelefonKontaktowy
        {
            get { return item.TelefonKontaktowy; }
            set
            {
                if (item.TelefonKontaktowy != value)
                {
                    item.TelefonKontaktowy = value;
                    OnPropertyChanged(() => TelefonKontaktowy);
                }
            }
        }

        public string Zmiana
        {
            get { return item.Zmiana; }
            set
            {
                if (item.Zmiana != value)
                {
                    item.Zmiana = value;
                    OnPropertyChanged(() => Zmiana);
                }
            }
        }

        public DateTime? DataOstatniegoSzkolenia
        {
            get { return item.DataOstatniegoSzkolenia; }
            set
            {
                if (item.DataOstatniegoSzkolenia != value)
                {
                    item.DataOstatniegoSzkolenia = value;
                    OnPropertyChanged(() => DataOstatniegoSzkolenia);
                }
            }
        }

        public decimal? SredniaOcena
        {
            get { return item.SredniaOcena; }
            set
            {
                if (item.SredniaOcena != value)
                {
                    item.SredniaOcena = value;
                    OnPropertyChanged(() => SredniaOcena);
                }
            }
        }

        public DateTime? DataOstatniegoWyjazdu
        {
            get { return item.DataOstatniegoWyjazdu; }
            set
            {
                if (item.DataOstatniegoWyjazdu != value)
                {
                    item.DataOstatniegoWyjazdu = value;
                    OnPropertyChanged(() => DataOstatniegoWyjazdu);
                }
            }
        }

        public int? LiczbaWszystkichWyjazdow
        {
            get { return item.LiczbaWszystkichWyjazdow; }
            set
            {
                if (item.LiczbaWszystkichWyjazdow != value)
                {
                    item.LiczbaWszystkichWyjazdow = value;
                    OnPropertyChanged(() => LiczbaWszystkichWyjazdow);
                }
            }
        }

        public string Certyfikaty
        {
            get { return item.Certyfikaty; }
            set
            {
                if (item.Certyfikaty != value)
                {
                    item.Certyfikaty = value;
                    OnPropertyChanged(() => Certyfikaty);
                }
            }
        }

        public int? IdKaretki
        {
            get { return item.IdKaretki; }
            set
            {
                if (item.IdKaretki != value)
                {
                    item.IdKaretki = value;
                    OnPropertyChanged(() => IdKaretki);
                }
            }
        }

        private string _KaretkaNumer;
        public string KaretkaNumer
        {
            get { return _KaretkaNumer; }
            set
            {
                if (_KaretkaNumer != value)
                {
                    _KaretkaNumer = value;
                    OnPropertyChanged(() => KaretkaNumer);
                }
            }
        }

        private string _KaretkaTyp;
        public string KaretkaTyp
        {
            get { return _KaretkaTyp; }
            set
            {
                if (_KaretkaTyp != value)
                {
                    _KaretkaTyp = value;
                    OnPropertyChanged(() => KaretkaTyp);
                }
            }
        }

        public int IdPlacowki
        {
            get { return item.IdPlacowki; }
            set
            {
                if (item.IdPlacowki != value)
                {
                    item.IdPlacowki = value;
                    OnPropertyChanged(() => IdPlacowki);
                }
            }
        }

        private string _PlacowkaNazwa;
        public string PlacowkaNazwa
        {
            get { return _PlacowkaNazwa; }
            set
            {
                if (_PlacowkaNazwa != value)
                {
                    _PlacowkaNazwa = value;
                    OnPropertyChanged(() => PlacowkaNazwa);
                }
            }
        }

        private string _PlacowkaMiasto;
        public string PlacowkaMiasto
        {
            get { return _PlacowkaMiasto; }
            set
            {
                if (_PlacowkaMiasto != value)
                {
                    _PlacowkaMiasto = value;
                    OnPropertyChanged(() => PlacowkaMiasto);
                }
            }
        }

        #endregion

        #region Helpers

        public override void Save()
        {
            item.CzyAktywny = true;
            item.KiedyDodal = DateTime.Now;
            item.KtoDodal = _currentUser?.Username ?? "System Admin";
            item.WersjaDanych = 1;

            medicalEntities.ZespolRatunkowy.Add(item);
            medicalEntities.SaveChanges();
        }

        private void getWybranaKaretka(KaretkaForAllView karetka)
        {
            if (karetka != null)
            {
                IdKaretki = karetka.IdKaretki;
                KaretkaNumer = karetka.NumerRejestracyjny;
                KaretkaTyp = karetka.TypKaretki;
            }
        }

        private void getWybranaPlacowka(PlacowkaForAllView placowka)
        {
            if (placowka != null)
            {
                IdPlacowki = placowka.IdPlacowki;
                PlacowkaNazwa = placowka.NazwaPlacowki;
                PlacowkaMiasto = placowka.Miasto;
            }
        }

        #endregion
    }
}
