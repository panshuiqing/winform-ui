using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tlw.ZPG.Infrastructure.Domain.Events
{
    public sealed class DomainEvents
    {
        private DomainEvents() { }

        private static IDictionary<Type, List<IDomainEventHandler>> handlerMap = new Dictionary<Type, List<IDomainEventHandler>>();

        /// <summary>
        /// 订阅事件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        public static void Subscribe<T>(IDomainEventHandler<T> handler) 
            where T : IDomainEvent
        {
            var type = typeof(T);
            List<IDomainEventHandler> list = null;
            if (!handlerMap.TryGetValue(type, out list))
            {
                list = new List<IDomainEventHandler>();
                handlerMap[type] = list;
            }
            handlerMap[type].Add((IDomainEventHandler)handler);
        }

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainEvent"></param>
        public static void Publish<T>(T domainEvent) 
            where T : IDomainEvent
        {
            var type = typeof(T);
            List<IDomainEventHandler> list = null;
            if (handlerMap.TryGetValue(type, out list))
            {
                foreach (var item in list)
                {
                    ((IDomainEventHandler<T>)item).Handle(domainEvent);
                }
            }
        }
    }

}
