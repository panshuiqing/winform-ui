namespace Tlw.ZPG.Domain.Models.Trading
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class LandAttach : EntityBase
    {
        public string AttachPath { get; set; }
        public string AttachType { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public bool IsAdminUpload { get; set; }
    }
}
