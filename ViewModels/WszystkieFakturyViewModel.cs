using Medical.Models.EntitiesForView;
using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.ViewModels
{
    public class WszystkieFakturyViewModel : WszystkieViewModel<FakturaForAllView>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<FakturaForAllView>
                (
                   medicalEntities.Faktura
                   .Where(faktura => faktura.CzyAktywny == true)
                   .Select(faktura => new FakturaForAllView
                   {
                       Numer = faktura.Numer,
                       DataWystawienia = faktura.DataWystawienia,
                       TerminPlatnosci = faktura.TerminPlatnosci,
                       Waluta = faktura.Waluta,
                       StatusPlatnosci = faktura.StatusPlatnosci,
                       Opis = faktura.Opis,
                       KategoriaKosztu = faktura.KategoriaKosztu,
                       OkresKsiegowy = faktura.OkresKsiegowy,
                       CzyZatwierdzona = faktura.CzyZatwierdzona ? "TAK" : "NIE",
                       NazwaFirmy = faktura.Kontrahent.Nazwa,
                       NazwaSposobuPlatnosci = faktura.SposobPlatnosci.Nazwa
                   })
                   .ToList()
                );
        }
        #endregion

        #region Konstruktor
        public WszystkieFakturyViewModel()
            : base()
        {
            base.DisplayName = "Faktury";
        }
        #endregion
    }
}