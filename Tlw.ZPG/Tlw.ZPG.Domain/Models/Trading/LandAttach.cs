namespace Tlw.ZPG.Domain.Models.Trading
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;
    using Tlw.ZPG.Domain.Models.Admin;
    using Tlw.ZPG.Domain.Models.Trading;

    public partial class LandAttach : Attachment
    {
        public int LandId { get; set; }
    }
}
