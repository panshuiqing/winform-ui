using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Infrastructure.Domain;

namespace Tlw.ZPG.Infrastructure.Repository
{
    public class RepositoryBase : IRepository<EntityBase>
    {
        #region IRepository<EntityBase> 成员

        public void Add(EntityBase entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(EntityBase entity)
        {
            throw new NotImplementedException();
        }

        public void Update(EntityBase entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<EntityBase> Where(System.Linq.Expressions.Expression<Func<EntityBase, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
