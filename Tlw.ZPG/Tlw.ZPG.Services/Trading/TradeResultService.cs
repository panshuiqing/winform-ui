using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Models.Trading;

namespace Tlw.ZPG.Services.Trading
{
    public class TradeResultService:ServiceBase<TradeResultAffiche>
    {
        /// <summary>
        /// 最新top 10
        /// </summary>
        /// <returns></returns>
        public IList<TradeResultAffiche> FindNewList()
        {
            return this.DbSet.OrderByDescending(t => t.DealTime).Take(10).ToList();
        }
    }
}
