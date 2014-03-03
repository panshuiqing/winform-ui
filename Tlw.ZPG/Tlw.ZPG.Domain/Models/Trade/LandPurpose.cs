namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class LandPurpose : EntityBase
    {
        public int LandId { get; set; }
        public decimal Area { get; set; }
        public int PurposeId { get; set; }

    }
}
