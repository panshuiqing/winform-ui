using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tlw.ZPG.Services
{
    public static class PageQueryExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageIndex, int pageSize, out int total)
        {
            total = query.Count();
            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize);
        }

        public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize);
        }
    }
}
