using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Infrastructure.DbContext
{
    public class ThreadStaticDbContext : DbContextContainer
    {
        [ThreadStatic]
        private static EFDbContext _session;

        public ThreadStaticDbContext(IDbContextFactory factory)
        {

        }

        protected override EFDbContext DbContext
        {
            get
            {
                return _session;
            }
            set
            {
                _session = value;
            }
        }
    }	   
}
