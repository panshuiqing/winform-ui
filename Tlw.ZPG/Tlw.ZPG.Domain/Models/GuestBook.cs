namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GuestBook
    {
        public int GuestBookId { get; set; }
        public string Tilte { get; set; }
        public string Content { get; set; }
        public string GuestName { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
