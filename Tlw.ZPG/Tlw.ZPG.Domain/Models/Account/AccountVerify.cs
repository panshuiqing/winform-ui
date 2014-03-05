namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class AccountVerify : EntityBase
    {
        public int AccountId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int VerifyAccountId { get; set; }
        public string VerifyAccount { get; set; }
        public string Content { get; set; }
        public bool IsBider { get; set; }
        public AccountVerifyStatus Status { get; set; }
    }
}
