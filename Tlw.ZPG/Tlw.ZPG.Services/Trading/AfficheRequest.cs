using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Enums;

namespace Tlw.ZPG.Services.Trading
{
    public class AfficheRequest : PageRequest
    {
        public string Title { get; set; }
        public string CountyCode { get; set; }
    }
}
