namespace Tlw.ZPG.Domain.Mapping.Admin
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

    internal partial class FunctionMap : EntityTypeConfiguration<Function>
    {
        public FunctionMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("U_Function");
            this.Property(t => t.ID).HasColumnName("FunctionId");
            this.Property(t => t.FunctionName).HasColumnName("FunctionName").IsRequired().HasMaxLength(50);
            this.Property(t => t.FunctionIcon).HasColumnName("FunctionIcon").HasMaxLength(200);
            this.Property(t => t.FunctionCode).HasColumnName("FunctionCode").HasMaxLength(50);
            this.Property(t => t.FunctionEvent).HasColumnName("FunctionEvent").HasMaxLength(100);
            this.Property(t => t.FunctionPosition).HasColumnName("FunctionPosition");
            this.Property(t => t.OrderNo).HasColumnName("OrderNo");
            this.Property(t => t.MenuId).HasColumnName("MenuId");
            this.Property(t => t.Remark).HasColumnName("Remark").HasMaxLength(200);
            this.HasRequired(t => t.Menu).WithMany(t => t.Functions).HasForeignKey(d => d.MenuId);
            this.HasMany(t => t.Roles).WithMany(t => t.Functions)
                   .Map(m =>
                   {
                       m.ToTable("U_RoleFunction");
                       m.MapLeftKey("FunctionId");
                       m.MapRightKey("RoleId");
                   });
        }
    }
}
