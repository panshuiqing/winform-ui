using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tlw.ZPG.Infrastructure.DbContext
{
    public interface IDbContextContainer
    {
        EFDbContext GetCurrentDbContext();
    }
}
