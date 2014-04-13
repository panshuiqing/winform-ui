using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Models.Admin;
using Tlw.ZPG.Infrastructure;
using Tlw.ZPG.Infrastructure.Utils;

namespace Tlw.ZPG.Services.Permission
{

    internal class UserService : ServiceBase<User>
    {
        public User FindByAccount(string account)
        {
            return this.Where(t => t.LoginAccount == account).FirstOrDefault();
        }
    }

    internal class RoleService : ServiceBase<Role>
    { }

    internal class FunctionService : ServiceBase<Function>
    { }

    internal class MenuService : ServiceBase<Menu>
    { }

    public class PermissionService
    {
        private UserService userService;
        private RoleService roleService;
        private FunctionService functionService;
        private MenuService menuService;

        public PermissionService()
        {
            userService = new UserService();
            roleService = new RoleService();
            functionService = new FunctionService();
            menuService = new MenuService();
        }

        #region create
        public void CreateUser(Tlw.ZPG.Domain.Models.Admin.User entity)
        {
            entity.EncryptPassword();
            userService.Insert(entity);
        }

        public void CreateRole(Tlw.ZPG.Domain.Models.Admin.Role entity)
        {
            roleService.Insert(entity);
        }

        public void CreateFunction(Tlw.ZPG.Domain.Models.Admin.Function entity)
        {
            functionService.Insert(entity);
        }

        public void CreateMenu(Tlw.ZPG.Domain.Models.Admin.Menu entity)
        {
            menuService.Insert(entity);
        } 
        #endregion

        #region delete
        public void DeleteUser(int userId)
        {
            userService.Delete(userId);
        }

        public void DeleteRole(int roleId)
        {
            roleService.Delete(roleId);
        }

        public void DeleteFunction(int functionId)
        {
            functionService.Delete(functionId);
        }

        public void DeleteMenu(int menuId)
        {
            menuService.Delete(menuId);
        } 
        #endregion

        #region update
        public void UpdateUser(Tlw.ZPG.Domain.Models.Admin.User entity)
        {
            userService.Update(entity);
        }

        public void UpdateRole(Tlw.ZPG.Domain.Models.Admin.Role entity)
        {
            roleService.Update(entity);
        }

        public void UpdateFunction(Tlw.ZPG.Domain.Models.Admin.Function entity)
        {
            functionService.Update(entity);
        }

        public void UpdateMenu(Tlw.ZPG.Domain.Models.Admin.Menu entity)
        {
            menuService.Update(entity);
        }  
        #endregion

        public void ChangePassword(string account, string password, string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword))
            {
                throw new ServiceException("新密码不能为空");
            }
            else
            {
                var user = FindByAccount(account);
                user.ChangePassword(password, newPassword);
            }
        }

        public bool ValidateUser(string account, string password)
        {
            if(string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password)) return false;
            var user = FindByAccount(account);
            return user != null && user.ValidatePassword(password);
        }

        public IList<Function> GetFunctions(int userId)
        {
            var user = userService.FindById(userId);
            return user.GetUserFunctions();
        }

        public IList<Menu> GetMenus(int userId)
        {
            var user = userService.FindById(userId);
            return user.GetUserMenus();
        }

        public void AddRolesToUser(int userId, int[] roles)
        {
            var user = userService.FindById(userId);
            foreach (var item in roles)
            {
                var role = roleService.FindById(item);
                user.Roles.Add(role);
            }
        }

        public void AddMenuToRole(int roleId, int[] menus)
        {
            var role = roleService.FindById(roleId);
            foreach (var item in menus)
            {
                var menu = menuService.FindById(item);
                if (!role.Menus.Contains(menu))
                {
                    role.Menus.Add(menu);
                }
            }
        }

        public void AddFunctionToRole(int roleId, int[] functions)
        {
            var role = roleService.FindById(roleId);
            foreach (var item in functions)
            {
                var function = functionService.FindById(item);
                if (!role.Functions.Contains(function))
                {
                    role.Functions.Add(function);
                }
            }
        }

        public User FindByAccount(string account)
        {
            return userService.FindByAccount(account);
        }
    }
}
