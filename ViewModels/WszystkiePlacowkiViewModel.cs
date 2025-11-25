using Medical.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Medical.ViewModels.Abstract;

namespace Medical.ViewModels
{
    public class WszystkiePlacowkiViewModel : WszystkieViewModel<dynamic>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<dynamic>
            (
                medicalEntities.Placowka
                    .Where(s => s.CzyAktywny == true)
                    .Select(p => new
                    {
                        p.NazwaPlacowki,
                        p.Adres,
                        p.Miasto,
                        p.KodPocztowy,
                        p.Telefon,
                        p.AdresEmail,
                        p.TypPlacowki,
                        p.GodzinyPracy,
                        p.LiczbaKaretek,
                        p.LiczbaZespolow,
                        p.PojemnoscGarazu,
                        p.DataOtwarcia,
                        p.DataOstatniejInspekcji,
                        p.Region,
                        p.Budzet,
                        p.ObszarZasieguRatunkowego,
                        CzyMaAkredytacje = p.CzyMaAkredytacje ? "TAK" : "NIE",
                    })
                    .ToList()
            );
        }
        #endregion
        public WszystkiePlacowkiViewModel()
            :base()
        {
            base.DisplayName = "Placowki";
        }
    }
}
