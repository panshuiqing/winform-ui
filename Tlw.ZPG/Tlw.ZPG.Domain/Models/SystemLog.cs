namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SystemLog
    {
        public int LogId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public OperateType LogType { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Ip { get; set; }
        public string Url { get; set; }
        public string StackTrace { get; set; }
        public string Remark { get; set; }
    }
}
