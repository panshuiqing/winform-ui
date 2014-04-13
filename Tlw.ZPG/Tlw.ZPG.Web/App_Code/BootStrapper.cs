using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Infrastructure.DbContext;

namespace Tlw.ZPG.Web
{
    public class BootStrapper
    {
        public static void Configure()
        {
            Tlw.ZPG.Services.BootStrapper.Configure();

            Tlw.ZPG.Infrastructure.Application.CacheManager = new Tlw.ZPG.Infrastructure.Caching.WebCacheManager();
            Tlw.ZPG.Infrastructure.Application.Messager = new Tlw.ZPG.Infrastructure.SMS.DefaultMessager();
        }
    }
}
