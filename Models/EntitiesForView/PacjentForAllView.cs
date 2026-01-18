using System;

namespace Medical.Models.EntitiesForView
{
    public class PacjentForAllView
    {
        public int IdPacjenta { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string AdresZamieszkania { get; set; }
        public string Miasto { get; set; }
        public string KodPocztowy { get; set; }
        public string TelefonKontaktowy { get; set; }
        public string AdresEmail { get; set; }
        public string Pesel { get; set; }
        public string Plec { get; set; }
        public string NumerKartyPacjenta { get; set; }
        public string GrupaKrwi { get; set; }
        public string InformacjeAlergie { get; set; }
        public string UbezpieczenieZdrowotne { get; set; }
        public string UwagiDodatkowe { get; set; }
        public string KontaktAwaryjnyImieNazwisko { get; set; }
        public string KontaktAwaryjnyTelefon { get; set; }
        public string ChorobyPrzewlekle { get; set; }
        public string RodzajNiepełnosprawności { get; set; }

        public PacjentForAllView()
        {
        }
    }
}
