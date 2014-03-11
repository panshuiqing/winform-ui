namespace Tlw.ZPG.Domain.Enums
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
        Normal,
        /// <summary>
        /// 挂失
        /// </summary>
        [Description("挂失")]
        Loss,
        /// <summary>
        /// 冻结
        /// </summary>
        [Description("冻结")]
        Froze
    }
}
