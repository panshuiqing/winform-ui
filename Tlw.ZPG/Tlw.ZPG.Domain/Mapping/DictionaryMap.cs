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

    internal partial class DictionaryMap : EntityTypeConfiguration<Dictionary>
    {
        public DictionaryMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("T_Dictionary");
            this.Property(t => t.ID).HasColumnName("DictionaryId");
            this.Property(t => t.DictionaryName).HasColumnName("DictionaryName").HasMaxLength(50);
            this.Property(t => t.DictionaryValue).HasColumnName("DictionaryValue").HasMaxLength(500);
            this.Property(t => t.DictionaryCode).HasColumnName("DictionaryCode").HasMaxLength(50);
            this.Property(t => t.Remark).HasColumnName("Remark").HasMaxLength(50);
            this.Property(t => t.OrderNum).HasColumnName("OrderNum");
        }
    }
}
