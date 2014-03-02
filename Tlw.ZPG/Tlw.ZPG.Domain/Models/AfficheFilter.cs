namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AfficheFilter
    {
        public int FilterId { get; set; }
        public string FilterKeyword { get; set; }
        public string Remark { get; set; }
        public string ErrorMessage { get; set; }
    }
}
