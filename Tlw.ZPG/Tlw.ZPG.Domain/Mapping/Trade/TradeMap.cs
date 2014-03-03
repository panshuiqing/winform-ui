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

    internal partial class TradeMap : EntityTypeConfiguration<Trade>
    {
        public TradeMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Z_Trade");
            this.Property(t => t.ID).HasColumnName("TradeId");
            this.Property(t => t.LandId).HasColumnName("LandId");
            this.Property(t => t.AfficheId).HasColumnName("AfficheId");
            this.Property(t => t.SignBeginTime).HasColumnName("SignBeginTime");
            this.Property(t => t.SignEndTime).HasColumnName("SignEndTime");
            this.Property(t => t.TradeBeginTime).HasColumnName("TradeBeginTime");
            this.Property(t => t.TradeEndTime).HasColumnName("TradeEndTime");
            this.Property(t => t.StartPrice).HasColumnName("StartPrice");
            this.Property(t => t.ReservePrice).HasColumnName("ReservePrice");
            this.Property(t => t.HangPriceRange).HasColumnName("HangPriceRange");
            this.Property(t => t.AuctionPriceRange).HasColumnName("AuctionPriceRange");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.DealTime).HasColumnName("DealTime");
            this.Property(t => t.DealUserId).HasColumnName("DealUserId");
            this.Property(t => t.Stage).HasColumnName("Stage");
            this.HasRequired(t => t.Land).WithRequiredPrincipal();
            this.HasRequired(t => t.TradeResultConfirm).WithRequiredPrincipal();
            this.HasMany(t => t.TradeMessages).WithRequired();
            this.HasMany(t => t.TradeLogs).WithRequired();
        }
    }
}
