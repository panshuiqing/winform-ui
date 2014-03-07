namespace Tlw.ZPG.Domain.Models.Admin
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;
    using Tlw.ZPG.Infrastructure.Utils;

    public partial class User : EntityBase
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
        }

        #region 属性
        public int CountyId { get; set; }
        public string UserName { get; set; }
        public string Unit { get; set; }
        public string LoginAccount { get; set; }
        public string LoginPassword { get; set; }
        public string LinkPhone { get; set; }
        public string EMail { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual County County { get; set; } 
        #endregion

        public void ChangePassword(string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword)) throw new ArgumentNullException("密码不能为空");
            this.LoginPassword = SecurityUtil.MD5Encrypt(newPassword);
        }

        public bool CheckPassword(string password)
        {
            return this.LoginPassword == SecurityUtil.MD5Encrypt(password);
        }
    }
}
