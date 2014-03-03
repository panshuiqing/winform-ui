namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class ApplyNumber : EntityBase
    {
        public string Number { get; set; }
        public bool IsUsed { get; set; }
        public Nullable<System.DateTime> UsedTime { get; set; }
    }
}
