namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccountInfo
    {
        public AccountInfo()
        {
            this.AccountVerifies = new HashSet<AccountVerify>();
            this.UnionBidPersons = new HashSet<Person>();
        }
    
        public int AccountInfoId { get; set; }
        public string RandomNumber { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int TradeId { get; set; }
        public int ApplyType { get; set; }
        public int ContactId { get; set; }
        public int AgentId { get; set; }
        public int CorporationId { get; set; }
        public AccountVerifyStatus Status { get; set; }
    
        public virtual Person Agent { get; set; }
        public virtual Person Contact { get; set; }
        public virtual Person Corporation { get; set; }
        public virtual Trade Trade { get; set; }
        public virtual ICollection<AccountVerify> AccountVerifies { get; set; }
        public virtual ICollection<Person> UnionBidPersons { get; set; }
    }
}
