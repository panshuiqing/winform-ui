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

    internal partial class TradeMessageMap : EntityTypeConfiguration<TradeMessage>
    {
        public TradeMessageMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Z_TradeMessage");
            this.Property(t => t.ID).HasColumnName("MessageId");
            this.Property(t => t.TradeId).HasColumnName("TradeId");
            this.Property(t => t.Title).HasColumnName("Title").HasMaxLength(50);
            this.Property(t => t.Content).HasColumnName("Content").IsRequired();
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreatorId).HasColumnName("CreatorId");
        }
    }
}
