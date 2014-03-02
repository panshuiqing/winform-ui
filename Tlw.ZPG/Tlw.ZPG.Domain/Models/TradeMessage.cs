namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TradeMessage
    {
        public int MessageId { get; set; }
        public int TradeId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
    
        public virtual Trade Trade { get; set; }
    }
}
