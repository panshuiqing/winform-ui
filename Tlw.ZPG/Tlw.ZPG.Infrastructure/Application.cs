using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Infrastructure.Caching;
using Tlw.ZPG.Infrastructure.DbContext;

namespace Tlw.ZPG.Infrastructure
{
    /// <summary>
    /// 运用程序全局对象
    /// </summary>
    public sealed class Application
    {
        private Application() { }

        public static SMS.IMessager Messager
        {
            get;
            set;
        }

        public static ICacheManager CacheManager
        {
            get;
            set;
        }
    }
}
