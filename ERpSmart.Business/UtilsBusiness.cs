using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
    public static class Utils
    {
        public static int isNull(int? value)
        {
            return value == null ? 0 :(int)value;
        }
        public static decimal isNull(decimal? value)
        {
            return value == null ? 0 : (decimal)value;
        }
        public static string isNull(string value)
        {
            return value == null ? "" : value;
        }
    }
}
