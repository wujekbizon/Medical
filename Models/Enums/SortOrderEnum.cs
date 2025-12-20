using System.ComponentModel;


namespace Medical.Models.Enums
{
    public enum SortOrderEnum
    {
        [Description("Średnia ocena (malejąco)")]
        SredniaOcenaMalejaco = 0,

        [Description("Średnia ocena (rosnąco)")]
        SredniaOcenaRosnaco = 1,

        [Description("Liczba ocen (malejąco)")]
        LiczbaOcenMalejaco = 2,

        [Description("Nazwa zespołu (A-Z)")]
        NazwaZespoluAZ = 3
    }
}
