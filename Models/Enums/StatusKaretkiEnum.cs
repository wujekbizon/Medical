using System.ComponentModel;

namespace Medical.Models.Enums
{
    public enum StatusKaretkiEnum
    {
        [Description("DOSTEPNA")]
        Dostepna = 0,

        [Description("W UZYCIU")]
        WUzyciu = 1,

        [Description("W NAPRAWIE")]
        WNaprawie = 2
    }
}
