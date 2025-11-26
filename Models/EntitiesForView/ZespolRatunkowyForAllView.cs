using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.EntitiesForView
{
    public class ZespolRatunkowyForAllView
    {
        public string NazwaZespolu { get; set; }
        public int LiczbaCzlonkow { get; set; }
        public string Specjalizacja { get; set; }
        public DateTime DataUtworzenia { get; set; }
        public string StatusZespolu { get; set; }
        public string TelefonKontaktowy { get; set; }
        public string Zmiana { get; set; }
        public DateTime? DataOstatniegoSzkolenia { get; set; }
        public decimal? SredniaOcena { get; set; }
        public DateTime? DataOstatniegoWyjazdu { get; set; }
        public int? LiczbaWszystkichWyjazdow { get; set; }
        public string Certyfikaty { get; set; }
        public string Karetka { get; set; }
        public string NazwaPlacowki { get; set; }

        public ZespolRatunkowyForAllView()
        {
        }
    }
}