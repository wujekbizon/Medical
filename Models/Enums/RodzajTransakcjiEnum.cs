using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.Enums
{
    public enum RodzajTransakcjiEnum
    {
        [Description("Elektroniczna")]
        Elektroniczna = 0,

        [Description("Gotówkowa")]
        Gotowkowa = 1,

        [Description("Instytucjonalna")]
        Instytucjonalna = 2,

        [Description("Rozliczeniowa")]
        Rozliczeniowa = 3,

        [Description("Kredytowa")]
        Kredytowa = 4,

        [Description("Leasingowa")]
        Leasingowa = 5
    }
}
