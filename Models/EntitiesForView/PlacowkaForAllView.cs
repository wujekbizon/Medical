using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.EntitiesForView
{
    public class PlacowkaForAllView
    {
        public int IdPlacowki { get; set; }
        public string NazwaPlacowki { get; set; }
        public string Adres { get; set; }
        public string Miasto { get; set; }
        public string KodPocztowy { get; set; }
        public string Telefon { get; set; }
        public string AdresEmail { get; set; }
        public string TypPlacowki { get; set; }
        public string GodzinyPracy { get; set; }
        public int? LiczbaKaretek { get; set; }
        public int? LiczbaZespolow { get; set; }
        public int? PojemnoscGarazu { get; set; }
        public DateTime? DataOtwarcia { get; set; }
        public DateTime? DataOstatniejInspekcji { get; set; }
        public string Region { get; set; }
        public decimal? Budzet { get; set; }
        public string ObszarZasieguRatunkowego { get; set; }
        public bool CzyMaAkredytacje { get; set; }

        public PlacowkaForAllView()
        {
        }
    }
}
