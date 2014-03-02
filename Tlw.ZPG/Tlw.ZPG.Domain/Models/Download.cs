namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Download
    {
        public int DownloadId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
    }
}
