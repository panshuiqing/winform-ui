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
            this.Property(t => t.ReservePrice).HasColumnName("ReservePrice").HasMaxLength(50);
            this.Property(t => t.CurrentPrice).HasColumnName("CurrentPrice");
            this.Property(t => t.HangPriceIncrease).HasColumnName("HangPriceIncrease");
            this.Property(t => t.AuctionPriceIncrease).HasColumnName("AuctionPriceIncrease");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.StatusTime).HasColumnName("StatusTime");
            this.Property(t => t.PrevStatus).HasColumnName("PrevStatus");
            this.Property(t => t.DealTime).HasColumnName("DealTime");
            this.Property(t => t.DealAccountId).HasColumnName("DealAccountId");
            this.Property(t => t.CreatorId).HasColumnName("CreatorId");
            this.Property(t => t.DealPrice).HasColumnName("DealPrice");
            this.Property(t => t.Stage).HasColumnName("Stage");
            this.Property(p => p.RowVersion).IsRowVersion();
            this.HasRequired(t => t.Land).WithRequiredPrincipal();
            this.HasOptional(t => t.DealAccount).WithOptionalPrincipal();
            this.HasRequired(t => t.Creator).WithMany();
            this.HasRequired(t => t.County).WithMany();
            this.HasRequired(t => t.TradeResultConfirm).WithRequiredPrincipal();
            
        }
    }
}
