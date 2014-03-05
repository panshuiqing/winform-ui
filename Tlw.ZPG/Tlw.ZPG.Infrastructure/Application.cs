using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Infrastructure.DbContext;
using Tlw.ZPG.Infrastructure.Events;

namespace Tlw.ZPG.Infrastructure
{
    /// <summary>
    /// 运用程序全局对象
    /// </summary>
    public static class Application
    {
        static Application()
        {
            EventAggregator = new EventAggregator();
            DbContextFactory = new Configuration("name=Tlw_ZPG_Context").AddAssemblyFile("Tlw.ZPG.Domain.dll").BuildDbContextFactory();
        }

        public static IEventAggregator EventAggregator
        {
            get;
            set;
        }

        public static IDbContextFactory DbContextFactory
        {
            get;
            set;
        }

        public static IUserContext UserContext
        {
            get;
            set;
        }
    }
}
