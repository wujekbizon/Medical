using System.ComponentModel;

namespace Medical.Models.Enums
{
    public enum SortPointsEnum
    {
        [Description("Suma punktów (malejąco)")]
        LacznePunktyMalejaco = 0,

        [Description("Suma punktów (rosnąco)")]
        LacznePunktyRosnaco = 1,

        [Description("Akredytowane na początku")]
        CzyAkredytowana = 2,
    }
}
