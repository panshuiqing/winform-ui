namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// 审核类别
    /// </summary>
    public enum VerifyType
    {
        /// <summary>
        /// 已审核，通过
        /// </summary>
        [Description("已审核，通过")]
        Verified,
        /// <summary>
        /// 已审核，不予受理
        /// </summary>
        [Description("已审核，不予受理")]
        NotAccept,
        /// <summary>
        /// 已审核，通知补件
        /// </summary>
        [Description("已审核，通知补件")]
        NotifyAdditional,
    }
}
