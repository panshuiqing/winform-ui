namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
        }
    
        public int UserId { get; set; }
        public int CountyId { get; set; }
        public string UserName { get; set; }
        public string Unit { get; set; }
        public string LoginAccount { get; set; }
        public string LoginPassword { get; set; }
        public string LinkPhone { get; set; }
        public string EMail { get; set; }
        public int Status { get; set; }
    
        public virtual ICollection<Role> Roles { get; set; }
    }
}
