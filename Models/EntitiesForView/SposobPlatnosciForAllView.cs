using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.EntitiesForView
{
    public class SposobPlatnosciForAllView
    {
        public int IdSposobuPlatnosci { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public bool CzyWymagaPotwierdzenia { get; set; }
        public string RodzajTransakcji { get; set; }

        public SposobPlatnosciForAllView()
        {
        }
    }
}
