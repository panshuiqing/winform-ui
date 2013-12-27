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
 * * 说明：IDocHostUIHandler.cs
 * *
********************************************************************/

using System;
using System.Runtime.InteropServices;

namespace CCWin.Win32.Com
{
    [ComVisible(true), ComImport()]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GuidAttribute("bd3f23c0-d43e-11cf-893b-00aa00bdce1a")]
    public interface IDocHostUIHandler
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ShowContextMenu(
            [In, MarshalAs(UnmanagedType.U4)] uint dwID,
            [In, MarshalAs(UnmanagedType.Struct)] ref tagPOINT pt,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pcmdtReserved,
            [In, MarshalAs(UnmanagedType.IDispatch)] object pdispReserved);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetHostInfo([In, Out, MarshalAs(UnmanagedType.Struct)] ref DOCHOSTUIINFO info);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ShowUI(
            [In, MarshalAs(UnmanagedType.I4)] int dwID,
            [In, MarshalAs(UnmanagedType.Interface)] IOleInPlaceActiveObject activeObject,
            [In, MarshalAs(UnmanagedType.Interface)] IOleCommandTarget commandTarget,
            [In, MarshalAs(UnmanagedType.Interface)] IOleInPlaceFrame frame,
            [In, MarshalAs(UnmanagedType.Interface)] IOleInPlaceUIWindow doc);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int HideUI();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int UpdateUI();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EnableModeless(
            [In, MarshalAs(UnmanagedType.Bool)] bool fEnable);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnDocWindowActivate(
            [In, MarshalAs(UnmanagedType.Bool)] bool fActivate);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnFrameWindowActivate(
            [In, MarshalAs(UnmanagedType.Bool)] bool fActivate);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ResizeBorder(
            [In, MarshalAs(UnmanagedType.Struct)] ref tagRECT rect,
            [In, MarshalAs(UnmanagedType.Interface)] IOleInPlaceUIWindow doc,
            [In, MarshalAs(UnmanagedType.Bool)] bool fFrameWindow);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int TranslateAccelerator(
            [In, MarshalAs(UnmanagedType.Struct)] ref tagMSG msg,
            [In] ref Guid group,
            [In, MarshalAs(UnmanagedType.U4)] uint nCmdID);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetOptionKeyPath(
            //out IntPtr pbstrKey,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out String pbstrKey,
            //[Out, MarshalAs(UnmanagedType.LPArray)] String[] pbstrKey,
            [In, MarshalAs(UnmanagedType.U4)] uint dw);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetDropTarget(
            [In, MarshalAs(UnmanagedType.Interface)] IDropTarget pDropTarget,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDropTarget ppDropTarget);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetExternal(
            [Out, MarshalAs(UnmanagedType.IDispatch)] out object ppDispatch);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int TranslateUrl(
            [In, MarshalAs(UnmanagedType.U4)] uint dwTranslate,
            [In, MarshalAs(UnmanagedType.LPWStr)] string strURLIn,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pstrURLOut);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int FilterDataObject(
            [In, MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IDataObject pDO,
            [Out, MarshalAs(UnmanagedType.Interface)] out System.Runtime.InteropServices.ComTypes.IDataObject ppDORet);
    }
}
