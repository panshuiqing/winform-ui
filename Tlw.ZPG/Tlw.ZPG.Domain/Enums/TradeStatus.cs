namespace Tlw.ZPG.Domain.Enums
{
    using System;
    using System.ComponentModel;

    public enum TradeStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal,
        /// <summary>
        /// 冻结
        /// </summary>
        [Description("冻结")]
        Froze,
        /// <summary>
        /// 终止
        /// </summary>
        [Description("终止")]
        Terminate,
    }
}
