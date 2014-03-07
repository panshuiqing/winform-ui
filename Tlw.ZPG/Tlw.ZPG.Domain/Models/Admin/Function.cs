namespace Tlw.ZPG.Domain.Models.Admin
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class Function : EntityBase
    {
        public Function()
        {
            this.Roles = new HashSet<Role>();
        }

        public string FunctionName { get; set; }
        public string FunctionIcon { get; set; }
        public string FunctionCode { get; set; }
        public string FunctionEvent { get; set; }
        public FunctionPosition FunctionPosition { get; set; }
        public int OrderNo { get; set; }
        public int MenuId { get; set; }
        public string Remark { get; set; }

        public virtual Menu Menu { get; set; }
        internal virtual ICollection<Role> Roles { get; set; }
    }
}
