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
        public string Email { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Role> Roles { get; internal set; }
        public virtual County County { get; set; } 
        #endregion

        public bool CheckPassword(string password)
        {
            return this.LoginPassword == SecurityUtil.MD5Encrypt(password);
        }

        public void EncryptPassword()
        {
            this.LoginPassword = SecurityUtil.MD5Encrypt(this.LoginPassword);
        }

        public void ChangePassword(string newPassword)
        {
            this.LoginPassword = SecurityUtil.MD5Encrypt(newPassword);
        }

        public IList<Menu> GetUserMenus()
        {
            List<Menu> list = new List<Menu>();
            foreach (var item in this.Roles)
            {
                list.AddRange(item.Menus);
            }
            return list;
        }

        public IList<Function> GetUserFunctions()
        {
            List<Function> list = new List<Function>();
            foreach (var item in this.Roles)
            {
                list.AddRange(item.Functions);
            }
            return list;
        }

        public override IEnumerable<BusinessRule> Validate()
        {
            if (string.IsNullOrEmpty(this.LoginAccount))
            {
                yield return new BusinessRule("登录账号不能为空");
            }
            if (string.IsNullOrEmpty(this.LoginPassword))
            {
                yield return new BusinessRule("登录密码不能为空");
            }
        }
    }
}
