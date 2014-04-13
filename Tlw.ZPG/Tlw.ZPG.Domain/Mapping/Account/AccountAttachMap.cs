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

    internal partial class AccountAttachMap : EntityTypeConfiguration<AccountAttach>
    {
        public AccountAttachMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("A_AccountAttach");
            this.Property(t => t.ID).HasColumnName("AttachId");
            this.Property(t => t.FilePath).HasColumnName("FilePath").IsRequired().HasMaxLength(200);
            this.Property(t => t.FileTitle).HasColumnName("FileTitle").IsRequired().HasMaxLength(100);
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.AccountId).HasColumnName("AccountId");
        }
    }
}
