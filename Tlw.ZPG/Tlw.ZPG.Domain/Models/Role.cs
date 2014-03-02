namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Role
    {
        public Role()
        {
            this.Buttons = new HashSet<Button>();
            this.Menus = new HashSet<Menu>();
            this.Users = new HashSet<User>();
        }
    
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    
        public virtual ICollection<Button> Buttons { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
