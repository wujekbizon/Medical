using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.EntitiesForView
{
    public class UdzielonaPomocForAllView
    {
        public int IdPomocy { get; set; }
        public DateTime DataPomocy { get; set; }
        public TimeSpan? CzasRozpoczecia { get; set; }
        public TimeSpan? CzasZakonczenia { get; set; }
        public string OpisPomocy { get; set; }
        public string ProceduryMedyczne { get; set; }
        public string WynikInterwencji { get; set; }
        public int CzasTrwaniaMinuty { get; set; }
        public string LokalizacjaInterwencji { get; set; }
        public string WymaganySprzet { get; set; }
        public string PacjentWymagalTransportu { get; set; }
        public string PriorytetInterwencji { get; set; }
        public string KodDiagnozyICD10 { get; set; }
        public string SzpitalTransportu { get; set; }
        public string StanPacjentaPrzyPrzekazaniu { get; set; }
        public string UdziałPolicji { get; set; }
        public string Pacjent { get; set; }
        public string NazwaZespolu { get; set; }
        public string Karetka { get; set; } 
        public string AdresZdarzenia { get; set; }
        public string AutorRaportu { get; set; }

        public UdzielonaPomocForAllView()
        {
        }
    }
}