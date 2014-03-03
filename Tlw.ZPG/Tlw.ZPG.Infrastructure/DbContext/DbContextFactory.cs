using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Infrastructure.DbContext
{
    public class DbContextFactory
    {
        private static readonly IDbContextFactory factory;

        private DbContextFactory()
        {
            
        }

        static DbContextFactory()
        {
            factory = new Configuration().Configure("name=Tlw_ZPG_Context").AddAssemblyFile("Tlw.ZPG.Domain.dll").BuildDbContextFactory();
        }

        public static IDbContextFactory ContextFactory
        {
            get
            {
                return factory;
            }
        }
    }
}
