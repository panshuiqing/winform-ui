using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tlw.ZPG.Infrastructure
{
    public interface IEntity<TID> : IValidatableEntity
    {
        TID ID { get; }
    }
}
