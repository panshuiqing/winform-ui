using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Enums;

namespace Tlw.ZPG.Services.Trading
{
    public class TradeRequest : PageRequest
    {
        public string LandNumber { get; set; }
        public string CountyCode { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TradeStatus? TradeStatus { get; set; }
    }
}
