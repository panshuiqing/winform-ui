/********************************************************************
 * *
 * * 使本项目源码或本项目生成的DLL前请仔细阅读以下协议内容，如果你同意以下协议才能使用本项目所有的功能，
 * * 否则如果你违反了以下协议，有可能陷入法律纠纷和赔偿，作者保留追究法律责任的权利。
 * *
 * * 1、你可以在开发的软件产品中使用和修改本项目的源码和DLL，但是请保留所有相关的版权信息。
 * * 2、不能将本项目源码与作者的其他项目整合作为一个单独的软件售卖给他人使用。
 * * 3、不能传播本项目的源码和DLL，包括上传到网上、拷贝给他人等方式。
 * * 4、以上协议暂时定制，由于还不完善，作者保留以后修改协议的权利。
 * *
 * * Copyright (C) 2013-? cskin Corporation All rights reserved.
 * * 网站：CSkin界面库 http://www.cskin.net
 * * 作者： 乔克斯 QQ：345015918 .Net项目技术组群：306485590
 * * 请保留以上版权信息，否则作者将保留追究法律责任。
 * *
 * * 创建时间：2013-12-08
 * * 说明：Helper.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using System.Drawing;

namespace CC2013
{
    /// <summary>
    /// 定义发布消息的委托
    /// </summary>
    /// <param name="sender">发布者</param>
    /// <param name="msg">消息</param>
    public delegate void SendHandler(object sender, object msg);

    /// <summary>
    /// 观察者的中间模块组建
    /// </summary>
    public class Helper
    {
        /// <summary>
        ///消息发布的事件
        /// </summary>
        public static event SendHandler eventSend;

        public static void SendMessage(object sender, object msg)
        {
            if (eventSend != null)
            {
                eventSend(sender, msg);
            }
        }

        #region 获取本机的公网IP

        //获取本机的公网IP
        public static string GetPublicIP()
        {
            string tempip = string.Empty;
            try
            {
                WebRequest wr = WebRequest.Create("http://iframe.ip138.com/ic.asp");
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string all = sr.ReadToEnd(); //读取网站的数据

                int start = all.IndexOf("[") + 1;
                int end = all.IndexOf("]", start);
                tempip = all.Substring(start, end - start);
                sr.Close();
                s.Close();
            }
            catch
            {
            }
            return tempip;
        }

        #endregion
    }

    #region eFrom枚举

    public enum eFrom
    {
        /// <summary>
        /// 显示提示窗口
        /// </summary>
        Show_Tip,
        /// <summary>
        /// 显示主窗口
        /// </summary>
        Show_Main,
        /// <summary>
        /// 修改主窗背景
        /// </summary>
        Main_BackImg,
    }

    #endregion

    #region 天气枚举

    /// <summary>天气</summary>
    public enum WeatherType
    {
        晴,
        多云,
        阴,
        阴转多云,
        阵雨,
        雷阵雨,
        雷阵雨伴有冰雹,
        雨夹雪,
        小雨,
        中雨,
        大雨,
        暴雨,
        大暴雨,
        特大暴雨,
        阵雪,
        小雪,
        中雪,
        大雪,
        暴雪,
        雾,
        冻雨,
        沙尘暴,
        小到中雨,
        中到大雨,
        大到暴雨,
        暴雨到大暴雨,
        大暴雨到特大暴雨,
        小到中雪,
        中到大雪,
        大到暴雪,
        浮尘,
        扬沙,
        强沙尘暴
    }

    #endregion

    #region 登录辅助类

    /// <summary>
    /// 登录辅助类
    /// </summary>
    [Serializable]
    public class User_Param
    {
        /// <summary>
        /// 登录号码
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 头象
        /// </summary>
        public Image HeadImg { get; set; }
        /// <summary>
        /// 用户状态按钮
        /// </summary>
        public CCWin.SkinControl.SkinButton BtnState { get; set; }
        /// <summary>
        /// IP辅助类
        /// </summary>
        public IpStat IpStat { get; set; }
        /// <summary>
        /// 主窗背景
        /// </summary>
        public Image BackImg { get; set; }
        /// <summary>
        /// 当天天气图片
        /// </summary>
        public Image WeatherImg { get; set; }
        /// <summary>
        /// 天气集合
        /// </summary>
        public List<Weather> WeatherList { get; set; }

        /// <summary>
        /// 当前气温
        /// </summary>
        public string CurrentTemp { get; set; }
        /// <summary>
        /// 风
        /// </summary>
        public string Wind { get; set; }
        /// <summary>
        /// WebSevice天气集合
        /// </summary>
        public List<WebSeviceWeather> WebWeatherList { get; set; }
    }

    #endregion

    #region 保存IP辅助类

    /// <summary>
    /// 保存IP辅助类
    /// </summary>
    [Serializable]
    public class IpStat
    {
        public int IpStatId { get; set; }
        public string IP { get; set; }
        public string IpSrc { get; set; }
        public string Country { get; set; }
        public string Local { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }
        public string StrTime { get; set; }
    }

    #endregion

    #region 天气辅助类

    public class Weather
    {
        /// <summary>
        /// 地区
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 温度
        /// </summary>
        public string Temperature { get; set; }
        /// <summary>
        /// 天气显示文字
        /// </summary>
        public string WeatherText { get; set; }
        /// <summary>
        /// 气候变化
        /// </summary>
        public string Climate { get; set; }
        /// <summary>
        /// 风
        /// </summary>
        public string Wind { get; set; }
        /// <summary>
        /// 天气图标
        /// </summary>
        public Image WeatherImg { get; set; }
    }

    #endregion

    #region WebSevice天气辅助类

    public class WebSeviceWeather
    {
        /// <summary>
        /// 温度
        /// </summary>
        public string Temperature { get; set; }
        /// <summary>
        /// 气候变化
        /// </summary>
        public string Climate { get; set; }
        /// <summary>
        /// 天气图标
        /// </summary>
        public Image WeatherImg { get; set; }
    }

    #endregion
}
