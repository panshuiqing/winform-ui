namespace Tlw.ZPG.Domain.Models.Bid
{
    using System;
using System.Collections.Generic;
using Tlw.ZPG.Domain.Enums;
using Tlw.ZPG.Domain.Models.Admin;
using Tlw.ZPG.Infrastructure;

    public partial class AccountVerify : EntityBase
    {
        public int AccountId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int? UserId { get; set; }
        public string Content { get; set; }
        public AccountVerifyStatus Status { get; set; }
    }
}
