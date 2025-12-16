using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.EntitiesForView
{
    public class RankingZespolowForView
    {   
        public int Pozycja { get; set; }
        public int IDZespolu { get; set; }
        public string NazwaZespolu { get; set; }
        public decimal SredniaOcena { get; set; }
        public int LiczbaOcen { get; set; }
        public decimal SumaOcen { get; set; }
        public string Status { get; set; }
        public string StatusKolor { get; set; }

        public RankingZespolowForView()
        {
        }
    }
}
