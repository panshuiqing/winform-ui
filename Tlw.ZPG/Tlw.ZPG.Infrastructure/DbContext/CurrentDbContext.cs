using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tlw.ZPG.Infrastructure.DbContext
{
    public abstract class CurrentDbContext : ICurrentDbContext
    {
        private const string DbContext_BIND_KEY = "MyDbContext";

        protected abstract EFDbContext DbContext { get; set; }

        public virtual EFDbContext GetCurrentDbContext()
        {
            if (DbContext == null)
            {
                throw new Exception("No DbContext bound to the current context");
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

        public static EFDbContext Unbind(IDbContextFactory factory)
        {
            var removedDbContext = GetCurrentDbContext(factory).DbContext;
            GetCurrentDbContext(factory).DbContext = null;
            return removedDbContext;
        }

        private static CurrentDbContext GetCurrentDbContext(IDbContextFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }
            if (factory.CurrentDbContext == null)
            {
                throw new Exception("没有配置CurrentDbContext");
            }
            CurrentDbContext currentDbContext = factory.CurrentDbContext as CurrentDbContext;
            if (currentDbContext == null)
            {
                throw new Exception("Current DbContext没有继承CurrentDbContext");
            }
            return currentDbContext;
        }
    }
}
