namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ApplyNumbers
    {
        public int ApplyId { get; set; }
        public string ApplyNumber { get; set; }
        public bool IsUsed { get; set; }
        public Nullable<System.DateTime> UsedTime { get; set; }
    }
}
