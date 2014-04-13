using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tlw.ZPG.Infrastructure.DbContext
{
    public class WebDbContext : DbContextContainer
    {
        private IDbContextFactory factory;

        public WebDbContext(IDbContextFactory factory)
        {
            this.factory = factory;
        }

        protected override EFDbContext DbContext
        {
            get
            {
                return System.Web.HttpContext.Current.Items[factory] as EFDbContext;
            }
            set
            {
                System.Web.HttpContext.Current.Items[factory] = value;
            }
        }
    }
}
