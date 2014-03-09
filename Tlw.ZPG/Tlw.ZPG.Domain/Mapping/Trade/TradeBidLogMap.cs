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

    internal partial class TradeBidLogMap : EntityTypeConfiguration<TradeBidLog>
    {
        public TradeBidLogMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Z_TradeBidLog");
            this.Property(t => t.ID).HasColumnName("LogId");
            this.Property(t => t.TradeId).HasColumnName("TradeId");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.PrevPrice).HasColumnName("PrevPrice");
            this.Property(t => t.AccountId).HasColumnName("AccountId");
            this.Property(t => t.ApplyNumber).HasColumnName("ApplyNumber").IsRequired().HasMaxLength(50);
            this.Property(t => t.Remark).HasColumnName("Remark").HasMaxLength(300);
            this.Property(t => t.IP).HasColumnName("IP").HasMaxLength(100);
            this.Property(t => t.SystemInfo).HasColumnName("SystemInfo").HasMaxLength(300);
            this.Property(t => t.ClientVersion).HasColumnName("ClientVersion").HasMaxLength(50);
            this.HasRequired(t => t.Trade).WithMany(t => t.TradeBidLogs).HasForeignKey(t => t.TradeId);
            this.HasRequired(t => t.Account).WithMany();
        }
    }
}
