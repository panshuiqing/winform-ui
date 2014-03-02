namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Purpose
    {
        public int PurposeId { get; set; }
        public int LandId { get; set; }
        public string PurposeName { get; set; }
        public int ParentId { get; set; }
    }
}
