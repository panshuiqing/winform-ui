namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// 申请类别
    /// </summary>
    public enum ApplyType
    {
        /// 法人
        /// </summary>
        [Description("法人")]
        Corporation,
        /// 知识问答
        /// </summary>
        [Description("自然人")]
        Natural,
        /// 联合竞买
        /// </summary>
        [Description("联合竞买")]
        Union,
        /// 其他组织
        /// </summary>
        [Description("其他组织")]
        OtherOrg,
    }
}
