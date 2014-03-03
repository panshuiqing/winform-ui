namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class TradeMessage : EntityBase
    {
        public int TradeId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
    
        public virtual Trade Trade { get; set; }
    }
}
