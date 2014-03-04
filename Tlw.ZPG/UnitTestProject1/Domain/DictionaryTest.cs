namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tlw.ZPG.Infrastructure;

    [TestClass]
    public class DictionaryTest
    {
        [TestMethod]
        public void AddAndFindTest()
        {
            string number = "1234";
            var context = Application.DbContextFactory.GetDbContext();
            var dictionary = new Dictionary() { DictionaryCode = number, DictionaryName = "aa", DictionaryValue = "3443", OrderNum = 43, Remark = "" };
            context.Set<Dictionary>().Add(dictionary);
            context.SaveChanges();
            var Dictionary_db = context.Set<Dictionary>().First(t => t.ID == dictionary.ID);
            Assert.AreEqual(number, Dictionary_db.DictionaryCode);
        }
        [TestMethod]
        public void RemoveTest()
        {
            var context = Application.DbContextFactory.GetDbContext();
            var dictionary = context.Set<Dictionary>().FirstOrDefault();
            if (dictionary != null)
            {
                context.Set<Dictionary>().Remove(dictionary);
                context.SaveChanges();
                Assert.IsNull(context.Set<Dictionary>().FirstOrDefault(t => t.ID == dictionary.ID));
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
            var dictionary = context.Set<Dictionary>().FirstOrDefault();
            if (dictionary != null)
            {
                dictionary.DictionaryCode = number;
                context.SaveChanges();
                dictionary = context.Set<Dictionary>().First(t => t.ID == dictionary.ID);
                Assert.AreEqual(number, dictionary.DictionaryCode);
            }
            else
            {
                Assert.Inconclusive("没有数据无法测试");
            }
        }
    }
}
