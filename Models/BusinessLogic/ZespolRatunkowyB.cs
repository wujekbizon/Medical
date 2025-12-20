using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medical.Models.EntitiesForView;

namespace Medical.Models.BusinessLogic
{
    public class ZespolRatunkowyB : DatabaseClass
    {
        #region Konstruktor
        public ZespolRatunkowyB(MedicalEntities medicalEntities)
            : base(medicalEntities)
        {
        }
        #endregion

        #region Funkcje pomocnicze
        public IQueryable<KeyAndValue> GetZespolyKeyAndValueItems()
        {
            var lista = new List<KeyAndValue>();

            lista.Add(new KeyAndValue
            {
                Key = 0,
                Value = "Wszystkie zespoły"
            });

            var zespoly = from zespol in medicalEntities.ZespolRatunkowy
                          where zespol.CzyAktywny == true
                          select new KeyAndValue
                          {
                              Key = zespol.IdZespolu,
                              Value = zespol.Placowka.NazwaPlacowki + " - " + zespol.NazwaZespolu
                          };
 
            lista.AddRange(zespoly.ToList());

            return lista.AsQueryable();
        }
        #endregion
    }
}
