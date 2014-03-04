using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tlw.ZPG.Infrastructure.Events
{
    public interface IEventHandler<T> where T : EntityBase
    {
        void Handle(T e);
    }
}
