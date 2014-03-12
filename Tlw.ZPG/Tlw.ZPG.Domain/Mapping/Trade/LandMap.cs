namespace Tlw.ZPG.Domain.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.Infrastructure;

    using Tlw.ZPG.Domain.Models.Trading;

    internal partial class LandMap : EntityTypeConfiguration<Land>
    {
        public LandMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Z_Land");
            this.Property(t => t.ID).HasColumnName("LandId");
            this.Property(t => t.ProjectName).HasColumnName("ProjectName").IsRequired().HasMaxLength(100);
            this.Property(t => t.LandNumber).HasColumnName("LandNumber").IsRequired().HasMaxLength(100);
            this.Property(t => t.Location).HasColumnName("Location").IsRequired().HasMaxLength(100);
            this.Property(t => t.Area).HasColumnName("Area");
            this.Property(t => t.LandPurpose).HasColumnName("LandPurpose").IsRequired().HasMaxLength(500);
            this.Property(t => t.LandState).HasColumnName("LandState");
            this.Property(t => t.Phones).HasColumnName("Phones").HasMaxLength(200);
            this.Property(t => t.Notice).HasColumnName("Notice");
            this.Property(t => t.Remark).HasColumnName("Remark").HasMaxLength(500);
            this.Property(t => t.OtherCondition).HasColumnName("OtherCondition").HasMaxLength(200);
            this.Property(t => t.Capability).HasColumnName("Capability");
            this.Property(t => t.Density).HasColumnName("Density");
            this.Property(t => t.GreenLandRate).HasColumnName("GreenLandRate");
            this.Property(t => t.FulfilGuarantee).HasColumnName("FulfilGuarantee");
            this.Property(t => t.CompletionGuarantee).HasColumnName("CompletionGuarantee");
            this.Property(t => t.LandScope).HasColumnName("LandScope").HasMaxLength(200);
            this.HasMany(t => t.Purposes).WithRequired();
        }
    }
}
