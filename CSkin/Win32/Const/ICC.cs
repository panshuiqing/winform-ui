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
 * * 说明：ICC.cs
 * *
********************************************************************/

using System;

namespace CCWin.Win32.Const
{
    /// <summary>
    /// INITCOMMONCONTROLSEX 结构的 dwICC 字段使用的常量。
    /// </summary>
    public static class ICC
    {
        /// <summary>
        /// listview, header
        /// </summary>
        public const int ICC_LISTVIEW_CLASSES = 0x00000001; 

        /// <summary>
        /// treeview, tooltips
        /// </summary>
        public const int ICC_TREEVIEW_CLASSES = 0x00000002;

        /// <summary>
        /// 注册工具栏、状态栏、Trackbar和Tooltip类。
        /// </summary>
        public const int ICC_BAR_CLASSES = 0x00000004; 
        
        /// <summary>
        /// tab, tooltips
        /// </summary>
        public const int ICC_TAB_CLASSES = 0x00000008;

        /// <summary>
        /// updown
        /// </summary>
        public const int ICC_UPDOWN_CLASS = 0x00000010; 

        /// <summary>
        /// progress
        /// </summary>
        public const int ICC_PROGRESS_CLASS = 0x00000020;

        /// <summary>
        /// hotkey
        /// </summary>
        public const int ICC_HOTKEY_CLASS = 0x00000040; 

        /// <summary>
        /// animate
        /// </summary>
        public const int ICC_ANIMATE_CLASS = 0x00000080; 
 
        public const int ICC_WIN95_CLASSES = 0x000000FF;

        /// <summary>
        /// month picker, date picker, time picker, updown
        /// </summary>
        public const int ICC_DATE_CLASSES = 0x00000100;

        /// <summary>
        /// comboex
        /// </summary>
        public const int ICC_USEREX_CLASSES = 0x00000200;

        /// <summary>
        ///注册Rebar类。
        /// </summary>
        public const int ICC_COOL_CLASSES = 0x00000400;

#if (_WIN32_IE0400) //>= 0x0400)
        public const int ICC_INTERNET_CLASSES = 0x00000800;

        /// <summary>
        /// page scroller
        /// </summary>
        public const int ICC_PAGESCROLLER_CLASS = 0x00001000;

        /// <summary>
        /// native font control
        /// </summary>
        public const int ICC_NATIVEFNTCTL_CLASS = 0x00002000;
#endif

#if (_WIN32_WINNT501)  //>= 0x501
        public const int ICC_STANDARD_CLASSES = 0x00004000;
        public const int ICC_LINK_CLASS = 0x00008000;
#endif
    }
}
