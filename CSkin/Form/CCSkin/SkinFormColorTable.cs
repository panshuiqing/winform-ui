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
 * * 说明：SkinFormColorTable.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CCWin
{
    public class SkinFormColorTable
    {
        //Color.FromArgb(75, 188, 254);
        public static readonly Color _captionActive =
            Color.Transparent;
        //Color.FromArgb(131, 209, 255);
        public static readonly Color _captionDeactive =
            Color.Transparent;
        //Color.FromArgb(40, 111, 152);
        public static readonly Color _captionText =
            Color.Black;
        //Color.FromArgb(55, 126, 168);
        public static readonly Color _border =
            Color.FromArgb(100, 0, 0, 0);
        //Color.FromArgb(200, 250, 250, 250);
        public static readonly Color _innerBorder =
            Color.FromArgb(100, 250, 250, 250);
        public static readonly Color _back =
            Color.FromArgb(128, 208, 255);
        public static Color _controlBoxActive =
            Color.FromArgb(51, 153, 204);
        public static Color _controlBoxDeactive =
            Color.FromArgb(88, 172, 218);
        public static readonly Color _controlBoxHover =
            Color.FromArgb(150, 39, 175, 231);
        public static readonly Color _controlBoxPressed =
           Color.FromArgb(150, 29, 142, 190);
        private static readonly Color _controlCloseBoxHover =
            Color.FromArgb(213, 66, 22);
        private static readonly Color _controlCloseBoxPressed =
            Color.FromArgb(171, 53, 17);
        public static readonly Color _controlBoxInnerBorder =
            Color.FromArgb(128, 250, 250, 250);

        public virtual Color CaptionActive
        {
            get { return _captionActive; }
        }

        public virtual Color CaptionDeactive
        {
            get { return _captionDeactive; }
        }

        public virtual Color CaptionText
        {
            get { return _captionText; }
        }

        public virtual Color Border
        {
            get { return _border; }
        }

        public virtual Color InnerBorder
        {
            get { return _innerBorder; }
        }

        public virtual Color Back
        {
            get { return _back; }
        }

        public virtual Color ControlBoxActive
        {
            get { return _controlBoxActive; }
            set { _controlBoxActive = value; }
        }

        public virtual Color ControlBoxDeactive
        {
            get { return _controlBoxDeactive; }
            set { _controlBoxDeactive = value; }
        }

        public virtual Color ControlBoxHover
        {
            get { return _controlBoxHover; }
        }

        public virtual Color ControlBoxPressed
        {
            get { return _controlBoxPressed; }
        }

        public virtual Color ControlCloseBoxHover
        {
            get { return _controlCloseBoxHover; }
        }

        public virtual Color ControlCloseBoxPressed
        {
            get { return _controlCloseBoxPressed; }
        }

        public virtual Color ControlBoxInnerBorder
        {
            get { return _controlBoxInnerBorder; }
        }
    }
}
