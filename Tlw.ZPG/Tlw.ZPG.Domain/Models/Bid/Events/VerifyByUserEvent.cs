using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Enums;
using Tlw.ZPG.Domain.Models.Bid;

namespace Tlw.ZPG.Domain.Models.Bid.Events
{
    public class VerifyByUserEvent : AccountEventBase
    {
        public VerifyType VerifyType { get; set; }
    }
}
