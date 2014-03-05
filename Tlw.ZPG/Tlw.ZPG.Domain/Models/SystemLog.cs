namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Domain.Models.Enums;
    using Tlw.ZPG.Infrastructure;

    public partial class SystemLog : EntityBase
    {
        public System.DateTime CreateTime { get; set; }
        public SystemLogType LogType { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Ip { get; set; }
        public string Url { get; set; }
        public string StackTrace { get; set; }
        public string Remark { get; set; }
    }
}
