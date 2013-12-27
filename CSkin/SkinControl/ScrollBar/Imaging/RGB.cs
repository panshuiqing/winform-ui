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
 * * 说明：RGB.cs
 * *
********************************************************************/

using System;
using System.Drawing;

namespace CCWin.Imaging
{
    public class RGB
    {
        private byte _r;
        private byte _g;
        private byte _b;

        public const short RIndex = 2;
        public const short GIndex = 1;
        public const short BIndex = 0;

        public byte R
        {
            get { return _r; }
            set { _r = value; }
        }

        public byte G
        {
            get { return _g; }
            set { _g = value; }
        }

        public byte B
        {
            get { return _b; }
            set { _b = value; }
        }

        public Color Color
        {
            get { return Color.FromArgb(_r, _g, _b); }
            set
            {
                _r = value.R;
                _g = value.G;
                _b = value.B;
            }
        }

        public RGB() { }

        public RGB(byte r, byte g, byte b)
        {
            _r = r;
            _g = g;
            _b = b;
        }

        public RGB(Color color)
        {
            _r = color.R;
            _g = color.G;
            _b = color.B;
        }

        public override string ToString()
        {
            return string.Format("RGB [R={0}, G={1}, B={2}]", _r, _g, _b);
        }
    }
}
