using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.EntitiesForView
{
    public class FakturaForAllView
    {
        public int IdFaktury { get; set; }
        public string Numer { get; set; }
        public DateTime DataWystawienia { get; set; }
        public DateTime? TerminPlatnosci { get; set; }
        public string Waluta { get; set; }
        public string StatusPlatnosci { get; set; }
        public string Opis { get; set; }
        public string KategoriaKosztu { get; set; }
        public string OkresKsiegowy { get; set; }
        public string CzyZatwierdzona { get; set; }
        public string NazwaFirmy { get; set; }
        public string NazwaSposobuPlatnosci { get; set; } 

        public FakturaForAllView()
        {
        }
    }
}