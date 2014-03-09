namespace Tlw.ZPG.Domain.Models.Trading
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class TradeResultConfirm : EntityBase
    {
        public System.DateTime CreateTime { get; set; }
        public Nullable<System.DateTime> ConfirmTime { get; set; }
        public System.DateTime ExpiredTime { get; set; }
        public string RandomNum { get; set; }
        public string Content { get; set; }
        public string LandNumber { get; set; }
        public string IP { get; set; }
        public string SystemInfo { get; set; }
    }
}
