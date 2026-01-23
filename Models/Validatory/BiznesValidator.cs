using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.Validatory
{
    public class BiznesValidator: Validator
    {
        public static string SprawdzNumerKartyPacjenta(string numerKarty)
        {
            if (string.IsNullOrWhiteSpace(numerKarty))
                return "Numer karty pacjenta nie może być pusty";

            var regex = new System.Text.RegularExpressions.Regex(@"^[A-Z]\d+/(?:0[1-9]|1[0-2])$");

            if (!regex.IsMatch(numerKarty))
                return "Numer karty pacjenta powinien mieć format: wielka litera, cyfry, /, miesiąc (01-12). Przykład: W650514/04";

            return null;
        }
    }
}
