using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tlw.ZPG.Infrastructure.DbContext
{
    public interface IDbContextFactory
    {
        EFDbContext GetDbContext();
        EFDbContext GetCurrentDbContext();
        IDbContextContainer DbContextContainer { get; }

        ConfigurationSettings Settings { get; }
    }
}
