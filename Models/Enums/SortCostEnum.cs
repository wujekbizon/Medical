using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.Enums
{
    public enum SortCostEnum
    {
        [Description("Łączne koszty (malejąco)")]
        LaczneKosztyMalejaco = 0,

        [Description("Łączne koszty (rosnąco)")]
        LaczneKosztyRosnaco = 1,

        [Description("Liczba kosztów (malejąco)")]
        LaczneLiczbaKosztowMalejaco = 2,

    }
}
