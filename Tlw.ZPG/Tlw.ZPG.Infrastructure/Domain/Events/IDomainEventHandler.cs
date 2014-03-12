using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tlw.ZPG.Infrastructure.Domain.Events
{
    public interface IDomainEventHandler<T> : IDomainEventHandler
        where T : IDomainEvent
    {
        void Handle(T e);
    }

    public interface IDomainEventHandler
    {
        
    }

}
