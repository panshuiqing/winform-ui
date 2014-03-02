namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.ComponentModel;

    public enum TradeStatus
    {
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal,
        /// 冻结
        /// </summary>
        [Description("冻结")]
        Froze,
        /// 终止
        /// </summary>
        [Description("终止")]
        Terminate,
        /// 已结束，等待竞买人确认
        /// </summary>
        [Description("已结束，等待竞买人确认")]
        WaitBidderConfirm,
        /// 已结束，等待挂牌人审核
        /// </summary>
        [Description("已结束，等待挂牌人审核")]
        WaitHangVerify,
        /// 已结束，审核通过
        /// </summary>
        [Description("已结束，审核通过")]
        Verified,
    }
}
