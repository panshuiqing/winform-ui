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

    internal partial class TradeHangLogMap : EntityTypeConfiguration<TradeHangLog>
    {
        public TradeHangLogMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Z_TradeHangLog");
            this.Property(t => t.ID).HasColumnName("LogId");
            this.Property(t => t.TradeId).HasColumnName("TradeId");
            this.Property(t => t.LogType).HasColumnName("LogType");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.InnerExplain).HasColumnName("InnerExplain").HasMaxLength(300);
            this.Property(t => t.OutExplain).HasColumnName("OutExplain").HasMaxLength(300);
            this.Property(t => t.Remark).HasColumnName("Remark").HasMaxLength(300);
            this.HasRequired(t => t.Trade).WithMany(t => t.TradeHangLogs).HasForeignKey(t => t.TradeId);
            this.HasRequired(t => t.User).WithMany();
        }
    }
}
