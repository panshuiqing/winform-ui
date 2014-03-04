namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class Download : EntityBase
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
    }
}
