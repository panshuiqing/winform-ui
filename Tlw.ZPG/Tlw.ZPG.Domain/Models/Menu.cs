namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class Menu : EntityBase
    {
        public Menu()
        {
            this.Buttons = new HashSet<Button>();
        }
    
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public int ParentId { get; set; }
        public string MenuIcon { get; set; }
        public int OrderNo { get; set; }
        public string MenuCode { get; set; }
    
        public virtual ICollection<Button> Buttons { get; set; }
        public virtual ICollection<Menu> Nodes { get; set; }
        public virtual Menu Parent { get; set; }
    }
}
