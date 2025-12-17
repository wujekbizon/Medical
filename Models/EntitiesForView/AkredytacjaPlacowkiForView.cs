using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.EntitiesForView
{
    public class AkredytacjaPlacowkiForView
    {
        public int Pozycja { get; set; }
        public int IdPlacowki { get; set; }
        public string NazwaPlacowki { get; set; }
        public decimal SredniaOcenaZespolow { get; set; }
        public int LiczbaOcen { get; set; }
        public int PunktyZaOceny { get; set; }
        public int LiczbaInterwencji { get; set; }
        public int PunktyZaInterwencje { get; set; }
        public int LiczbaAktywnychZespolow { get; set; }
        public int LiczbaAktywnychKaretek { get; set; }
        public int PunktyZaKaretki { get; set; }
        public int LacznePunkty { get; set; }
        public bool CzyAkredytowana { get; set; }
        public string StatusAkredytacji { get; set; }
        public string KolorStatusu { get; set; }
        public string Rekomendacje { get; set; }

        public AkredytacjaPlacowkiForView()
        {
        }
    }


}
