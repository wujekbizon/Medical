using Medical.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.BusinessLogic
{
    public class PlacowkaB : DatabaseClass
    {
        public PlacowkaB(MedicalEntities medicalEntities)
            : base(medicalEntities)
        {
        }

        #region Funkcje pomocnicze 
        public IQueryable<KeyAndValue> GetPlacowkiKeyAndValueItems()
        {
            var wszystkiePlacowki = new List<KeyAndValue>
            {
                new KeyAndValue { Key = 0, Value = "Wszystkie placówki" }
            };

        
            var activePlacowki = medicalEntities.Placowka
                .Where(p => p.CzyAktywny == true)
                .OrderBy(p => p.NazwaPlacowki)
                .Select(p => new KeyAndValue
                {
                    Key = p.IdPlacowki,
                    Value = p.NazwaPlacowki
                })
                .ToList();

            wszystkiePlacowki.AddRange(activePlacowki);

            return wszystkiePlacowki.AsQueryable();
        }

        #endregion
    }
}
