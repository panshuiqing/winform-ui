
namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// ½»Ò×½×¶Î
    /// </summary>
    public enum TradeStage
    {
        /// <summary>
        /// Î´Öª
        /// </summary>
        [Description("Î´Öª")]
        None,
        /// <summary>
        /// ¹ÒÅÆ
        /// </summary>
        [Description("¹ÒÅÆ")]
        Hang,
        /// <summary>
        /// µÈ´ý
        /// </summary>
        [Description("µÈ´ý")]
        Ready,
        /// <summary>
        /// ÅÄÂô
        /// </summary>
        [Description("ÅÄÂô")]
        Auction,
    }
}
