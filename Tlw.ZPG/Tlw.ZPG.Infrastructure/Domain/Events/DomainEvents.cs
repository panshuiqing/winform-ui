using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tlw.ZPG.Infrastructure.Domain.Events
{
    public static class DomainEvents
    {
        private static IDictionary<Type, List<Delegate>> handlerMap = new Dictionary<Type, List<Delegate>>();

        /// <summary>
        /// 订阅事件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        public static void Subscribe<T>(Action<T> action) where T : IDomainEvent
        {
            var type = typeof(T);
            List<Delegate> list = null;
            if (handlerMap.TryGetValue(type, out list))
            {
                list.Add(action);
            }
            else
            {
                list = new List<Delegate>();
                list.Add(action);
                handlerMap[type] = list;
            }
        }

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainEvent"></param>
        public static void Publish<T>(T domainEvent) where T : IDomainEvent
        {
            var type = typeof(T);
            List<Delegate> list = null;
            if (handlerMap.TryGetValue(type, out list))
            {
                foreach (var item in list)
                {
                    item.DynamicInvoke(domainEvent);
                }
            }
        }
    }

}
