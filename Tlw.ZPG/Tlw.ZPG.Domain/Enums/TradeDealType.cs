namespace Tlw.ZPG.Domain.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// 成交类型
    /// </summary>
    public enum TradeDealType
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        None,
        /// <summary>
        /// 网上挂牌
        /// </summary>
        [Description("网上挂牌")]
        Hang,
        /// <summary>
        /// 转入网上拍卖
        /// </summary>
        [Description("转入网上拍卖")]
        Auction,
    }
}
