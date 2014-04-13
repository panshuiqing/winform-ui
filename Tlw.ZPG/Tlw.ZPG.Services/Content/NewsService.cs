using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Models;

namespace Tlw.ZPG.Services.Content
{
    public class NewsService : ServiceBase<News>
    {
        public IList<News> Find(NewsRequest request)
        {
            var query = Where(t => t.NewsType == request.NewsType);
            if (string.IsNullOrEmpty(request.Keyword))
            {
                return query.OrderByDescending(t => t.ID).Page(request).ToList();
            }
            return query.Where(t => t.Title.Contains(request.Keyword)).OrderByDescending(t => t.ID).Page(request).ToList();
        }
    }
}
