namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class News : EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public NewsType NewsType { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public string CreatorUser { get; set; }
    }
}
