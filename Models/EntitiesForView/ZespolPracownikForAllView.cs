using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.EntitiesForView
{
    public class ZespolPracownikForAllView
    {
        public int IdZespoluPracownika { get; set; }
        public string NazwaZespolu { get; set; }
        public string ImiePracownika { get; set; }
        public string NazwiskoPracownika { get; set; }
        public string Pracownik { get; set; }
        public string RolaWZespole { get; set; }
        public DateTime DataDolaczenia { get; set; }
        public DateTime? DataOpuszczenia { get; set; }
        public string PowodZmiany { get; set; }
        public DateTime DataPrzypisania { get; set; }

        public ZespolPracownikForAllView()
        {
        }
    }
}