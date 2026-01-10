using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.Enums
{
    public enum TypKaretkiEnum
    {
        [Description("Typ P")]
        TypP = 0,

        [Description("Typ A")]
        TypA = 1,

        [Description("Typ S")]
        TypS = 2,

        [Description("Typ T")]
        TypT = 3
    }
}
