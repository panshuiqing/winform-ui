namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FeedBook
    {
        public int FeedBookId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CustomerName { get; set; }
        public string ContactPhone { get; set; }
        public string LandNames { get; set; }
        public string CardNo { get; set; }
    }
}
