using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tlw.ZPG.Web
{
    public sealed class Utils
    {
        public static int ToInt(string value,int defaultValue)
        {
            int result = 0;
            if (!int.TryParse(value, out result))
            {
                result = defaultValue;
            }
            return result;
        }
    }
}