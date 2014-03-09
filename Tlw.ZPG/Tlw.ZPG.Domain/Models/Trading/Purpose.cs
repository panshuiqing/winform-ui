namespace Tlw.ZPG.Domain.Models.Trading
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class Purpose : EntityBase
    {
        public Purpose()
        {
            this.Nodes = new HashSet<Purpose>();
        }
    
        public string PurposeName { get; set; }
        public int? ParentId { get; set; }
        public int OrderNum { get; set; }

        public virtual ICollection<Purpose> Nodes { get; internal set; }
        public virtual Purpose Parent { get; set; }
    }
}
