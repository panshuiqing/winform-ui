using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tlw.ZPG.Infrastructure;
using Tlw.ZPG.Infrastructure.DbContext;

namespace Tlw.ZPG.Services
{
    public class ServiceBase<TEntity>
        where TEntity : EntityBase
    {
        public virtual void Insert(TEntity entity)
        {
            if (entity == null) throw new ServiceException("entity");
            Validate(entity);
            this.DbSet.Add(entity);
            LogManager.WriteInsertLog(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null) throw new ServiceException("entity");
            this.DbSet.Remove(entity);
            LogManager.WriteDeleteLog(entity);
        }

        public virtual void Delete(object id)
        {
            if (id == null) throw new ServiceException("id");
            var entity = this.FindById(id);
            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null) throw new ServiceException("entity");
            Validate(entity);
            LogManager.WriteUpdateLog(entity);
        }

        public virtual TEntity FindById(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual IList<TEntity> FindAll()
        {
            return this.DbSet.ToList();
        }

        public IList<TEntity> Find(PageRequest request)
        {
            return this.DbSet.Page(request).ToList();
        }

        private void Validate(TEntity entity)
        {
            var rules = entity.Validate();
            if (rules.Any())
            {
                string message = string.Empty;
                foreach (var item in rules)
                {
                    message += item.Rule + ",";
                }
                throw new ServiceException(message.TrimEnd(','));
            }
        }

        internal IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DbSet.Where(predicate);
        }

        internal DbContext DbContext
        {
            get
            {
                return Application.DbContextFactory.GetCurrentDbContext();
            }
        }

        internal DbSet<TEntity> DbSet
        {
            get
            {
                return Application.DbContextFactory.GetCurrentDbContext().Set<TEntity>();
            }
        }
    }
}
