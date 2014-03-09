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

    internal partial class ClientErrorLogMap : EntityTypeConfiguration<ClientErrorLog>
    {
        public ClientErrorLogMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("T_ClientErrorLog");
            this.Property(t => t.ID).HasColumnName("LogId");
            this.Property(t => t.Ip).HasColumnName("Ip").HasMaxLength(50);
            this.Property(t => t.StackTrace).HasColumnName("StackTrace");
            this.Property(t => t.Remark).HasColumnName("Remark").HasMaxLength(500);
            this.Property(t => t.ApplyNumber).HasColumnName("ApplyNumber").HasMaxLength(50);
            this.Property(t => t.SystemInfo).HasColumnName("SystemInfo").HasMaxLength(200);
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
        }
    }
}
