namespace Tlw.ZPG.Domain.Models.Admin
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class Menu : EntityBase
    {
        public Menu()
        {
            this.Functions = new HashSet<Function>();
            this.Nodes = new HashSet<Menu>();
            this.Roles = new HashSet<Role>();
        }

        #region 属性
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public int? ParentId { get; set; }
        public string MenuIcon { get; set; }
        public int OrderNo { get; set; }
        public string MenuCode { get; set; }

        public virtual ICollection<Function> Functions { get; internal set; }
        internal virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Menu> Nodes { get; internal set; }
        public virtual Menu Parent { get; set; } 
        #endregion

        public override IEnumerable<BusinessRule> Validate()
        {
            if (string.IsNullOrEmpty(this.MenuName))
            {
                yield return new BusinessRule("MenuName", "菜单名称不能为空");
            }
        }
    }
}
