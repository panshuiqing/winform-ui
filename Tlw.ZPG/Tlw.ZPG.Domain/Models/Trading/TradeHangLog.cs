namespace Tlw.ZPG.Domain.Models.Trading
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Domain.Enums;
    using Tlw.ZPG.Domain.Models.Admin;
    using Tlw.ZPG.Infrastructure;

    public partial class TradeHangLog : EntityBase
    {
        public int TradeId { get; set; }
        public TradeLogType LogType { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int UserId { get; set; }
        public string InnerExplain { get; set; }
        public string OutExplain { get; set; }
        public string Remark { get; set; }

        public virtual Trade Trade { get; set; }
        public virtual User User { get; set; }
    }
}
