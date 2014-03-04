using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Infrastructure;
using Tlw.ZPG.Infrastructure.Events;

namespace Tlw.ZPG.Services.Events
{
    public class EntityUpdatedEvent<TEntity> : CompositePresentationEvent<TEntity>
        where TEntity : EntityBase
    {
    }
}
