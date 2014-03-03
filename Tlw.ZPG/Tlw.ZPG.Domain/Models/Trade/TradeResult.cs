namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class TradeResult : EntityBase
    {
        public int TradeId { get; set; }
        public string LandNumber { get; set; }
        public string LandPurpose { get; set; }
        public int LandType { get; set; }
        public decimal LandArea { get; set; }
        public string LandLocation { get; set; }
        public System.DateTime DealTime { get; set; }
        public string DealUser { get; set; }
        public decimal DealPrice { get; set; }
        public decimal StartPrice { get; set; }
        public string Content { get; set; }
        public int CountyId { get; set; }
        public int CretorId { get; set; }
        public bool IsOnlineResult { get; set; }

        public virtual County County { get; set; }
    }
}
