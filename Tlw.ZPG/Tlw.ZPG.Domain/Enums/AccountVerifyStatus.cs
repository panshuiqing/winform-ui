namespace Tlw.ZPG.Domain.Models
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
        /// 未提交
        /// </summary>
        [Description("已提交")]
        Submited,
        /// 未提交
        /// </summary>
        [Description("已审核，通过")]
        Verified,
        /// 未提交
        /// </summary>
        [Description("已审核，不予受理")]
        NotAccept,
        /// 未提交
        /// </summary>
        [Description("已审核，通知补件")]
        NotifySupply,
        /// 未提交
        /// </summary>
        [Description("已补件，已提交")]
        SuppliedAndSubmited,
    }
}
