using GalaSoft.MvvmLight.Messaging;
using Medical.Models.EntitiesForView;
using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Medical.ViewModels
{
    public class WszystkieRolePracownikaViewModel : WszystkieViewModel<RolaPracownikaForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<RolaPracownikaForAllView>(
                from rola in medicalEntities.RolaPracownika
                where rola.CzyAktywny == true
                select new RolaPracownikaForAllView
                {
                    IdRoli = rola.IdRoli,
                    NazwaRoli = rola.NazwaRoli,
                    PoziomUprawnien = rola.PoziomUprawnien,
                    OpisObowiazkow = rola.OpisObowiazkow,
                    MinimalneWyksztalcenie = rola.MinimalneWyksztalcenie,
                    WymaganeSzkolenia = rola.WymaganeSzkolenia,
                    CzyWymagaLicencji = rola.CzyWymagaLicencji,
                    MaksymalnaLiczbaGodzinTygodniowo = rola.MaksymalnaLiczbaGodzinTygodniowo,
                    SredniaPlaca = rola.SredniaPlaca,
                    Benefity = rola.Benefity,
                    DataOstatniejAktualizacji = rola.DataOstatniejAktualizacji,
                    NazwaDzialu = rola.NazwaDzialu,
                    CzyJestLideremZespolu = rola.CzyJestLideremZespolu,
                    LimitZatrudnienia = rola.LimitZatrudnienia,
                    WymaganeUmiejetnosci = rola.WymaganeUmiejetnosci,
                    RolaNastepnegoEtapuKariery = rola.RolaNastepnegoEtapuKariery
                }
            );
        }
        #endregion
        #region Konstruktor
        public WszystkieRolePracownikaViewModel()
            :base()
        {
            base.DisplayName = "Role";
        }
        #endregion

        #region Właściwosci
        private RolaPracownikaForAllView _WybranaRola;
        public RolaPracownikaForAllView WybranaRola
        {
            get
            {
                return _WybranaRola;
            }
            set
            {
                if (_WybranaRola != value)
                {
                    _WybranaRola = value;
                    Messenger.Default.Send(_WybranaRola);
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
        "nazwaRoli",
        "sredniaPlaca",
        "minimalneWyksztalcenie",
        "maksymalnaLiczbaGodzinTygodniowo",
        "limitZatrudnienia",
        "dataOstatniejszAktualizacji",
        "wymaganeUmiejetnosci",
        "wymaganeSzkolenia"
    };
        }

        public override List<string> getComboBoxFindList()
        {
            return new List<string>
    {
        "nazwaRoli",
        "minimalneWyksztalcenie",
        "wymaganeUmiejetnosci",
        "wymaganeSzkolenia",
        "nazwaDzialu",
        "opisObowiazkan",
        "benefity"
    };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "nazwaRoli":
                    List = new ObservableCollection<RolaPracownikaForAllView>(List.OrderBy(item => item.NazwaRoli));
                    break;
                case "sredniaPlaca":
                    List = new ObservableCollection<RolaPracownikaForAllView>(List.OrderBy(item => item.SredniaPlaca));
                    break;
                case "minimalneWyksztalcenie":
                    List = new ObservableCollection<RolaPracownikaForAllView>(List.OrderBy(item => item.MinimalneWyksztalcenie));
                    break;
                case "maksymalnaLiczbaGodzinTygodniowo":
                    List = new ObservableCollection<RolaPracownikaForAllView>(List.OrderBy(item => item.MaksymalnaLiczbaGodzinTygodniowo));
                    break;
                case "limitZatrudnienia":
                    List = new ObservableCollection<RolaPracownikaForAllView>(List.OrderBy(item => item.LimitZatrudnienia));
                    break;
                case "dataOstatniejszAktualizacji":
                    List = new ObservableCollection<RolaPracownikaForAllView>(List.OrderBy(item => item.DataOstatniejAktualizacji));
                    break;
                case "wymaganeUmiejetnosci":
                    List = new ObservableCollection<RolaPracownikaForAllView>(List.OrderBy(item => item.WymaganeUmiejetnosci));
                    break;
                case "wymaganeSzkolenia":
                    List = new ObservableCollection<RolaPracownikaForAllView>(List.OrderBy(item => item.WymaganeSzkolenia));
                    break;
                default:
                    break;
            }
        }

        public override void Find()
        {
            switch (FindField)
            {
                case "nazwaRoli":
                    List = new ObservableCollection<RolaPracownikaForAllView>(List.Where(item =>
                        item.NazwaRoli != null && ((string)item.NazwaRoli).StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "minimalneWyksztalcenie":
                    List = new ObservableCollection<RolaPracownikaForAllView>(List.Where(item =>
                        item.MinimalneWyksztalcenie != null && ((string)item.MinimalneWyksztalcenie).StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "wymaganeUmiejetnosci":
                    List = new ObservableCollection<RolaPracownikaForAllView>(List.Where(item =>
                        item.WymaganeUmiejetnosci != null && ((string)item.WymaganeUmiejetnosci).Contains(FindTextBox)));
                    break;
                case "wymaganeSzkolenia":
                    List = new ObservableCollection<RolaPracownikaForAllView>(List.Where(item =>
                        item.WymaganeSzkolenia != null && ((string)item.WymaganeSzkolenia).Contains(FindTextBox)));
                    break;
                case "nazwaDzialu":
                    List = new ObservableCollection<RolaPracownikaForAllView>(List.Where(item =>
                        item.NazwaDzialu != null && ((string)item.NazwaDzialu).StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "opisObowiazkan":
                    List = new ObservableCollection<RolaPracownikaForAllView>(List.Where(item =>
                        item.OpisObowiazkow != null && ((string)item.OpisObowiazkow).Contains(FindTextBox)));
                    break;
                case "benefity":
                    List = new ObservableCollection<RolaPracownikaForAllView>(List.Where(item =>
                        item.Benefity != null && ((string)item.Benefity).Contains(FindTextBox)));
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
