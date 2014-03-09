namespace Tlw.ZPG.Domain.Models.Trading
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class LandPurpose : EntityBase
    {
        public int LandId { get; set; }
        public decimal Area { get; set; }
        public int PurposeId { get; set; }
        public Purpose Purpose { get; set; }

    }
}
