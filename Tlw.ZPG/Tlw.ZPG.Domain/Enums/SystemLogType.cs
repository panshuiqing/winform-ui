namespace Tlw.ZPG.Domain.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// 操作类别
    /// </summary>
    public enum SystemLogType
    {
        /// <summary>
        /// 新增
        /// </summary>
        [Description("新增")]
        Add,
        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        Delete,
        /// <summary>
        /// 修改
        /// </summary>
        [Description("修改")]
        Update,
        /// <summary>
        /// 操作异常
        /// </summary>
        [Description("操作异常")]
        Exception,
        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other,
    }
}
