using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.Enums
{
    public enum GrupaKrwiEnum
    {
        [Description("0+")]
        ZeroPlus = 0,

        [Description("0-")]
        ZeroMinus = 1,

        [Description("A+")]
        APlus = 2,

        [Description("A-")]
        AMinus = 3,

        [Description("B+")]
        BPlus = 4,

        [Description("B-")]
        BMinus = 5,

        [Description("AB+")]
        ABPlus = 6,

        [Description("AB-")]
        ABMinus = 7
    }
}
