using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.Enums
{
    public enum WalutaEnum
    {
        [Description("PLN")]
        PLN = 0,
        [Description("EUR")]
        EUR = 1,
        [Description("USD")]
        USD = 2
    }
}
