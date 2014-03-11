using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Services
{
    public class PageRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
    }
}
