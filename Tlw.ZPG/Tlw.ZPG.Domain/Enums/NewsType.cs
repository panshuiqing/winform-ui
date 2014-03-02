namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// 新闻类别
    /// </summary>
    public enum NewsType
    {
        /// 政策法规资讯
        /// </summary>
        [Description("政策法规资讯")]
        Info,
        /// 知识问答
        /// </summary>
        [Description("知识问答")]
        QA,
        /// 常见问题解答
        /// </summary>
        [Description("常见问题解答")]
        FAQ
    }
}
