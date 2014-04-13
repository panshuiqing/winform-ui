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
            string path = System.Web.HttpContext.Current.Server.MapPath("~App_Data/templete/affiche.html");
            string templete = System.IO.File.ReadAllText(path);
            entity.FormatContent(templete);
            base.Update(entity);
        }

        /// <summary>
        /// 补充公告
        /// </summary>
        /// <param name="originalId">原公告id</param>
        public void Replenish(int originalId, Affiche affiche)
        {
            var originalAffiche = this.FindById(originalId);
            originalAffiche.Supply(UserContext.Current.UserId, affiche);
            Insert(affiche);
        }

        public void Release(int afficheId)
        {
            var affiche = this.FindById(afficheId);
            affiche.Release(UserContext.Current.UserId);
        }

        public void AddTrade(int afficheId, Trade trade)
        {
            if (trade == null) throw new ServiceException("trade不能为空");
            var affiche = this.FindById(afficheId);
            Validate(affiche);
            affiche.AddTrade(UserContext.Current.UserId, trade);
        }

        public IList<Affiche> Find(AfficheRequest request)
        {
            var query = this.DbSet.AsQueryable();
            if (!string.IsNullOrEmpty(request.CountyCode))
            {
                query = query.Where(a => a.County.CountyCode.Contains(StringUtil.TrimEnd(request.CountyCode, "0")));
            }
            if (!string.IsNullOrEmpty(request.Title))
            {
                query = query.Where(a => a.Title.Contains(request.Title));
            }
            if (!string.IsNullOrEmpty(request.Tag))
            {
                query = query.Where(t => t.Tags.Contains(request.Tag));
            }
            return query.OrderByDescending(t => t.ID).Page(request).ToList();
        }
    }
}
