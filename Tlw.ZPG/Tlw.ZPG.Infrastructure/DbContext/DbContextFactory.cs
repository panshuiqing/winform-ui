using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Infrastructure.DbContext
{
    public class DbContextFactory
    {
        private readonly static DbContextFactory instance = new DbContextFactory();
        private readonly IDbContextFactory factory;

        private DbContextFactory() 
        {
            factory = new Configuration("name=Tlw_ZPG_Context").AddAssembly("Tlw.ZPG.Domain").BuildDbContextFactory();
        }

        public static DbContextFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public EFDbContext GetDbContext()
        {
            return factory.GetDbContext();
        }

        public EFDbContext GetCurrentDbContext()
        {
            return factory.GetCurrentDbContext();
        }
    }
}
