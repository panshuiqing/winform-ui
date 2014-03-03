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

    internal partial class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("U_User");
            this.Property(t => t.ID).HasColumnName("UserId");
            this.Property(t => t.CountyId).HasColumnName("CountyId");
            this.Property(t => t.UserName).HasColumnName("UserName").IsRequired().IsUnicode(false).HasMaxLength(20);
            this.Property(t => t.Unit).HasColumnName("Unit").IsUnicode(false).HasMaxLength(100);
            this.Property(t => t.LoginAccount).HasColumnName("LoginAccount").IsRequired().IsUnicode(false).HasMaxLength(30);
            this.Property(t => t.LoginPassword).HasColumnName("LoginPassword").IsRequired().IsUnicode(false).HasMaxLength(200);
            this.Property(t => t.LinkPhone).HasColumnName("LinkPhone").IsUnicode(false).HasMaxLength(20);
            this.Property(t => t.EMail).HasColumnName("EMail").IsUnicode(false).HasMaxLength(50);
            this.Property(t => t.Status).HasColumnName("Status");
            this.HasRequired(t => t.County).WithMany().HasForeignKey(d => d.CountyId);
        }
    }
}
