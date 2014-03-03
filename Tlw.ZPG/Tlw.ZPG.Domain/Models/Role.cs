namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class Role : EntityBase
    {
        public Role()
        {
            this.Buttons = new HashSet<Button>();
            this.Menus = new HashSet<Menu>();
            this.Users = new HashSet<User>();
        }
    
        public string RoleName { get; set; }
    
        public virtual ICollection<Button> Buttons { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
