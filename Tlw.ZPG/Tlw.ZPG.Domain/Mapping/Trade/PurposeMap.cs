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

    internal partial class PurposeMap : EntityTypeConfiguration<Purpose>
    {
        public PurposeMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Z_Purpose");
            this.Property(t => t.ID).HasColumnName("PurposeId");
            this.Property(t => t.PurposeName).HasColumnName("PurposeName").IsRequired().HasMaxLength(100);
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.OrderNum).HasColumnName("OrderNum");
            this.HasRequired(t => t.Parent).WithMany(t => t.Nodes).HasForeignKey(d => d.ParentId);
        }
    }
}
