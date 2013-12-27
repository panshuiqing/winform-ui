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
 * * 说明：IRichEditOle.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CCWin.SkinControl
{
    [ComImport, 
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
    Guid("00020D00-0000-0000-c000-000000000046")]
    public interface IRichEditOle
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetClientSite(out IOleClientSite site);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetObjectCount();
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetLinkCount();
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetObject(int iob, [In, Out] REOBJECT lpreobject, [MarshalAs(UnmanagedType.U4)] GETOBJECTOPTIONS flags);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int InsertObject(REOBJECT lpreobject);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ConvertObject(int iob, Guid rclsidNew, string lpstrUserTypeNew);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ActivateAs(Guid rclsid, Guid rclsidAs);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetHostNames(string lpstrContainerApp, string lpstrContainerObj);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetLinkAvailable(int iob, bool fAvailable);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetDvaspect(int iob, uint dvaspect);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int HandsOffStorage(int iob);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SaveCompleted(int iob, IStorage lpstg);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int InPlaceDeactivate();
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ContextSensitiveHelp(bool fEnterMode);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetClipboardData([In, Out] ref CHARRANGE lpchrg, [MarshalAs(UnmanagedType.U4)] GETCLIPBOARDDATAFLAGS reco, out IDataObject lplpdataobj);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ImportDataObject(IDataObject lpdataobj, int cf, IntPtr hMetaPict);
    }
}
