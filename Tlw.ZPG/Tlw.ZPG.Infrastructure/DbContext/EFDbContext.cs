using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Tlw.ZPG.Infrastructure.DbContext
{
    public class EFDbContext : System.Data.Entity.DbContext
    {
        public EFDbContext(IDbContextFactory factory)
            : base(factory.Settings.NameOrConnectionString)
        {
            DbContextFactory = factory;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            IList<Type> types = new List<Type>();
            if (this.DbContextFactory.Settings.Assambles.Count > 0)
            {
                foreach (var item in this.DbContextFactory.Settings.Assambles)
                {
                    foreach (var type in item.GetTypes())
                    {
                        types.Add(type);
                    }
                }
            }
            else if (this.DbContextFactory.Settings.Types.Count > 0)
            {
                foreach (var type in this.DbContextFactory.Settings.Types)
                {
                    types.Add(type);
                }
            }
            else if (this.DbContextFactory.Settings.AssemblyNames.Count > 0)
            {
                foreach (var item in this.DbContextFactory.Settings.AssemblyNames)
                {
                    foreach (var type in  Assembly.Load(item).GetTypes())
                    {
                        types.Add(type);
                    }
                }
            }
            else
            {
                foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
                {
                    types.Add(type);
                }
            }
            var typesToRegister = types
                 .Where(type => !String.IsNullOrEmpty(type.Namespace))
                 .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

        #region IDbContext 成员

        public IDbContextFactory DbContextFactory
        {
            get;
            private set;
        }

        #endregion
    }
}
