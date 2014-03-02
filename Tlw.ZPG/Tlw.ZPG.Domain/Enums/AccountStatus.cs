namespace Tlw.ZPG.Domain.Models.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// 账户状态
    /// </summary>
    public enum AccountStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal = 0,
        /// <summary>
        /// 挂失
        /// </summary>
        [Description("挂失")]
        Loss = 1,
        /// <summary>
        /// 冻结
        /// </summary>
        [Description("冻结")]
        Froze = 2
    }
}
