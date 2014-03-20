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

    internal partial class AttachmentMap : EntityTypeConfiguration<Attachment>
    {
        public AttachmentMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("T_Attachment");
            this.Property(t => t.ID).HasColumnName("AttachmentId");
            this.Property(t => t.FilePath).HasColumnName("FilePath").IsRequired().HasMaxLength(200);
            this.Property(t => t.FileTitle).HasColumnName("AttachType").IsRequired().HasMaxLength(100);
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.UserId).HasColumnName("CreatorId");
            this.Property(t => t.AccountId).HasColumnName("AccountId");
            this.Property(t => t.ItemId).HasColumnName("ItemId");
        }
    }
}
