namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Domain.Models.Enums;
    using Tlw.ZPG.Infrastructure;

    public partial class Account : EntityBase
    {
        public Account()
        {
            this.AccountVerifies = new HashSet<AccountVerify>();
            this.UnionBidPersons = new HashSet<Person>();
        }

        #region  Ù–‘
        public string ApplyNumber { get; set; }
        public string Password { get; set; }
        public bool PasswordUpdated { get; set; }
        public System.DateTime CreateTime { get; set; }
        public AccountStatus Status { get; set; }
        public virtual Trade Trade { get; set; }
        public string RandomNumber { get; set; }
        public int TradeId { get; set; }
        public ApplyType ApplyType { get; set; }
        public int ContactId { get; set; }
        public int AgentId { get; set; }
        public int CorporationId { get; set; }
        public bool IsOnline { get; set; }
        public Nullable<System.DateTime> OnlineTime { get; set; }
        public AccountVerifyStatus VerifyStatus { get; set; }
        public virtual Person Agent { get; set; }
        public virtual Person Contact { get; set; }
        public virtual Person Corporation { get; set; }
        public virtual ICollection<AccountVerify> AccountVerifies { get; set; }
        public virtual ICollection<Person> UnionBidPersons { get; set; } 
        #endregion

        public override IEnumerable<BusinessRule> Validate()
        {
            return base.Validate();
        }
    }
}
