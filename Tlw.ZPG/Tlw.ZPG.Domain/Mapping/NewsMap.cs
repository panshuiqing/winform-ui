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

    internal partial class NewsMap : EntityTypeConfiguration<News>
    {
        public NewsMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("C_News");
            this.Property(t => t.ID).HasColumnName("NewsId");
            this.Property(t => t.Title).HasColumnName("Title").IsRequired().HasMaxLength(100);
            this.Property(t => t.Content).HasColumnName("Content").IsRequired();
            this.Property(t => t.NewsType).HasColumnName("NewsType");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreatorId).HasColumnName("CreatorId");
            this.HasRequired(t => t.Creator).WithMany();
        }
    }
}
