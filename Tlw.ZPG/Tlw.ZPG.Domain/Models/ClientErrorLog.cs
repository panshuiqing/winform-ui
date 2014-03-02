namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ClientErrorLog
    {
        public int LogId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string ApplyNumber { get; set; }
        public string Ip { get; set; }
        public string SystemInfo { get; set; }
        public string StackTrace { get; set; }
        public string Remark { get; set; }
    }
}
