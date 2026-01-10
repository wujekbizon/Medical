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
    public class NowaOceanZespoluViewModel : JedenViewModel<OcenaZespolu>
    {
        #region Konstruktor
        private readonly UserForAllView _currentUser;

        public NowaOceanZespoluViewModel(UserForAllView currentUser)
            : base()
        {
            base.DisplayName = "Ocena Zespołu";
            item = new OcenaZespolu();
            _currentUser = currentUser;

            DataOceny = DateTime.Now;
            CzyOtrzymanoFeedbackOdPacjenta = false;

            Messenger.Default.Register<ZespolRatunkowyForAllView>(this, getWybranyZespol);
            Messenger.Default.Register<PracownikForAllView>(this, getWybranyPracownik);
            Messenger.Default.Register<ZleceniaWyjazduForAllView>(this, getWybranyWyjazd);
        }
        #endregion

        #region Komendy

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

        #endregion
        #region Właściwości

        public int Ocena
        {
            get
            {
                return item.Ocena;
            }
            set
            {
                if (item.Ocena != value)
                {
                    item.Ocena = value;
                    OnPropertyChanged(() => Ocena);
                }
            }
        }

        public DateTime DataOceny
        {
            get
            {
                return item.DataOceny;
            }
            set
            {
                if (item.DataOceny != value)
                {
                    item.DataOceny = value;
                    OnPropertyChanged(() => DataOceny);
                }
            }
        }

        public string Komentarz
        {
            get
            {
                return item.Komentarz;
            }
            set
            {
                if (item.Komentarz != value)
                {
                    item.Komentarz = value;
                    OnPropertyChanged(() => Komentarz);
                }
            }
        }

        public string KryteriumOceny
        {
            get
            {
                return item.KryteriumOceny;
            }
            set
            {
                if (item.KryteriumOceny != value)
                {
                    item.KryteriumOceny = value;
                    OnPropertyChanged(() => KryteriumOceny);
                }
            }
        }

        public int? WagaOceny
        {
            get
            {
                return item.WagaOceny;
            }
            set
            {
                if (item.WagaOceny != value)
                {
                    item.WagaOceny = value;
                    OnPropertyChanged(() => WagaOceny);
                }
            }
        }

        public int? OcenaCzasuReakcji
        {
            get
            {
                return item.OcenaCzasuReakcji;
            }
            set
            {
                if (item.OcenaCzasuReakcji != value)
                {
                    item.OcenaCzasuReakcji = value;
                    OnPropertyChanged(() => OcenaCzasuReakcji);
                }
            }
        }

        public int? OcenaProfesjonalizmu
        {
            get
            {
                return item.OcenaProfesjonalizmu;
            }
            set
            {
                if (item.OcenaProfesjonalizmu != value)
                {
                    item.OcenaProfesjonalizmu = value;
                    OnPropertyChanged(() => OcenaProfesjonalizmu);
                }
            }
        }

        public int? OcenaSkutecznosci
        {
            get
            {
                return item.OcenaSkutecznosci;
            }
            set
            {
                if (item.OcenaSkutecznosci != value)
                {
                    item.OcenaSkutecznosci = value;
                    OnPropertyChanged(() => OcenaSkutecznosci);
                }
            }
        }

        public bool CzyOtrzymanoFeedbackOdPacjenta
        {
            get
            {
                return item.CzyOtrzymanoFeedbackOdPacjenta ?? false;
            }
            set
            {
                if (item.CzyOtrzymanoFeedbackOdPacjenta != value)
                {
                    item.CzyOtrzymanoFeedbackOdPacjenta = value;
                    OnPropertyChanged(() => CzyOtrzymanoFeedbackOdPacjenta);
                }
            }
        }

        public string SugerowaneUlepszenia
        {
            get
            {
                return item.SugerowaneUlepszenia;
            }
            set
            {
                if (item.SugerowaneUlepszenia != value)
                {
                    item.SugerowaneUlepszenia = value;
                    OnPropertyChanged(() => SugerowaneUlepszenia);
                }
            }
        }

        public int? OcenaStosowaniaStandardow
        {
            get
            {
                return item.OcenaStosowaniaStandardow;
            }
            set
            {
                if (item.OcenaStosowaniaStandardow != value)
                {
                    item.OcenaStosowaniaStandardow = value;
                    OnPropertyChanged(() => OcenaStosowaniaStandardow);
                }
            }
        }

        public int IdZespolu
        {
            get
            {
                return item.IdZespolu;
            }
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
            get
            {
                return _ZespolNazwa;
            }
            set
            {
                if (_ZespolNazwa != value)
                {
                    _ZespolNazwa = value;
                    OnPropertyChanged(() => ZespolNazwa);
                }
            }
        }

        private string _ZespolSpecjalizacja;
        public string ZespolSpecjalizacja
        {
            get
            {
                return _ZespolSpecjalizacja;
            }
            set
            {
                if (_ZespolSpecjalizacja != value)
                {
                    _ZespolSpecjalizacja = value;
                    OnPropertyChanged(() => ZespolSpecjalizacja);
                }
            }
        }

        private int? _ZespolLiczbaCzlonkow;
        public int? ZespolLiczbaCzlonkow
        {
            get
            {
                return _ZespolLiczbaCzlonkow;
            }
            set
            {
                if (_ZespolLiczbaCzlonkow != value)
                {
                    _ZespolLiczbaCzlonkow = value;
                    OnPropertyChanged(() => ZespolLiczbaCzlonkow);
                }
            }
        }

        public int IdOceniajacego
        {
            get
            {
                return item.IdOceniajacego;
            }
            set
            {
                if (item.IdOceniajacego != value)
                {
                    item.IdOceniajacego = value;
                    OnPropertyChanged(() => IdOceniajacego);
                }
            }
        }

        private string _OceniajacyImie;
        public string OceniajacyImie
        {
            get
            {
                return _OceniajacyImie;
            }
            set
            {
                if (_OceniajacyImie != value)
                {
                    _OceniajacyImie = value;
                    OnPropertyChanged(() => OceniajacyImie);
                }
            }
        }

        private string _OceniajacyNazwisko;
        public string OceniajacyNazwisko
        {
            get
            {
                return _OceniajacyNazwisko;
            }
            set
            {
                if (_OceniajacyNazwisko != value)
                {
                    _OceniajacyNazwisko = value;
                    OnPropertyChanged(() => OceniajacyNazwisko);
                }
            }
        }

        private string _OceniajacyRola;
        public string OceniajacyRola
        {
            get
            {
                return _OceniajacyRola;
            }
            set
            {
                if (_OceniajacyRola != value)
                {
                    _OceniajacyRola = value;
                    OnPropertyChanged(() => OceniajacyRola);
                }
            }
        }
        public int IdWyjazdu
        {
            get
            {
                return item.IdWyjazdu;
            }
            set
            {
                if (item.IdWyjazdu != value)
                {
                    item.IdWyjazdu = value;
                    OnPropertyChanged(() => IdWyjazdu);
                }
            }
        }

        private DateTime? _WyjazdDataZgloszenia;
        public DateTime? WyjazdDataZgloszenia
        {
            get
            {
                return _WyjazdDataZgloszenia;
            }
            set
            {
                if (_WyjazdDataZgloszenia != value)
                {
                    _WyjazdDataZgloszenia = value;
                    OnPropertyChanged(() => WyjazdDataZgloszenia);
                }
            }
        }

        private string _WyjazdAdres;
        public string WyjazdAdres
        {
            get
            {
                return _WyjazdAdres;
            }
            set
            {
                if (_WyjazdAdres != value)
                {
                    _WyjazdAdres = value;
                    OnPropertyChanged(() => WyjazdAdres);
                }
            }
        }

        private string _WyjazdTypZdarzenia;
        public string WyjazdTypZdarzenia
        {
            get
            {
                return _WyjazdTypZdarzenia;
            }
            set
            {
                if (_WyjazdTypZdarzenia != value)
                {
                    _WyjazdTypZdarzenia = value;
                    OnPropertyChanged(() => WyjazdTypZdarzenia);
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
    
            medicalEntities.OcenaZespolu.Add(item);
            medicalEntities.SaveChanges();
        }

        private void getWybranyZespol(ZespolRatunkowyForAllView zespol)
        {
            if (zespol != null)
            {
                IdZespolu = zespol.IdZespolu;
                ZespolNazwa = zespol.NazwaZespolu;
                ZespolSpecjalizacja = zespol.Specjalizacja;
                ZespolLiczbaCzlonkow = zespol.LiczbaCzlonkow;
            }
        }

        private void getWybranyPracownik(PracownikForAllView pracownik)
        {
            if (pracownik != null)
            {
                IdOceniajacego = pracownik.IdPracownika;
                OceniajacyImie = pracownik.Imie;
                OceniajacyNazwisko = pracownik.Nazwisko;
                OceniajacyRola = pracownik.NazwaRoli;
            }
        }

        private void getWybranyWyjazd(ZleceniaWyjazduForAllView wyjazd)
        {
            if (wyjazd != null)
            {
                IdWyjazdu = wyjazd.IdWyjazdu;
                WyjazdDataZgloszenia = wyjazd.DataCzasZgloszenia;
                WyjazdAdres = wyjazd.AdresZdarzenia;
                WyjazdTypZdarzenia = wyjazd.TypZdarzenia;
            }
        }

        #endregion

    }
}
