using System;
using System.Collections.Generic;
using System.Text;

namespace Teleware.ZPG.Client
{
    public sealed class WebUrls
    {
        /// <summary>
        /// 基地址
        /// </summary>
        public static string BaseUrl = "http://localhost:6756/";
        /// <summary>
        /// 交易详情地址
        /// </summary>
        public static string TradeDetailUrl = BaseUrl + "res/TradeDetail.aspx";
        /// <summary>
        /// 公告内容地址
        /// </summary>
        public static string AfficheUrl = BaseUrl + "res/Affiche.aspx";
        /// <summary>
        /// 结果公示地址
        /// </summary>
        public static string TradeResultUrl = BaseUrl + "res/TradeResult.aspx";
        /// <summary>
        /// 申请信息地址
        /// </summary>
        public static string ApplyInfoUrl = BaseUrl + "res/ApplyInfo.aspx";
        /// <summary>
        /// 申请信息地址
        /// </summary>
        public static string MainInfoUrl = BaseUrl + "res/MainInfo.aspx";

    }
}
