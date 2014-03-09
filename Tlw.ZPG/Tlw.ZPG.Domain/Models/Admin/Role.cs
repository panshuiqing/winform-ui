namespace Tlw.ZPG.Domain.Models.Admin
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

        public virtual ICollection<Function> Functions { get; internal set; }
        public virtual ICollection<Menu> Menus { get; internal set; }
        internal virtual ICollection<User> Users { get; set; }

        public override IEnumerable<BusinessRule> Validate()
        {
            if (string.IsNullOrEmpty(this.RoleName))
            {
                yield return new BusinessRule("角色名称不能为空");
            }
        }
    }
}
