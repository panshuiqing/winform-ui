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
    
    internal partial class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {                        
              this.HasKey(t => t.ID);        
              this.ToTable("A_Person");
              this.Property(t => t.ID).HasColumnName("PersonId");
              this.Property(t => t.AccountId).HasColumnName("AccountId");
              this.Property(t => t.PersonName).HasColumnName("PersonName").HasMaxLength(50);
              this.Property(t => t.PassportType).HasColumnName("PassportType").HasMaxLength(50);
              this.Property(t => t.PassportNumber).HasColumnName("PassportNumber").HasMaxLength(100);
              this.Property(t => t.Unit).HasColumnName("Unit").HasMaxLength(100);
              this.Property(t => t.UnitCode).HasColumnName("UnitCode").HasMaxLength(50);
              this.Property(t => t.Address).HasColumnName("Address").HasMaxLength(200);
              this.Property(t => t.Telephone).HasColumnName("Telephone").HasMaxLength(50);
              this.Property(t => t.MobilePhone).HasColumnName("MobilePhone").HasMaxLength(50);
              this.Property(t => t.Email).HasColumnName("Email").HasMaxLength(50);
              this.Property(t => t.Business).HasColumnName("Business").HasMaxLength(50);
              this.Property(t => t.PostalCode).HasColumnName("PostalCode").HasMaxLength(50);
              this.Property(t => t.ApplyType).HasColumnName("ApplyType");
         }
    }
}
