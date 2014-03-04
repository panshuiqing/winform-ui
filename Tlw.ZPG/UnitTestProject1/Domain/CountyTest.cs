namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tlw.ZPG.Infrastructure;

    [TestClass]
    public class CountyTest
    {
        [TestMethod]
        public void AddAndFindTest()
        {
            string number = "1234";
            var context = Application.DbContextFactory.GetDbContext();
            var county = new County() { CountyCode = number, CountyName = "aa", FullName = "aabb", OrderNo = 1 };
            context.Set<County>().Add(county);
            context.SaveChanges();
            var County_db = context.Set<County>().First(t => t.ID == county.ID);
            Assert.AreEqual(number, County_db.CountyCode);
        }

        [TestMethod]
        public void AddAndFindTest2()
        {
            string number = "1234";
            var context = Application.DbContextFactory.GetDbContext();
            var county = new County() { CountyCode = number, CountyName = "bb", FullName = "aabb", OrderNo = 1 };
            var sub = new County() { CountyCode = "11", CountyName = "bb", OrderNo = 1, FullName = "bb" };
            county.Nodes.Add(sub);
            context.Set<County>().Add(county);
            context.SaveChanges();
            var County_db = context.Set<County>().First(t => t.ID == county.ID);
            Assert.IsTrue(County_db.CountyCode == number && County_db.Nodes.ToList()[0].CountyCode == "11");
        }

        [TestMethod]
        public void AddAndFindTest3()
        {
            string number = "1234";
            var context = Application.DbContextFactory.GetDbContext();
            var county = new County() { CountyCode = number, CountyName = "cc", FullName = "aabb", OrderNo = 1 };
            county.Parent = new County() { CountyCode = "3432", OrderNo = 2, FullName = "345", CountyName = "gg" };
            context.Set<County>().Add(county);
            context.SaveChanges();
            var County_db = context.Set<County>().First(t => t.ID == county.ID);
            Assert.IsTrue(County_db.CountyCode == number && County_db.Parent.CountyCode == "3432");
        }


        [TestMethod]
        public void RemoveTest()
        {
            var context = Application.DbContextFactory.GetDbContext();
            var county = context.Set<County>().FirstOrDefault();
            if (county != null)
            {
                List<County> nodes = county.Nodes.ToList();
                context.Set<County>().Remove(county);
                context.SaveChanges();
                bool isNull = true;
                foreach (var item in nodes)
                {
                    isNull = context.Set<County>().FirstOrDefault(t => t.ID == item.ID) == null;
                    if (!isNull) break;
                }
                Assert.IsTrue(context.Set<County>().FirstOrDefault(t => t.ID == county.ID) == null && isNull);
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
            var county = context.Set<County>().FirstOrDefault();
            if (county != null)
            {
                county.CountyCode = number;
                context.SaveChanges();
                county = context.Set<County>().First(t => t.ID == county.ID);
                Assert.AreEqual(number, county.CountyCode);
            }
            else
            {
                Assert.Inconclusive("没有数据无法测试");
            }
        }
    }
}
