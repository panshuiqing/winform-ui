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
 * * 说明：Helper.cs
 * *
********************************************************************/

using System;
using System.Windows.Forms;
using CCWin.Win32.Const;
using System.Runtime.InteropServices;

namespace CCWin.Win32
{
    public static class Helper
    {
        public static bool LeftKeyPressed()
        {
            if (SystemInformation.MouseButtonsSwapped)
            {
                return (NativeMethods.GetKeyState(VK.VK_RBUTTON) < 0);
            }
            else
            {
                return (NativeMethods.GetKeyState(VK.VK_LBUTTON) < 0);
            }
        }

        public static int HIWORD(int n)
        {
            return ((n >> 0x10) & 0xffff);
        }

        public static int HIWORD(IntPtr n)
        {
            return HIWORD((int)((long)n));
        }

        public static int LOWORD(int n)
        {
            return (n & 0xffff);
        }

        public static int LOWORD(IntPtr n)
        {
            return LOWORD((int)((long)n));
        }

        public static int MAKELONG(int low, int high)
        {
            return ((high << 0x10) | (low & 0xffff));
        }

        public static IntPtr MAKELPARAM(int low, int high)
        {
            return (IntPtr)((high << 0x10) | (low & 0xffff));
        }

        public static int SignedHIWORD(int n)
        {
            return (short)((n >> 0x10) & 0xffff);
        }

        public static int SignedHIWORD(IntPtr n)
        {
            return SignedHIWORD((int)((long)n));
        }

        public static int SignedLOWORD(int n)
        {
            return (short)(n & 0xffff);
        }

        public static int SignedLOWORD(IntPtr n)
        {
            return SignedLOWORD((int)((long)n));
        }

        public static void Swap(ref int x, ref int y)
        {
            int tmp = x;
            x = y;
            y = tmp;
        }

        public static IntPtr ToIntPtr(object structure)
        {
            IntPtr lparam = IntPtr.Zero;
            lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(structure));
            Marshal.StructureToPtr(structure, lparam, false);
            return lparam;
        }

        public static void SetRedraw(IntPtr hWnd, bool redraw)
        {
            IntPtr ptr = redraw ? Result.TRUE : Result.FALSE;
            NativeMethods.SendMessage(hWnd, WM.WM_SETREDRAW, ptr, 0);
        }
    }
}
