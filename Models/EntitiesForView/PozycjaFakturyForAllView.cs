using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.EntitiesForView
{
    public class PozycjaFakturyForAllView
    {
        public int IdPozycji { get; set; }
        public string NumerFaktury { get; set; }
        public string NazwaUslugi { get; set; }
        public decimal Ilosc { get; set; }
        public decimal CenaJednostkowaNetto { get; set; }
        public decimal StawkaVAT { get; set; }
        public decimal KwotaNetto { get; set; }
        public decimal KwotaVAT { get; set; }
        public decimal KwotaBrutto { get; set; }
        public string JednostkaMiary { get; set; }
        public string Kod { get; set; }
        public string KategoriaPozycji { get; set; }

        public PozycjaFakturyForAllView()
        {
        }
    }
}