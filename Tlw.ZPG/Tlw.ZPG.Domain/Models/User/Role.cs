namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class Role : EntityBase
    {
        public Role()
        {
            this.Functions = new HashSet<Function>();
            this.Menus = new HashSet<Menu>();
            this.Users = new HashSet<User>();
        }
    
        public string RoleName { get; set; }
    
        public virtual ICollection<Function> Functions { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
