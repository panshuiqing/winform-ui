namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dictionary
    {
        public int DictionaryId { get; set; }
        public string DictionaryName { get; set; }
        public string DictionaryValue { get; set; }
        public string DictionaryCode { get; set; }
        public string Remark { get; set; }
        public int OrderNum { get; set; }
    }
}
