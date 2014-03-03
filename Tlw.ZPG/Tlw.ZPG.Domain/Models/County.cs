namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class County : EntityBase
    {
        public string CountyName { get; set; }
        public int ParentId { get; set; }
        public int OrderNo { get; set; }
        public string FullName { get; set; }
        public string CountyCode { get; set; }

        public virtual ICollection<County> Nodes { get; set; }
        public virtual County Parent { get; set; }
    }
}
