namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;
using Tlw.ZPG.Domain.Models.Admin;
    using Tlw.ZPG.Domain.Models.Trading;

    public partial class ApplyNumber : EntityBase
    {
        public static ApplyNumber Create(string number)
        {
            return new ApplyNumber() { Number = number };
        }

        public string Number { get; set; }
        public bool IsUsed { get; set; }
        public Nullable<System.DateTime> UsedTime { get; set; }
        public int? GrantUserId { get; set; }
        public int? TradeId { get; set; }

        public User GrantUser { get; set; }
        public Trade Trade { get; set; }
    }
}
