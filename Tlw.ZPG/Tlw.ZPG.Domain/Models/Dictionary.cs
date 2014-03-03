namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class Dictionary : EntityBase
    {
        public string DictionaryName { get; set; }
        public string DictionaryValue { get; set; }
        public string DictionaryCode { get; set; }
        public string Remark { get; set; }
        public int OrderNum { get; set; }
    }
}
