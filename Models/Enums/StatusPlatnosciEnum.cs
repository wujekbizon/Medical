using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Models.Enums
{
    public enum StatusPlatnosciEnum
    {
        [Description("Nieopłacona")]
        Nieoplacona = 0,
        [Description("Opłacona")]
        Oplacona = 1,
        [Description("Przeterminowana")]
        Przeterminowana = 2
    }
}
