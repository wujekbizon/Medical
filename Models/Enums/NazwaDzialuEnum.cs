using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.Enums
{
    public enum NazwaDzialuEnum
    {
        [Description("Medyczny")]
        Medyczny = 0,

        [Description("Administracja")]
        Administracja = 1,

        [Description("Logistyka")]
        Logistyka = 2,

        [Description("Dyspozytornia")]
        Dyspozytornia = 3,

        [Description("Ratownictwo")]
        Ratownictwo = 4,

        [Description("Transport Sanitarny")]
        TransportSanitarny = 5,

        [Description("Gospodarczy")]
        Gospodarczy = 6
    }
}
