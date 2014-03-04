namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tlw.ZPG.Infrastructure;

    [TestClass]
    public class ApplyNumberTest 
    {

        [TestMethod]
        public void AddAndFindTest()
        {
            string number="1234";
            var context = Application.DbContextFactory.GetDbContext();
            var applyNumber = new ApplyNumber() { Number = number, IsUsed = false, UsedTime = null };
            context.Set<ApplyNumber>().Add(applyNumber);
            context.SaveChanges();
            var applyNumber_db = context.Set<ApplyNumber>().First(t => t.ID == applyNumber.ID);
            Assert.AreEqual(number, applyNumber_db.Number);
        }

        [TestMethod]
        public void RemoveTest()
        {
            var context = Application.DbContextFactory.GetDbContext();
            var applyNumber = context.Set<ApplyNumber>().FirstOrDefault();
            if (applyNumber != null)
            {
                context.Set<ApplyNumber>().Remove(applyNumber);
                context.SaveChanges();
                Assert.IsNull(context.Set<ApplyNumber>().FirstOrDefault(t => t.ID == applyNumber.ID));
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
            var applyNumber = context.Set<ApplyNumber>().FirstOrDefault();
            if (applyNumber != null)
            {
                applyNumber.Number = number;
                context.SaveChanges();
                applyNumber = context.Set<ApplyNumber>().First(t => t.ID == applyNumber.ID);
                Assert.AreEqual(number, applyNumber.Number);
            }
            else
            {
                Assert.Inconclusive("没有数据无法测试");
            }
        }
    }
}
