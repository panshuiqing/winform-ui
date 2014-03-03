//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    
    internal partial class TradeResultConfirmMap : EntityTypeConfiguration<TradeResultConfirm>
    {
        public TradeResultConfirmMap()
        {                        
              this.HasKey(t => t.ID);        
              this.ToTable("Z_TradeResultConfirm");
              this.Property(t => t.ID).HasColumnName("TradeId").HasDatabaseGeneratedOption(new Nullable<DatabaseGeneratedOption>(DatabaseGeneratedOption.None));
              this.Property(t => t.CreateTime).HasColumnName("CreateTime");
              this.Property(t => t.ConfirmTime).HasColumnName("ConfirmTime");
              this.Property(t => t.ExpiredTime).HasColumnName("ExpiredTime");
              this.Property(t => t.RandomNum).HasColumnName("RandomNum").IsRequired().HasMaxLength(50);
         }
    }
}
