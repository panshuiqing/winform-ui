using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace Tlw.ZPG.Infrastructure.Caching
{
    public partial class MemoryCacheManager : ICacheManager
    {
        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }
        
        public virtual T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public virtual void Set(string key, object data, int minute)
        {
            if (data == null)
                return;

            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(minute);
            Cache.Add(new CacheItem(key, data), policy);
        }

        public virtual bool IsSet(string key)
        {
            return (Cache.Contains(key));
        }

        public virtual void Remove(string key)
        {
            Cache.Remove(key);
        }
        
        public virtual void Clear()
        {
            foreach (var item in Cache)
                Remove(item.Key);
        }
    }
}