namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccountVerify
    {
        public int VerifyId { get; set; }
        public int AccountInfoId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int VerifyAccountId { get; set; }
        public string VerifyAccount { get; set; }
        public string Content { get; set; }
        public bool IsBider { get; set; }
    }
}
