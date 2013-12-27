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
 * * 说明：IDataObject.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CCWin.SkinControl
{
    [ComVisible(true),
    ComImport(),
    Guid("0000010E-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDataObject
    {
        [PreserveSig()]
        uint GetData(
            ref FORMATETC a,
            ref STGMEDIUM b);

        [PreserveSig()]
        uint GetDataHere(
            ref FORMATETC pFormatetc,
            out STGMEDIUM pMedium);

        [PreserveSig()]
        uint QueryGetData(
            ref FORMATETC pFormatetc);

        [PreserveSig()]
        uint GetCanonicalFormatEtc(
            ref FORMATETC pformatectIn,
            out	FORMATETC pformatetcOut);

        [PreserveSig()]
        uint SetData(
            ref FORMATETC pFormatectIn,
            ref STGMEDIUM pmedium,
            [In, MarshalAs(UnmanagedType.Bool)]
			bool fRelease);

        [PreserveSig()]
        uint EnumFormatEtc(
            uint dwDirection, IEnumFORMATETC penum);

        [PreserveSig()]
        uint DAdvise(
            ref FORMATETC pFormatetc,
            int advf,
            [In, MarshalAs(UnmanagedType.Interface)]
			IAdviseSink pAdvSink,
            out uint pdwConnection);

        [PreserveSig()]
        uint DUnadvise(
            uint dwConnection);

        [PreserveSig()]
        uint EnumDAdvise(
            [Out, MarshalAs(UnmanagedType.Interface)]
			out IEnumSTATDATA ppenumAdvise);
    }
}
