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

    internal partial class LandAttachMap : EntityTypeConfiguration<LandAttach>
    {
        public LandAttachMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Z_LandAttach");
            this.Property(t => t.ID).HasColumnName("AttachId");
            this.Property(t => t.LandId).HasColumnName("LandId");
            this.Property(t => t.AttachPath).HasColumnName("AttachPath").IsRequired().HasMaxLength(200);
            this.Property(t => t.AttachType).HasColumnName("AttachType").IsRequired().HasMaxLength(50);
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreatorId).HasColumnName("CreatorId");
            this.Property(t => t.IsAdminCreate).HasColumnName("IsAdminCreate");
        }
    }
}
