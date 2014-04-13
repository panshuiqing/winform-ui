using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Services
{
    /// <summary>
    /// 系统日志编码5位数字表示，起始1-2位表示模块或者类别，3-4位表示具体功能，最后一位作为标志说明，默认0
    /// <para>00系统异常,01公告,02竞买号,03交易,04其他</para>
    /// </summary>
    public sealed class SystemLogCodes
    {
        private SystemLogCodes() { }

        public const string L00000 = "00000";
        public const string L01000 = "00000";

        /// <summary>
        /// 冻结竞买号
        /// </summary>
        public const string L02000 = "02000";
        /// <summary>
        /// 发放竞买号
        /// </summary>
        public const string L02010 = "02010";
        /// <summary>
        /// 重置密码
        /// </summary>
        public const string L02020 = "02020";
        /// <summary>
        /// 审核竞买申请
        /// </summary>
        public const string L02030 = "02030";
        /// <summary>
        /// 解冻竞买号
        /// </summary>
        public const string L02040 = "02040";
        /// <summary>
        /// 挂失竞买号
        /// </summary>
        public const string L02050 = "02050";
        /// <summary>
        /// 解冻竞买号
        /// </summary>
        public const string L02060 = "02060";

        public const string L03000 = "00000";
        public const string L04000 = "00000";
    }
}
