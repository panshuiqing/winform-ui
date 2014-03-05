namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class FeedBook : EntityBase
    {
        public System.DateTime CreateTime { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ReplyContent { get; set; }
        public DateTime? ReplyTime { get; set; }
        public int ReplyUserId { get; set; }
        public string CustomerName { get; set; }
        public string ContactPhone { get; set; }
        public string LandNames { get; set; }
        public string CardNo { get; set; }
        public string QueryNumber { get; set; }

        public User ReplyUser { get; set; }

        public void Reply(string replyContent,int replyUserId)
        {
            this.ReplyUserId = replyUserId;
            this.ReplyContent = replyContent;
            this.ReplyTime = DateTime.Now;
        }
    }
}
