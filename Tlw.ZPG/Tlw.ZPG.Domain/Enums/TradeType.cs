namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// 交易类别
    /// </summary>
    public enum TradeType
    {
        /// 报价
        /// </summary>
        [Description("报价")]
        SubmitPrice,
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
        [Description("竞买确认成交")]
        BidderConfigResult,
    }
}
