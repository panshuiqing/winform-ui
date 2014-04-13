namespace Tlw.ZPG.Domain.Models.Trading
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Tlw.ZPG.Domain.Models.Bid;
    using Tlw.ZPG.Infrastructure;

    public partial class TradeDetail : EntityBase
    {
        public int TradeId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public decimal Price { get; set; }
        public decimal PrevPrice { get; set; }
        public int AccountId { get; set; }
        public string ApplyNumber { get; set; }
        public string Remark { get; set; }
        public string IP { get; set; }
        public string SystemInfo { get; set; }
        [Timestamp]
        internal byte[] RowVersion { get; set; }
    
        public virtual Trade Trade { get; set; }
        public virtual Account Account { get; set; }
    }
}
