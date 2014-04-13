using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Infrastructure.DbContext
{
    public class ConfigurationSettings
    {
        public ConfigurationSettings()
        {
            this.Types = new List<Type>();
            this.AssemblyNames = new List<string>();
            this.Assambles = new List<Assembly>();
        }

        public string NameOrConnectionString { get; set; }
        public IList<string> AssemblyNames { get; set; }
        public IList<Assembly> Assambles { get; set; }
        public IList<Type> Types { get; set; }
    }

}
