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
    using Tlw.ZPG.Domain.Models.Bid;

    internal partial class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("A_Account");
            this.Property(t => t.ID).HasColumnName("AccountId").HasDatabaseGeneratedOption(new Nullable<DatabaseGeneratedOption>(DatabaseGeneratedOption.None));
            this.Property(t => t.TradeId).HasColumnName("TradeId");
            this.Property(t => t.ApplyNumber).HasColumnName("ApplyNumber").HasMaxLength(50);
            this.Property(t => t.Password).HasColumnName("Password").HasMaxLength(50);
            this.Property(t => t.PasswordUpdated).HasColumnName("PasswordUpdated");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.IsOnline).HasColumnName("IsOnline");
            this.Property(t => t.OnlineTime).HasColumnName("OnlineTime");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.RandomNumber).HasColumnName("RandomNumber").IsRequired().HasMaxLength(50);
            this.Property(t => t.ApplyType).HasColumnName("ApplyType");
            this.Property(t => t.ContactId).HasColumnName("ContactId");
            this.Property(t => t.AccountPersonId).HasColumnName("AccountPersonId");
            this.Property(t => t.AgentId).HasColumnName("AgentId");
            this.Property(t => t.CorporationId).HasColumnName("CorporationId");
            this.Property(t => t.VerifyStatus).HasColumnName("VerifyStatus");
            this.HasOptional(t => t.Agent).WithOptionalDependent();
            this.HasRequired(t => t.Contact).WithRequiredDependent();
            this.HasOptional(t => t.Corporation).WithOptionalDependent();
            this.HasRequired(t => t.AccountPerson).WithRequiredDependent();
            this.HasMany(t => t.UnionBidPersons).WithRequired();
            this.HasMany(t => t.AccountVerifies).WithRequired();
            this.HasRequired(t => t.Trade).WithMany().WillCascadeOnDelete(false);
            this.HasMany(t => t.Attachments).WithRequired();
        }
    }
}
