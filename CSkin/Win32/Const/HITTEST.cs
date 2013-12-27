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
 * * 说明：HITTEST.cs
 * *
********************************************************************/

using System;

namespace CCWin.Win32.Const
{
    public class HITTEST
    {
        /// <summary>
        /// On the screen background or on a dividing line between windows 
        /// (same as HTNOWHERE; except that the DefWindowProc function produces a system beep to indicate an error).
        /// </summary>
        public const int HTERROR = (-2);
        /// <summary>
        /// In a window currently covered by another window in the same thread 
        /// (the message will be sent to underlying windows in the same thread until one of them returns a code that is not HTTRANSPARENT).
        /// </summary>
        public const int HTTRANSPARENT = (-1);
        /// <summary>
        /// On the screen background or on a dividing line between windows.
        /// </summary>
        public const int HTNOWHERE = 0;
        /// <summary>In a client area.</summary>
        public const int HTCLIENT = 1;
        /// <summary>In a title bar.</summary>
        public const int HTCAPTION = 2;
        /// <summary>In a window menu or in a Close button in a child window.</summary>
        public const int HTSYSMENU = 3;
        /// <summary>In a size box (same as HTSIZE).</summary>
        public const int HTGROWBOX = 4;
        /// <summary>In a menu.</summary>
        public const int HTMENU = 5;
        /// <summary>In a horizontal scroll bar.</summary>
        public const int HTHSCROLL = 6;
        /// <summary>In the vertical scroll bar.</summary>
        public const int HTVSCROLL = 7;
        /// <summary>In a Minimize button.</summary>
        public const int HTMINBUTTON = 8;
        /// <summary>In a Maximize button.</summary>
        public const int HTMAXBUTTON = 9;
        /// <summary>In the left border of a resizable window 
        /// (the user can click the mouse to resize the window horizontally).</summary>
        public const int HTLEFT = 10;
        /// <summary>
        /// In the right border of a resizable window 
        /// (the user can click the mouse to resize the window horizontally).
        /// </summary>
        public const int HTRIGHT = 11;
        /// <summary>In the upper-horizontal border of a window.</summary>
        public const int HTTOP = 12;
        /// <summary>In the upper-left corner of a window border.</summary>
        public const int HTTOPLEFT = 13;
        /// <summary>In the upper-right corner of a window border.</summary>
        public const int HTTOPRIGHT = 14;
        /// <summary>	In the lower-horizontal border of a resizable window 
        /// (the user can click the mouse to resize the window vertically).</summary>
        public const int HTBOTTOM = 15;
        /// <summary>In the lower-left corner of a border of a resizable window 
        /// (the user can click the mouse to resize the window diagonally).</summary>
        public const int HTBOTTOMLEFT = 16;
        /// <summary>	In the lower-right corner of a border of a resizable window 
        /// (the user can click the mouse to resize the window diagonally).</summary>
        public const int HTBOTTOMRIGHT = 17;
        /// <summary>In the border of a window that does not have a sizing border.</summary>
        public const int HTBORDER = 18;

        public const int HTOBJECT = 19;
        /// <summary>In a Close button.</summary>
        public const int HTCLOSE = 20;
        /// <summary>In a Help button.</summary>
        public const int HTHELP = 21;
    }
}
