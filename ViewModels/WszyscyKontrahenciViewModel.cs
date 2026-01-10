using GalaSoft.MvvmLight.Messaging;
using Medical.Models;
using Medical.Models.EntitiesForView;
using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Medical.ViewModels
{
    public class WszyscyKontrahenciViewModel :  WszystkieViewModel<KontrahentForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<KontrahentForAllView>
            (
                from kontrahent in medicalEntities.Kontrahent
                select new KontrahentForAllView
                {
                    IdKontrahenta = kontrahent.IdKontrahenta,
                    Nazwa = kontrahent.Nazwa,
                    Typ = kontrahent.Typ,
                    OsobaKontaktowa = kontrahent.OsobaKontaktowa,
                    TelefonKontaktowy = kontrahent.TelefonKontaktowy,
                    AdresEmail = kontrahent.AdresEmail,
                    AdresSiedziby = kontrahent.AdresSiedziby,
                    Miasto = kontrahent.Miasto,
                    KodPocztowy = kontrahent.KodPocztowy,
                    NIP = kontrahent.NIP,
                    NumerKontaBankowego = kontrahent.NumerKontaBankowego,
                    KategoriaBiznesowa = kontrahent.KategoriaBiznesowa,
                    DataRozpoczeciaWspolpracy = kontrahent.DataRozpoczeciaWspolpracy,
                    DataZakonczeniaUmowy = kontrahent.DataZakonczeniaUmowy,
                    WarunkiPlatnosci = kontrahent.WarunkiPlatnosci,
                    LacznaWartoscTransakcji = kontrahent.LacznaWartoscTransakcji,
                    StatusWspolpracy = kontrahent.StatusWspolpracy,
                    Adres = kontrahent.Miasto + " " + kontrahent.AdresSiedziby + " " + kontrahent.KodPocztowy
                }
            );
        }
        #endregion
        #region Konstruktor
        public WszyscyKontrahenciViewModel()
            : base()
        {
            base.DisplayName = "Kontrahenci";
        }
        #endregion

        #region Właściwosci
        private KontrahentForAllView _WybranyKontrahent;
        public KontrahentForAllView WybranyKontrahent
        {
            get
            {
                return _WybranyKontrahent;
            }
            set  
            {
                if (_WybranyKontrahent != value)
                {
                    _WybranyKontrahent = value;
                    Messenger.Default.Send(_WybranyKontrahent);
                    OnRequestClose(); 
                }
            }
        }
        #endregion

        #region Sortowanie i Filtrowanie

        public override List<string> getComboBoxSortList()
        {
            return new List<string>
            {
                "nazwa",
                "nip",
                "kategoriaBiznesowa",
                "status",
                "typ",
                "miasto",
                "kodPocztowy",
                "dataRozpoczeciaWspolpracy",
                "dataZakonczeniaUmowy",
                "warunkiPlatnosci",
                "numerKontaBankowego"
            };
        }

        public override List<string> getComboBoxFindList()
        {
            return new List<string> 
            {
                "nazwa",
                "nip",
                "miasto",
                "kodPocztowy",
                "adresEmail",
                "telefonKontaktowy",
                "numerKontaBankowego",
                "kategoriaBiznesowa"
            };
        }
        public override void Sort()
        {
            switch (SortField)
            {
                case "nazwa":
                    List = new ObservableCollection<KontrahentForAllView>(List.OrderBy(item => item.Nazwa));
                    break;
                case "nip":
                    List = new ObservableCollection<KontrahentForAllView>(List.OrderBy(item => item.NIP));
                    break;
                case "kategoriaBiznesowa":
                    List = new ObservableCollection<KontrahentForAllView>(List.OrderBy(item => item.KategoriaBiznesowa));
                    break;
                case "status":
                    List = new ObservableCollection<KontrahentForAllView>(List.OrderBy(item => item.StatusWspolpracy));
                    break;
                case "typ":
                    List = new ObservableCollection<KontrahentForAllView>(List.OrderBy(item => item.Typ));
                    break;
                case "miasto":
                    List = new ObservableCollection<KontrahentForAllView>(List.OrderBy(item => item.Miasto));
                    break;
                case "kodPocztowy":
                    List = new ObservableCollection<KontrahentForAllView>(List.OrderBy(item => item.KodPocztowy));
                    break;
                case "dataRozpoczeciaWspolpracy":
                    List = new ObservableCollection<KontrahentForAllView>(List.OrderBy(item => item.DataRozpoczeciaWspolpracy));
                    break;
                case "dataZakonczeniaUmowy":
                    List = new ObservableCollection<KontrahentForAllView>(List.OrderBy(item => item.DataZakonczeniaUmowy));
                    break;
                case "warunkiPlatnosci":
                    List = new ObservableCollection<KontrahentForAllView>(List.OrderBy(item => item.WarunkiPlatnosci));
                    break;
                case "numerKontaBankowego":
                    List = new ObservableCollection<KontrahentForAllView>(List.OrderBy(item => item.NumerKontaBankowego));
                    break;
                default:
                    break;
            }
        }

        public override void Find()
        {
            switch (FindField)
            {
                case "nazwa":
                    List = new ObservableCollection<KontrahentForAllView>(List.Where(item =>
                        item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "nip":
                    List = new ObservableCollection<KontrahentForAllView>(List.Where(item =>
                        item.NIP != null && item.NIP.StartsWith(FindTextBox)));
                    break;
                case "miasto":
                    List = new ObservableCollection<KontrahentForAllView>(List.Where(item =>
                        item.Miasto != null && item.Miasto.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "kodPocztowy":
                    List = new ObservableCollection<KontrahentForAllView>(List.Where(item =>
                        item.KodPocztowy != null && item.KodPocztowy.StartsWith(FindTextBox)));
                    break;
                case "adresEmail":
                    List = new ObservableCollection<KontrahentForAllView>(List.Where(item =>
                        item.AdresEmail != null && item.AdresEmail.Contains(FindTextBox)));
                    break;
                case "telefonKontaktowy":
                    List = new ObservableCollection<KontrahentForAllView>(List.Where(item =>
                        item.TelefonKontaktowy != null && item.TelefonKontaktowy.Contains(FindTextBox)));
                    break;
                case "numerKontaBankowego":
                    List = new ObservableCollection<KontrahentForAllView>(List.Where(item =>
                        item.NumerKontaBankowego != null && item.NumerKontaBankowego.Contains(FindTextBox)));
                    break;
                case "kategoriaBiznesowa":
                    List = new ObservableCollection<KontrahentForAllView>(List.Where(item =>
                        item.KategoriaBiznesowa != null && item.KategoriaBiznesowa.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
