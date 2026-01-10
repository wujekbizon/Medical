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
    public class NowaUdzielonaPomocViewModel : JedenViewModel<UdzielonaPomoc>
    {
        #region Pola
        private readonly UserForAllView _currentUser;
        #endregion
        #region Konstruktor

        public NowaUdzielonaPomocViewModel(UserForAllView currentUser)
            : base()
        {
            base.DisplayName = "Udzielona Pomoc";
            item = new UdzielonaPomoc();
            _currentUser = currentUser;

            DataPomocy = DateTime.Now;
            CzyWymagalTransportu = false;
            CzyBylWymaganyUdziałPolicji = false;

            Messenger.Default.Register<PacjentForAllView>(this, getWybranyPacjent);
            Messenger.Default.Register<ZespolRatunkowyForAllView>(this, getWybranyZespol);
            Messenger.Default.Register<KaretkaForAllView>(this, getWybranaKaretka);
            Messenger.Default.Register<ZleceniaWyjazduForAllView>(this, getWybranyWyjazd);
            Messenger.Default.Register<PracownikForAllView>(this, getWybranyAutor);
        }
        #endregion

        #region Komendy

        private BaseCommand _ShowPacjenci;
        public ICommand ShowPacjenci
        {
            get
            {
                if (_ShowPacjenci == null)
                {
                    _ShowPacjenci = new BaseCommand(() =>
                    {
                        Messenger.Default.Send("PacjenciShow");
                    });
                }
                return _ShowPacjenci;
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

        private BaseCommand _ShowWyjazdy;
        public ICommand ShowWyjazdy
        {
            get
            {
                if (_ShowWyjazdy == null)
                {
                    _ShowWyjazdy = new BaseCommand(() =>
                    {
                        Messenger.Default.Send("ZleceniaWyjazduShow");
                    });
                }
                return _ShowWyjazdy;
            }
        }

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

        #endregion
        #region Właściwości
        public DateTime DataPomocy
        {
            get { return item.DataPomocy; }
            set
            {
                if (item.DataPomocy != value)
                {
                    item.DataPomocy = value;
                    OnPropertyChanged(() => DataPomocy);
                }
            }
        }

        public DateTime? CzasRozpoczecia
        {
            get
            {
                return item.CzasRozpoczecia.HasValue
                    ? DateTime.Today.Add(item.CzasRozpoczecia.Value)
                    : (DateTime?)null;
            }
            set
            {
                var newValue = value?.TimeOfDay;
                if (item.CzasRozpoczecia != newValue)
                {
                    item.CzasRozpoczecia = newValue;
                    OnPropertyChanged(() => CzasRozpoczecia);
                    CalculateCzasTrwania();
                }
            }
        }

        public DateTime? CzasZakonczenia
        {
            get
            {
                return item.CzasZakonczenia.HasValue
                    ? DateTime.Today.Add(item.CzasZakonczenia.Value)
                    : (DateTime?)null;
            }
            set
            {
                var newValue = value?.TimeOfDay;
                if (item.CzasZakonczenia != newValue)
                {
                    item.CzasZakonczenia = newValue;
                    OnPropertyChanged(() => CzasZakonczenia);
                    CalculateCzasTrwania();
                }
            }
        }

        public string OpisPomocy
        {
            get { return item.OpisPomocy; }
            set
            {
                if (item.OpisPomocy != value)
                {
                    item.OpisPomocy = value;
                    OnPropertyChanged(() => OpisPomocy);
                }
            }
        }

        public string ProceduryMedyczne
        {
            get { return item.ProceduryMedyczne; }
            set
            {
                if (item.ProceduryMedyczne != value)
                {
                    item.ProceduryMedyczne = value;
                    OnPropertyChanged(() => ProceduryMedyczne);
                }
            }
        }

        public string WynikInterwencji
        {
            get { return item.WynikInterwencji; }
            set
            {
                if (item.WynikInterwencji != value)
                {
                    item.WynikInterwencji = value;
                    OnPropertyChanged(() => WynikInterwencji);
                }
            }
        }

        public int CzasTrwaniaMinuty
        {
            get { return item.CzasTrwaniaMinuty; }
            set
            {
                if (item.CzasTrwaniaMinuty != value)
                {
                    item.CzasTrwaniaMinuty = value;
                    OnPropertyChanged(() => CzasTrwaniaMinuty);
                }
            }
        }

        public string LokalizacjaInterwencji
        {
            get { return item.LokalizacjaInterwencji; }
            set
            {
                if (item.LokalizacjaInterwencji != value)
                {
                    item.LokalizacjaInterwencji = value;
                    OnPropertyChanged(() => LokalizacjaInterwencji);
                }
            }
        }

        public string WymaganySprzet
        {
            get { return item.WymaganySprzet; }
            set
            {
                if (item.WymaganySprzet != value)
                {
                    item.WymaganySprzet = value;
                    OnPropertyChanged(() => WymaganySprzet);
                }
            }
        }

        public bool CzyWymagalTransportu
        {
            get { return item.CzyWymagalTransportu ?? false; }
            set
            {
                if (item.CzyWymagalTransportu != value)
                {
                    item.CzyWymagalTransportu = value;
                    OnPropertyChanged(() => CzyWymagalTransportu);
                }
            }
        }

        public string PriorytetInterwencji
        {
            get { return item.PriorytetInterwencji; }
            set
            {
                if (item.PriorytetInterwencji != value)
                {
                    item.PriorytetInterwencji = value;
                    OnPropertyChanged(() => PriorytetInterwencji);
                }
            }
        }

        public string KodDiagnozyICD10
        {
            get { return item.KodDiagnozyICD10; }
            set
            {
                if (item.KodDiagnozyICD10 != value)
                {
                    item.KodDiagnozyICD10 = value;
                    OnPropertyChanged(() => KodDiagnozyICD10);
                }
            }
        }

        public string SzpitalTransportu
        {
            get { return item.SzpitalTransportu; }
            set
            {
                if (item.SzpitalTransportu != value)
                {
                    item.SzpitalTransportu = value;
                    OnPropertyChanged(() => SzpitalTransportu);
                }
            }
        }

        public string StanPacjentaPrzyPrzekazaniu
        {
            get { return item.StanPacjentaPrzyPrzekazaniu; }
            set
            {
                if (item.StanPacjentaPrzyPrzekazaniu != value)
                {
                    item.StanPacjentaPrzyPrzekazaniu = value;
                    OnPropertyChanged(() => StanPacjentaPrzyPrzekazaniu);
                }
            }
        }

        public bool CzyBylWymaganyUdziałPolicji
        {
            get { return item.CzyBylWymaganyUdziałPolicji ?? false; }
            set
            {
                if (item.CzyBylWymaganyUdziałPolicji != value)
                {
                    item.CzyBylWymaganyUdziałPolicji = value;
                    OnPropertyChanged(() => CzyBylWymaganyUdziałPolicji);
                }
            }
        }
        public int IdPacjenta
        {
            get { return item.IdPacjenta; }
            set
            {
                if (item.IdPacjenta != value)
                {
                    item.IdPacjenta = value;
                    OnPropertyChanged(() => IdPacjenta);
                }
            }
        }

        private string _PacjentImie;
        public string PacjentImie
        {
            get { return _PacjentImie; }
            set
            {
                if (_PacjentImie != value)
                {
                    _PacjentImie = value;
                    OnPropertyChanged(() => PacjentImie);
                }
            }
        }

        private string _PacjentNazwisko;
        public string PacjentNazwisko
        {
            get { return _PacjentNazwisko; }
            set
            {
                if (_PacjentNazwisko != value)
                {
                    _PacjentNazwisko = value;
                    OnPropertyChanged(() => PacjentNazwisko);
                }
            }
        }

        private string _PacjentPesel;
        public string PacjentPesel
        {
            get { return _PacjentPesel; }
            set
            {
                if (_PacjentPesel != value)
                {
                    _PacjentPesel = value;
                    OnPropertyChanged(() => PacjentPesel);
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

        public int IdWyjazdu
        {
            get { return item.IdWyjazdu; }
            set
            {
                if (item.IdWyjazdu != value)
                {
                    item.IdWyjazdu = value;
                    OnPropertyChanged(() => IdWyjazdu);
                }
            }
        }

        private string _WyjazdAdres;
        public string WyjazdAdres
        {
            get { return _WyjazdAdres; }
            set
            {
                if (_WyjazdAdres != value)
                {
                    _WyjazdAdres = value;
                    OnPropertyChanged(() => WyjazdAdres);
                }
            }
        }

        public int IdAutoraRaportu
        {
            get { return item.IdAutoraRaportu; }
            set
            {
                if (item.IdAutoraRaportu != value)
                {
                    item.IdAutoraRaportu = value;
                    OnPropertyChanged(() => IdAutoraRaportu);
                }
            }
        }

        private string _AutorImie;
        public string AutorImie
        {
            get { return _AutorImie; }
            set
            {
                if (_AutorImie != value)
                {
                    _AutorImie = value;
                    OnPropertyChanged(() => AutorImie);
                }
            }
        }

        private string _AutorNazwisko;
        public string AutorNazwisko
        {
            get { return _AutorNazwisko; }
            set
            {
                if (_AutorNazwisko != value)
                {
                    _AutorNazwisko = value;
                    OnPropertyChanged(() => AutorNazwisko);
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

            medicalEntities.UdzielonaPomoc.Add(item);
            medicalEntities.SaveChanges();
        }

        private void CalculateCzasTrwania()
        {
            if (item.CzasRozpoczecia.HasValue && item.CzasZakonczenia.HasValue)
            {
                var roznica = item.CzasZakonczenia.Value - item.CzasRozpoczecia.Value;
                CzasTrwaniaMinuty = (int)roznica.TotalMinutes;
            }
        }

        private void getWybranyPacjent(PacjentForAllView pacjent)
        {
            if (pacjent != null)
            {
                IdPacjenta = pacjent.IdPacjenta;
                PacjentImie = pacjent.Imie;
                PacjentNazwisko = pacjent.Nazwisko;
                PacjentPesel = pacjent.Pesel;
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

        private void getWybranyWyjazd(ZleceniaWyjazduForAllView wyjazd)
        {
            if (wyjazd != null)
            {
                IdWyjazdu = wyjazd.IdWyjazdu;
                WyjazdAdres = wyjazd.AdresZdarzenia;
            }
        }

        private void getWybranyAutor(PracownikForAllView pracownik)
        {
            if (pracownik != null)
            {
                IdAutoraRaportu = pracownik.IdPracownika;
                AutorImie = pracownik.Imie;
                AutorNazwisko = pracownik.Nazwisko;
            }
        }

        #endregion
    }
}
