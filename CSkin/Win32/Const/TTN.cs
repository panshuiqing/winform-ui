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
 * * 说明：TTN.cs
 * *
********************************************************************/

using System;
using System.Runtime.InteropServices;

namespace CCWin.Win32.Const
{
    public static class TTN
    {
        // ownerdraw
        public const int TTN_FIRST = (-520);

        public const int TTN_GETDISPINFOA = (TTN_FIRST - 0);
        public const int TTN_GETDISPINFOW = (TTN_FIRST - 10);
        public const int TTN_SHOW = (TTN_FIRST - 1);
        public const int TTN_POP = (TTN_FIRST - 2);
        public const int TTN_LINKCLICK = (TTN_FIRST - 3);

        public const int TTN_NEEDTEXTA = TTN_GETDISPINFOA;
        public const int TTN_NEEDTEXTW = TTN_GETDISPINFOW;

        public const int TTN_LAST = (-549);

        public readonly static int TTN_GETDISPINFO;
        public readonly static int TTN_NEEDTEXT;

        static TTN()
        {
            bool unicode = Marshal.SystemDefaultCharSize != 1;
            if (unicode)
            {
                TTN_GETDISPINFO = TTN_GETDISPINFOW;
                TTN_NEEDTEXT = TTN_NEEDTEXTW;
            }
            else
            {
                TTN_GETDISPINFO = TTN_GETDISPINFOA;
                TTN_NEEDTEXT = TTN_NEEDTEXTA;
            }
        }
    }
}
