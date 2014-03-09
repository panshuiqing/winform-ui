using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tlw.ZPG.Domain.Models.Admin;
using Tlw.ZPG.Infrastructure;

namespace UnitTestProject1.Domain.Admin
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void AddAndFindTest()
        {
            string number = "1234";
            var context = Application.DbContextFactory.GetDbContext();
            var user = new User() { Email = "email", UserName = number, Unit = "unit", LoginAccount = "account", LoginPassword = "aa" };
            context.Set<User>().Add(user);
            context.SaveChanges();
            var log_db = context.Set<User>().First(t => t.ID == user.ID);
            Assert.AreEqual(number, log_db.UserName);
        }

        [TestMethod]
        public void AddAndFindTest2()
        {
            string number = "1234";
            var context = Application.DbContextFactory.GetDbContext();
            var user = new User() { Email = "email", UserName = number, Unit = "unit", LoginAccount = "account", LoginPassword = "aa" };
            var role = new Role() { ID = 3, RoleName="cc" };
            context.Set<Role>().Attach(role);
            context.Entry(role).State = System.Data.EntityState.Added;
            user.Roles.Add(role);
            context.Set<User>().Add(user);
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
            }
            var log_db = context.Set<User>().First(t => t.ID == user.ID);
            Assert.AreEqual(number, log_db.UserName);
        }

        [TestMethod]
        public void RemoveTest()
        {
            var context = Application.DbContextFactory.GetDbContext();
            var user = context.Set<User>().FirstOrDefault();
            if (user != null)
            {
                List<Role> nodes = user.Roles.ToList();
                context.Set<User>().Remove(user);
                context.SaveChanges();
                bool isNull = true;
                foreach (var item in nodes)
                {
                    isNull = context.Set<User>().FirstOrDefault(t => t.ID == item.ID) == null;
                    if (!isNull) break;
                }
                Assert.IsTrue(context.Set<User>().FirstOrDefault(t => t.ID == user.ID) == null && isNull);
            }
            else
            {
                Assert.Inconclusive("没有数据无法测试");
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            string number = Guid.NewGuid().ToString();
            var context = Application.DbContextFactory.GetDbContext();
            var county = context.Set<User>().FirstOrDefault();
            if (county != null)
            {
                county.LoginAccount = number;
                context.SaveChanges();
                county = context.Set<User>().First(t => t.ID == county.ID);
                Assert.AreEqual(number, county.LoginAccount);
            }
            else
            {
                Assert.Inconclusive("没有数据无法测试");
            }
        }
    }
}
