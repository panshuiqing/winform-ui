namespace Tlw.ZPG.Domain.Models.Bid
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;
    using Tlw.ZPG.Domain.Models.Admin;
    using Tlw.ZPG.Domain.Models.Trading;

    public partial class AccountAttach : Attachment
    {
        public int AccountId { get; set; }
    }
}
