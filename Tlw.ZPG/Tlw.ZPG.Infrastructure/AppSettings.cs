using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Infrastructure
{
    public sealed class AppSettings
    {
        private static readonly Dictionary<string, string> settings = new Dictionary<string, string>();
        static AppSettings()
        {
            foreach (var item in  ConfigurationManager.AppSettings.AllKeys)
            {
                settings[item] = ConfigurationManager.AppSettings[item];
            }
        }

        public static string GetValue(string key)
        {
            return GetValue(key, (string)null);
        }

        public static string GetValue(string key, string defaultValue)
        {
            if (!settings.ContainsKey(key))
            {
                return defaultValue;
            }
            return settings[key];
        }

        public static bool GetValue(string key, bool defaultValue)
        {
            var value = GetValue(key, "");
            return new string[] { "y", "1", "true", "ok" }.Any(t => t == value.ToLower());
        }

        public static double GetValue(string key, double defaultValue)
        {
            var value = GetValue(key, defaultValue.ToString());
            return double.Parse(value);
        }

        public static DateTime GetValue(string key, DateTime defaultValue)
        {
            var value = GetValue(key, defaultValue.ToString());
            return DateTime.Parse(value);
        }
    }
}
