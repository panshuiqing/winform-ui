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

    internal partial class TradeResultMap : EntityTypeConfiguration<TradeResult>
    {
        public TradeResultMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Z_TradeResult");
            this.Property(t => t.ID).HasColumnName("ResultId");
            this.Property(t => t.TradeId).HasColumnName("TradeId");
            this.Property(t => t.LandNumber).HasColumnName("LandNumber").IsRequired().HasMaxLength(50);
            this.Property(t => t.LandPurpose).HasColumnName("LandPurpose").IsRequired().HasMaxLength(500);
            this.Property(t => t.LandType).HasColumnName("LandType");
            this.Property(t => t.LandArea).HasColumnName("LandArea");
            this.Property(t => t.LandLocation).HasColumnName("LandLocation").HasMaxLength(200);
            this.Property(t => t.DealTime).HasColumnName("DealTime");
            this.Property(t => t.DealUser).HasColumnName("DealUser").IsRequired().HasMaxLength(50);
            this.Property(t => t.DealPrice).HasColumnName("DealPrice");
            this.Property(t => t.StartPrice).HasColumnName("StartPrice");
            this.Property(t => t.Content).HasColumnName("Content").IsRequired();
            this.Property(t => t.CountyId).HasColumnName("CountyId");
            this.Property(t => t.CretorId).HasColumnName("CretorId");
            this.Property(t => t.IsOnlineResult).HasColumnName("IsOnlineResult");
        }
    }
}
