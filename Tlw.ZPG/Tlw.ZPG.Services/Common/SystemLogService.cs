using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Models;

namespace Tlw.ZPG.Services.Common
{
    public class SystemLogService : ServiceBase<SystemLog>
    {
        public IList<SystemLog> Find(PageRequest request)
        {
            return this.DbSet.Page(request).ToList();
        }
    }
}
