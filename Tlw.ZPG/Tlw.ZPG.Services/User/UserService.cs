using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Services.User
{
    public class UserService:ServiceBase<Domain.Models.Admin.User>
    {
        public override void Insert(Tlw.ZPG.Domain.Models.Admin.User entity)
        {
            entity.LoginPassword = Tlw.ZPG.Infrastructure.Utils.SecurityUtil.MD5Encrypt(entity.LoginPassword);
            base.Insert(entity);
        }

        public void ChangePassword(string account, string password, string newPassword)
        {
            if (string.IsNullOrEmpty(account)) throw new ArgumentNullException("用户名不能为空");
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("密码不能为空");
            var user = this.Where(t => t.LoginAccount == account).First();
            if (user == null || !user.CheckPassword(password)) throw new Exception("用户名或密码不正确");
            user.ChangePassword(newPassword);
        }
    }
}
