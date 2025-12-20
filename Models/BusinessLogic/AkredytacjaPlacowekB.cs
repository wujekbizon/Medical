using Medical.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.BusinessLogic
{
    public class AkredytacjaPlacowekB : DatabaseClass
    {
        #region Konstruktor
        public AkredytacjaPlacowekB(MedicalEntities medicalEntities)
            : base(medicalEntities)
        {
        }
        #endregion

        #region Funkcje biznesowe
        public List<AkredytacjaPlacowkiForView> OcenAkredytacje(
            DateTime dataOd,
            DateTime dataDo,
            int minimalnaLiczbaOcen,
            int? idPlacowki,
            int sortOrder)
        {
            var placowki = medicalEntities.Placowka
                .Where(p => p.CzyAktywny == true)
                .Where(p => !idPlacowki.HasValue || idPlacowki <= 0 || p.IdPlacowki == idPlacowki.Value)
                .ToList();

            var wyniki = new List<AkredytacjaPlacowkiForView>();

            foreach (var placowka in placowki)
            {
                var zespoly = placowka.ZespolRatunkowy
                    .Where(z => z.CzyAktywny == true)
                    .ToList();

                var oceny = zespoly
                    .SelectMany(z => z.OcenaZespolu)
                    .Where(o => o.CzyAktywny == true
                            && o.DataOceny >= dataOd
                            && o.DataOceny <= dataDo)
                    .ToList();

                decimal sredniaOcena = oceny.Any() ? (decimal)oceny.Average(o => o.Ocena) : 0;
                int liczbaOcen = oceny.Count;

                var interwencje = zespoly
                    .SelectMany(z => z.UdzielonaPomoc)
                    .Where(u => u.CzyAktywny == true
                            && u.DataPomocy >= dataOd
                            && u.DataPomocy <= dataDo)
                    .ToList();

                int liczbaInterwencji = interwencje.Count;
                int liczbaAktywnychZespolow = placowka.LiczbaZespolow ?? 0;
                int liczbaAktywnychKaretek = placowka.LiczbaKaretek ?? 0;
                int punktyOceny = ObliczPunktyZaOceny(sredniaOcena, liczbaOcen);
                int punktyInterwencje = ObliczPunktyZaInterwencje(liczbaInterwencji);
                int punktyKaretki = ObliczPunktyZaKaretki(liczbaAktywnychZespolow, liczbaAktywnychKaretek);
                int lacznePunkty = punktyOceny + punktyInterwencje + punktyKaretki;
                bool czyAkredytowana = OkreslStatusAkredytacji(lacznePunkty);

                if (liczbaOcen < minimalnaLiczbaOcen)
                    continue;

                var wynik = new AkredytacjaPlacowkiForView
                {
                    IdPlacowki = placowka.IdPlacowki,
                    NazwaPlacowki = placowka.NazwaPlacowki,
                    SredniaOcenaZespolow = sredniaOcena,
                    LiczbaOcen = liczbaOcen,
                    PunktyZaOceny = punktyOceny,
                    LiczbaInterwencji = liczbaInterwencji,
                    PunktyZaInterwencje = punktyInterwencje,
                    LiczbaAktywnychZespolow = liczbaAktywnychZespolow,
                    LiczbaAktywnychKaretek = liczbaAktywnychKaretek,
                    PunktyZaKaretki = punktyKaretki,
                    LacznePunkty = lacznePunkty,
                    CzyAkredytowana = czyAkredytowana,
                    StatusAkredytacji = OkreslStatusTekst(czyAkredytowana),
                    KolorStatusu = OkreslKolorStatusu(czyAkredytowana)
                };

                wynik.Rekomendacje = GenerujRekomendacje(wynik);
                wyniki.Add(wynik);
            }

            var sortedQuery = SortujWyniki(wyniki, sortOrder);

            var wynikiFinalne = new List<AkredytacjaPlacowkiForView>();
            int pozycja = 1;
            foreach (var item in sortedQuery)
            {
                item.Pozycja = pozycja++;
                wynikiFinalne.Add(item);
            }

            return wynikiFinalne;
        }
        #endregion

        #region Metody pomocnicze
        private IEnumerable<AkredytacjaPlacowkiForView> SortujWyniki(
            List<AkredytacjaPlacowkiForView> wyniki,
            int sortOrder)
        {
            switch (sortOrder)
            {
                case 0:
                    return wyniki.OrderByDescending(x => x.LacznePunkty);
                case 1:
                    return wyniki.OrderBy(x => x.LacznePunkty);
                case 2:
                    return wyniki.OrderByDescending(x => x.CzyAkredytowana)
                                 .ThenByDescending(x => x.LacznePunkty);
                default:
                    return wyniki.OrderByDescending(x => x.LacznePunkty);
            }
        }

        private int ObliczPunktyZaOceny(decimal sredniaOcena, int liczbaOcen)
        {
            int punkty = 0;

            if (sredniaOcena >= 9.0m)
                punkty += 25;
            else if (sredniaOcena >= 8.0m)
                punkty += 20;
            else if (sredniaOcena >= 7.0m)
                punkty += 15;
            else if (sredniaOcena >= 6.0m)
                punkty += 10;
            else if (sredniaOcena >= 5.0m)
                punkty += 5;

            if (liczbaOcen >= 50)
                punkty += 15;
            else if (liczbaOcen >= 30)
                punkty += 12;
            else if (liczbaOcen >= 20)
                punkty += 9;
            else if (liczbaOcen >= 10)
                punkty += 6;
            else if (liczbaOcen >= 5)
                punkty += 3;

            return Math.Min(punkty, 40);
        }

        private int ObliczPunktyZaInterwencje(int liczbaInterwencji)
        {
            if (liczbaInterwencji >= 200)
                return 40;
            else if (liczbaInterwencji >= 150)
                return 35;
            else if (liczbaInterwencji >= 100)
                return 30;
            else if (liczbaInterwencji >= 75)
                return 25;
            else if (liczbaInterwencji >= 50)
                return 20;
            else if (liczbaInterwencji >= 30)
                return 15;
            else if (liczbaInterwencji >= 20)
                return 10;
            else if (liczbaInterwencji >= 10)
                return 5;
            else
                return 0;
        }

        private int ObliczPunktyZaKaretki(int liczbaZespolow, int liczbaKaretek)
        {
            int punkty = 0;

            if (liczbaZespolow >= 5)
                punkty += 10;
            else if (liczbaZespolow >= 4)
                punkty += 8;
            else if (liczbaZespolow >= 3)
                punkty += 6;
            else if (liczbaZespolow >= 2)
                punkty += 4;
            else if (liczbaZespolow >= 1)
                punkty += 2;

            if (liczbaKaretek >= 8)
                punkty += 10;
            else if (liczbaKaretek >= 6)
                punkty += 8;
            else if (liczbaKaretek >= 4)
                punkty += 6;
            else if (liczbaKaretek >= 3)
                punkty += 4;
            else if (liczbaKaretek >= 2)
                punkty += 2;

            return Math.Min(punkty, 20);
        }

        private bool OkreslStatusAkredytacji(int lacznePunkty)
        {
            const int PROG_AKREDYTACJI = 35;
            return lacznePunkty >= PROG_AKREDYTACJI;
        }

        private string OkreslStatusTekst(bool czyAkredytowana)
        {
            return czyAkredytowana ? "Akredytowana" : "Nieakredytowana";
        }

        private string OkreslKolorStatusu(bool czyAkredytowana)
        {
            return czyAkredytowana ? "Green" : "Red";
        }

        private string GenerujRekomendacje(AkredytacjaPlacowkiForView wynik)
        {
            var rekomendacje = new List<string>();

            if (wynik.PunktyZaOceny < 20)
                rekomendacje.Add("Poprawa ocen zespołów");

            if (wynik.LiczbaOcen < 10)
                rekomendacje.Add("Zbieranie większej liczby ocen");

            if (wynik.PunktyZaInterwencje < 20)
                rekomendacje.Add("Zwiększenie liczby interwencji");

            if (wynik.LiczbaAktywnychZespolow < 3)
                rekomendacje.Add("Rozbudowa zespołów ratunkowych");

            if (wynik.LiczbaAktywnychKaretek < 4)
                rekomendacje.Add("Zwiększenie floty karetek");

            if (rekomendacje.Count == 0)
                return wynik.CzyAkredytowana ? "Brak - placówka spełnia wszystkie kryteria" : "Wymaga poprawy w wielu obszarach";

            return string.Join(", ", rekomendacje);
        }
        #endregion
    }
}
