using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Models.Trading;
using Tlw.ZPG.Infrastructure.Utils;

namespace Tlw.ZPG.Services.Trading
{
    public class AfficheService : ServiceBase<Affiche>
    {
        public override void Delete(Affiche entity)
        {
            if (entity.IsRelease) throw new ServiceException("公告已发布，不能删除");
            base.Delete(entity);
        }

        public override void Update(Affiche entity)
        {
            if (entity.IsRelease) throw new ServiceException("公告已发布，不能修改");
            base.Update(entity);
        }

        /// <summary>
        /// 补充公告
        /// </summary>
        /// <param name="originalId">原公告</param>
        public void Replenish(int originalId,Affiche affiche)
        {
            var originalAffiche = this.FindById(originalId);
            affiche.Replenish(originalAffiche);
        }

        public void Release(int userId,int afficheId)
        {
            var affiche = this.FindById(afficheId);
            affiche.Release(userId);
        }

        public void AddTrade(int afficheId, int userId, Land land, Trade trade)
        {
            var affiche = this.FindById(afficheId);
            affiche.AddTrade(userId, trade, land);
        }

        public IList<Affiche> Find(AfficheRequest request)
        {
            if (string.IsNullOrEmpty(request.CountyCode) && string.IsNullOrEmpty(request.Title))
                return this.FindAll().ToList();
            var query = from a in this.DbSet
                        where a.County.CountyCode.Contains(StringUtil.TrimEnd(request.CountyCode, "0"))
                        select a;
            if (!string.IsNullOrEmpty(request.Title))
            {
                query.Where(a => a.Title.Contains(request.Title));
            }
            return query.Page(request).ToList();
        }
    }
}
