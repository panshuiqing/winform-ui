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
 * * 说明：AndyDateConvert.cs
 * *
********************************************************************/

using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CC2013
{
    /// <summary>
    /// 把"2007-11-4"转换为"二〇〇七年十一月四号" 
    /// 示例：DateConvert.Instance.Baodate2Chinese("2007-11-4")
    /// 示例：DateConvert.Instance.Baodate2Chinese("07-11-4")
    /// 示例：DateConvert.Instance.Baodate2Chinese("2007/11/4")
    /// 示例：DateConvert.Instance.Baodate2Chinese("07/11/4")
    /// </summary>
    public class DateConvert
    {
        private static DateConvert m_DateConvert = null;

        private char[] strChinese;

        private DateConvert()
        {
            strChinese = new char[] {
                 '〇','一','二','三','四','五','六','七','八','九','十'
             };
        }

        public static DateConvert Instance
        {
            get
            {
                if (m_DateConvert == null)
                    m_DateConvert = new DateConvert();
                return m_DateConvert;
            }
        }

        public string Baodate2Chinese(string strDate)
        {
            StringBuilder result = new StringBuilder();

            // 依据正则表达式判断参数是否正确
            Regex theReg = new Regex(@"(d{2}|d{4})(/|-)(d{1,2})(/|-)(d{1,2})");
            if (theReg.Match(strDate).Length != 0)
            {
                // 将数字日期的年月日存到字符数组str中
                string[] str = null;
                if (strDate.Contains("-"))
                {
                    str = strDate.Split('-');
                }
                else if (strDate.Contains("/"))
                {
                    str = strDate.Split('/');
                }

                // str[0]中为年，将其各个字符转换为相应的汉字
                for (int i = 0; i < str[0].Length; i++)
                {
                    result.Append(strChinese[int.Parse(str[0][i].ToString())]);
                }
                result.Append("年");

                // 转换月
                int month = int.Parse(str[1]);
                int MN1 = month / 10;
                int MN2 = month % 10;

                if (MN1 > 1)
                {
                    result.Append(strChinese[MN1]);
                }
                if (MN1 > 0)
                {
                    result.Append(strChinese[10]);
                }
                if (MN2 != 0)
                {
                    result.Append(strChinese[MN2]);
                }
                result.Append("月");

                // 转换日
                int day = int.Parse(str[2]);
                int DN1 = day / 10;
                int DN2 = day % 10;

                if (DN1 > 1)
                {
                    result.Append(strChinese[DN1]);
                }
                if (DN1 > 0)
                {
                    result.Append(strChinese[10]);
                }
                if (DN2 != 0)
                {
                    result.Append(strChinese[DN2]);
                }
                result.Append("日");
            }
            else
            {
                throw new ArgumentException();
            }

            return result.ToString();
        }

    }
}
