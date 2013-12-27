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
 * * 说明：DWebBrowserEvents2.cs
 * *
********************************************************************/

using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace CCWin.Win32.Com
{
    [ComImport, Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D"), 
    TypeLibType(TypeLibTypeFlags.FHidden | TypeLibTypeFlags.FDispatchable), 
    InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface DWebBrowserEvents2
    {
        [PreserveSig,
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), 
        DispId(0x66)]
        void StatusTextChange([In, MarshalAs(UnmanagedType.BStr)] string Text);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), 
        DispId(0x6c)]
        void ProgressChange([In] int Progress, [In] int ProgressMax);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        DispId(0x69)]
        void CommandStateChange([In] int Command, [In] bool Enable);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), 
        DispId(0x6a)]
        void DownloadBegin();

        [PreserveSig,
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        DispId(0x68)]
        void DownloadComplete();

        [PreserveSig,
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        DispId(0x71)]
        void TitleChange([In, MarshalAs(UnmanagedType.BStr)] string Text);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        DispId(0x70)]
        void PropertyChange([In, MarshalAs(UnmanagedType.BStr)] string szProperty);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        DispId(250)]
        void BeforeNavigate2(
            [In, MarshalAs(UnmanagedType.IDispatch)] object pDisp,
            [In, MarshalAs(UnmanagedType.Struct)] ref object URL, 
            [In, MarshalAs(UnmanagedType.Struct)] ref object Flags, 
            [In, MarshalAs(UnmanagedType.Struct)] ref object TargetFrameName, 
            [In, MarshalAs(UnmanagedType.Struct)] ref object PostData,
            [In, MarshalAs(UnmanagedType.Struct)] ref object Headers, 
            [In, Out] ref bool Cancel);

        [PreserveSig,
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        DispId(0xfb)]
        void NewWindow2(
            [In, Out, MarshalAs(UnmanagedType.IDispatch)] ref object ppDisp, 
            [In, Out] ref bool Cancel);

        [PreserveSig,
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), 
        DispId(0xfc)]
        void NavigateComplete2(
            [In, MarshalAs(UnmanagedType.IDispatch)] object pDisp,
            [In, MarshalAs(UnmanagedType.Struct)] ref object URL);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        DispId(0x103)]
        void DocumentComplete(
            [In, MarshalAs(UnmanagedType.IDispatch)] object pDisp,
            [In, MarshalAs(UnmanagedType.Struct)] ref object URL);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), 
        DispId(0xfd)]
        void OnQuit();

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), 
        DispId(0xfe)]
        void OnVisible([In] bool Visible);

        [PreserveSig,
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        DispId(0xff)]
        void OnToolBar([In] bool ToolBar);

        [PreserveSig, MethodImpl(
            MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        DispId(0x100)]
        void OnMenuBar([In] bool MenuBar);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), 
        DispId(0x101)]
        void OnStatusBar([In] bool StatusBar);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        DispId(0x102)]
        void OnFullScreen([In] bool FullScreen);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        DispId(260)]
        void OnTheaterMode([In] bool TheaterMode);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        DispId(0x106)]
        void WindowSetResizable([In] bool Resizable);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), 
        DispId(0x108)]
        void WindowSetLeft([In] int Left);

        [PreserveSig,
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        DispId(0x109)]
        void WindowSetTop([In] int Top);

        [PreserveSig,
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        DispId(0x10a)]
        void WindowSetWidth([In] int Width);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), 
        DispId(0x10b)]
        void WindowSetHeight([In] int Height);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), 
        DispId(0x107)]
        void WindowClosing([In] bool IsChildWindow, [In, Out] ref bool Cancel);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        DispId(0x10c)]
        void ClientToHostWindow([In, Out] ref int CX, [In, Out] ref int CY);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        DispId(0x10d)]
        void SetSecureLockIcon([In] int SecureLockIcon);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), 
        DispId(270)]
        void FileDownload([In, Out] ref bool Cancel);

        [PreserveSig,
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), 
        DispId(0x10f)]
        void NavigateError(
            [In, MarshalAs(UnmanagedType.IDispatch)] object pDisp,
            [In, MarshalAs(UnmanagedType.Struct)] ref object URL, 
            [In, MarshalAs(UnmanagedType.Struct)] ref object Frame, 
            [In, MarshalAs(UnmanagedType.Struct)] ref object StatusCode,
            [In, Out] ref bool Cancel);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), 
        DispId(0xe1)]
        void PrintTemplateInstantiation(
            [In, MarshalAs(UnmanagedType.IDispatch)] object pDisp);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), 
        DispId(0xe2)]
        void PrintTemplateTeardown([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), 
        DispId(0xe3)]
        void UpdatePageStatus(
            [In, MarshalAs(UnmanagedType.IDispatch)] object pDisp,
            [In, MarshalAs(UnmanagedType.Struct)] ref object nPage,
            [In, MarshalAs(UnmanagedType.Struct)] ref object fDone);

        [PreserveSig,
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        DispId(0x110)]
        void PrivacyImpactedStateChange([In] bool bImpacted);

        [PreserveSig, 
        MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), 
        DispId(0x111)]
        void NewWindow3(
            [In, Out, MarshalAs(UnmanagedType.IDispatch)] ref object ppDisp,
            [In, Out] ref bool Cancel, [In] uint dwFlags, 
            [In, MarshalAs(UnmanagedType.BStr)] string bstrUrlContext,
            [In, MarshalAs(UnmanagedType.BStr)] string bstrUrl);
    }
}
