namespace Tlw.ZPG.Domain.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// 账户审核状态
    /// </summary>
    public enum AccountVerifyStatus
    {
        /// <summary>
        /// 未提交
        /// </summary>
        [Description("未提交")]
        UnSubmit,
        /// <summary>
        /// 已提交
        /// </summary>
        [Description("已提交")]
        Submited,
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
        NotifySupply,
        /// <summary>
        /// 已补件，已提交
        /// </summary>
        [Description("已补件，已提交")]
        SuppliedAndSubmited,
    }
}
