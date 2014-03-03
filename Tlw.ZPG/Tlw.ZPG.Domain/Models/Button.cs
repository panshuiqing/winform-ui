namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class Button : EntityBase
    {
        public string ButtonName { get; set; }
        public string ButtonIcon { get; set; }
        public string ButtonCode { get; set; }
        public string ButtonEvent { get; set; }
        public ButtonPosition ButtonPosition { get; set; }
        public int OrderNo { get; set; }
        public string Remark { get; set; }
    }
}
