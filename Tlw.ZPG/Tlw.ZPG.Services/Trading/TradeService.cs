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
            var query = this.DbSet.AsQueryable();
            query = query.Where(t => t.County.CountyCode.Contains(StringUtil.TrimEnd(request.CountyCode, "0")));
            if (!string.IsNullOrEmpty(request.LandNumber))
            {
                query = query.Where(t => t.Land.LandNumber.Contains(request.LandNumber));
            }
            if (request.BeginTime.HasValue)
            {
                query = query.Where(t => t.CreateTime >= request.BeginTime);
            }
            if (request.EndTime.HasValue)
            {
                query = query.Where(t => t.CreateTime <= request.EndTime);
            }
            if (request.TradeStatus.HasValue)
            {
                query = query.Where(t => t.Status == request.TradeStatus);
            }
            return query.Page(request).ToList();
        }

        /// <summary>
        /// 最新报价Top 20
        /// </summary>
        /// <returns></returns>
        public IList<TradeDetail> FindNewDetails(int count)
        {
            return CurrentDbContext.Set<TradeDetail>().OrderByDescending(t => t.ID).Take(count).ToList();
        }
    }
}
