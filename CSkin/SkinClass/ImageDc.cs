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
 * * 说明：ImageDc.cs
 * *
********************************************************************/

using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Security;
using System.Security.Permissions;
using CCWin.Win32;

namespace CCWin.SkinClass
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class ImageDc : IDisposable
    {
        private int _height = 0;
        private int _width = 0;
        private IntPtr _pHdc = IntPtr.Zero;
        private IntPtr _pBmp = IntPtr.Zero;
        private IntPtr _pBmpOld = IntPtr.Zero;

        public ImageDc(int width, int height, IntPtr hBmp)
        {
            CreateImageDc(width, height, hBmp);
        }

        public ImageDc(int width, int height)
        {
            CreateImageDc(width, height, IntPtr.Zero);
        }

        public IntPtr Hdc
        {
            get { return _pHdc; }
        }

        public IntPtr HBmp
        {
            get { return _pBmp; }
        }

        private void CreateImageDc(int width, int height, IntPtr hBmp)
        {
            IntPtr pHdc = IntPtr.Zero;

            pHdc = NativeMethods.CreateDCA("DISPLAY", "", "", 0);
            _pHdc = NativeMethods.CreateCompatibleDC(pHdc);
            if (hBmp != IntPtr.Zero)
            {
                _pBmp = hBmp;
            }
            else
            {
                _pBmp = NativeMethods.CreateCompatibleBitmap(pHdc, width, height);
            }
            _pBmpOld = NativeMethods.SelectObject(_pHdc, _pBmp);
            if (_pBmpOld == IntPtr.Zero)
            {
                ImageDestroy();
            }
            else
            {
                _width = width;
                _height = height;
            }
            NativeMethods.DeleteDC(pHdc);
            pHdc = IntPtr.Zero;
        }

        private void ImageDestroy()
        {
            if (_pBmpOld != IntPtr.Zero)
            {
                NativeMethods.SelectObject(_pHdc, _pBmpOld);
                _pBmpOld = IntPtr.Zero;
            }
            if (_pBmp != IntPtr.Zero)
            {
                NativeMethods.DeleteObject(_pBmp);
                _pBmp = IntPtr.Zero;
            }
            if (_pHdc != IntPtr.Zero)
            {
                NativeMethods.DeleteDC(_pHdc);
                _pHdc = IntPtr.Zero;
            }
        }

        public void Dispose()
        {
            ImageDestroy();
        }
    }
}
