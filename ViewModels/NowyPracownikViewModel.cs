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
    public class NowyPracownikViewModel : JedenViewModel<Pracownik>
    {
        #region Pola
        private readonly UserForAllView _currentUser;
        #endregion

        #region Konstruktor

        public NowyPracownikViewModel(UserForAllView currentUser)
            : base()
        {
            base.DisplayName = "Pracownik";
            item = new Pracownik();
            _currentUser = currentUser;

            DataZatrudnienia = DateTime.Now;
            StatusZatrudnienia = "Aktywny";

            Messenger.Default.Register<RolaPracownikaForAllView>(this, getWybranaRola);
            Messenger.Default.Register<PlacowkaForAllView>(this, getWybranaPlacowka);
        }
        #endregion

        #region Komendy

        private BaseCommand _ShowRole;
        public ICommand ShowRole
        {
            get
            {
                if (_ShowRole == null)
                {
                    _ShowRole = new BaseCommand(() =>
                    {
                        Messenger.Default.Send("RoleShow");
                    });
                }
                return _ShowRole;
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

        public string Imie
        {
            get { return item.Imie; }
            set
            {
                if (item.Imie != value)
                {
                    item.Imie = value;
                    OnPropertyChanged(() => Imie);
                }
            }
        }

        public string Nazwisko
        {
            get { return item.Nazwisko; }
            set
            {
                if (item.Nazwisko != value)
                {
                    item.Nazwisko = value;
                    OnPropertyChanged(() => Nazwisko);
                }
            }
        }

        public string Pesel
        {
            get { return item.Pesel; }
            set
            {
                if (item.Pesel != value)
                {
                    item.Pesel = value;
                    OnPropertyChanged(() => Pesel);
                }
            }
        }

        public DateTime? DataUrodzenia
        {
            get { return item.DataUrodzenia; }
            set
            {
                if (item.DataUrodzenia != value)
                {
                    item.DataUrodzenia = value;
                    OnPropertyChanged(() => DataUrodzenia);
                }
            }
        }

        public string AdresZamieszkania
        {
            get { return item.AdresZamieszkania; }
            set
            {
                if (item.AdresZamieszkania != value)
                {
                    item.AdresZamieszkania = value;
                    OnPropertyChanged(() => AdresZamieszkania);
                }
            }
        }

        public string Miasto
        {
            get { return item.Miasto; }
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
            get { return item.KodPocztowy; }
            set
            {
                if (item.KodPocztowy != value)
                {
                    item.KodPocztowy = value;
                    OnPropertyChanged(() => KodPocztowy);
                }
            }
        }

        public string TelefonSluzbowy
        {
            get { return item.TelefonSluzbowy; }
            set
            {
                if (item.TelefonSluzbowy != value)
                {
                    item.TelefonSluzbowy = value;
                    OnPropertyChanged(() => TelefonSluzbowy);
                }
            }
        }

        public string AdresEmailSluzbowy
        {
            get { return item.AdresEmailSluzbowy; }
            set
            {
                if (item.AdresEmailSluzbowy != value)
                {
                    item.AdresEmailSluzbowy = value;
                    OnPropertyChanged(() => AdresEmailSluzbowy);
                }
            }
        }

        public string NumerKontaBankowego
        {
            get { return item.NumerKontaBankowego; }
            set
            {
                if (item.NumerKontaBankowego != value)
                {
                    item.NumerKontaBankowego = value;
                    OnPropertyChanged(() => NumerKontaBankowego);
                }
            }
        }

        public DateTime DataZatrudnienia
        {
            get { return item.DataZatrudnienia; }
            set
            {
                if (item.DataZatrudnienia != value)
                {
                    item.DataZatrudnienia = value;
                    OnPropertyChanged(() => DataZatrudnienia);
                }
            }
        }

        public string StatusZatrudnienia
        {
            get { return item.StatusZatrudnienia; }
            set
            {
                if (item.StatusZatrudnienia != value)
                {
                    item.StatusZatrudnienia = value;
                    OnPropertyChanged(() => StatusZatrudnienia);
                }
            }
        }

        public string NumerPrawaWykonywaniaZawodu
        {
            get { return item.NumerPrawaWykonywaniaZawodu; }
            set
            {
                if (item.NumerPrawaWykonywaniaZawodu != value)
                {
                    item.NumerPrawaWykonywaniaZawodu = value;
                    OnPropertyChanged(() => NumerPrawaWykonywaniaZawodu);
                }
            }
        }

        public string KwalifikacjeDodatkowe
        {
            get { return item.KwalifikacjeDodatkowe; }
            set
            {
                if (item.KwalifikacjeDodatkowe != value)
                {
                    item.KwalifikacjeDodatkowe = value;
                    OnPropertyChanged(() => KwalifikacjeDodatkowe);
                }
            }
        }

        public DateTime? DataWaznosciBadanLekarskich
        {
            get { return item.DataWaznosciBadanLekarskich; }
            set
            {
                if (item.DataWaznosciBadanLekarskich != value)
                {
                    item.DataWaznosciBadanLekarskich = value;
                    OnPropertyChanged(() => DataWaznosciBadanLekarskich);
                }
            }
        }

        public decimal? StawkaGodzinowa
        {
            get { return item.StawkaGodzinowa; }
            set
            {
                if (item.StawkaGodzinowa != value)
                {
                    item.StawkaGodzinowa = value;
                    OnPropertyChanged(() => StawkaGodzinowa);
                }
            }
        }

        public string TypUmowy
        {
            get { return item.TypUmowy; }
            set
            {
                if (item.TypUmowy != value)
                {
                    item.TypUmowy = value;
                    OnPropertyChanged(() => TypUmowy);
                }
            }
        }

        public int? LiczbaDniUrlopu
        {
            get { return item.LiczbaDniUrlopu; }
            set
            {
                if (item.LiczbaDniUrlopu != value)
                {
                    item.LiczbaDniUrlopu = value;
                    OnPropertyChanged(() => LiczbaDniUrlopu);
                }
            }
        }

        public string PreferowanaZmiana
        {
            get { return item.PreferowanaZmiana; }
            set
            {
                if (item.PreferowanaZmiana != value)
                {
                    item.PreferowanaZmiana = value;
                    OnPropertyChanged(() => PreferowanaZmiana);
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

        public int IdRoli
        {
            get { return item.IdRoli; }
            set
            {
                if (item.IdRoli != value)
                {
                    item.IdRoli = value;
                    OnPropertyChanged(() => IdRoli);
                }
            }
        }

        private string _RolaNazwa;
        public string RolaNazwa
        {
            get { return _RolaNazwa; }
            set
            {
                if (_RolaNazwa != value)
                {
                    _RolaNazwa = value;
                    OnPropertyChanged(() => RolaNazwa);
                }
            }
        }

        private string _RolaNazwaDzialu;
        public string RolaNazwaDzialu
        {
            get { return _RolaNazwaDzialu; }
            set
            {
                if (_RolaNazwaDzialu != value)
                {
                    _RolaNazwaDzialu = value;
                    OnPropertyChanged(() => RolaNazwaDzialu);
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

            medicalEntities.Pracownik.Add(item);
            medicalEntities.SaveChanges();
        }

        private void getWybranaRola(RolaPracownikaForAllView rola)
        {
            if (rola != null)
            {
                IdRoli = rola.IdRoli;
                RolaNazwa = rola.NazwaRoli;
                RolaNazwaDzialu = rola.NazwaDzialu;
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
