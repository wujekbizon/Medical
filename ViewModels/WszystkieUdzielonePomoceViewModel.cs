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
    public class WszystkieUdzielonePomoceViewModel : WszystkieViewModel<UdzielonaPomocForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<UdzielonaPomocForAllView>
                (
                   medicalEntities.UdzielonaPomoc
                   .Where(pomoc => pomoc.CzyAktywny == true)
                   .Select(pomoc => new UdzielonaPomocForAllView
                   {
                       DataPomocy = pomoc.DataPomocy,
                       CzasRozpoczecia = pomoc.CzasRozpoczecia,
                       CzasZakonczenia = pomoc.CzasZakonczenia,
                       OpisPomocy = pomoc.OpisPomocy,
                       ProceduryMedyczne = pomoc.ProceduryMedyczne,
                       WynikInterwencji = pomoc.WynikInterwencji,
                       CzasTrwaniaMinuty = pomoc.CzasTrwaniaMinuty,
                       LokalizacjaInterwencji = pomoc.LokalizacjaInterwencji,
                       WymaganySprzet = pomoc.WymaganySprzet,
                       PacjentWymagalTransportu = pomoc.CzyWymagalTransportu == true ? "TAK" : "NIE",
                       PriorytetInterwencji = pomoc.PriorytetInterwencji,
                       KodDiagnozyICD10 = pomoc.KodDiagnozyICD10,
                       SzpitalTransportu = pomoc.SzpitalTransportu,
                       StanPacjentaPrzyPrzekazaniu = pomoc.StanPacjentaPrzyPrzekazaniu,
                       UdziałPolicji = pomoc.CzyBylWymaganyUdziałPolicji == true ? "TAK" : "NIE",
                       Pacjent = pomoc.Pacjent.Imie + " " + pomoc.Pacjent.Nazwisko,
                       NazwaZespolu = pomoc.ZespolRatunkowy.NazwaZespolu,
                       Karetka = pomoc.Karetka.NumerRejestracyjny,
                       AdresZdarzenia = pomoc.ZlecenieWyjazdu.AdresZdarzenia,
                       AutorRaportu = pomoc.Pracownik.Imie + " " + pomoc.Pracownik.Nazwisko
                   })
                   .ToList()
                );
        }
        #endregion

        #region Konstruktor
        public WszystkieUdzielonePomoceViewModel()
        {
            base.DisplayName = "Udzielone Pomoce";
        }
        #endregion
    }
}