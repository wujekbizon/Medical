using GalaSoft.MvvmLight.Messaging;
using Medical.Helper;
using Medical.Models;
using Medical.Models.EntitiesForView;
using Medical.ViewModels.Abstract;
using System;
using System.Windows.Input;

namespace Medical.ViewModels
{
    public class NoweKosztyUtrzymaniaViewModel : JedenViewModel<KosztUtrzymania>
    {
        #region Pola
        private readonly UserForAllView _currentUser;
        #endregion
        #region Konstruktor

        public NoweKosztyUtrzymaniaViewModel(UserForAllView currentUser)
            : base()
        {
            base.DisplayName = "Koszt Utrzymania";
            item = new KosztUtrzymania();
            _currentUser = currentUser;

            DataKosztu = DateTime.Now;
            CzyZaksiegowany = false;
            CzyJestCyklczny = false;
            OkresRozliczeniowy = OkresKsiegowyHelper.GenerujOkresKsiegowy();

            Messenger.Default.Register<KaretkaForAllView>(this, getWybranaKaretka);
            Messenger.Default.Register<FakturaForAllView>(this, getWybranaFaktura);
            Messenger.Default.Register<KontrahentForAllView>(this, getWybranyKontrahent);
            Messenger.Default.Register<SposobPlatnosciForAllView>(this, getWybranySposobPlatnosci);
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

        private BaseCommand _ShowSposobyPlatnosci;
        public ICommand ShowSposobyPlatnosci
        {
            get
            {
                if (_ShowSposobyPlatnosci == null)
                {
                    _ShowSposobyPlatnosci = new BaseCommand(() =>
                    {
                        Messenger.Default.Send("SposobyPlatnosciShow");
                    });
                }
                return _ShowSposobyPlatnosci;
            }
        }

        #endregion

        #region Właściwości

        public string RodzajKosztu
        {
            get { return item.RodzajKosztu; }
            set
            {
                if (item.RodzajKosztu != value)
                {
                    item.RodzajKosztu = value;
                    OnPropertyChanged(() => RodzajKosztu);
                }
            }
        }

        public decimal Kwota
        {
            get { return item.Kwota; }
            set
            {
                if (item.Kwota != value)
                {
                    item.Kwota = value;
                    OnPropertyChanged(() => Kwota);
                }
            }
        }

        public DateTime DataKosztu
        {
            get { return item.DataKosztu; }
            set
            {
                if (item.DataKosztu != value)
                {
                    item.DataKosztu = value;
                    OnPropertyChanged(() => DataKosztu);
                }
            }
        }

        public string OpisSzczegolowy
        {
            get { return item.OpisSzczegolowy; }
            set
            {
                if (item.OpisSzczegolowy != value)
                {
                    item.OpisSzczegolowy = value;
                    OnPropertyChanged(() => OpisSzczegolowy);
                }
            }
        }

        public DateTime? DataKsiegowania
        {
            get { return item.DataKsiegowania; }
            set
            {
                if (item.DataKsiegowania != value)
                {
                    item.DataKsiegowania = value;
                    OnPropertyChanged(() => DataKsiegowania);
                }
            }
        }

        public bool CzyZaksiegowany
        {
            get { return item.CzyZaksiegowany; }
            set
            {
                if (item.CzyZaksiegowany != value)
                {
                    item.CzyZaksiegowany = value;
                    OnPropertyChanged(() => CzyZaksiegowany);
                }
            }
        }

        public string OkresRozliczeniowy
        {
            get { return item.OkresRozliczeniowy; }
            set
            {
                if (item.OkresRozliczeniowy != value)
                {
                    item.OkresRozliczeniowy = value;
                    OnPropertyChanged(() => OkresRozliczeniowy);
                }
            }
        }

        public string NumerDowoduZakupu
        {
            get { return item.NumerDowoduZakupu; }
            set
            {
                if (item.NumerDowoduZakupu != value)
                {
                    item.NumerDowoduZakupu = value;
                    OnPropertyChanged(() => NumerDowoduZakupu);
                }
            }
        }

        public string CentrumKosztowe
        {
            get { return item.CentrumKosztowe; }
            set
            {
                if (item.CentrumKosztowe != value)
                {
                    item.CentrumKosztowe = value;
                    OnPropertyChanged(() => CentrumKosztowe);
                }
            }
        }

        public bool CzyJestCyklczny
        {
            get { return item.CzyJestCyklczny ?? false; }
            set
            {
                if (item.CzyJestCyklczny != value)
                {
                    item.CzyJestCyklczny = value;
                    OnPropertyChanged(() => CzyJestCyklczny);
                }
            }
        }

        public decimal? KwotaBudzetowa
        {
            get { return item.KwotaBudzetowa; }
            set
            {
                if (item.KwotaBudzetowa != value)
                {
                    item.KwotaBudzetowa = value;
                    OnPropertyChanged(() => KwotaBudzetowa);
                }
            }
        }

        public string UwagiKsięgowe
        {
            get { return item.UwagiKsięgowe; }
            set
            {
                if (item.UwagiKsięgowe != value)
                {
                    item.UwagiKsięgowe = value;
                    OnPropertyChanged(() => UwagiKsięgowe);
                }
            }
        }

        public int IdKaretki
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

        public int? IdFaktury
        {
            get { return item.IdFaktury; }
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
            get { return _FakturaNumer; }
            set
            {
                if (_FakturaNumer != value)
                {
                    _FakturaNumer = value;
                    OnPropertyChanged(() => FakturaNumer);
                }
            }
        }

        public int? IdKontrahenta
        {
            get { return item.IdKontrahenta; }
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
            get { return _KontrahentNazwa; }
            set
            {
                if (_KontrahentNazwa != value)
                {
                    _KontrahentNazwa = value;
                    OnPropertyChanged(() => KontrahentNazwa);
                }
            }
        }

        public int? IdSposobuPlatnosci
        {
            get { return item.IdSposobuPlatnosci; }
            set
            {
                if (item.IdSposobuPlatnosci != value)
                {
                    item.IdSposobuPlatnosci = value;
                    OnPropertyChanged(() => IdSposobuPlatnosci);
                }
            }
        }

        private string _SposobPlatnosciNazwa;
        public string SposobPlatnosciNazwa
        {
            get { return _SposobPlatnosciNazwa; }
            set
            {
                if (_SposobPlatnosciNazwa != value)
                {
                    _SposobPlatnosciNazwa = value;
                    OnPropertyChanged(() => SposobPlatnosciNazwa);
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

            medicalEntities.KosztUtrzymania.Add(item);
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

        private void getWybranaFaktura(FakturaForAllView faktura)
        {
            if (faktura != null)
            {
                IdFaktury = faktura.IdFaktury;
                FakturaNumer = faktura.Numer;
            }
        }

        private void getWybranyKontrahent(KontrahentForAllView kontrahent)
        {
            if (kontrahent != null)
            {
                IdKontrahenta = kontrahent.IdKontrahenta;
                KontrahentNazwa = kontrahent.Nazwa;
            }
        }

        private void getWybranySposobPlatnosci(SposobPlatnosciForAllView sposob)
        {
            if (sposob != null)
            {
                IdSposobuPlatnosci = sposob.IdSposobuPlatnosci;
                SposobPlatnosciNazwa = sposob.Nazwa;
            }
        }

        #endregion
    }
}
