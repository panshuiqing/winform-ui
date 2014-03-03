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

    internal partial class DownloadMap : EntityTypeConfiguration<Download>
    {
        public DownloadMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("C_Download");
            this.Property(t => t.ID).HasColumnName("DownloadId");
            this.Property(t => t.FileName).HasColumnName("FileName").IsRequired().HasMaxLength(50);
            this.Property(t => t.FilePath).HasColumnName("FilePath").HasMaxLength(200);
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreatorId).HasColumnName("CreatorId");
        }
    }
}
