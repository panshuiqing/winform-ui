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
 * * 说明：FrmWeatherFit.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using CCWin.SkinControl;
using System.Xml;

namespace CC2013
{
    public partial class FrmWeatherFit : CCSkinMain
    {
        Point Xy;
        FrmWeather Weather;
        public FrmWeatherFit(FrmWeather weather, Point xy)
        {
            Xy = xy;
            Weather = weather;
            InitializeComponent();
        }

        private void FrmWeatherFit_Load(object sender, EventArgs e)
        {
            this.Location = Xy;
        }

        //private readonly string CityXmlPath = @"Back\Cities.xml"; //城市代码XML
        private void btnOk_Click(object sender, EventArgs e)
        {
            string area = txtCode.Text.Trim();
            if (!string.IsNullOrEmpty(area))
            {
                string[] s = WeatherGet.GetByWebSeviceUrl(area); //调用WebServiceURL
                if (s != null)
                {
                    Weather.UserParam.IpStat.Local = area;
                    WeatherGet.DisWeatherInfo(Weather.UserParam, s); //分解天气信息与获取背景图
                }
                
                Helper.SendMessage(null, eFrom.Main_BackImg);
                Weather.SetImg();
                ////获取《中国气象网》的代码号
                //string code = string.Empty; //天气代码号
                //XmlDocument doc = new XmlDocument();
                //doc.Load(CityXmlPath);//加载文件
                //XmlNodeList data = doc.DocumentElement.ChildNodes;
                //foreach (XmlNode xnf in data)
                //{
                //    XmlElement xe = (XmlElement)xnf;
                //    if (xe.InnerText == txtCode.Text)
                //    {
                //        XmlElement xmlCode = (XmlElement)xe.NextSibling;
                //        code = xmlCode.InnerText;
                //        Weather.UserParam.WeatherList = WeatherGet.GetThreeDayWeather(code); //近三天天气放入参数
                //        WeatherGet.GetWeatherImg(Weather.UserParam); //获背景图
                //        Weather.SetImg();
                //        break;
                //    }
                //}
            }

            Weather.Location = Weather.LoactionPoint = Xy;
            this.Close();
            Weather.BaseShow();
            Weather.Special = false;
            Weather.TimShow(true);
        }

        //选中城市并查询天气
        private void lbWeather_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCode.Text = lbWeather.SelectedItem.ToString().Replace("(本地)","");
            btnOk.PerformClick();
        }
    }
}
