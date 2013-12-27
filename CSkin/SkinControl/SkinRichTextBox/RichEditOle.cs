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
 * * 说明：RichEditOle.cs
 * *
********************************************************************/

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using CCWin.Win32;

namespace CCWin.SkinControl
{
    public class RichEditOle
    {
        private SkinRichTextBox _richEdit;
        private IRichEditOle _richEditOle;

        public RichEditOle(SkinRichTextBox richEdit)
        {
            _richEdit = richEdit;
        }

        public IRichEditOle IRichEditOle
        {
            get
            {
                if (_richEditOle == null)
                {
                    _richEditOle = NativeMethods.SendMessage(
                        _richEdit.Handle, NativeMethods.EM_GETOLEINTERFACE, 0);
                }
                return _richEditOle;
            }
        }

        public void InsertControl(Control control)
        {
            if (control != null)
            {
                ILockBytes bytes;
                IStorage storage;
                IOleClientSite site;
                Guid guid = Marshal.GenerateGuidForType(control.GetType());
                NativeMethods.CreateILockBytesOnHGlobal(IntPtr.Zero, true, out bytes);
                NativeMethods.StgCreateDocfileOnILockBytes(bytes, 0x1012, 0, out storage);
                IRichEditOle.GetClientSite(out site);
                REOBJECT lpreobject = new REOBJECT();
                lpreobject.cp = _richEdit.TextLength;
                lpreobject.clsid = guid;
                lpreobject.pstg = storage;
                lpreobject.poleobj = Marshal.GetIUnknownForObject(control);
                lpreobject.polesite = site;
                lpreobject.dvAspect = 1;
                lpreobject.dwFlags = 2;
                lpreobject.dwUser = 1;
                IRichEditOle.InsertObject(lpreobject);
                Marshal.ReleaseComObject(bytes);
                Marshal.ReleaseComObject(site);
                Marshal.ReleaseComObject(storage);
            }
        }

        public bool InsertImageFromFile(string strFilename)
        {
            ILockBytes bytes;
            IStorage storage;
            IOleClientSite site;
            object obj2;
            NativeMethods.CreateILockBytesOnHGlobal(IntPtr.Zero, true, out bytes);
            NativeMethods.StgCreateDocfileOnILockBytes(bytes, 0x1012, 0, out storage);
            IRichEditOle.GetClientSite(out site);
            FORMATETC pFormatEtc = new FORMATETC();
            pFormatEtc.cfFormat = (CLIPFORMAT)0;
            pFormatEtc.ptd = IntPtr.Zero;
            pFormatEtc.dwAspect = DVASPECT.DVASPECT_CONTENT;
            pFormatEtc.lindex = -1;
            pFormatEtc.tymed = TYMED.TYMED_NULL;
            Guid riid = new Guid("{00000112-0000-0000-C000-000000000046}");
            Guid rclsid = new Guid("{00000000-0000-0000-0000-000000000000}");
            NativeMethods.OleCreateFromFile(ref rclsid, strFilename, ref riid, 1, ref pFormatEtc, site, storage, out obj2);
            if (obj2 == null)
            {
                Marshal.ReleaseComObject(bytes);
                Marshal.ReleaseComObject(site);
                Marshal.ReleaseComObject(storage);
                return false;
            }
            IOleObject pUnk = (IOleObject)obj2;
            Guid pClsid = new Guid();
            pUnk.GetUserClassID(ref pClsid);
            NativeMethods.OleSetContainedObject(pUnk, true);
            REOBJECT lpreobject = new REOBJECT();
            lpreobject.cp = _richEdit.TextLength;
            lpreobject.clsid = pClsid;
            lpreobject.pstg = storage;
            lpreobject.poleobj = Marshal.GetIUnknownForObject(pUnk);
            lpreobject.polesite = site;
            lpreobject.dvAspect = 1;
            lpreobject.dwFlags = 2;
            lpreobject.dwUser = 0;
            IRichEditOle.InsertObject(lpreobject);
            Marshal.ReleaseComObject(bytes);
            Marshal.ReleaseComObject(site);
            Marshal.ReleaseComObject(storage);
            Marshal.ReleaseComObject(pUnk);
            return true;
        }

        public REOBJECT InsertOleObject(
            IOleObject oleObject,
            int index)
        {
            if (oleObject == null)
            {
                return null;
            }

            ILockBytes pLockBytes;
            NativeMethods.CreateILockBytesOnHGlobal(IntPtr.Zero, true, out pLockBytes);

            IStorage pStorage;
            NativeMethods.StgCreateDocfileOnILockBytes(
                pLockBytes, 
                (uint)(STGM.STGM_SHARE_EXCLUSIVE | STGM.STGM_CREATE | STGM.STGM_READWRITE),
                0, 
                out pStorage);

            IOleClientSite pOleClientSite;
            IRichEditOle.GetClientSite(out pOleClientSite);

            Guid guid = new Guid();

            oleObject.GetUserClassID(ref guid);
            NativeMethods.OleSetContainedObject(oleObject, true);

            REOBJECT reoObject = new REOBJECT();

            reoObject.cp = _richEdit.TextLength;
            reoObject.clsid = guid;
            reoObject.pstg = pStorage;
            reoObject.poleobj = Marshal.GetIUnknownForObject(oleObject);
            reoObject.polesite = pOleClientSite;
            reoObject.dvAspect = (uint)DVASPECT.DVASPECT_CONTENT;
            reoObject.dwFlags = (uint)REOOBJECTFLAGS.REO_BELOWBASELINE;
            reoObject.dwUser = (uint)index;

            IRichEditOle.InsertObject(reoObject);

            Marshal.ReleaseComObject(pLockBytes);
            Marshal.ReleaseComObject(pOleClientSite);
            Marshal.ReleaseComObject(pStorage);

            return reoObject;
        }

        public void UpdateObjects()
        {
            int objectCount = this.IRichEditOle.GetObjectCount();
            for (int i = 0; i < objectCount; i++)
            {
                REOBJECT lpreobject = new REOBJECT();
                IRichEditOle.GetObject(i, lpreobject, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES);
                Point positionFromCharIndex = this._richEdit.GetPositionFromCharIndex(lpreobject.cp);
                Rectangle rc = new Rectangle(positionFromCharIndex.X, positionFromCharIndex.Y, 50, 50);
                _richEdit.Invalidate(rc, false);
            }
        }

        public void UpdateObjects(int pos)
        {
            REOBJECT lpreobject = new REOBJECT();
            IRichEditOle.GetObject(
                pos,
                lpreobject,
                GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES);
            UpdateObjects(lpreobject);
        }

        public void UpdateObjects(REOBJECT reObj)
        {
            Point positionFromCharIndex = _richEdit.GetPositionFromCharIndex(
                    reObj.cp);
            Size size = GetSizeFromMillimeter(reObj);
            Rectangle rc = new Rectangle(positionFromCharIndex, size);
            _richEdit.Invalidate(rc, false);
        }

        private Size GetSizeFromMillimeter(REOBJECT lpreobject)
        {
            using (Graphics graphics = Graphics.FromHwnd(_richEdit.Handle))
            {
                Point[] pts = new Point[1];
                graphics.PageUnit = GraphicsUnit.Millimeter;

                pts[0] = new Point(
                    lpreobject.sizel.Width / 100,
                    lpreobject.sizel.Height / 100);
                graphics.TransformPoints(
                    CoordinateSpace.Device,
                    CoordinateSpace.Page,
                    pts);
                return new Size(pts[0]);
            }
        }
    }
}
