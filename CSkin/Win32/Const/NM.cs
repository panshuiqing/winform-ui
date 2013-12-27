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
 * * 说明：NM.cs
 * *
********************************************************************/

using System;

namespace CCWin.Win32.Const
{
    /// <summary>
    /// Generic WM_NOTIFY notification codes 
    /// </summary>
    public static class NM
    {
        public const int NM_FIRST = 0;
        public const int NM_OUTOFMEMORY = (NM_FIRST - 1);
        public const int NM_CLICK = (NM_FIRST - 2);    // uses NMCLICK struct
        public const int NM_DBLCLK = (NM_FIRST - 3);
        public const int NM_RETURN = (NM_FIRST - 4);
        public const int NM_RCLICK = (NM_FIRST - 5);    // uses NMCLICK struct
        public const int NM_RDBLCLK = (NM_FIRST - 6);
        public const int NM_SETFOCUS = (NM_FIRST - 7);
        public const int NM_KILLFOCUS = (NM_FIRST - 8);

#if (_WIN32_IE0300) //>= 0x0300
        public const int NM_CUSTOMDRAW = (NM_FIRST-12);
        public const int NM_HOVER = (NM_FIRST-13);
#endif

#if (_WIN32_IE0400) //>= 0x0400
        public const int NM_NCHITTEST = (NM_FIRST-14);   // uses NMMOUSE struct
        public const int NM_KEYDOWN  = (NM_FIRST-15);   // uses NMKEY struct
        public const int NM_RELEASEDCAPTURE = (NM_FIRST-16);
        public const int NM_SETCURSOR = (NM_FIRST-17);   // uses NMMOUSE struct
        public const int NM_CHAR = (NM_FIRST-18);   // uses NMCHAR struct
#endif

#if (_WIN32_IE0401) //>= 0x0401
        public const int NM_TOOLTIPSCREATED = (NM_FIRST-19);   // notify of when the tooltips window is create
#endif

#if (_WIN32_IE0500) //>= 0x0500
        public const int NM_LDOWN = (NM_FIRST-20);
        public const int NM_RDOWN = (NM_FIRST-21);
        public const int NM_THEMECHANGED = (NM_FIRST-22);
#endif
    }
}
