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
    public class WszyscyPracownicyViewModel : WszystkieViewModel<PracownikForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<PracownikForAllView>
                (
                   medicalEntities.Pracownik
                   .Where(pracownik => pracownik.CzyAktywny == true)
                   .Select(pracownik => new PracownikForAllView
                   {
                       Imie = pracownik.Imie,
                       Nazwisko = pracownik.Nazwisko,
                       Pesel = pracownik.Pesel,
                       DataUrodzenia = pracownik.DataUrodzenia,
                       AdresZamieszkania = pracownik.AdresZamieszkania,
                       Miasto = pracownik.Miasto,
                       KodPocztowy = pracownik.KodPocztowy,
                       TelefonSluzbowy = pracownik.TelefonSluzbowy,
                       AdresEmailSluzbowy = pracownik.AdresEmailSluzbowy,
                       NumerKontaBankowego = pracownik.NumerKontaBankowego,
                       DataZatrudnienia = pracownik.DataZatrudnienia,
                       StatusZatrudnienia = pracownik.StatusZatrudnienia,
                       NumerPrawaWykonywaniaZawodu = pracownik.NumerPrawaWykonywaniaZawodu,
                       KwalifikacjeDodatkowe = pracownik.KwalifikacjeDodatkowe,
                       DataWaznosciBadanLekarskich = pracownik.DataWaznosciBadanLekarskich,
                       StawkaGodzinowa = pracownik.StawkaGodzinowa,
                       TypUmowy = pracownik.TypUmowy,
                       LiczbaDniUrlopu = pracownik.LiczbaDniUrlopu,
                       PreferowanaZmiana = pracownik.PreferowanaZmiana,
                       DataOstatniegoSzkolenia = pracownik.DataOstatniegoSzkolenia,
                       NazwaRoli = pracownik.RolaPracownika.NazwaRoli,
                       NazwaPlacowki = pracownik.Placowka.NazwaPlacowki
                   })
                   .ToList()
                );
        }
        #endregion

        #region Konstruktor
        public WszyscyPracownicyViewModel()
        {
            base.DisplayName = "Pracownicy";
        }
        #endregion
    }
}