using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tlw.ZPG.Infrastructure.DbContext
{
    public abstract class DbContextContainer : IDbContextContainer
    {
        private const string DbContext_BIND_KEY = "MyDbContext";

        protected abstract EFDbContext DbContext { get; set; }

        public virtual EFDbContext GetCurrentDbContext()
        {
            if (DbContext == null)
            {
                throw new Exception("当前容器没有绑定EFDbContext");
            }
            return DbContext;
        }

        public static void Bind(EFDbContext dbContext)
        {
            GetCurrentDbContext(dbContext.DbContextFactory).DbContext = dbContext;
        }

        public static bool HasBind(IDbContextFactory factory)
        {
            return GetCurrentDbContext(factory).DbContext != null;
        }

        public static EFDbContext Unbind(EFDbContext dbContext)
        {
            var removedDbContext = GetCurrentDbContext(dbContext.DbContextFactory).DbContext;
            GetCurrentDbContext(dbContext.DbContextFactory).DbContext = null;
            return removedDbContext;
        }

        private static DbContextContainer GetCurrentDbContext(IDbContextFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }
            if (factory.DbContextContainer == null)
            {
                throw new Exception("没有配置CurrentDbContext");
            }
            DbContextContainer currentDbContext = factory.DbContextContainer as DbContextContainer;
            if (currentDbContext == null)
            {
                throw new Exception("Current DbContext没有继承CurrentDbContext");
            }
            return currentDbContext;
        }
    }
}
