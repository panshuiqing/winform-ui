namespace Tlw.ZPG.Domain.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// 日志类别
    /// </summary>
    public enum SystemLogType
    {
        /// <summary>
        /// 公告日志
        /// </summary>
        [Description("公告日志")]
        Affiche,
        /// <summary>
        /// 交易日志
        /// </summary>
        [Description("交易日志")]
        Trade,
        /// <summary>
        /// 竞买号日志
        /// </summary>
        [Description("竞买号日志")]
        ApplyNumber,
        /// <summary>
        /// 登录日志
        /// </summary>
        [Description("登录日志")]
        Login,
        /// <summary>
        /// 异常日志
        /// </summary>
        [Description("异常日志")]
        Exception,
        /// <summary>
        /// 其他日志
        /// </summary>
        [Description("其他日志")]
        Other,
    }
}
