using System;
using System.Collections.Generic;

namespace Tlw.ZPG.Infrastructure
{
    public abstract class EntityBase : EntityBase<int>
    {
       
        public override bool IsTransient
        {
            get
            {
                return this.ID == 0;
            }
        }
    }

    public abstract class EntityBase<TID> : IEntity<TID> 
    {
        public virtual TID ID 
        { 
            get;
            set;
        }

        public virtual IEnumerable<BusinessRule> Validate()
        {
            return new BusinessRule[] { };
        }

        public abstract bool IsTransient { get; }

        public override bool Equals(object entity)
        {
            return entity != null
               && entity is EntityBase<TID>
               && this == (EntityBase<TID>)entity;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public static bool operator ==(EntityBase<TID> entity1, EntityBase<TID> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }

            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }

            if (entity1.ID.ToString() == entity2.ID.ToString())
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(EntityBase<TID> entity1, EntityBase<TID> entity2)
        {
            return (!(entity1 == entity2));
        }
    }

}
