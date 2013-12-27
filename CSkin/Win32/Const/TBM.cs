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
 * * 说明：TBM.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace CCWin.Win32.Const
{
    /// <summary>
    /// trackbar messages.
    /// </summary>
    public static class TBM
    {
        private const int WM_USER = 0x0400;

        public const int TBM_GETRANGEMIN = (WM_USER + 1);
        public const int TBM_GETRANGEMAX = (WM_USER + 2);
        public const int TBM_GETTIC = (WM_USER + 3);
        public const int TBM_SETTIC = (WM_USER + 4);
        public const int TBM_SETPOS = (WM_USER + 5);
        public const int TBM_SETRANGE = (WM_USER + 6);
        public const int TBM_SETRANGEMIN = (WM_USER + 7);
        public const int TBM_SETRANGEMAX = (WM_USER + 8);
        public const int TBM_CLEARTICS = (WM_USER + 9);
        public const int TBM_SETSEL = (WM_USER + 10);
        public const int TBM_SETSELSTART = (WM_USER + 11);
        public const int TBM_SETSELEND = (WM_USER + 12);
        public const int TBM_GETPTICS = (WM_USER + 14);
        public const int TBM_GETTICPOS = (WM_USER + 15);
        public const int TBM_GETNUMTICS = (WM_USER + 16);
        public const int TBM_GETSELSTART = (WM_USER + 17);
        public const int TBM_GETSELEND = (WM_USER + 18);
        public const int TBM_CLEARSEL = (WM_USER + 19);
        public const int TBM_SETTICFREQ = (WM_USER + 20);
        public const int TBM_SETPAGESIZE = (WM_USER + 21);
        public const int TBM_GETPAGESIZE = (WM_USER + 22);
        public const int TBM_SETLINESIZE = (WM_USER + 23);
        public const int TBM_GETLINESIZE = (WM_USER + 24);
        public const int TBM_GETTHUMBRECT = (WM_USER + 25);
        public const int TBM_GETCHANNELRECT = (WM_USER + 26);
        public const int TBM_SETTHUMBLENGTH = (WM_USER + 27);
        public const int TBM_GETTHUMBLENGTH = (WM_USER + 28);
    }
}
