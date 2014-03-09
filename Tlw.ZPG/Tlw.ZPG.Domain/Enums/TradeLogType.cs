namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// 交易日志类别
    /// </summary>
    public enum TradeLogType
    {
        /// 竞买人登陆
        /// </summary>
        [Description("竞买人登陆")]
        BidderLogin,
        /// 竞买人登出
        /// </summary>
        [Description("竞买人登出")]
        BidderLoginOut,
        /// 竞买人修改密码
        /// </summary>
        [Description("竞买人修改密码")]
        BidderUpdatePassword,
        /// 竞竞买确认成交
        /// </summary>
        [Description("竞买人确认成交")]
        BidderConfigResult,
        /// 挂牌人冻结交易
        /// </summary>
        [Description("挂牌人冻结交易")]
        HangFroze,
        /// 挂牌人解冻交易
        /// </summary>
        [Description("挂牌人解冻交易")]
        HangRecover,
        /// 挂牌人终止交易
        /// </summary>
        [Description("挂牌人终止交易")]
        HangTerminate,
        /// 挂牌人录入保留价
        /// </summary>
        [Description("挂牌人录入保留价")]
        HangReservePrice,
    }
}
