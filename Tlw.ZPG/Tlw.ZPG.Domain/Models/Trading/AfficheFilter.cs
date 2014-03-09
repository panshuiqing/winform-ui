namespace Tlw.ZPG.Domain.Models.Trading
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class AfficheFilter : EntityBase
    {
        public string FilterKeyword { get; set; }
        public string Remark { get; set; }
        public string ErrorMessage { get; set; }
    }
}
