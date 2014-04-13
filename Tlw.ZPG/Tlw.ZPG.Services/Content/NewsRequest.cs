using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Services
{
    public class NewsRequest : PageRequest
    {
        public string Keyword { get; set; }
        public Domain.Enums.NewsType NewsType { get; set; }
    }
}
