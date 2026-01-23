using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.Validatory
{
    public class StringValidator:Validator
    {
        public static string SprawdzPesel(string pesel)
        {
            if (string.IsNullOrWhiteSpace(pesel))
                return "PESEL nie może być pusty";

            if (pesel.Length != 11)
                return "PESEL musi składać się z dokładnie 11 cyfr";

            if (!pesel.All(char.IsDigit))
                return "PESEL może zawierać tylko cyfry";

            return null;
        }
    }
}
