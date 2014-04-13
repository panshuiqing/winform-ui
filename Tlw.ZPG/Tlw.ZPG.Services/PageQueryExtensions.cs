using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tlw.ZPG.Services
{
    public static class PageQueryExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, PageRequest request)
        {
            request.RowCount = query.Count();
            return query.Skip((request.PageIndex - 1) * request.PageSize)
                        .Take(request.PageSize);
        }
    }
}
