namespace Tlw.ZPG.Domain.Models
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
    }
}
