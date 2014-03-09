namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class GuestBook : EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string GuestName { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string CardNo { get; set; }

        public override IEnumerable<BusinessRule> Validate()
        {
            if (string.IsNullOrEmpty(this.Content))
            {
                yield return new BusinessRule("留言内容不能为空");
            }
            if (this.Content.Length > 300)
            {
                yield return new BusinessRule("留言内容字符总数不能超过300");
            }
        }
    }
}
