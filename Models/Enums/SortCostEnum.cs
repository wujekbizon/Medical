using System.ComponentModel;

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
