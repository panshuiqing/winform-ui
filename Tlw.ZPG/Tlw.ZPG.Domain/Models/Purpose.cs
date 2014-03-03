namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class Purpose : EntityBase
    {
        public int LandId { get; set; }
        public string PurposeName { get; set; }
        public int ParentId { get; set; }
    }
}
