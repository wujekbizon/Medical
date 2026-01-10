using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.Enums
{
    public enum TypPaliwaEnum
    {
        [Description("Diesel")]
        Diesel = 0,

        [Description("Benzyna")]
        Benzyna = 1,

        [Description("LPG")]
        LPG = 2,

        [Description("Elektryk")]
        Elektryk = 3
    }
}
