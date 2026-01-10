using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.EntitiesForView
{
    public class KaretkaForAllView
    {
        public int IdKaretki { get; set; }
        public string NumerRejestracyjny { get; set; }
        public string TypKaretki { get; set; }
        public string Status { get; set; }
        public string PlacowkaZarzadzajaca { get; set; }

        public KaretkaForAllView()
        {
        }
    }
}
