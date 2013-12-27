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
 * * 说明：IWebBrowser2.cs
 * *
********************************************************************/

using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;

namespace CCWin.Win32.Com
{
    [ComImport, 
    Guid("D30C1661-CDAF-11d0-8A3E-00C04FC9E26E"), 
    TypeLibType(TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDual | TypeLibTypeFlags.FHidden), 
    SuppressUnmanagedCodeSecurity]
    public interface IWebBrowser2
    {
        [DispId(100)]
        void GoBack();

        [DispId(0x65)]
        void GoForward();

        [DispId(0x66)]
        void GoHome();

        [DispId(0x67)]
        void GoSearch();

        [DispId(0x68)]
        void Navigate(
            [In] string Url, 
            [In] ref object flags, 
            [In] ref object targetFrameName, 
            [In] ref object postData, [In] ref object headers);

        [DispId(-550)]
        void Refresh();

        [DispId(0x69)]
        void Refresh2([In] ref object level);

        [DispId(0x6a)]
        void Stop();

        [DispId(200)]
        object Application { [return: MarshalAs(UnmanagedType.IDispatch)] get; }

        [DispId(0xc9)]
        object Parent { [return: MarshalAs(UnmanagedType.IDispatch)] get; }

        [DispId(0xca)]
        object Container { [return: MarshalAs(UnmanagedType.IDispatch)] get; }

        [DispId(0xcb)]
        object Document { [return: MarshalAs(UnmanagedType.IDispatch)] get; }

        [DispId(0xcc)]
        bool TopLevelContainer { get; }

        [DispId(0xcd)]
        string Type { get; }

        [DispId(0xce)]
        int Left { get; set; }

        [DispId(0xcf)]
        int Top { get; set; }

        [DispId(0xd0)]
        int Width { get; set; }

        [DispId(0xd1)]
        int Height { get; set; }

        [DispId(210)]
        string LocationName { get; }

        [DispId(0xd3)]
        string LocationURL { get; }

        [DispId(0xd4)]
        bool Busy { get; }

        [DispId(300)]
        void Quit();

        [DispId(0x12d)]
        void ClientToWindow(out int pcx, out int pcy);

        [DispId(0x12e)]
        void PutProperty([In] string property, [In] object vtValue);

        [DispId(0x12f)]
        object GetProperty([In] string property);

        [DispId(0)]
        string Name { get; }

        [DispId(-515)]
        int HWND { get; }

        [DispId(400)]
        string FullName { get; }

        [DispId(0x191)]
        string Path { get; }

        [DispId(0x192)]
        bool Visible { get; set; }

        [DispId(0x193)]
        bool StatusBar { get; set; }

        [DispId(0x194)]
        string StatusText { get; set; }

        [DispId(0x195)]
        int ToolBar { get; set; }

        [DispId(0x196)]
        bool MenuBar { get; set; }

        [DispId(0x197)]
        bool FullScreen { get; set; }

        [DispId(500)]
        void Navigate2(
            [In] ref object URL, 
            [In] ref object flags, 
            [In] ref object targetFrameName,
            [In] ref object postData, 
            [In] ref object headers);

        [DispId(0x1f5)]
        OLECMDF QueryStatusWB([In] OLECMDID cmdID);

        [DispId(0x1f6)]
        void ExecWB(
            [In] OLECMDID cmdID,
            [In] OLECMDEXECOPT cmdexecopt, 
            ref object pvaIn, 
            IntPtr pvaOut);

        [DispId(0x1f7)]
        void ShowBrowserBar(
            [In] ref object pvaClsid, 
            [In] ref object pvarShow, 
            [In] ref object pvarSize);

        [DispId(-525)]
        WebBrowserReadyState ReadyState { get; }

        [DispId(550)]
        bool Offline { get; set; }

        [DispId(0x227)]
        bool Silent { get; set; }

        [DispId(0x228)]
        bool RegisterAsBrowser { get; set; }

        [DispId(0x229)]
        bool RegisterAsDropTarget { get; set; }

        [DispId(0x22a)]
        bool TheaterMode { get; set; }

        [DispId(0x22b)]
        bool AddressBar { get; set; }

        [DispId(0x22c)]
        bool Resizable { get; set; }
    }
}
