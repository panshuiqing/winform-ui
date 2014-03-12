using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Infrastructure.Caching;
using Tlw.ZPG.Infrastructure.DbContext;

namespace Tlw.ZPG.Infrastructure
{
    /// <summary>
    /// 运用程序全局对象
    /// </summary>
    public static class Application
    {
        /// <summary>
        /// 字典表缓存键
        /// </summary>
        private const string Dictionary_CACHE_KEY = "Dictionary_CACHE_KEY";

        static Application()
        {
            DbContextFactory = new Configuration("name=Tlw_ZPG_Context").AddAssemblyFile("Tlw.ZPG.Domain.dll").BuildDbContextFactory();
        }

        public static IDbContextFactory DbContextFactory
        {
            get;
            set;
        }

        public static SMS.IMessager Messager
        {
            get;
            set;
        }

        public static IUserContext UserContext
        {
            get;
            set;
        }

        public static ICacheManager CacheManager
        {
            get;
            set;
        }

        public static void SetDictionaryCache(IDictionary<string, string> map)
        {
            CacheManager.Set(Dictionary_CACHE_KEY, map, 60);
        }

        public static IDictionary<string, string> GetDictionary()
        {
            return CacheManager.Get<IDictionary<string, string>>(Dictionary_CACHE_KEY);
        }

        public static string GetDictionaryValue(string key, string defaultValue)
        {
            var map = CacheManager.Get<IDictionary<string, string>>(Dictionary_CACHE_KEY);
            if (map == null || map.ContainsKey(key) || map[key] == null)
            {
                return defaultValue;
            }
            return map[key];
        }

        public static bool GetDictionaryValue(string key, bool defaultValue)
        {
            var value = GetDictionaryValue(key, "");
            return new string[] { "y", "1", "true", "true" }.Any(t => t == value);
        }

        public static double GetDictionaryValue(string key, double defaultValue)
        {
            var value = GetDictionaryValue(key, defaultValue.ToString());
            return double.Parse(value);
        }

        public static DateTime GetDictionaryValue(string key, DateTime defaultValue)
        {
            var value = GetDictionaryValue(key, defaultValue.ToString());
            return DateTime.Parse(value);
        }
    }
}
