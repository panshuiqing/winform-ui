namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tlw.ZPG.Infrastructure;

    [TestClass]
    public class GuestBookTest
    {
        [TestMethod]
        public void AddAndFindTest()
        {
            string number = "1234";
            var context = Application.DbContextFactory.GetDbContext();
            var guestBook = new GuestBook() { Address = number, Content = "453", CreateTime = DateTime.Now, GuestName = "4353", Phone = "4353", Title = "453" };
            context.Set<GuestBook>().Add(guestBook);
            context.SaveChanges();
            var GuestBook_db = context.Set<GuestBook>().First(t => t.ID == guestBook.ID);
            Assert.AreEqual(number, GuestBook_db.Address);
        }
        [TestMethod]
        public void RemoveTest()
        {
            var context = Application.DbContextFactory.GetDbContext();
            var guestBook = context.Set<GuestBook>().FirstOrDefault();
            if (guestBook != null)
            {
                context.Set<GuestBook>().Remove(guestBook);
                context.SaveChanges();
                Assert.IsNull(context.Set<GuestBook>().FirstOrDefault(t => t.ID == guestBook.ID));
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
            var guestBook = context.Set<GuestBook>().FirstOrDefault();
            if (guestBook != null)
            {
                guestBook.Address = number;
                context.SaveChanges();
                guestBook = context.Set<GuestBook>().First(t => t.ID == guestBook.ID);
                Assert.AreEqual(number, guestBook.Address);
            }
            else
            {
                Assert.Inconclusive("没有数据无法测试");
            }
        }
    }
}
