using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.EntitiesForView
{
    public class PracownikForAllView
    {
        public int IdPracownika { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public string AdresZamieszkania { get; set; }
        public string Miasto { get; set; }
        public string KodPocztowy { get; set; }
        public string TelefonSluzbowy { get; set; }
        public string AdresEmailSluzbowy { get; set; }
        public string NumerKontaBankowego { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        public string StatusZatrudnienia { get; set; }
        public string NumerPrawaWykonywaniaZawodu { get; set; }
        public string KwalifikacjeDodatkowe { get; set; }
        public DateTime? DataWaznosciBadanLekarskich { get; set; }
        public decimal? StawkaGodzinowa { get; set; }
        public string TypUmowy { get; set; }
        public int? LiczbaDniUrlopu { get; set; }
        public string PreferowanaZmiana { get; set; }
        public DateTime? DataOstatniegoSzkolenia { get; set; }
        public string NazwaRoli { get; set; }
        public string NazwaPlacowki { get; set; }

        public PracownikForAllView()
        {
        }
    }
}