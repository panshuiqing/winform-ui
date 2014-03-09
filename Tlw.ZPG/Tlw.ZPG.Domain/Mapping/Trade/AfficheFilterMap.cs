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

    internal partial class AfficheFilterMap : EntityTypeConfiguration<AfficheFilter>
    {
        public AfficheFilterMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Z_AfficheFilter");
            this.Property(t => t.ID).HasColumnName("FilterId");
            this.Property(t => t.FilterKeyword).HasColumnName("FilterKeyword").IsRequired().HasMaxLength(100);
            this.Property(t => t.Remark).HasColumnName("Remark").HasMaxLength(300);
            this.Property(t => t.ErrorMessage).HasColumnName("ErrorMessage").HasMaxLength(100);
        }
    }
}
