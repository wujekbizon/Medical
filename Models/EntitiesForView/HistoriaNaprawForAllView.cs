using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.EntitiesForView
{
    public class HistoriaNaprawForAllView
    {
        public int IdNaprawy { get; set; }
        public string RodzajNaprawy { get; set; }
        public string OpisNaprawy { get; set; }
        public DateTime DataRozpoczecia { get; set; }
        public DateTime? DataZakonczenia { get; set; }
        public decimal KosztNaprawy { get; set; }
        public decimal? CzasTrwaniaNaprawy { get; set; }
        public int? GwarancjaMiesiecy { get; set; }
        public string StanKaretkiPrzedNaprawa { get; set; }
        public string StanKaretkiPoNaprawie { get; set; }
        public string CzyZatwierdzona { get; set; } 
        public string Karetka { get; set; }
        public string NumerFaktury { get; set; }
        public string NazwaFirmy { get; set; }

        public HistoriaNaprawForAllView()
        {
        }
    }
}