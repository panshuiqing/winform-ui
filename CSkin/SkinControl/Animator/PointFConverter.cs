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
 * * 说明：PointFConverter.cs
 * *
********************************************************************/

using System;
using System.ComponentModel;
using System.Drawing;

namespace CCWin.SkinControl
{
    /// <summary>
    /// PointFConverter
    /// Thanks for Jay Riggs
    /// </summary>
    public class PointFConverter : ExpandableObjectConverter
    {
        /// <summary>
        /// Creates a new instance of PointFConverter
        /// </summary>
        public PointFConverter()
        {
        }

        /// <summary>
        /// Boolean, true if the source type is a string
        /// </summary>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string)) return true;
            return base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        /// Converts the specified string into a PointF
        /// </summary>
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                try
                {
                    string s = (string)value;
                    string[] converterParts = s.Split(',');
                    float x = 0;
                    float y = 0;
                    if (converterParts.Length > 1)
                    {
                        x = float.Parse(converterParts[0].Trim().Trim('{', 'X', 'x','='));
                        y = float.Parse(converterParts[1].Trim().Trim('}', 'Y', 'y','='));
                    }
                    else if (converterParts.Length == 1)
                    {
                        x = float.Parse(converterParts[0].Trim());
                        y = 0;
                    }
                    else
                    {
                        x = 0F;
                        y = 0F;
                    }
                    return new PointF(x, y);
                }
                catch
                {
                    throw new ArgumentException("Cannot convert [" + value.ToString() + "] to pointF");
                }
            }
            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// Converts the PointF into a string
        /// </summary>
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value.GetType() == typeof(PointF))
                {
                    PointF pt = (PointF)value;
                    return string.Format("{{X={0}, Y={1}}}", pt.X, pt.Y);
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
