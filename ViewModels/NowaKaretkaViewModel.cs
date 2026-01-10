using GalaSoft.MvvmLight.Messaging;
using Medical.Helper;
using Medical.Models;
using Medical.Models.EntitiesForView;
using Medical.Models.Enums;
using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Medical.ViewModels
{
    public class NowaKaretkaViewModel : JedenViewModel<Karetka>
    {
        #region Pola
        private readonly UserForAllView _currentUser;
        #endregion

        #region Konstruktor
        public NowaKaretkaViewModel(UserForAllView currentUser)
            : base()
        {
            base.DisplayName = "Karetka";
            item = new Karetka();
            _currentUser = currentUser;

            Messenger.Default.Register<PlacowkaForAllView>(this, getWybranaPlacowka);
        }
        #endregion

        #region Komendy

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
        public string NumerRejestracyjny
        {
            get
            {
                return item.NumerRejestracyjny;
            }
            set
            {
                if (item.NumerRejestracyjny != value)
                {
                    item.NumerRejestracyjny = value;
                    OnPropertyChanged(() => NumerRejestracyjny);
                }
            }
        }

        public string TypKaretki
        {
            get
            {
                return item.TypKaretki;
            }
            set
            {
                if (item.TypKaretki != value)
                {
                    item.TypKaretki = value;
                    OnPropertyChanged(() => TypKaretki);
                }
            }
        }

        public int RokProdukcji
        {
            get
            {
                return item.RokProdukcji;
            }
            set
            {
                if (item.RokProdukcji != value)
                {
                    item.RokProdukcji = value;
                    OnPropertyChanged(() => RokProdukcji);
                }
            }
        }

        public string Status
        {
            get
            {
                return item.Status;
            }
            set
            {
                if (item.Status != value)
                {
                    item.Status = value;
                    OnPropertyChanged(() => Status);
                }
            }
        }

        public int PrzebiegKm
        {
            get
            {
                return item.PrzebiegKm;
            }
            set
            {
                if (item.PrzebiegKm != value)
                {
                    item.PrzebiegKm = value;
                    OnPropertyChanged(() => PrzebiegKm);
                }
            }
        }

        public DateTime? DataOstatniegoPrzegladu
        {
            get
            {
                return item.DataOstatniegoPrzegladu;
            }
            set
            {
                if (item.DataOstatniegoPrzegladu != value)
                {
                    item.DataOstatniegoPrzegladu = value;
                    OnPropertyChanged(() => DataOstatniegoPrzegladu);
                }
            }
        }

        public DateTime? DataWaznosciUbezpieczenia
        {
            get
            {
                return item.DataWaznosciUbezpieczenia;
            }
            set
            {
                if (item.DataWaznosciUbezpieczenia != value)
                {
                    item.DataWaznosciUbezpieczenia = value;
                    OnPropertyChanged(() => DataWaznosciUbezpieczenia);
                }
            }
        }

        public decimal? PojemnoscSilnika
        {
            get
            {
                return item.PojemnoscSilnika;
            }
            set
            {
                if (item.PojemnoscSilnika != value)
                {
                    item.PojemnoscSilnika = value;
                    OnPropertyChanged(() => PojemnoscSilnika);
                }
            }
        }

        public int? MocSilnikaKM
        {
            get
            {
                return item.MocSilnikaKM;
            }
            set
            {
                if (item.MocSilnikaKM != value)
                {
                    item.MocSilnikaKM = value;
                    OnPropertyChanged(() => MocSilnikaKM);
                }
            }
        }

        public string NumerVIN
        {
            get
            {
                return item.NumerVIN;
            }
            set
            {
                if (item.NumerVIN != value)
                {
                    item.NumerVIN = value;
                    OnPropertyChanged(() => NumerVIN);
                }
            }
        }

        public string TypPaliwa
        {
            get
            {
                return item.TypPaliwa;
            }
            set
            {
                if (item.TypPaliwa != value)
                {
                    item.TypPaliwa = value;
                    OnPropertyChanged(() => TypPaliwa);
                }
            }
        }

        public string Kolor
        {
            get
            {
                return item.Kolor;
            }
            set
            {
                if (item.Kolor != value)
                {
                    item.Kolor = value;
                    OnPropertyChanged(() => Kolor);
                }
            }
        }

        public int? LiczbaMiejsc
        {
            get
            {
                return item.LiczbaMiejsc;
            }
            set
            {
                if (item.LiczbaMiejsc != value)
                {
                    item.LiczbaMiejsc = value;
                    OnPropertyChanged(() => LiczbaMiejsc);
                }
            }
        }

        public DateTime? DataNabycia
        {
            get
            {
                return item.DataNabycia;
            }
            set
            {
                if (item.DataNabycia != value)
                {
                    item.DataNabycia = value;
                    OnPropertyChanged(() => DataNabycia);
                }
            }
        }

        public int? SzacowanaZywotnoscLat
        {
            get
            {
                return item.SzacowanaZywotnoscLat;
            }
            set
            {
                if (item.SzacowanaZywotnoscLat != value)
                {
                    item.SzacowanaZywotnoscLat = value;
                    OnPropertyChanged(() => SzacowanaZywotnoscLat);
                }
            }
        }

        public int IdPlacowki
        {
            get
            {
                return item.IdPlacowki;
            }
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
            get
            {
                return _PlacowkaNazwa;
            }
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
            get
            {
                return _PlacowkaMiasto;
            }
            set
            {
                if (_PlacowkaMiasto != value)
                {
                    _PlacowkaMiasto = value;
                    OnPropertyChanged(() => PlacowkaMiasto);
                }
            }
        }

        private string _PlacowkaAdres;
        public string PlacowkaAdres
        {
            get
            {
                return _PlacowkaAdres;
            }
            set
            {
                if (_PlacowkaAdres != value)
                {
                    _PlacowkaAdres = value;
                    OnPropertyChanged(() => PlacowkaAdres);
                }
            }
        }

        private string _PlacowkaTelefon;
        public string PlacowkaTelefon
        {
            get
            {
                return _PlacowkaTelefon;
            }
            set
            {
                if (_PlacowkaTelefon != value)
                {
                    _PlacowkaTelefon = value;
                    OnPropertyChanged(() => PlacowkaTelefon);
                }
            }
        }

        public IEnumerable<KeyAndValue> TypKaretkiItems
        {
            get
            {
                return EnumHelper.GetEnumKeyAndValues<TypKaretkiEnum>();
            }
        }

        public IEnumerable<KeyAndValue> StatusKaretkiItems
        {
            get
            {
                return EnumHelper.GetEnumKeyAndValues<StatusKaretkiEnum>();
            }
        }

        public IEnumerable<KeyAndValue> TypPaliwaItems
        {
            get
            {
                return EnumHelper.GetEnumKeyAndValues<TypPaliwaEnum>();
            }
        }

        #endregion

        #region Helpers

        public override void Save()
        {
            item.CzyAktywny = true;
            item.KiedyDodal = DateTime.Now;
            item.KtoDodal = _currentUser.Name +" " + _currentUser.LastName ?? "System Admin";
            item.WersjaDanych = 1;

            medicalEntities.Karetka.Add(item);
            medicalEntities.SaveChanges();
        }

        private void getWybranaPlacowka(PlacowkaForAllView placowka)
        {
            if (placowka != null)
            {
                IdPlacowki = placowka.IdPlacowki;
                PlacowkaNazwa = placowka.NazwaPlacowki;
                PlacowkaMiasto = placowka.Miasto;
                PlacowkaAdres = placowka.Adres;
                PlacowkaTelefon = placowka.Telefon;
            }
        }

        #endregion
    }
}
