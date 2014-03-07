namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tlw.ZPG.Infrastructure;

    [TestClass]
    public class SystemLogTest
    {
        [TestMethod]
        public void AddAndFindTest()
        {
            string number = "1234";
            var context = Application.DbContextFactory.GetDbContext();
            var systemLog = new SystemLog() { CreateTime = DateTime.Now, Ip = number, LogType = Enums.SystemLogType.Add, Remark = "4534", Url = "5345", UserId = 4, UserName = "4353" };
            context.Set<SystemLog>().Add(systemLog);
            context.SaveChanges();
            var SystemLog_db = context.Set<SystemLog>().First(t => t.ID == systemLog.ID);
            Assert.AreEqual(number, SystemLog_db.Ip);
        }
        [TestMethod]
        public void RemoveTest()
        {
            var context = Application.DbContextFactory.GetDbContext();
            var systemLog = context.Set<SystemLog>().FirstOrDefault();
            if (systemLog != null)
            {
                context.Set<SystemLog>().Remove(systemLog);
                context.SaveChanges();
                Assert.IsNull(context.Set<SystemLog>().FirstOrDefault(t => t.ID == systemLog.ID));
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
            var systemLog = context.Set<SystemLog>().FirstOrDefault();
            if (systemLog != null)
            {
                systemLog.Ip = number;
                context.SaveChanges();
                systemLog = context.Set<SystemLog>().First(t => t.ID == systemLog.ID);
                Assert.AreEqual(number, systemLog.Ip);
            }
            else
            {
                Assert.Inconclusive("没有数据无法测试");
            }
        }
    }
}
