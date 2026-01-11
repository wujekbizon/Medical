using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.EntitiesForView
{
    public class RolaPracownikaForAllView
    {
        public int IdRoli { get; set; }
        public string NazwaRoli { get; set; }
        public int PoziomUprawnien { get; set; }
        public string OpisObowiazkow { get; set; }
        public string MinimalneWyksztalcenie { get; set; }
        public string WymaganeSzkolenia { get; set; }
        public bool CzyWymagaLicencji { get; set; }
        public int? MaksymalnaLiczbaGodzinTygodniowo { get; set; }
        public decimal? SredniaPlaca { get; set; }
        public string Benefity { get; set; }
        public DateTime? DataOstatniejAktualizacji { get; set; }
        public string NazwaDzialu { get; set; }
        public bool CzyJestLideremZespolu { get; set; }
        public int? LimitZatrudnienia { get; set; }
        public string WymaganeUmiejetnosci { get; set; }
        public string RolaNastepnegoEtapuKariery { get; set; }

        public RolaPracownikaForAllView()
        {
        }
    }
}
