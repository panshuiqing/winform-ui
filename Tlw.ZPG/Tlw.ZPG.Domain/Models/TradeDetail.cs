namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TradeDetail
    {
        public int DetailId { get; set; }
        public int TradeId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public decimal Price { get; set; }
        public decimal PrevPrice { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Remark { get; set; }
    
        public virtual Trade Trade { get; set; }
        public virtual County County { get; set; }
    }
}
