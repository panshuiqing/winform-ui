namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class GuestBook : EntityBase
    {
        public string Tilte { get; set; }
        public string Content { get; set; }
        public string GuestName { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string CardNo { get; set; }
    }
}
