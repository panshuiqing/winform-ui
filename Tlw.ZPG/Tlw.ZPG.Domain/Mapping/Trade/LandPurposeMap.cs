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

    internal partial class LandPurposeMap : EntityTypeConfiguration<LandPurpose>
    {
        public LandPurposeMap()
        {
            this.HasKey(t => new { t.LandId, t.PurposeId });
            this.ToTable("Z_LandPurpose");
            this.Property(t => t.PurposeId).HasColumnName("PurposeId");
            this.Property(t => t.LandId).HasColumnName("LandId");
            this.Property(t => t.Area).HasColumnName("Area");
        }
    }
}
