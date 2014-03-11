using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Enums;

namespace Tlw.ZPG.Services.Bid
{
    public class AccountRequest : PageRequest
    {
        public AccountVerifyStatus? VerifyStatus { get; set; }
    }
}
