using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.BusinessLogic
{
    public class DatabaseClass
    {
        #region Baza Danych
        protected MedicalEntities medicalEntities;
        #endregion

        #region Konstruktor
        public DatabaseClass(MedicalEntities medicalEntities)
        {
            this.medicalEntities = medicalEntities;
        }
        #endregion
    }
}
