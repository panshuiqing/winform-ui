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

    internal partial class FeedBookMap : EntityTypeConfiguration<FeedBook>
    {
        public FeedBookMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("C_FeedBook");
            this.Property(t => t.ID).HasColumnName("FeedBookId");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.Title).HasColumnName("Title").IsRequired().HasMaxLength(100);
            this.Property(t => t.Content).HasColumnName("Content").IsRequired().HasMaxLength(300);
            this.Property(t => t.CustomerName).HasColumnName("CustomerName").HasMaxLength(50);
            this.Property(t => t.ContactPhone).HasColumnName("ContactPhone").HasMaxLength(50);
            this.Property(t => t.LandNames).HasColumnName("LandNames").HasMaxLength(100);
            this.Property(t => t.CardNo).HasColumnName("CardNo").HasMaxLength(50);
        }
    }
}
