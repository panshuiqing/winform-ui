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

    internal partial class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("A_Account");
            this.Property(t => t.ID).HasColumnName("AccountId").HasDatabaseGeneratedOption(new Nullable<DatabaseGeneratedOption>(DatabaseGeneratedOption.None));
            this.Property(t => t.TradeId).HasColumnName("TradeId");
            this.Property(t => t.ApplyNumber).HasColumnName("ApplyNumber").IsRequired().HasMaxLength(50);
            this.Property(t => t.Password).HasColumnName("Password").IsRequired().HasMaxLength(50);
            this.Property(t => t.PasswordUpdated).HasColumnName("PasswordUpdated");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.IsOnline).HasColumnName("IsOnline");
            this.Property(t => t.OnlineTime).HasColumnName("OnlineTime");
            this.Property(t => t.Status).HasColumnName("Status");
            this.HasRequired(t => t.AccountInfo).WithRequiredPrincipal();
            this.HasRequired(t => t.Trade).WithMany();
        }
    }
}
