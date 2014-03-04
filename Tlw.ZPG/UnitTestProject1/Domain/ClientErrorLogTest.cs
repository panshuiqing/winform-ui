namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tlw.ZPG.Infrastructure;

    [TestClass]
    public class ClientErrorLogTest
    {
        [TestMethod]
        public void AddAndFindTest()
        {
            string number = "1234";
            var context = Application.DbContextFactory.GetDbContext();
            var log = new ClientErrorLog() { ApplyNumber = number, CreateTime = DateTime.Now, Ip = "222.44.4.4", Remark = "", SystemInfo = "" };
            context.Set<ClientErrorLog>().Add(log);
            context.SaveChanges();
            var log_db = context.Set<ClientErrorLog>().First(t => t.ID == log.ID);
            Assert.AreEqual(number, log_db.ApplyNumber);
        }

        [TestMethod]
        public void RemoveTest()
        {
            var context = Application.DbContextFactory.GetDbContext();
            var log = context.Set<ClientErrorLog>().FirstOrDefault();
            if (log != null)
            {
                context.Set<ClientErrorLog>().Remove(log);
                context.SaveChanges();
                Assert.IsNull(context.Set<ClientErrorLog>().FirstOrDefault(t => t.ID == log.ID));
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
            var log = context.Set<ClientErrorLog>().FirstOrDefault();
            if (log != null)
            {
                log.ApplyNumber = number;
                context.SaveChanges();
                log = context.Set<ClientErrorLog>().First(t => t.ID == log.ID);
                Assert.AreEqual(number, log.ApplyNumber);
            }
            else
            {
                Assert.Inconclusive("没有数据无法测试");
            }
        }
    }
}
