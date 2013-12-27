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
 * * 说明：DI.cs
 * *
********************************************************************/

using System;

namespace CCWin.Win32.Const
{
    public static class DI
    {
        /// <summary>
        /// Draws the icon or cursor using the mask.
        /// </summary>
        public const int DI_MASK = 0x0001;

        /// <summary>
        /// Draws the icon or cursor using the image.
        /// </summary>
        public const int DI_IMAGE = 0x0002;

        /// <summary>
        /// Combination of DI_IMAGE and DI_MASK.
        /// </summary>
        public const int DI_NORMAL = 0x0003;

        /// <summary>
        /// Draws the icon or cursor using the system default image rather than the user-specified image. 
        /// For more information, see About Cursors. Windows NT4.0 and later: This flag is ignored.
        /// </summary>
        public const int DI_COMPAT = 0x0004;

        /// <summary>
        /// Draws the icon or cursor using the width and height specified by the system metric values for cursors or icons, 
        /// if the cxWidth and cyWidth parameters are set to zero. If this flag is not specified and cxWidth and cyWidth are set to zero, 
        /// the function uses the actual resource size. 
        /// </summary>
        public const int DI_DEFAULTSIZE = 0x0008;

        /// <summary>
        /// Windows XP: Draws the icon as an unmirrored icon. By default, the icon is drawn as a mirrored icon if hdc is mirrored.
        /// </summary>
        public const int DI_NOMIRROR = 0x0010;
    }
}
