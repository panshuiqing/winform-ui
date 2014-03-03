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

    internal partial class TradeLogMap : EntityTypeConfiguration<TradeLog>
    {
        public TradeLogMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Z_TradeLog");
            this.Property(t => t.ID).HasColumnName("LogId");
            this.Property(t => t.TradeId).HasColumnName("TradeId");
            this.Property(t => t.LogType).HasColumnName("LogType");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.CurrentPrice).HasColumnName("CurrentPrice");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.UserName).HasColumnName("UserName").IsRequired().HasMaxLength(50);
            this.Property(t => t.InnerExplain).HasColumnName("InnerExplain").HasMaxLength(300);
            this.Property(t => t.OutrExplain).HasColumnName("OutrExplain").HasMaxLength(300);
            this.Property(t => t.Remark).HasColumnName("Remark").HasMaxLength(300);
            this.Property(t => t.IP).HasColumnName("IP").HasMaxLength(100);
            this.Property(t => t.SystemInfo).HasColumnName("SystemInfo").HasMaxLength(300);
            this.Property(t => t.ClientVersion).HasColumnName("ClientVersion").HasMaxLength(50);
        }
    }
}
