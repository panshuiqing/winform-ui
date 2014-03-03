namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class Trade : EntityBase
    {
        public Trade()
        {
            this.TradeMessages = new HashSet<TradeMessage>();
            this.TradeLogs = new HashSet<TradeLog>();
            this.TradeResult = new HashSet<TradeResult>();
            this.Accounts = new HashSet<Account>();
            this.TradeDetails = new HashSet<TradeDetail>();
        }
    
        public int LandId { get; set; }
        public int AfficheId { get; set; }
        public System.DateTime SignBeginTime { get; set; }
        public System.DateTime SignEndTime { get; set; }
        public System.DateTime TradeBeginTime { get; set; }
        public System.DateTime TradeEndTime { get; set; }
        public decimal StartPrice { get; set; }
        public decimal ReservePrice { get; set; }
        public decimal HangPriceRange { get; set; }
        public decimal AuctionPriceRange { get; set; }
        public TradeStatus Status { get; set; }
        public System.DateTime DealTime { get; set; }
        public int DealUserId { get; set; }
        public TradeStage Stage { get; set; }
    
        public virtual Affiche Affiche { get; set; }
        public virtual Land Land { get; set; }
        public virtual ICollection<TradeMessage> TradeMessages { get; set; }
        public virtual ICollection<TradeLog> TradeLogs { get; set; }
        public virtual ICollection<TradeResult> TradeResult { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<TradeDetail> TradeDetails { get; set; }
        public virtual TradeResultConfirm TradeResultConfirm { get; set; }
    }
}
