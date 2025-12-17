using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.EntitiesForView
{
    public class KosztyKaretkiForView
    {
       
        public int Pozycja { get; set; }
        public int IdPlacowki { get; set; }
        public string NazwaPlacowki { get; set; }
        public int LiczbaKaretek { get; set; }
        public decimal LaczneKoszty { get; set; }
        public int LiczbaKosztow { get; set; }
        public decimal SredniKosztNaKaretke { get; set; }
        public string KategoriaKosztow { get; set; }
        public string KolorKategorii { get; set; }
        public string LaczneKosztyFormatted => $"{LaczneKoszty:C2}";
        public string SredniKosztFormatted => $"{SredniKosztNaKaretke:C2}";

        public KosztyKaretkiForView()
        {
        }
    }
}
