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
    public class NowyZespolPracownikViewModel : JedenViewModel<ZespolPracownik>
    {
        #region Pola
        private readonly UserForAllView _currentUser;
        #endregion
        #region Konstruktor

        public NowyZespolPracownikViewModel(UserForAllView currentUser)
            : base()
        {
            base.DisplayName = "Zespół-Pracownik";
            item = new ZespolPracownik();
            _currentUser = currentUser;

            DataDolaczenia = DateTime.Now;
            DataPrzypisania = DateTime.Now;

            Messenger.Default.Register<ZespolRatunkowyForAllView>(this, getWybranyZespol);
            Messenger.Default.Register<PracownikForAllView>(this, getWybranyPracownik);
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

        #endregion
        #region Właściwości


        public string RolaWZespole
        {
            get { return item.RolaWZespole; }
            set
            {
                if (item.RolaWZespole != value)
                {
                    item.RolaWZespole = value;
                    OnPropertyChanged(() => RolaWZespole);
                }
            }
        }

        public DateTime DataDolaczenia
        {
            get { return item.DataDolaczenia; }
            set
            {
                if (item.DataDolaczenia != value)
                {
                    item.DataDolaczenia = value;
                    OnPropertyChanged(() => DataDolaczenia);
                }
            }
        }

        public DateTime? DataOpuszczenia
        {
            get { return item.DataOpuszczenia; }
            set
            {
                if (item.DataOpuszczenia != value)
                {
                    item.DataOpuszczenia = value;
                    OnPropertyChanged(() => DataOpuszczenia);
                }
            }
        }

        public string PowodZmiany
        {
            get { return item.PowodZmiany; }
            set
            {
                if (item.PowodZmiany != value)
                {
                    item.PowodZmiany = value;
                    OnPropertyChanged(() => PowodZmiany);
                }
            }
        }

        public DateTime DataPrzypisania
        {
            get { return item.DataPrzypisania; }
            set
            {
                if (item.DataPrzypisania != value)
                {
                    item.DataPrzypisania = value;
                    OnPropertyChanged(() => DataPrzypisania);
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

        private string _ZespolSpecjalizacja;
        public string ZespolSpecjalizacja
        {
            get { return _ZespolSpecjalizacja; }
            set
            {
                if (_ZespolSpecjalizacja != value)
                {
                    _ZespolSpecjalizacja = value;
                    OnPropertyChanged(() => ZespolSpecjalizacja);
                }
            }
        }

 
        public int IdPracownika
        {
            get { return item.IdPracownika; }
            set
            {
                if (item.IdPracownika != value)
                {
                    item.IdPracownika = value;
                    OnPropertyChanged(() => IdPracownika);
                }
            }
        }

        private string _PracownikImie;
        public string PracownikImie
        {
            get { return _PracownikImie; }
            set
            {
                if (_PracownikImie != value)
                {
                    _PracownikImie = value;
                    OnPropertyChanged(() => PracownikImie);
                }
            }
        }

        private string _PracownikNazwisko;
        public string PracownikNazwisko
        {
            get { return _PracownikNazwisko; }
            set
            {
                if (_PracownikNazwisko != value)
                {
                    _PracownikNazwisko = value;
                    OnPropertyChanged(() => PracownikNazwisko);
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

            medicalEntities.ZespolPracownik.Add(item);
            medicalEntities.SaveChanges();
        }

        private void getWybranyZespol(ZespolRatunkowyForAllView zespol)
        {
            if (zespol != null)
            {
                IdZespolu = zespol.IdZespolu;
                ZespolNazwa = zespol.NazwaZespolu;
                ZespolSpecjalizacja = zespol.Specjalizacja;
            }
        }

        private void getWybranyPracownik(PracownikForAllView pracownik)
        {
            if (pracownik != null)
            {
                IdPracownika = pracownik.IdPracownika;
                PracownikImie = pracownik.Imie;
                PracownikNazwisko = pracownik.Nazwisko;
            }
        }

        #endregion
    }
}
