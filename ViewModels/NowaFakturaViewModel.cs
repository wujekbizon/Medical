using GalaSoft.MvvmLight.Messaging;
using Medical.Helper;
using Medical.Models;
using Medical.Models.EntitiesForView;
using Medical.Models.Enums;
using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;


namespace Medical.ViewModels
{
    public class NowaFakturaViewModel : JedenViewModel<Faktura>
    {
        private readonly UserForAllView _currentUser;
        #region Konstruktor
        public NowaFakturaViewModel(UserForAllView currentUser)
        {
            base.DisplayName = "Faktura";
            item = new Faktura();
            _currentUser = currentUser;
            Numer = FakturaNumerGenerator.GenerateNumber();
            DataWystawienia = DateTime.Now;
            OkresKsiegowy = OkresKsiegowyHelper.GenerujOkresKsiegowy();
            Messenger.Default.Register<KontrahentForAllView>(this, getWybranyKontrahent);
        }
        #endregion
        #region Komendy
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

        public string Numer
        {
            get
            {
                return item.Numer;
            }
            set
            {
                if (item.Numer != value)
                {
                    item.Numer = value;
                    OnPropertyChanged(() => Numer);
                }
            }
        }

        public DateTime DataWystawienia
        {
            get
            {
                return item.DataWystawienia;
            }
            set
            {
                if (item.DataWystawienia != value)
                {
                    item.DataWystawienia = value;
                    OnPropertyChanged(() => DataWystawienia);
                }
            }
        }

        public int IdKontrahenta
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

        public DateTime? TerminPlatnosci
        {
            get
            {
                return item.TerminPlatnosci;
            }
            set
            {
                if (item.TerminPlatnosci != value)
                {
                    item.TerminPlatnosci = value;
                    OnPropertyChanged(() => TerminPlatnosci);
                }
            }
        }

        public string Waluta
        {
            get
            {
                return item.Waluta;
            }
            set
            {
                if (item.Waluta != value)
                {
                    item.Waluta = value;
                    OnPropertyChanged(() => Waluta);
                }
            }
        }

        public string StatusPlatnosci
        {
            get
            {
                return item.StatusPlatnosci;
            }
            set
            {
                if (item.StatusPlatnosci != value)
                {
                    item.StatusPlatnosci = value;
                    OnPropertyChanged(() => StatusPlatnosci);
                }
            }
        }

        public string Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                if (item.Opis != value)
                {
                    item.Opis = value;
                    OnPropertyChanged(() => Opis);
                }
            }
        }

        public string KategoriaKosztu
        {
            get
            {
                return item.KategoriaKosztu;
            }
            set
            {
                if (item.KategoriaKosztu != value)
                {
                    item.KategoriaKosztu = value;
                    OnPropertyChanged(() => KategoriaKosztu);
                }
            }
        }

        public string OkresKsiegowy
        {
            get
            {
                return item.OkresKsiegowy;
            }
            set
            {
                if (item.OkresKsiegowy != value)
                {
                    item.OkresKsiegowy = value;
                    OnPropertyChanged(() => OkresKsiegowy);
                }
            }
        }

        public int? IdSposobuPlatnosci
        {
            get
            {
                return item.IdSposobuPlatnosci;
            }
            set
            {
                if (item.IdSposobuPlatnosci != value)
                {
                    item.IdSposobuPlatnosci = value;
                    OnPropertyChanged(() => IdSposobuPlatnosci);
                }
            }
        }

        public IQueryable<SposobPlatnosci> SposobyPlatnosciItems
        {
            get
            {
                return
                    (
                        from sposobPlatnosci in medicalEntities.SposobPlatnosci
                        where sposobPlatnosci.CzyAktywny == true
                        select sposobPlatnosci
                    ).ToList().AsQueryable();
            }
        }

        public IEnumerable<KeyAndValue> WalutaItems
        {
            get
            {
                return EnumHelper.GetEnumKeyAndValues<WalutaEnum>();
            }
        }

        public IEnumerable<KeyAndValue> StatusPlatnosciItems
        {
            get
            {
                return EnumHelper.GetEnumKeyAndValues<StatusPlatnosciEnum>();
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

            medicalEntities.Faktura.Add(item);
            FakturaNumerGenerator.Increment();
            medicalEntities.SaveChanges();

     
        }

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
