using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tlw.ZPG.Infrastructure;
using Tlw.ZPG.Infrastructure.DbContext;
using Tlw.ZPG.Services.Events;

namespace Tlw.ZPG.Services
{
    public class ServiceBase<TEntity>
        where TEntity : EntityBase
    {
        public virtual void Insert(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            this.DbSet.Add(entity);
            Application.EventAggregator.GetEvent<EntityInsertedEvent<TEntity>>().Publish(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            this.DbSet.Remove(entity);
            Application.EventAggregator.GetEvent<EntityDeletedEvent<TEntity>>().Publish(entity);
        }

        public virtual void Delete(object id)
        {
            if (id == null) throw new ArgumentNullException("id");
            var entity = this.FindById(id);
            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            Application.EventAggregator.GetEvent<EntityUpdatedEvent<TEntity>>().Publish(entity); 
        }

        public virtual TEntity FindById(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual ICollection<TEntity> FindAll()
        {
            return this.DbSet.ToList();
        }

        protected IQueryable<TEntity> Where(Expression<Func<TEntity,bool>> predicate)
        {
            return this.DbSet.Where(predicate);
        }

        protected DbContext DbContext
        {
            get
            {
                return Application.DbContextFactory.GetCurrentDbContext();
            }
        }

        protected DbSet<TEntity> DbSet
        {
            get
            {
                return Application.DbContextFactory.GetCurrentDbContext().Set<TEntity>();
            }
        }
    }
}
