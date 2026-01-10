using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.EntitiesForView
{
    public class KontrahentForAllView
    {
        public int IdKontrahenta { get; set; }
        public string Nazwa { get; set; }
        public string Typ { get; set; }
        public string OsobaKontaktowa { get; set; }
        public string TelefonKontaktowy { get; set; }
        public string AdresEmail { get; set; }
        public string AdresSiedziby { get; set; }
        public string Miasto { get; set; }
        public string KodPocztowy { get; set; }
        public string NIP { get; set; }
        public string NumerKontaBankowego { get; set; }
        public string KategoriaBiznesowa { get; set; }
        public DateTime? DataRozpoczeciaWspolpracy { get; set; }
        public DateTime? DataZakonczeniaUmowy { get; set; }
        public string WarunkiPlatnosci { get; set; }
        public decimal? LacznaWartoscTransakcji { get; set; }
        public string StatusWspolpracy { get; set; }
        public string Adres { get; set; }

        public KontrahentForAllView()
        {
        }
    }
}
