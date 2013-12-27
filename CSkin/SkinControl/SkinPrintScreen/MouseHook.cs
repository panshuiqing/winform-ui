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
 * * 说明：MouseHook.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CCWin.SkinControl
{
    public class MouseHook
    {
        #region Win32

        [DllImport("user32.dll")]   //设置钩子  第二个参数为回调函数指针
        public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hmod, int dwThreadid);
        [DllImport("user32.dll")]   //传递到下一个钩子
        public static extern int CallNextHookEx(IntPtr hHook, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]   //卸载钩子
        public static extern bool UnhookWindowsHookEx(IntPtr hHook);
        [DllImport("kernel32.dll")] //获取模块句柄  
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        private const int WH_MOUSE_LL = 14;//全局鼠标Hook 7是局部的 13全局键盘 2局部键盘
        private const uint WM_LBUTTONDOWN = 0x201;
        private const uint WM_LBUTTONUP = 0x202;
        private const uint WM_RBUTTONDOWN = 0x204;
        private const uint WM_RBUTTONUP = 0x205;

        public struct POINT
        {
            public int X;
            public int Y;
        }
        //鼠标结构信息
        public struct MSLLHOOTSTRUCT
        {
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        #endregion

        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        public delegate void MHookEventHandler(object sender, MHookEventArgs e);
        public event MHookEventHandler MHookEvent;

        private IntPtr hHook = IntPtr.Zero;
        public IntPtr HHook {
            get { return hHook; }
        }

        GCHandle gc;
        //Hook回调函数
        private int MouseHookProcedure(int nCode, IntPtr wParam, IntPtr lParam) {
            if (nCode >= 0 && MHookEvent != null) {
                MSLLHOOTSTRUCT stMSLL = (MSLLHOOTSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOTSTRUCT));
                ButtonStatus btnStatus = ButtonStatus.None;
                if (wParam == (IntPtr)WM_LBUTTONDOWN)
                    btnStatus = ButtonStatus.LeftDown;
                else if (wParam == (IntPtr)WM_LBUTTONUP)
                    btnStatus = ButtonStatus.LeftUp;
                else if (wParam == (IntPtr)WM_RBUTTONDOWN)
                    btnStatus = ButtonStatus.RightDown;
                else if (wParam == (IntPtr)WM_RBUTTONUP)
                    btnStatus = ButtonStatus.RightUp;
                MHookEvent(this, new MHookEventArgs(btnStatus, stMSLL.pt.X, stMSLL.pt.Y));
            }
            return CallNextHookEx(hHook, nCode, wParam, lParam);
        }
        //设置Hook
        public bool SetHook() {
            if (hHook != IntPtr.Zero)
                return false;
            HookProc mouseCallBack = new HookProc(MouseHookProcedure);
            hHook = SetWindowsHookEx(WH_MOUSE_LL, mouseCallBack,
                GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
            if (hHook != IntPtr.Zero) {
                gc = GCHandle.Alloc(mouseCallBack);
                return true;
            }
            return false;
        }
        //卸载Hook
        public bool UnLoadHook() {
            if (hHook == IntPtr.Zero)
                return false;
            if (UnhookWindowsHookEx(hHook)) {
                hHook = IntPtr.Zero;
                gc.Free();
                return true;
            }
            return false;
        }
    }
    //鼠标状态枚举值
    public enum ButtonStatus { LeftDown, LeftUp, RightDown, RightUp, None }
    //事件参数
    public class MHookEventArgs : EventArgs
    {
        private ButtonStatus mButton;
        public ButtonStatus MButton {
            get { return mButton; }
        }

        private int x;
        public int X {
            get { return x; }
        }

        private int y;
        public int Y {
            get { return y; }
        }

        public MHookEventArgs(ButtonStatus btn, int cx, int cy) {
            this.mButton = btn;
            this.x = cx;
            this.y = cy;
        }
    }
}
