using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Infrastructure.DbContext
{
    public class Configuration
    {
        public ConfigurationSettings Settings
        {
            get;
            private set;
        }

        public Configuration()
        {
            this.Settings = new ConfigurationSettings();
            this.Settings.NameOrConnectionString = "DbContext";
        }

        public Configuration(ConfigurationSettings settings)
        {
            this.Settings = settings;
        }

        public Configuration(string nameOrConnectionString)
            : this()
        {
            this.Settings.NameOrConnectionString = nameOrConnectionString;
        }

        public Configuration AddClass(Type type)
        {
            this.Settings.Types.Add(type);
            return this;
        }

        public Configuration AddAssembly(Assembly assembly)
        {
            this.Settings.Assambles.Add(assembly);
            return this;
        }

        public Configuration AddAssemblyFile(string fileName)
        {
            this.Settings.AssemblyFileNames.Add(fileName);
            return this;
        }

        public IDbContextFactory BuildDbContextFactory()
        {
            return new DbContextFactoryImpl(this.Settings);
        }
    }
}
