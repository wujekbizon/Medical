using GalaSoft.MvvmLight.Messaging;
using Medical.Helper;
using Medical.Models;
using Medical.Models.EntitiesForView;
using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Medical.ViewModels
{
    public class NoweZlecenieWyjazduViewModel : JedenViewModel<ZlecenieWyjazdu>
    {
        #region Pola
        private readonly UserForAllView _currentUser;
        #endregion

        #region Konstruktor
        public NoweZlecenieWyjazduViewModel(UserForAllView currentUser)
            : base()
        {
            base.DisplayName = "Zlecenie Wyjazdu";
            item = new ZlecenieWyjazdu();
            _currentUser = currentUser;

            DataCzasZgloszenia = DateTime.Now;
            StatusZlecenia = "Nowe";

            Messenger.Default.Register<PracownikForAllView>(this, getWybranyDyspozytor);
            Messenger.Default.Register<ZespolRatunkowyForAllView>(this, getWybranyZespol);
            Messenger.Default.Register<KaretkaForAllView>(this, getWybranaKaretka);
        }
        #endregion
        #region Komendy

        private BaseCommand _ShowPracownicy;
        public ICommand ShowPracownicy
        {
            get
            {
                if (_ShowPracownicy == null)
                {
                    _ShowPracownicy = new BaseCommand(() =>
                    {
                        Messenger.Default.Send("PracownicyShow");
                    });
                }
                return _ShowPracownicy;
            }
        }

        private BaseCommand _ShowZespoly;
        public ICommand ShowZespoly
        {
            get
            {
                if (_ShowZespoly == null)
                {
                    _ShowZespoly = new BaseCommand(() =>
                    {
                        Messenger.Default.Send("ZespolyRatunkoweShow");
                    });
                }
                return _ShowZespoly;
            }
        }

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

        #endregion

        #region Właściwości

        public DateTime DataCzasZgloszenia
        {
            get { return item.DataCzasZgloszenia; }
            set
            {
                if (item.DataCzasZgloszenia != value)
                {
                    item.DataCzasZgloszenia = value;
                    OnPropertyChanged(() => DataCzasZgloszenia);
                    CalculateCzasReakcji();
                }
            }
        }

        public string AdresZdarzenia
        {
            get { return item.AdresZdarzenia; }
            set
            {
                if (item.AdresZdarzenia != value)
                {
                    item.AdresZdarzenia = value;
                    OnPropertyChanged(() => AdresZdarzenia);
                }
            }
        }

        public string TypZdarzenia
        {
            get { return item.TypZdarzenia; }
            set
            {
                if (item.TypZdarzenia != value)
                {
                    item.TypZdarzenia = value;
                    OnPropertyChanged(() => TypZdarzenia);
                }
            }
        }

        public string Priorytet
        {
            get { return item.Priorytet; }
            set
            {
                if (item.Priorytet != value)
                {
                    item.Priorytet = value;
                    OnPropertyChanged(() => Priorytet);
                }
            }
        }

        public string StatusZlecenia
        {
            get { return item.StatusZlecenia; }
            set
            {
                if (item.StatusZlecenia != value)
                {
                    item.StatusZlecenia = value;
                    OnPropertyChanged(() => StatusZlecenia);
                }
            }
        }

        public string OpisZdarzenia
        {
            get { return item.OpisZdarzenia; }
            set
            {
                if (item.OpisZdarzenia != value)
                {
                    item.OpisZdarzenia = value;
                    OnPropertyChanged(() => OpisZdarzenia);
                }
            }
        }

        public DateTime? CzasWyjazdu
        {
            get { return item.CzasWyjazdu; }
            set
            {
                if (item.CzasWyjazdu != value)
                {
                    item.CzasWyjazdu = value;
                    OnPropertyChanged(() => CzasWyjazdu);
                    CalculateCzasReakcji();
                }
            }
        }

        public DateTime? CzasPrzyjazduNaMiejsce
        {
            get { return item.CzasPrzyjazduNaMiejsce; }
            set
            {
                if (item.CzasPrzyjazduNaMiejsce != value)
                {
                    item.CzasPrzyjazduNaMiejsce = value;
                    OnPropertyChanged(() => CzasPrzyjazduNaMiejsce);
                }
            }
        }

        public DateTime? CzasPowrotuDoBazy
        {
            get { return item.CzasPowrotuDoBazy; }
            set
            {
                if (item.CzasPowrotuDoBazy != value)
                {
                    item.CzasPowrotuDoBazy = value;
                    OnPropertyChanged(() => CzasPowrotuDoBazy);
                }
            }
        }

        public string TelefonDzwoniacego
        {
            get { return item.TelefonDzwoniacego; }
            set
            {
                if (item.TelefonDzwoniacego != value)
                {
                    item.TelefonDzwoniacego = value;
                    OnPropertyChanged(() => TelefonDzwoniacego);
                }
            }
        }

        public int? CzasReakcjiSekundy
        {
            get { return item.CzasReakcjiSekundy; }
            set
            {
                if (item.CzasReakcjiSekundy != value)
                {
                    item.CzasReakcjiSekundy = value;
                    OnPropertyChanged(() => CzasReakcjiSekundy);
                }
            }
        }

        public decimal? DystansKm
        {
            get { return item.DystansKm; }
            set
            {
                if (item.DystansKm != value)
                {
                    item.DystansKm = value;
                    OnPropertyChanged(() => DystansKm);
                }
            }
        }

        public int? LiczbaPacjentow
        {
            get { return item.LiczbaPacjentow; }
            set
            {
                if (item.LiczbaPacjentow != value)
                {
                    item.LiczbaPacjentow = value;
                    OnPropertyChanged(() => LiczbaPacjentow);
                }
            }
        }

        public string WarunkiPogodowe
        {
            get { return item.WarunkiPogodowe; }
            set
            {
                if (item.WarunkiPogodowe != value)
                {
                    item.WarunkiPogodowe = value;
                    OnPropertyChanged(() => WarunkiPogodowe);
                }
            }
        }

        public string WymaganeDodatkoweWsparcie
        {
            get { return item.WymaganeDodatkoweWsparcie; }
            set
            {
                if (item.WymaganeDodatkoweWsparcie != value)
                {
                    item.WymaganeDodatkoweWsparcie = value;
                    OnPropertyChanged(() => WymaganeDodatkoweWsparcie);
                }
            }
        }

        public int IdDyspozytora
        {
            get { return item.IdDyspozytora; }
            set
            {
                if (item.IdDyspozytora != value)
                {
                    item.IdDyspozytora = value;
                    OnPropertyChanged(() => IdDyspozytora);
                }
            }
        }

        private string _DyspozytorImie;
        public string DyspozytorImie
        {
            get { return _DyspozytorImie; }
            set
            {
                if (_DyspozytorImie != value)
                {
                    _DyspozytorImie = value;
                    OnPropertyChanged(() => DyspozytorImie);
                }
            }
        }

        private string _DyspozytorNazwisko;
        public string DyspozytorNazwisko
        {
            get { return _DyspozytorNazwisko; }
            set
            {
                if (_DyspozytorNazwisko != value)
                {
                    _DyspozytorNazwisko = value;
                    OnPropertyChanged(() => DyspozytorNazwisko);
                }
            }
        }

        public int IdZespolu
        {
            get { return item.IdZespolu; }
            set
            {
                if (item.IdZespolu != value)
                {
                    item.IdZespolu = value;
                    OnPropertyChanged(() => IdZespolu);
                }
            }
        }

        private string _ZespolNazwa;
        public string ZespolNazwa
        {
            get { return _ZespolNazwa; }
            set
            {
                if (_ZespolNazwa != value)
                {
                    _ZespolNazwa = value;
                    OnPropertyChanged(() => ZespolNazwa);
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

        #endregion

        #region Helpers

        private void CalculateCzasReakcji()
        {
            if (item.CzasWyjazdu.HasValue)
            {
                var roznica = item.CzasWyjazdu.Value - item.DataCzasZgloszenia;
                CzasReakcjiSekundy = (int)roznica.TotalSeconds;
            }
        }

        public override void Save()
        {
            item.CzyAktywny = true;
            item.KiedyDodal = DateTime.Now;
            item.KtoDodal = _currentUser?.Username ?? "System Admin";
            item.WersjaDanych = 1;

            medicalEntities.ZlecenieWyjazdu.Add(item);
            medicalEntities.SaveChanges();
        }

        private void getWybranyDyspozytor(PracownikForAllView pracownik)
        {
            if (pracownik != null)
            {
                IdDyspozytora = pracownik.IdPracownika;
                DyspozytorImie = pracownik.Imie;
                DyspozytorNazwisko = pracownik.Nazwisko;
            }
        }

        private void getWybranyZespol(ZespolRatunkowyForAllView zespol)
        {
            if (zespol != null)
            {
                IdZespolu = zespol.IdZespolu;
                ZespolNazwa = zespol.NazwaZespolu;
            }
        }

        private void getWybranaKaretka(KaretkaForAllView karetka)
        {
            if (karetka != null)
            {
                IdKaretki = karetka.IdKaretki;
                KaretkaNumer = karetka.NumerRejestracyjny;
            }
        }

        #endregion
    }
}
