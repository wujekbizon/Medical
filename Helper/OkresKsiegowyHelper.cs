using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Helper
{
    public static class OkresKsiegowyHelper
    {
        public static string GenerujOkresKsiegowy()
        {
            DateTime now = DateTime.Now;
            return $"{now.Year:D4}-{now.Month:D2}";
        }
    }
}
