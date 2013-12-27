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
 * * 说明：WeatherGet.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
using System.Collections;

namespace CC2013
{
    /// <summary>
    /// 获取当地的天气状况
    /// </summary>
    public class WeatherGet
    {

        #region 分解省市级

        /// <summary>
        /// 分解省市级
        /// </summary>
        /// <param name="str">省市级</param>
        /// <returns>最低地级县名称</returns>
        public static string GetCity(string str)
        {
            string local = string.Empty;
            str = System.Text.RegularExpressions.Regex.Replace(str, "省", ",");
            str = System.Text.RegularExpressions.Regex.Replace(str, "市", ",");
            str = System.Text.RegularExpressions.Regex.Replace(str, "区", ",");

            if (str[str.Length - 1] == ',')//如果最后一个字符是逗号
            {
                str = str.Substring(0, str.Length - 1);//去掉最后的逗号
            }

            string[] arrayStr = str.Split(',');
            if (arrayStr.Length > 0)
            {
                local = arrayStr[arrayStr.Length - 1];
            }
            return local;
        }

        #endregion

        #region 获取城市的天气状况

        /// <summary>
        /// 获取城市的天气状况
        /// </summary>
        /// <param name="code">中国天气网的代码</param>
        /// <returns>json文本</returns>
        public static string GetWeather(string code)
        {
            string wUrl = string.Format("http://m.weather.com.cn/data/{0}.html", code);
            HttpWebRequest wNetr = (HttpWebRequest)HttpWebRequest.Create(wUrl);
            HttpWebResponse wNetp = (HttpWebResponse)wNetr.GetResponse();

            wNetr.ContentType = "text/html";
            wNetr.Method = "Get";

            Stream Streams = wNetp.GetResponseStream();
            StreamReader Reads = new StreamReader(Streams, Encoding.UTF8);

            String ReCode = Reads.ReadToEnd();
            //关闭暂时不适用的资源
            Reads.Dispose();
            Streams.Dispose();
            wNetp.Close();

            ReCode = "[" + ReCode + "]";
            
            //保存入Hash
            //ReCode = ReCode.Replace("\"", "").Replace("{", "").Replace("}", "");
            //string strTemp = "";
            //Hashtable ta = new Hashtable();
            //for (int i = 0; i < ReCode.Split(',').Length; i++)
            //{
            //    strTemp = ReCode.Split(',')[i].ToString();
            //    ta.Add(strTemp.Split(':')[0], strTemp.Split(':')[1]);
            //}

            return ReCode;
        }

        #endregion

        #region 获取近三天的天气

        /// <summary>
        /// 获取近三天的天气
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static List<Weather> GetThreeDayWeather(string code)
        {
            //string jsonData = GetWeather(code);
            //JArray ja = (JArray)JsonConvert.DeserializeObject(jsonData);
            //List<Weather> weatherList = new List<Weather>();

            //for (int i = 1; i < 4; i++)
            //{
            //    Weather weather = new Weather();
            //    weather.City = ja[0]["weatherinfo"]["city"].ToString();
            //    weather.Temperature = ja[0]["weatherinfo"]["temp" + i].ToString();
            //    weather.WeatherText = ja[0]["weatherinfo"]["img_title" + i].ToString();
            //    weather.Climate = ja[0]["weatherinfo"]["weather" + i].ToString();
            //    weather.Wind = ja[0]["weatherinfo"]["wind" + i].ToString();
            //    weatherList.Add(weather);
            //}

            //return weatherList;

            return new List<Weather>();
        }

        #endregion

        #region 获取当天天气图标

        public static void GetWeatherImg(User_Param userParam)
        {
            if (userParam.WeatherList == null || userParam.WeatherList.Count < 3)
            {
                return;
            }

            WeatherType weatherType;

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    weatherType = (WeatherType)Enum.Parse(typeof(WeatherType), userParam.WeatherList[i].WeatherText);
                }
                catch (Exception)
                {
                    return;
                }


                switch (weatherType)
                {
                    case WeatherType.晴:
                        if (i == 0)
                        {
                            userParam.BackImg = CC2013.Properties.Resources.main_1;
                            userParam.WeatherImg = CC2013.Properties.Resources.Big_1;
                        }
                        userParam.WeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_1;
                        break;
                    case WeatherType.多云:
                        if (i == 0)
                        {
                            userParam.BackImg = CC2013.Properties.Resources.main_2;
                            userParam.WeatherImg = CC2013.Properties.Resources.Big_2;
                        }
                        userParam.WeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_2;
                        break;
                    case WeatherType.阴:
                        if (i == 0)
                        {
                            userParam.BackImg = CC2013.Properties.Resources.main_3;
                            userParam.WeatherImg = CC2013.Properties.Resources.Big_3;
                        }
                        userParam.WeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_3;
                        break;
                    case WeatherType.阴转多云:
                        if (i == 0)
                        {
                            userParam.BackImg = CC2013.Properties.Resources.main_3;
                            userParam.WeatherImg = CC2013.Properties.Resources.Big_3;
                        }
                        userParam.WeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_3;
                        break;
                    case WeatherType.阵雨:
                        if (i == 0)
                        {
                            userParam.BackImg = CC2013.Properties.Resources.main_4;
                            userParam.WeatherImg = CC2013.Properties.Resources.Big_4;
                        }
                        userParam.WeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_4;
                        break;
                    case WeatherType.雷阵雨:
                        if (i == 0)
                        {
                            userParam.BackImg = CC2013.Properties.Resources.main_5;
                            userParam.WeatherImg = CC2013.Properties.Resources.Big_5;
                        }
                        userParam.WeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_5;
                        break;
                    case WeatherType.雷阵雨伴有冰雹:
                    case WeatherType.雨夹雪:
                        if (i == 0)
                        {
                            userParam.BackImg = CC2013.Properties.Resources.main_3;
                            userParam.WeatherImg = CC2013.Properties.Resources.Big_3;
                        }
                        userParam.WeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_3;
                        break;
                    case WeatherType.小雨:
                    case WeatherType.中雨:
                    case WeatherType.大雨:
                    case WeatherType.小到中雨:
                    case WeatherType.中到大雨:
                    case WeatherType.暴雨:
                    case WeatherType.大暴雨:
                    case WeatherType.特大暴雨:
                    case WeatherType.大到暴雨:
                    case WeatherType.暴雨到大暴雨:
                    case WeatherType.大暴雨到特大暴雨:
                    case WeatherType.冻雨:
                        if (i == 0)
                        {
                            userParam.BackImg = CC2013.Properties.Resources.main_6;
                            userParam.WeatherImg = CC2013.Properties.Resources.Big_6;
                        }
                        userParam.WeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_6;
                        break;
                    case WeatherType.阵雪:
                    case WeatherType.小雪:
                    case WeatherType.中雪:
                    case WeatherType.大雪:
                    case WeatherType.暴雪:
                    case WeatherType.小到中雪:
                    case WeatherType.中到大雪:
                    case WeatherType.大到暴雪:
                        if (i == 0)
                        {
                            userParam.BackImg = CC2013.Properties.Resources.main_7;
                            userParam.WeatherImg = CC2013.Properties.Resources.Big_7;
                        }
                        userParam.WeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_7;
                        break;
                    case WeatherType.雾:
                        if (i == 0)
                        {
                            userParam.BackImg = CC2013.Properties.Resources.main_8;
                            userParam.WeatherImg = CC2013.Properties.Resources.Big_8;
                        }
                        userParam.WeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_8;
                        break;
                    case WeatherType.浮尘:
                    case WeatherType.扬沙:
                        if (i == 0)
                        {
                            userParam.BackImg = CC2013.Properties.Resources.main_9;
                            userParam.WeatherImg = CC2013.Properties.Resources.Big_9;
                        }
                        userParam.WeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_9;
                        break;
                    case WeatherType.沙尘暴:
                    case WeatherType.强沙尘暴:
                        if (i == 0)
                        {
                            userParam.BackImg = CC2013.Properties.Resources.main_10;
                            userParam.WeatherImg = CC2013.Properties.Resources.Big_10;
                        }
                        userParam.WeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_10;
                        break;
                    default:
                        break;
                }
            }
            
        }

        #endregion

        /***********WebService调用天气***********/

        public static string[] GetByWebSevice(string local)
        {
            if (!string.IsNullOrEmpty(local))
            {
                string[] s;
                try
                {
                    object[] args = new object[1];
                    args[0] = local;
                    string urlServices = "http://www.webxml.com.cn/WebServices/WeatherWebService.asmx";
                    object obj = WebServiceHelper.InvokeWebService(urlServices, "getWeatherbyCityName", args);
                    s = obj as string[];
                    return s;
                }
                catch (Exception)
                {
                    return null;
                    //MessageBox.Show("不能获取天气！", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }

            return null;
        }

        public static string[] GetByWebSeviceUrl(string local)
        {
            if (!string.IsNullOrEmpty(local))
            {
                string[] s;
                try
                {
                    WeatherService.WeatherWebService w = new WeatherService.WeatherWebService();
                    s = w.getWeatherbyCityName(local);
                    return s;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return null;
        }

        #region 分解天气信息ByWebSevice

        public static void DisWeatherInfo(User_Param userParam, string[] s)
        {
            string temp = s[10].Replace("今日天气实况：", "");
            string[] arrayLen = temp.Split('；');
            userParam.CurrentTemp = arrayLen[0].Split('：')[1]; //当前气温
            userParam.Wind = arrayLen[1].Split('：')[1]; //风

            //气候
            userParam.WebWeatherList = new List<WebSeviceWeather>();
            GetInfo(userParam.WebWeatherList, s, 5, 6);
            GetInfo(userParam.WebWeatherList, s, 12, 13);
            GetInfo(userParam.WebWeatherList, s, 17, 18);

            GetImgByWebSevice(userParam);
        }

        private static void GetInfo(List<WebSeviceWeather> webWeatherList, string[] s, int t, int c)
        {
            WebSeviceWeather weather = new WebSeviceWeather();
            weather.Temperature = s[t];
            weather.Climate = s[c].Split(' ')[1];
            webWeatherList.Add(weather);
        }

        #endregion

        #region 获取当天天气图标ByWebSevice

        private static void GetImgByWebSevice(User_Param userParam)
        {
            if (userParam.WebWeatherList == null || userParam.WebWeatherList.Count < 3)
            {
                return;
            }


            for (int i = 0; i < 3; i++)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(userParam.WebWeatherList[i].Climate, "浮尘")
                    || System.Text.RegularExpressions.Regex.IsMatch(userParam.WebWeatherList[i].Climate, "扬沙"))
                {
                    if (i == 0)
                    {
                        userParam.BackImg = CC2013.Properties.Resources.main_9;
                        userParam.WeatherImg = CC2013.Properties.Resources.Big_9;
                    }
                    userParam.WebWeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_9;
                    continue;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(userParam.WebWeatherList[i].Climate, "沙尘"))
                {
                    if (i == 0)
                    {
                        userParam.BackImg = CC2013.Properties.Resources.main_10;
                        userParam.WeatherImg = CC2013.Properties.Resources.Big_10;
                    }
                    userParam.WebWeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_10;
                    continue;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(userParam.WebWeatherList[i].Climate, "雪"))
                {
                    if (i == 0)
                    {
                        userParam.BackImg = CC2013.Properties.Resources.main_7;
                        userParam.WeatherImg = CC2013.Properties.Resources.Big_7;
                    }
                    userParam.WebWeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_7;
                    continue;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(userParam.WebWeatherList[i].Climate, "雨"))
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(userParam.WebWeatherList[i].Climate, "阵雨"))
                    {
                        if (i == 0)
                        {
                            userParam.BackImg = CC2013.Properties.Resources.main_4;
                            userParam.WeatherImg = CC2013.Properties.Resources.Big_4;
                        }
                        userParam.WebWeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_4;
                        continue;
                    }

                    if (System.Text.RegularExpressions.Regex.IsMatch(userParam.WebWeatherList[i].Climate, "雷"))
                    {
                        if (i == 0)
                        {
                            userParam.BackImg = CC2013.Properties.Resources.main_5;
                            userParam.WeatherImg = CC2013.Properties.Resources.Big_5;
                        }
                        userParam.WebWeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_5;
                        continue;
                    }
                    else
                    {
                        if (i == 0)
                        {
                            userParam.BackImg = CC2013.Properties.Resources.main_6;
                            userParam.WeatherImg = CC2013.Properties.Resources.Big_6;
                        }
                        userParam.WebWeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_6;
                        continue;
                    }

                }
                if (System.Text.RegularExpressions.Regex.IsMatch(userParam.WebWeatherList[i].Climate, "阴"))
                {
                    if (i == 0)
                    {
                        userParam.BackImg = CC2013.Properties.Resources.main_3;
                        userParam.WeatherImg = CC2013.Properties.Resources.Big_3;
                    }
                    userParam.WebWeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_3;
                    continue;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(userParam.WebWeatherList[i].Climate, "多云"))
                {
                    if (i == 0)
                    {
                        userParam.BackImg = CC2013.Properties.Resources.main_2;
                        userParam.WeatherImg = CC2013.Properties.Resources.Big_2;
                    }
                    userParam.WebWeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_2;
                    continue;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(userParam.WebWeatherList[i].Climate, "晴"))
                {
                    if (i == 0)
                    {
                        userParam.BackImg = CC2013.Properties.Resources.main_1;
                        userParam.WeatherImg = CC2013.Properties.Resources.Big_1;
                    }
                    userParam.WebWeatherList[i].WeatherImg = CC2013.Properties.Resources.Small_1;
                    continue;
                }

            }
        }

        #endregion
        

        #region 获取城市代码(此方法连接网址时常超时，已没使用)

        /// <summary>
        /// 获取城市代码
        /// </summary>
        /// <returns></returns>
        private static string GetCityId()
        {
            HttpWebRequest wNetr = (HttpWebRequest)HttpWebRequest.Create("http://61.4.185.48:81/g/");
            HttpWebResponse wNetp = (HttpWebResponse)wNetr.GetResponse();

            wNetr.ContentType = "text/html";
            wNetr.Method = "Get";

            Stream Streams = wNetp.GetResponseStream();
            StreamReader Reads = new StreamReader(Streams, Encoding.UTF8);

            String ReCode = Reads.ReadToEnd();
            //关闭暂时不适用的资源
            Reads.Dispose();
            Streams.Dispose();
            wNetp.Close();
            //分析返回代码
            String[] Temp = ReCode.Split(';');

            ReCode = Temp[1].Replace("var id=", "");

            return ReCode;
        }

        #endregion
    }
}
