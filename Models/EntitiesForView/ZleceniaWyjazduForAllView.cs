using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.EntitiesForView
{
    public class ZleceniaWyjazduForAllView
    {
        public int IdWyjazdu { get; set; }
        public DateTime DataCzasZgloszenia { get; set; }
        public string AdresZdarzenia { get; set; }
        public string TypZdarzenia { get; set; }
        public string Priorytet { get; set; }
        public string StatusZlecenia { get; set; }
        public string OpisZdarzenia { get; set; }
        public DateTime? CzasWyjazdu { get; set; }
        public DateTime? CzasPrzyjazduNaMiejsce { get; set; }
        public DateTime? CzasPowrotuDoBazy { get; set; }
        public string TelefonDzwoniacego { get; set; }
        public int? CzasReakcjiSekundy { get; set; }
        public decimal? Dystans { get; set; }
        public int? LiczbaPacjentow { get; set; }
        public string WarunkiPogodowe { get; set; }
        public string WymaganeDodatkoweWsparcie { get; set; }
        public string Dyspozytor { get; set; }
        public string NazwaZespolu { get; set; }
        public string NumerRejestracyjnyKaretki { get; set; }

        public ZleceniaWyjazduForAllView()
        {
        }
    }
}