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
    
    internal partial class ApplyNumbersMap : EntityTypeConfiguration<ApplyNumbers>
    {
        public ApplyNumbersMap()
        {                        
              this.HasKey(t => t.ID);        
              this.ToTable("A_ApplyNumbers");
              this.Property(t => t.ID).HasColumnName("ApplyId");
              this.Property(t => t.ApplyNumber).HasColumnName("ApplyNumber").IsRequired().HasMaxLength(50);
              this.Property(t => t.IsUsed).HasColumnName("IsUsed");
              this.Property(t => t.UsedTime).HasColumnName("UsedTime");
         }
    }
}