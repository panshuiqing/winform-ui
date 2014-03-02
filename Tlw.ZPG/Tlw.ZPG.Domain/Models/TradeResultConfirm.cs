namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TradeResultConfirm
    {
        public int TradeId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<System.DateTime> ConfirmTime { get; set; }
        public System.DateTime ExpiredTime { get; set; }
        public string RandomNum { get; set; }
    }
}
