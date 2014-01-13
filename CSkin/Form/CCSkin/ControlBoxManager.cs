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
 * * 说明：ControlBoxManager.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using CCWin.SkinClass;
using System.Threading;
using CCWin.SkinControl;
using CCWin.Localization;

namespace CCWin
{
    public class ControlBoxManager : IDisposable
    {
        private CCSkinMain _owner;
        private bool _mouseDown;
        private ControlBoxState _closBoxState;
        private ControlBoxState _minimizeBoxState;
        private ControlBoxState _maximizeBoxState;

        public ControlBoxManager(CCSkinMain owner)
        {
            _owner = owner;
        }

        public bool CloseBoxVisibale
        {
            get { return _owner.ControlBox; }
        }

        public bool MaximizeBoxVisibale
        {
            get { return _owner.ControlBox && _owner.MaximizeBox; }
        }

        public bool MinimizeBoxVisibale
        {
            get { return _owner.ControlBox && _owner.MinimizeBox; }
        }

        public Rectangle CloseBoxRect
        {
            get
            {
                if (CloseBoxVisibale)
                {
                    Point offset = ControlBoxOffset;
                    Size size = _owner.CloseBoxSize;
                    return new Rectangle(
                        _owner.Width - offset.X - size.Width,
                        offset.Y,
                        size.Width,
                        size.Height);
                }
                return Rectangle.Empty;
            }
        }

        public Rectangle MaximizeBoxRect
        {
            get
            {
                if (MaximizeBoxVisibale)
                {
                    Point offset = ControlBoxOffset;
                    Size size = _owner.MaxSize;
                    return new Rectangle(
                        CloseBoxRect.X - ControlBoxSpace - size.Width,
                        offset.Y,
                        size.Width,
                        size.Height);
                }
                return Rectangle.Empty;
            }
        }

        public Rectangle MinimizeBoxRect
        {
            get
            {
                if (MinimizeBoxVisibale)
                {
                    Point offset = ControlBoxOffset;
                    Size size = _owner.MiniSize;
                    int x = MaximizeBoxVisibale ?
                        MaximizeBoxRect.X - ControlBoxSpace - size.Width :
                        CloseBoxRect.X - ControlBoxSpace - size.Width;
                    return new Rectangle(
                        x,
                        offset.Y,
                        size.Width,
                        size.Height);
                }
                return Rectangle.Empty;
            }
        }

        public CustomSysButtonCollection SysButtonItems
        {
            get
            {
                CmSysButton Sitem = null;
                foreach (CmSysButton item in _owner.SysButtonItems)
                {
                    Size size = item.Size;
                    int x =
                        MinimizeBoxVisibale ?
                        MinimizeBoxRect.X - ControlBoxSpace - size.Width :
                        MaximizeBoxVisibale ?
                        MaximizeBoxRect.X - ControlBoxSpace - size.Width :
                        CloseBoxRect.X - ControlBoxSpace - size.Width;
                    if (Sitem != null)
                    {
                        if (Sitem.Visibale)
                        {
                            x = Sitem.Bounds.X - ControlBoxSpace - size.Width;
                        }
                    }
                    Rectangle rc = new Rectangle(new Point(x, _owner.ControlBoxOffset.Y), item.Bounds.Size);
                    item.Bounds = rc;
                    Sitem = item;
                }
                return _owner.SysButtonItems;
            }
        }

        public ControlBoxState CloseBoxState
        {
            get { return _closBoxState; }
            protected set
            {
                if (_closBoxState != value)
                {
                    _closBoxState = value;
                    if (_owner != null)
                    {
                        Invalidate(CloseBoxRect);
                    }
                }
            }
        }

        public ControlBoxState MinimizeBoxState
        {
            get { return _minimizeBoxState; }
            protected set
            {
                if (_minimizeBoxState != value)
                {
                    _minimizeBoxState = value;
                    if (_owner != null)
                    {
                        Invalidate(MinimizeBoxRect);
                    }
                }
            }
        }

        public ControlBoxState MaximizeBoxState
        {
            get { return _maximizeBoxState; }
            protected set
            {
                if (_maximizeBoxState != value)
                {
                    _maximizeBoxState = value;
                    if (_owner != null)
                    {
                        Invalidate(MaximizeBoxRect);
                    }
                }
            }
        }

        public Point ControlBoxOffset
        {
            get { return _owner.ControlBoxOffset; }
        }

        public int ControlBoxSpace
        {
            get { return _owner.ControlBoxSpace; }
        }

        public void ProcessMouseOperate(
            Point mousePoint, MouseOperate operate)
        {
            if (!_owner.ControlBox)
            {
                return;
            }

            Rectangle closeBoxRect = CloseBoxRect;
            Rectangle minimizeBoxRect = MinimizeBoxRect;
            Rectangle maximizeBoxRect = MaximizeBoxRect;

            bool closeBoxVisibale = CloseBoxVisibale;
            bool minimizeBoxVisibale = MinimizeBoxVisibale;
            bool maximizeBoxVisibale = MaximizeBoxVisibale;

            switch (operate)
            {
                case MouseOperate.Move:
                    ProcessMouseMove(
                        mousePoint,
                        closeBoxRect,
                        minimizeBoxRect,
                        maximizeBoxRect,
                        closeBoxVisibale,
                        minimizeBoxVisibale,
                        maximizeBoxVisibale);
                    break;
                case MouseOperate.Down:
                    ProcessMouseDown(
                        mousePoint,
                        closeBoxRect,
                        minimizeBoxRect,
                        maximizeBoxRect,
                        closeBoxVisibale,
                        minimizeBoxVisibale,
                        maximizeBoxVisibale);
                    break;
                case MouseOperate.Up:
                    ProcessMouseUP(
                        mousePoint,
                        closeBoxRect,
                        minimizeBoxRect,
                        maximizeBoxRect,
                        closeBoxVisibale,
                        minimizeBoxVisibale,
                        maximizeBoxVisibale);
                    break;
                case MouseOperate.Leave:
                    ProcessMouseLeave(
                        closeBoxVisibale,
                        minimizeBoxVisibale,
                        maximizeBoxVisibale);
                    break;
                case MouseOperate.Hover:
                    break;
            }
        }

        private void ProcessMouseMove(
            Point mousePoint,
            Rectangle closeBoxRect,
            Rectangle minimizeBoxRect,
            Rectangle maximizeBoxRect,
            bool closeBoxVisibale,
            bool minimizeBoxVisibale,
            bool maximizeBoxVisibale)
        {
            string toolTip = string.Empty;
            bool hide = true;

            if (closeBoxVisibale)
            {
                if (closeBoxRect.Contains(mousePoint))
                {
                    hide = false;
                    if (!_mouseDown)
                    {
                        if (CloseBoxState != ControlBoxState.Hover)
                        {
                            toolTip = _owner.CloseButtonToolTip;
                        }
                        CloseBoxState = ControlBoxState.Hover;
                    }
                    else
                    {
                        if (CloseBoxState == ControlBoxState.PressedLeave)
                        {
                            CloseBoxState = ControlBoxState.Pressed;
                        }
                    }
                }
                else
                {
                    if (!_mouseDown)
                    {
                        CloseBoxState = ControlBoxState.Normal;
                    }
                    else
                    {
                        if (CloseBoxState == ControlBoxState.Pressed)
                        {
                            CloseBoxState = ControlBoxState.PressedLeave;
                        }
                    }
                }
            }

            if (minimizeBoxVisibale)
            {
                if (minimizeBoxRect.Contains(mousePoint))
                {
                    hide = false;
                    if (!_mouseDown)
                    {
                        if (MinimizeBoxState != ControlBoxState.Hover)
                        {
                            toolTip = _owner.MinButtonToolTip;
                        }
                        MinimizeBoxState = ControlBoxState.Hover;
                    }
                    else
                    {
                        if (MinimizeBoxState == ControlBoxState.PressedLeave)
                        {
                            MinimizeBoxState = ControlBoxState.Pressed;
                        }
                    }
                }
                else
                {
                    if (!_mouseDown)
                    {
                        MinimizeBoxState = ControlBoxState.Normal;
                    }
                    else
                    {
                        if (MinimizeBoxState == ControlBoxState.Pressed)
                        {
                            MinimizeBoxState = ControlBoxState.PressedLeave;
                        }
                    }
                }
            }

            if (maximizeBoxVisibale)
            {
                if (maximizeBoxRect.Contains(mousePoint))
                {
                    hide = false;
                    if (!_mouseDown)
                    {
                        if (MaximizeBoxState != ControlBoxState.Hover)
                        {
                            bool maximize =
                                _owner.WindowState == FormWindowState.Maximized;
                            toolTip = maximize ? _owner.RestoreButtonToolTip : _owner.MaxButtonToolTip;
                        }
                        MaximizeBoxState = ControlBoxState.Hover;
                    }
                    else
                    {
                        if (MaximizeBoxState == ControlBoxState.PressedLeave)
                        {
                            MaximizeBoxState = ControlBoxState.Pressed;
                        }
                    }
                }
                else
                {
                    if (!_mouseDown)
                    {
                        MaximizeBoxState = ControlBoxState.Normal;
                    }
                    else
                    {
                        if (MaximizeBoxState == ControlBoxState.Pressed)
                        {
                            MaximizeBoxState = ControlBoxState.PressedLeave;
                        }
                    }
                }
            }
            //自定义系统按钮
            foreach (CmSysButton item in SysButtonItems)
            {
                if (item.Visibale)
                {
                    if (item.Bounds.Contains(mousePoint))
                    {
                        hide = false;
                        if (!_mouseDown)
                        {
                            if (item.BoxState != ControlBoxState.Hover)
                            {
                                toolTip = item.ToolTip;
                            }
                            item.BoxState = ControlBoxState.Hover;
                        }
                        else
                        {
                            if (item.BoxState == ControlBoxState.PressedLeave)
                            {
                                item.BoxState = ControlBoxState.Pressed;
                            }
                        }
                    }
                    else
                    {
                        if (!_mouseDown)
                        {
                            item.BoxState = ControlBoxState.Normal;
                        }
                        else
                        {
                            if (item.BoxState == ControlBoxState.Pressed)
                            {
                                item.BoxState = ControlBoxState.PressedLeave;
                            }
                        }
                    }
                }
            }

            if (toolTip != string.Empty)
            {
                HideToolTip();
                ShowTooTip(toolTip);
            }

            if (hide)
            {
                HideToolTip();
            }
        }

        private void ProcessMouseDown(
            Point mousePoint,
            Rectangle closeBoxRect,
            Rectangle minimizeBoxRect,
            Rectangle maximizeBoxRect,
            bool closeBoxVisibale,
            bool minimizeBoxVisibale,
            bool maximizeBoxVisibale)
        {
            _mouseDown = true;

            if (closeBoxVisibale)
            {
                if (closeBoxRect.Contains(mousePoint))
                {
                    CloseBoxState = ControlBoxState.Pressed;
                    return;
                }
            }

            if (minimizeBoxVisibale)
            {
                if (minimizeBoxRect.Contains(mousePoint))
                {
                    MinimizeBoxState = ControlBoxState.Pressed;
                    return;
                }
            }

            foreach (CmSysButton item in SysButtonItems)
            {
                if (item.Visibale)
                {
                    if (item.Bounds.Contains(mousePoint))
                    {
                        item.BoxState = ControlBoxState.Pressed;
                        return;
                    }
                }
            }

            if (maximizeBoxVisibale)
            {
                if (maximizeBoxRect.Contains(mousePoint))
                {
                    MaximizeBoxState = ControlBoxState.Pressed;
                    return;
                }
            }
        }

        private void ProcessMouseUP(
            Point mousePoint,
            Rectangle closeBoxRect,
            Rectangle minimizeBoxRect,
            Rectangle maximizeBoxRect,
            bool closeBoxVisibale,
            bool minimizeBoxVisibale,
            bool maximizeBoxVisibale)
        {
            _mouseDown = false;

            if (closeBoxVisibale)
            {
                if (closeBoxRect.Contains(mousePoint))
                {
                    if (CloseBoxState == ControlBoxState.Pressed)
                    {
                        _owner.Close();
                        CloseBoxState = ControlBoxState.Normal;
                        return;
                    }
                }
                CloseBoxState = ControlBoxState.Normal;
            }

            if (minimizeBoxVisibale)
            {
                if (minimizeBoxRect.Contains(mousePoint))
                {
                    if (MinimizeBoxState == ControlBoxState.Pressed)
                    {
                        if (_owner.ShowInTaskbar)
                        {
                            _owner.WindowState = FormWindowState.Minimized;
                        }
                        else
                        {
                            _owner.Hide();
                        }
                        MinimizeBoxState = ControlBoxState.Normal;
                        return;
                    }
                }
                MinimizeBoxState = ControlBoxState.Normal;
            }

            foreach (CmSysButton item in SysButtonItems)
            {
                if (item.Visibale)
                {
                    if (item.Bounds.Contains(mousePoint))
                    {
                        if (item.BoxState == ControlBoxState.Pressed)
                        {
                            //调用事件
                            _owner.SysbottomAv(_owner, new SysButtonEventArgs(item));
                            item.BoxState = ControlBoxState.Normal;
                            return;
                        }
                    }
                    item.BoxState = ControlBoxState.Normal;
                }
            }

            if (maximizeBoxVisibale)
            {
                if (maximizeBoxRect.Contains(mousePoint))
                {
                    if (MaximizeBoxState == ControlBoxState.Pressed)
                    {
                        bool maximize =
                            _owner.WindowState == FormWindowState.Maximized;
                        if (maximize)
                        {
                            _owner.WindowState = FormWindowState.Normal;
                        }
                        else
                        {
                            _owner.WindowState = FormWindowState.Maximized;
                        }

                        MaximizeBoxState = ControlBoxState.Normal;
                        return;
                    }
                }
                MaximizeBoxState = ControlBoxState.Normal;
            }
        }

        private void ProcessMouseLeave(
            bool closeBoxVisibale,
            bool minimizeBoxVisibale,
            bool maximizeBoxVisibale)
        {
            if (closeBoxVisibale)
            {
                if (CloseBoxState == ControlBoxState.Pressed)
                {
                    CloseBoxState = ControlBoxState.PressedLeave;
                }
                else
                {
                    CloseBoxState = ControlBoxState.Normal;
                }
            }

            if (minimizeBoxVisibale)
            {
                if (MinimizeBoxState == ControlBoxState.Pressed)
                {
                    MinimizeBoxState = ControlBoxState.PressedLeave;
                }
                else
                {
                    MinimizeBoxState = ControlBoxState.Normal;
                }
            }

            foreach (CmSysButton item in SysButtonItems)
            {
                if (item.Visibale)
                {
                    if (item.BoxState == ControlBoxState.Pressed)
                    {
                        item.BoxState = ControlBoxState.PressedLeave;
                    }
                    else
                    {
                        item.BoxState = ControlBoxState.Normal;
                    }
                }
            }

            if (maximizeBoxVisibale)
            {
                if (MaximizeBoxState == ControlBoxState.Pressed)
                {
                    MaximizeBoxState = ControlBoxState.PressedLeave;
                }
                else
                {
                    MaximizeBoxState = ControlBoxState.Normal;
                }
            }

            HideToolTip();
        }

        private void Invalidate(Rectangle rect)
        {
            _owner.Invalidate(rect);
        }

        private void ShowTooTip(string toolTipText)
        {
            if (_owner != null)
            {
                _owner.ToolTip.Active = true;
                _owner.ToolTip.SetToolTip(_owner, toolTipText);
            }
        }

        private void HideToolTip()
        {
            if (_owner != null)
            {
                _owner.ToolTip.Active = false;
            }
        }

        #region IDisposable 成员

        public void Dispose()
        {
            _owner = null;
        }

        #endregion
    }
}
