using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Services
{
    public class PageRequest
    {
        public PageRequest()
        {
            PageIndex = 1;
            PageSize = 50;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
    }
}
