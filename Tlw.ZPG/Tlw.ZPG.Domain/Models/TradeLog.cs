namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class TradeLog : EntityBase
    {
        public int TradeId { get; set; }
        public TradeType LogType { get; set; }
        public int Status { get; set; }
        public System.DateTime CreateTime { get; set; }
        public decimal Price { get; set; }
        public decimal CurrentPrice { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string InnerExplain { get; set; }
        public string OutrExplain { get; set; }
        public string Remark { get; set; }
        public string IP { get; set; }
        public string SystemInfo { get; set; }
        public string ClientVersion { get; set; }
    
        public virtual Trade Trade { get; set; }
    }
}
