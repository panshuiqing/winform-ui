namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// 操作类别
    /// </summary>
    public enum OperateType
    {
        #region 用户
        /// 用户登录
        /// </summary>
        [Description("用户登录")]
        UserLogin,
        /// 修改个人信息
        /// </summary>
        [Description("修改个人信息")]
        UserInfoUpdated,
        /// 修改密码
        /// </summary>
        [Description("修改密码")]
        UserPasswordUpdated,
        /// 新建用户
        /// </summary>
        [Description("新建用户")]
        UserCreated, 
        #endregion

        #region 公告
        /// 新建公告
        /// </summary>
        [Description("新建公告")]
        AfficheCreated,
        /// 修改公告
        /// </summary>
        [Description("修改公告")]
        AfficheUpdated,
        /// 补充公告
        /// </summary>
        [Description("补充公告")]
        AfficheSupplied,
        /// 发布公告
        /// </summary>
        [Description("发布公告")]
        AfficheReleased,
        /// 删除公告
        /// </summary>
        [Description("删除公告")]
        AfficheDeleted,
        #endregion

        #region 宗地
        /// 新建宗地
        /// </summary>
        [Description("新建宗地")]
        LandCreated,
        /// 修改宗地
        /// </summary>
        [Description("修改宗地")]
        LandUpdated,
        /// 删除宗地
        /// </summary>
        [Description("删除宗地")]
        LandDeleted,
        /// 录入报保留价
        /// </summary>
        [Description("录入报保留价")]
        BasePriceInputed,
        #endregion

        #region 公示
        /// 新建公示
        /// </summary>
        [Description("新建公示")]
        NoticeCreated,
        /// 修改公示
        /// </summary>
        [Description("修改公示")]
        NoticeUpdated,
        /// 删除公示
        /// </summary>
        [Description("删除公示")]
        NoticeDeleted,
        /// 发布公示
        /// </summary>
        [Description("发布公示")]
        NoticeReleased,
        #endregion

        #region 交易
        /// 交易冻结
        /// </summary>
        [Description("交易冻结")]
        TradeFrozed,
        /// 交易终止
        /// </summary>
        [Description("交易终止")]
        TradeTerminated,
        /// 挂牌人审核成交结果
        /// </summary>
        [Description("挂牌人审核成交结果")]
        TradeResultVerified,
        /// 挂牌人发送消息
        /// </summary>
        [Description("挂牌人发送消息")]
        TradeSendMessage,
        #endregion

        #region 竞买号
        /// 挂牌人审核
        /// </summary>
        [Description("挂牌人审核")]
        ApplyHangVerify,
        /// 竞买号挂失
        /// </summary>
        [Description("竞买号挂失")]
        ApplyNumberLossed,
        /// 竞买号冻结
        /// </summary>
        [Description("竞买号冻结")]
        ApplyNumberFrozed,
        /// 竞买号解冻
        /// </summary>
        [Description("竞买号解冻")]
        ApplyNumberUnFrozed,
        /// 重新发放密码
        /// </summary>
        [Description("重新发放密码")]
        ApplyPasswordReset,
        /// 修改手机号码
        /// </summary>
        [Description("修改手机号码")]
        ApplyPhoneUpdated,
        /// 上传附件
        /// </summary>
        [Description("上传附件")]
        ApplyFilesUploaded,
        #endregion

        #region 公网内容
        /// 回复投诉
        /// </summary>
        [Description("回复投诉")]
        FeedBookReplaied,
        /// 发布政策法规资讯
        /// </summary>
        [Description("发布政策法规资讯")]
        InfoReleased,
        /// 发布知识问答
        /// </summary>
        [Description("发布知识问答")]
        QAReleased,
        /// 发布常见问题解答
        /// </summary>
        [Description("发布常见问题解答")]
        FAQReleased,
        /// 发布格式文书
        /// </summary>
        [Description("发布格式文书")]
        FilesReleased,
        #endregion

        #region 短信
        /// <summary>
        /// 短信群发
        /// </summary>
        [Description("短信群发")]
        SendGroupSMS,

        #endregion

        /// 其他
        /// </summary>
        [Description("其他")]
        Other,
    }
}
