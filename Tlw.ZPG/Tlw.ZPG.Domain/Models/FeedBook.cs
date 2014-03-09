namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Domain.Models.Admin;
    using Tlw.ZPG.Infrastructure;

    public partial class FeedBook : EntityBase
    {
        public System.DateTime CreateTime { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ReplyContent { get; set; }
        public DateTime? ReplyTime { get; set; }
        public int? ReplyUserId { get; set; }
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

        public override IEnumerable<BusinessRule> Validate()
        {
            if (string.IsNullOrEmpty(this.Content))
            {
                yield return new BusinessRule("举报内容不能为空");
            }
            if (this.Content.Length > 300)
            {
                yield return new BusinessRule("举报内容字符总数不能超过300");
            }
        }
    }
}
