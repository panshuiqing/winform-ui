
namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// 交易阶段
    /// </summary>
    public enum TradeStage
    {
        /// 未开始
        /// </summary>
        [Description("未开始")]
        UnStart,
        /// 挂牌
        /// </summary>
        [Description("挂牌")]
        Hang,
        /// 等待
        /// </summary>
        [Description("等待")]
        Ready,
        /// 拍卖
        /// </summary>
        [Description("拍卖")]
        Auction
    }
}
