using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tlw.ZPG.Infrastructure.DbContext
{
    public class WebCurrentDbContext : CurrentDbContext
    {
        private const string DbContextFactoryMapKey = "DbContextFactoryMapKey";

        protected override EFDbContext DbContext
        {
            get
            {
                return System.Web.HttpContext.Current.Items[DbContextFactoryMapKey] as EFDbContext;
            }
            set
            {
                System.Web.HttpContext.Current.Items[DbContextFactoryMapKey] = value;
            }
        }
    }
}
