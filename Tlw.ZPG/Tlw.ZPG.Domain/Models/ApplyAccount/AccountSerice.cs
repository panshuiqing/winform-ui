using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Infrastructure;
using Tlw.ZPG.Infrastructure.Utils;

namespace Tlw.ZPG.Domain.Models.ApplyAccount
{
    public class AccountSerice
    {
        private static DbSet<TEntity> DbSet<TEntity>()
            where TEntity : EntityBase
        {
            return Application.DbContextFactory.GetCurrentDbContext().Set<TEntity>();
        }

        public static ApplyNumber GetApplyNumber()
        {
            return DbSet<ApplyNumber>().FirstOrDefault(t => !t.IsUsed);
        }

        public static bool ValidateAccount(string applyNumber, string password)
        {
            if (string.IsNullOrEmpty(applyNumber)) throw new ArgumentNullException("竞买号不能为空");
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("密码不能为空");
            var account = DbSet<Account>().Single(t => t.ApplyNumber == applyNumber);
            return account != null && account.Password == SecurityUtil.MD5Encrypt(password);
        }
    }
}
