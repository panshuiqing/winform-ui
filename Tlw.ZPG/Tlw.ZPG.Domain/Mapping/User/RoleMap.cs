namespace Tlw.ZPG.Domain.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.Infrastructure;

    using Tlw.ZPG.Domain.Models;
    using Tlw.ZPG.Domain.Models.Admin;

    internal partial class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("U_Role");
            this.Property(t => t.ID).HasColumnName("RoleId");
            this.Property(t => t.RoleName).HasColumnName("RoleName").IsRequired().HasMaxLength(50);
            this.HasMany(t => t.Users).WithMany(t => t.Roles)
                    .Map(m =>
                    {
                        m.ToTable("U_UserRole");
                        m.MapLeftKey("RoleId");
                        m.MapRightKey("UserId");
                    });
        }
    }
}
