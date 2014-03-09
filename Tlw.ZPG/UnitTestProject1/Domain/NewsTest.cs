namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tlw.ZPG.Infrastructure;

    [TestClass]
    public class NewsTest 
    {
        [TestMethod]
        public void AddAndFindTest()
        {
            string number = "1234";
            var context = Application.DbContextFactory.GetDbContext();
            var news = new News() { Content = number, CreateTime = DateTime.Now, NewsType = NewsType.FAQ, Title = "aa" };
            context.Set<News>().Add(news);
            context.SaveChanges();
            var News_db = context.Set<News>().First(t => t.ID == news.ID);
            Assert.AreEqual(number, News_db.Content);
        }
        [TestMethod]
        public void RemoveTest()
        {
            var context = Application.DbContextFactory.GetDbContext();
            var news = context.Set<News>().FirstOrDefault();
            if (news != null)
            {
                context.Set<News>().Remove(news);
                context.SaveChanges();
                Assert.IsNull(context.Set<News>().FirstOrDefault(t => t.ID == news.ID));
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
            var news = context.Set<News>().FirstOrDefault();
            if (news != null)
            {
                news.Content = number;
                context.SaveChanges();
                news = context.Set<News>().First(t => t.ID == news.ID);
                Assert.AreEqual(number, news.Content);
            }
            else
            {
                Assert.Inconclusive("没有数据无法测试");
            }
        }
    }
}
