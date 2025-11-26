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
    public class WszystkieHistorieNaprawViewModel : WszystkieViewModel<HistoriaNaprawForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<HistoriaNaprawForAllView>
                (
                   medicalEntities.HistoriaNapraw
                   .Where(naprawa => naprawa.CzyAktywny == true)
                   .Select(naprawa => new HistoriaNaprawForAllView
                   {
                       RodzajNaprawy = naprawa.RodzajNaprawy,
                       OpisNaprawy = naprawa.OpisNaprawy,
                       DataRozpoczecia = naprawa.DataRozpoczecia,
                       DataZakonczenia = naprawa.DataZakonczenia,
                       KosztNaprawy = naprawa.KosztNaprawy,
                       CzasTrwaniaNaprawy = naprawa.CzasTrwaniaNaprawy,
                       GwarancjaMiesiecy = naprawa.GwarancjaMiesiecy,
                       StanKaretkiPrzedNaprawa = naprawa.StanKaretkiPrzedNaprawa,
                       StanKaretkiPoNaprawie = naprawa.StanKaretkiPoNaprawie,
                       CzyZatwierdzona = naprawa.CzyZatwierdzona ? "TAK" : "NIE",
                       Karetka = naprawa.Karetka.NumerRejestracyjny,
                       NumerFaktury = naprawa.Faktura.Numer,
                       NazwaFirmy = naprawa.Kontrahent.Nazwa
                   })
                   .ToList()
                );
        }
        #endregion

        #region Konstruktor
        public WszystkieHistorieNaprawViewModel()
        {
            base.DisplayName = "Historie Napraw";
        }
        #endregion
    }
}