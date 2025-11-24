using System;

namespace Medical.Models.EntitiesForView
{
    /// <summary>
    /// DTO for displaying Pacjent (Patient) data in list views
    /// Combines data from Pacjent and related entities
    /// </summary>
    public class PacjentForAllView
    {
        #region Properties
        public int IdPacjenta { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string ImieNazwisko => $"{Imie} {Nazwisko}";
        public DateTime DataUrodzenia { get; set; }
        public int Wiek => DateTime.Now.Year - DataUrodzenia.Year;
        public string Pesel { get; set; }
        public string Plec { get; set; }
        public string TelefonKontaktowy { get; set; }
        public string AdresEmail { get; set; }
        public string Miasto { get; set; }
        public string GrupaKrwi { get; set; }
        public string UbezpieczenieZdrowotne { get; set; }
        public string InformacjeAlergie { get; set; }
        public string ChorobyPrzewlekle { get; set; }
        public bool CzyAktywny { get; set; }
        public DateTime KiedyDodal { get; set; }
        #endregion
    }
}
