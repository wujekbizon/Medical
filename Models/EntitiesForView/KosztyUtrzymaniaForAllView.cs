using System;

namespace Medical.Models.EntitiesForView
{
    public class KosztyUtrzymaniaForAllView
    {
        public string RodzajKosztu { get; set; }
        public decimal Kwota { get; set; }
        public DateTime DataKosztu { get; set; }
        public string OpisSzczegolowy { get; set; }
        public DateTime? DataKsiegowania { get; set; }
        public string Zaksiegowana { get; set; }
        public string OkresRozliczeniowy { get; set; }
        public string NumerDowoduZakupu { get; set; }
        public string CentrumKosztowe { get; set; }
        public string Cyklczna { get; set; }
        public decimal? KwotaBudzetowa { get; set; }
        public string UwagiKsięgowe { get; set; }
        public string Karetka { get; set; }
        public string NumerFaktury { get; set; }
        public string NazwaFirmy{ get; set; }
        public string NazwaSposobuPlatnosci { get; set; }

        public KosztyUtrzymaniaForAllView()
        {
        }
    }
}