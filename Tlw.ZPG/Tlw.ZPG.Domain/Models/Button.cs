namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Button
    {
        public int ButtonId { get; set; }
        public string ButtonName { get; set; }
        public string ButtonIcon { get; set; }
        public string ButtonCode { get; set; }
        public string ButtonEvent { get; set; }
        public ButtonPosition ButtonPosition { get; set; }
        public int OrderNo { get; set; }
        public string Remark { get; set; }
    }
}
