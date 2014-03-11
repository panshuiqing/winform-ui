namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Domain.Enums;
    using Tlw.ZPG.Domain.Models.Admin;
    using Tlw.ZPG.Infrastructure;

    public partial class News : EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public NewsType NewsType { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
    }
}
