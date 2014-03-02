namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Domain.Models.Enums;
    
    public partial class Account
    {
        public int AccountId { get; set; }
        public int TradeId { get; set; }
        public int AccountInfoId { get; set; }
        public string ApplyNumber { get; set; }
        public string Password { get; set; }
        public bool PasswordUpdated { get; set; }
        public System.DateTime CreateTime { get; set; }
        public bool IsOnline { get; set; }
        public Nullable<System.DateTime> OnlineTime { get; set; }
        public AccountStatus Status { get; set; }
    
        public virtual AccountInfo AccountInfo { get; set; }
        public virtual Trade Trade { get; set; }
    }
}
