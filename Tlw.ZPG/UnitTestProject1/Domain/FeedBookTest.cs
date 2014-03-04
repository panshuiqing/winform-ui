namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tlw.ZPG.Infrastructure;

    [TestClass]
    public class FeedBookTest
    {
        [TestMethod]
        public void AddAndFindTest()
        {
            string number = "1234";
            var context = Application.DbContextFactory.GetDbContext();
            var feedBook = new FeedBook() { CardNo = number, ContactPhone = "3453", Content = "34534", CreateTime = DateTime.Now, CustomerName = "453", LandNames = "3535", Title = "34534" };
            context.Set<FeedBook>().Add(feedBook);
            context.SaveChanges();
            var FeedBook_db = context.Set<FeedBook>().First(t => t.ID == feedBook.ID);
            Assert.AreEqual(number, FeedBook_db.CardNo);
        }
        [TestMethod]
        public void RemoveTest()
        {
            var context = Application.DbContextFactory.GetDbContext();
            var feedBook = context.Set<FeedBook>().FirstOrDefault();
            if (feedBook != null)
            {
                context.Set<FeedBook>().Remove(feedBook);
                context.SaveChanges();
                Assert.IsNull(context.Set<FeedBook>().FirstOrDefault(t => t.ID == feedBook.ID));
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
            var feedBook = context.Set<FeedBook>().FirstOrDefault();
            if (feedBook != null)
            {
                feedBook.CardNo = number;
                context.SaveChanges();
                feedBook = context.Set<FeedBook>().First(t => t.ID == feedBook.ID);
                Assert.AreEqual(number, feedBook.CardNo);
            }
            else
            {
                Assert.Inconclusive("没有数据无法测试");
            }
        }
    }
}
