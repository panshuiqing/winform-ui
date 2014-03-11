namespace Tlw.ZPG.Domain.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// 交易阶段
    /// </summary>
    public enum TradeStage
    {
        /// <summary>
        /// 未开始报名
        /// </summary>
        [Description("未开始报名")]
        UnStartSign,
        /// <summary>
        /// 报名中
        /// </summary>
        [Description("报名中")]
        Signing,
        /// <summary>
        /// 挂牌
        /// </summary>
        [Description("挂牌")]
        Hang,
        /// <summary>
        /// 等待
        /// </summary>
        [Description("等待")]
        Ready,
        /// <summary>
        /// 拍卖
        /// </summary>
        [Description("拍卖")]
        Auction,
        /// <summary>
        /// 结束
        /// </summary>
        [Description("结束")]
        Complete,
    }
}
