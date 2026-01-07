using Medical.Models.EntitiesForView;
using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.ViewModels
{
    public class WszystkiePozycjeFakturyViewModel : WszystkieViewModel<PozycjaFakturyForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<PozycjaFakturyForAllView>
                (
                   medicalEntities.PozycjaFaktury
                   .Where(pozycja => pozycja.CzyAktywny == true)
                   .Select(pozycja => new PozycjaFakturyForAllView
                   {
                       NumerFaktury = pozycja.Faktura.Numer,
                       NazwaUslugi = pozycja.NazwaUslugi,
                       Ilosc = pozycja.Ilosc,
                       CenaJednostkowaNetto = pozycja.CenaJednostkowaNetto,
                       StawkaVAT = pozycja.StawkaVAT,
                       KwotaNetto = pozycja.KwotaNetto,
                       KwotaVAT = pozycja.KwotaVAT,
                       KwotaBrutto = pozycja.KwotaBrutto,
                       JednostkaMiary = pozycja.JednostkaMiary,
                       Kod = pozycja.Kod,
                       KategoriaPozycji = pozycja.KategoriaPozycji
                   })
                   .ToList()
                );
        }
        #endregion

        #region Konstruktor
        public WszystkiePozycjeFakturyViewModel()
        {
            base.DisplayName = "Pozycje Faktur";
        }
        #endregion
        #region Sortowanie i Filtrowanie
        public override List<string> getComboBoxSortList()
        {
            return new List<string>
    {
        "numerFaktury",
        "nazwaUslugi",
        "kwotaBrutto",
        "kwotaNetto",
        "ilosc",
        "cenaJednostkowaNetto",
        "stawkaVAT",
        "kategoriaPozycji",
        "kod"
    };
        }

        public override List<string> getComboBoxFindList()
        {
            return new List<string>
    {
        "numerFaktury",
        "nazwaUslugi",
        "kod",
        "kategoriaPozycji",
        "jednostkaMiary"
    };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "numerFaktury":
                    List = new ObservableCollection<PozycjaFakturyForAllView>(List.OrderBy(item => item.NumerFaktury));
                    break;
                case "nazwaUslugi":
                    List = new ObservableCollection<PozycjaFakturyForAllView>(List.OrderBy(item => item.NazwaUslugi));
                    break;
                case "kwotaBrutto":
                    List = new ObservableCollection<PozycjaFakturyForAllView>(List.OrderBy(item => item.KwotaBrutto));
                    break;
                case "kwotaNetto":
                    List = new ObservableCollection<PozycjaFakturyForAllView>(List.OrderBy(item => item.KwotaNetto));
                    break;
                case "ilosc":
                    List = new ObservableCollection<PozycjaFakturyForAllView>(List.OrderBy(item => item.Ilosc));
                    break;
                case "cenaJednostkowaNetto":
                    List = new ObservableCollection<PozycjaFakturyForAllView>(List.OrderBy(item => item.CenaJednostkowaNetto));
                    break;
                case "stawkaVAT":
                    List = new ObservableCollection<PozycjaFakturyForAllView>(List.OrderBy(item => item.StawkaVAT));
                    break;
                case "kategoriaPozycji":
                    List = new ObservableCollection<PozycjaFakturyForAllView>(List.OrderBy(item => item.KategoriaPozycji));
                    break;
                case "kod":
                    List = new ObservableCollection<PozycjaFakturyForAllView>(List.OrderBy(item => item.Kod));
                    break;
                default:
                    break;
            }
        }

        public override void Find()
        {
            switch (FindField)
            {
                case "numerFaktury":
                    List = new ObservableCollection<PozycjaFakturyForAllView>(List.Where(item =>
                        item.NumerFaktury != null && item.NumerFaktury.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "nazwaUslugi":
                    List = new ObservableCollection<PozycjaFakturyForAllView>(List.Where(item =>
                        item.NazwaUslugi != null && item.NazwaUslugi.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "kod":
                    List = new ObservableCollection<PozycjaFakturyForAllView>(List.Where(item =>
                        item.Kod != null && item.Kod.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "kategoriaPozycji":
                    List = new ObservableCollection<PozycjaFakturyForAllView>(List.Where(item =>
                        item.KategoriaPozycji != null && item.KategoriaPozycji.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "jednostkaMiary":
                    List = new ObservableCollection<PozycjaFakturyForAllView>(List.Where(item =>
                        item.JednostkaMiary != null && item.JednostkaMiary.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
                    break;
                default:
                    break;
            }
        }
        #endregion

    }
}