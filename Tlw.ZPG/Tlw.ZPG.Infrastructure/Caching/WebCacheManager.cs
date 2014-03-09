using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace Tlw.ZPG.Infrastructure.Caching
{
    public partial class WebCacheManager : ICacheManager
    {
        public virtual T Get<T>(string key)
        {
            return (T)HttpRuntime.Cache[key];
        }

        public virtual void Set(string key, object data, int minute)
        {
            if (data == null || string.IsNullOrEmpty(key))
            {
                return;
            }
            HttpRuntime.Cache.Insert(key, data, null, DateTime.Now.AddMinutes(minute), TimeSpan.Zero);
        }

        public virtual bool IsSet(string key)
        {
            bool isSet = false;
            var enumerator = HttpRuntime.Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Key.ToString() == key)
                {
                    isSet = true;
                    break;
                }
            }
            return isSet;
        }

        public virtual void Remove(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }

        public virtual void Clear()
        {
            List<object> keys = new List<object>();
            var enumerator=HttpRuntime.Cache.GetEnumerator();
            while(enumerator.MoveNext())
            {
                keys.Add(enumerator.Key);
            }
            foreach (var item in keys)
            {
                HttpRuntime.Cache.Remove(item.ToString());
            }
        }
    }
}