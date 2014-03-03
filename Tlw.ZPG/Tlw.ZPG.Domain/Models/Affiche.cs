namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class Affiche : EntityBase
    {
        public string ParentId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string OtherContent { get; set; }
        public string QualificationRequire { get; set; }
        public int CreatorId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime SignBeginTime { get; set; }
        public System.DateTime SignEndTime { get; set; }
        public System.DateTime TradeBeginTime { get; set; }
        public System.DateTime TradeEndTime { get; set; }
        public bool IsRelease { get; set; }
        public System.DateTime ReleaseTime { get; set; }
        public string Notice { get; set; }
        public int CountyId { get; set; }
        public bool IsOnlineAffiche { get; set; }
        public int SellModel { get; set; }
        public string AfficheNumber { get; set; }
        public string RatificationNumber { get; set; }
        public string RatificationOrg { get; set; }
        public int VerifyStatus { get; set; }
        public int VerifyUserId { get; set; }

        public virtual County County { get; set; }
        public virtual User Creator { get; set; }
    }
}
