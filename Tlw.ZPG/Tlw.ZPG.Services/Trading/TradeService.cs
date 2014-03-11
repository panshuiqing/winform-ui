using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Models.Trading;
using Tlw.ZPG.Infrastructure.Utils;

namespace Tlw.ZPG.Services.Trading
{
    public class TradeService : ServiceBase<Trade>
    {
        public IList<Trade> Find(TradeRequest request)
        {
            var query = from t in this.DbSet
                        where t.County.CountyCode.Contains(StringUtil.TrimEnd(request.CountyCode,"0"))
                        select t;
            if (!string.IsNullOrEmpty(request.LandNumber))
            {
                query.Where(t => t.Land.LandNumber.Contains(request.LandNumber));
            }
            if (request.BeginTime.HasValue)
            {
                query.Where(t => t.CreateTime >= request.BeginTime);
            }
            if (request.EndTime.HasValue)
            {
                query.Where(t => t.CreateTime <= request.EndTime);
            }
            if (request.TradeStatus.HasValue)
            {
                query.Where(t => t.Status == request.TradeStatus);
            }
            return query.Page(request).ToList();
        }
    }
}
