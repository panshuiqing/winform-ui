namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class Person : EntityBase
    {
        public int AccountId { get; set; }
        public string PersonName { get; set; }
        public string PassportType { get; set; }
        public string PassportNumber { get; set; }
        public string Unit { get; set; }
        public string UnitCode { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Business { get; set; }
        public string PostalCode { get; set; }
        public ApplyType ApplyType { get; set; }
    }
}
