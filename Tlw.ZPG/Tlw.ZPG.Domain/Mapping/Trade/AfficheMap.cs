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

    internal partial class AfficheMap : EntityTypeConfiguration<Affiche>
    {
        public AfficheMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Z_Affiche");
            this.Property(t => t.ID).HasColumnName("AfficheId");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.Title).HasColumnName("Title").IsRequired().HasMaxLength(200);
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.OtherContent).HasColumnName("OtherContent");
            this.Property(t => t.QualificationRequire).HasColumnName("QualificationRequire");
            this.Property(t => t.CreatorId).HasColumnName("CreatorId");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.SignBeginTime).HasColumnName("SignBeginTime");
            this.Property(t => t.SignEndTime).HasColumnName("SignEndTime");
            this.Property(t => t.TradeBeginTime).HasColumnName("TradeBeginTime");
            this.Property(t => t.TradeEndTime).HasColumnName("TradeEndTime");
            this.Property(t => t.VerifyTime).HasColumnName("VerifyTime");
            this.Property(t => t.IsRelease).HasColumnName("IsRelease");
            this.Property(t => t.ReleaseTime).HasColumnName("ReleaseTime");
            this.Property(t => t.Notice).HasColumnName("Notice");
            this.Property(t => t.CountyId).HasColumnName("CountyId");
            this.Property(t => t.AfficheType).HasColumnName("AfficheType").IsRequired().HasMaxLength(50);
            this.Property(t => t.SellModel).HasColumnName("SellModel").IsRequired().HasMaxLength(50);
            this.Property(t => t.AfficheNumber).HasColumnName("AfficheNumber").IsRequired().HasMaxLength(50);
            this.Property(t => t.AfficheNumberShort).HasColumnName("AfficheNumberShort").IsRequired().HasMaxLength(50);
            this.Property(t => t.RatificationNumber).HasColumnName("RatificationNumber").HasMaxLength(50);
            this.Property(t => t.RatificationOrg).HasColumnName("RatificationOrg").HasMaxLength(100);
            this.Property(t => t.VerifyStatus).HasColumnName("VerifyStatus");
            this.Property(t => t.VerifyUserId).HasColumnName("VerifyUserId");
            this.Property(t => t.Tags).HasColumnName("Tags").HasMaxLength(100);
            this.HasRequired(t => t.County).WithMany();
            this.HasOptional(t => t.VerifyUser).WithMany();
            this.HasRequired(t => t.Creator).WithMany();
            this.HasMany(t => t.Trades).WithRequired(t => t.Affiche).HasForeignKey(t => t.AfficheId);
            this.HasOptional(t => t.Parent).WithMany(t => t.Nodes).HasForeignKey(d => d.ParentId).WillCascadeOnDelete(true);
        }
    }
}
