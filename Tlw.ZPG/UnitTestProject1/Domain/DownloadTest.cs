namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tlw.ZPG.Infrastructure;
    using Tlw.ZPG.Domain.Models.Admin;

    [TestClass]
    public class DownloadTest
    {
        [TestMethod]
        public void AddAndFindTest()
        {
            string number = "1234";
            var context = Application.DbContextFactory.GetDbContext();
            var download = new Download() { CreateTime = DateTime.Now, FileName = number, FilePath = "45646" };
            context.Set<Download>().Add(download);
            context.SaveChanges();
            var download_db = context.Set<Download>().First(t => t.ID == download.ID);
            Assert.AreEqual(number, download_db.FileName);
        }

        [TestMethod]
        public void RemoveTest()
        {
            var context = Application.DbContextFactory.GetDbContext();
            var download = context.Set<Download>().FirstOrDefault();
            if (download != null)
            {
                context.Set<Download>().Remove(download);
                context.SaveChanges();
                Assert.IsNull(context.Set<Download>().FirstOrDefault(t => t.ID == download.ID));
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
            var download = context.Set<Download>().FirstOrDefault();
            if (download != null)
            {
                download.FileName = number;
                context.SaveChanges();
                download = context.Set<Download>().First(t => t.ID == download.ID);
                Assert.AreEqual(number, download.FileName);
            }
            else
            {
                Assert.Inconclusive("没有数据无法测试");
            }
        }
    }
}
