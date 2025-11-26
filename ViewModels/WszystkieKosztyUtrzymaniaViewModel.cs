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
    public class WszystkieKosztyUtrzymaniaViewModel : WszystkieViewModel<KosztyUtrzymaniaForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<KosztyUtrzymaniaForAllView>
                (
                   medicalEntities.KosztUtrzymania
                   .Where(koszt => koszt.CzyAktywny == true)
                   .Select( koszt => new KosztyUtrzymaniaForAllView
                   {
                       RodzajKosztu = koszt.RodzajKosztu,
                       Kwota = koszt.Kwota,
                       DataKosztu = koszt.DataKosztu,
                       OpisSzczegolowy = koszt.OpisSzczegolowy,
                       DataKsiegowania = koszt.DataKsiegowania,
                       Zaksiegowana = koszt.CzyZaksiegowany ? "TAK" : "NIE",  
                       OkresRozliczeniowy = koszt.OkresRozliczeniowy,
                       NumerDowoduZakupu = koszt.NumerDowoduZakupu,
                       CentrumKosztowe = koszt.CentrumKosztowe,
                       Cyklczna = (bool)koszt.CzyJestCyklczny? "TAK" : "NIE",  
                       KwotaBudzetowa = koszt.KwotaBudzetowa,
                       UwagiKsięgowe = koszt.UwagiKsięgowe,
                       Karetka = koszt.Karetka.NumerRejestracyjny,
                       NumerFaktury = koszt.Faktura.Numer,
                       NazwaFirmy = koszt.Kontrahent.Nazwa,
                       NazwaSposobuPlatnosci = koszt.SposobPlatnosci.Nazwa
                   })
                );
        }
        #endregion

        #region Konstruktor
        public WszystkieKosztyUtrzymaniaViewModel()
        {
            base.DisplayName = "Koszty Utrzymania";
        }
        #endregion
    }
}