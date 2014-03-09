using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Models.Admin;
using Tlw.ZPG.Infrastructure.Utils;

namespace Tlw.ZPG.Services.Admin
{
    public class UserService:ServiceBase<User>
    {
        public override void Insert(Tlw.ZPG.Domain.Models.Admin.User entity)
        {
            if (entity == null) throw new ServiceException("entity");
            entity.EncryptPassword();
            base.Insert(entity);
        }

        public void ChangePassword(string account, string password, string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword)) throw new ServiceException("新密码不能为空");
            var user = FindByAccount(account);
            if (user == null || !user.CheckPassword(password)) throw new ServiceException("用户名或密码不正确");
            user.ChangePassword(newPassword);
        }

        public UserLoginResult Login(string account, string password)
        {
            UserLoginResult result = new UserLoginResult();
            var user = FindByAccount(account);
            if (user == null || !user.CheckPassword(password))
            {
                result.Message = "用户名或密码不正确";
            }
            else
            {
                result.Success = true;
                result.User = user;
            }
            return result;
        }

        public void AddRoles(int userId, int[] roles)
        {
            var user = this.FindById(userId);
            if (user == null) throw new ServiceException("不存在此用户");
            foreach (var item in roles)
            {
                user.Roles.Add(new Role() { ID = item });
            }
        }

        private User FindByAccount(string account)
        {
            return this.Where(t => t.LoginAccount == account).FirstOrDefault();
        }
    }
}
