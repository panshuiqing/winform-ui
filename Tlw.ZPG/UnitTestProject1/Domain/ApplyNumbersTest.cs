namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ApplyNumbersTest 
    {

        [TestMethod]
        public void AddAndFindTest()
        {
            string number="1234";
            var context = Tlw.ZPG.Infrastructure.DbContext.DbContextFactory.Current.GetDbContext();
            context.Set<ApplyNumber>().Add(new ApplyNumber() { Number = number, IsUsed = false, UsedTime = null });
            var id = context.SaveChanges();
            var applyNumber = context.Set<ApplyNumber>().Find(id);
            Assert.AreEqual(number, applyNumber.Number);
        }

        [TestMethod]
        public void RemoveTest()
        {
            var context = Tlw.ZPG.Infrastructure.DbContext.DbContextFactory.Current.GetDbContext();
            var applyNumber = context.Set<ApplyNumber>().FirstOrDefault();
            if (applyNumber != null)
            {
                context.Set<ApplyNumber>().Remove(applyNumber);
                context.SaveChanges();
                Assert.IsNull(context.Set<ApplyNumber>().Find(applyNumber.ID));
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
            var context = Tlw.ZPG.Infrastructure.DbContext.DbContextFactory.Current.GetDbContext();
            var applyNumber = context.Set<ApplyNumber>().FirstOrDefault();
            if (applyNumber != null)
            {
                applyNumber.Number = number;
                context.SaveChanges();
                applyNumber = context.Set<ApplyNumber>().FirstOrDefault(t => t.ID == applyNumber.ID);
                Assert.AreEqual(number, applyNumber.Number);
            }
            else
            {
                Assert.Inconclusive("没有数据无法测试");
            }
        }

        [TestMethod]
        public void SelectTest()
        {
        }
    }
}
