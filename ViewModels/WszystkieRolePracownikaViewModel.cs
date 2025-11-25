using Medical.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.ViewModels
{
    public class WszystkieRolePracownikaViewModel : WszystkieViewModel<dynamic>
    {
        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<dynamic>
            (
                 medicalEntities.RolaPracownika
                    .Where(s => s.CzyAktywny == true)
                    .Select(p => new
                    {
                        p.NazwaRoli,
                        p.PoziomUprawnien,
                        p.OpisObowiazkow,
                        p.MinimalneWyksztalcenie,
                        p.WymaganeSzkolenia,
                        CzyWymagaLicencji = p.CzyWymagaLicencji ? "TAK" : "NIE",
                        p.MaksymalnaLiczbaGodzinTygodniowo,
                        p.SredniaPlaca,
                        p.Benefity,
                        p.DataOstatniejAktualizacji,
                        p.NazwaDzialu,
                        CzyJestLideremZespolu = p.CzyJestLideremZespolu ? "TAK" : "NIE",
                        p.LimitZatrudnienia,
                        p.WymaganeUmiejetnosci,
                        p.RolaNastepnegoEtapuKariery,
                    })
                    .ToList()
            );
        }
        #endregion
        #region Konstruktor
        public WszystkieRolePracownikaViewModel()
            :base()
        {
            base.DisplayName = "Role";
        }
        #endregion

    }
}
