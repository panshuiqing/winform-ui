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
 * * 说明：SkinHScrollBar.cs
 * *
********************************************************************/

using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using CCWin.Imaging;
using System.Drawing.Drawing2D;
using CCWin.SkinClass;

namespace CCWin.SkinControl
{
    [ToolboxBitmap(typeof(HScrollBar))]
    public class SkinHScrollBar : HScrollBar, IScrollBarPaint
    {
        private ScrollBarManager _manager;
        public SkinHScrollBar()
            : base()
        {
            this.Font = CCWin.Localization.Localizer.DefaultFont;
        }

        #region 属性与变量
        private Color _base = Color.FromArgb(171, 230, 247);
        public Color Base
        {
            get { return _base; }
            set
            {
                if (_base != value)
                {
                    _base = value;
                    this.Invalidate();
                }
            }
        }

        private Color _backNormal = Color.FromArgb(235, 249, 253);
        public Color BackNormal
        {
            get { return _backNormal; }
            set
            {
                if (_backNormal != value)
                {
                    _backNormal = value;
                    this.Invalidate();
                }
            }
        }

        private Color _backHover = Color.FromArgb(121, 216, 243);
        public Color BackHover
        {
            get { return _backHover; }
            set
            {
                if (_backHover != value)
                {
                    _backHover = value;
                    this.Invalidate();
                }
            }
        }

        private Color _backPressed = Color.FromArgb(70, 202, 239);
        public Color BackPressed
        {
            get { return _backPressed; }
            set
            {
                if (_backPressed != value)
                {
                    _backPressed = value;
                    this.Invalidate();
                }
            }
        }

        private Color _border = Color.FromArgb(89, 210, 249);
        public Color Border
        {
            get { return _border; }
            set
            {
                if (_border != value)
                {
                    _border = value;
                    this.Invalidate();
                }
            }
        }

        private Color _innerBorder = Color.FromArgb(200, 250, 250, 250);
        public Color InnerBorder
        {
            get { return _innerBorder; }
            set
            {
                if (_innerBorder != value)
                {
                    _innerBorder = value;
                    this.Invalidate();
                }
            }
        }

        private Color _fore = Color.FromArgb(48, 135, 192);
        public Color Fore
        {
            get { return _fore; }
            set
            {
                if (_fore != value)
                {
                    _fore = value;
                    this.Invalidate();
                }
            }
        }
        #endregion

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (_manager != null)
            {
                _manager.Dispose();
            }
            if (!this.DesignMode)
            {
                _manager = new ScrollBarManager(this);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_manager != null)
                {
                    _manager.Dispose();
                    _manager = null;
                }
            }
            base.Dispose(disposing);
        }

        protected virtual void OnPaintScrollBarTrack(
            PaintScrollBarTrackEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.TrackRectangle;

            Color baseColor = GetGray(Base);

            ControlPaintEx.DrawScrollBarTrack(
                g, rect, baseColor, Color.White, e.Orientation);
        }

        protected virtual void OnPaintScrollBarArrow(
           PaintScrollBarArrowEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.ArrowRectangle;
            ControlState controlState = e.ControlState;
            ArrowDirection direction = e.ArrowDirection;
            bool bHorizontal = e.Orientation == Orientation.Horizontal;
            bool bEnabled = e.Enabled;

            Color backColor = BackNormal;
            Color baseColor = Base;
            Color borderColor = Border;
            Color innerBorderColor = InnerBorder;
            Color foreColor = Fore;

            bool changeColor = false;

            if (bEnabled)
            {
                switch (controlState)
                {
                    case ControlState.Hover:
                        baseColor = BackHover;
                        break;
                    case ControlState.Pressed:
                        baseColor = BackPressed;
                        changeColor = true;
                        break;
                    default:
                        baseColor = Base;
                        break;
                }
            }
            else
            {
                backColor = GetGray(backColor);
                baseColor = GetGray(Base);
                borderColor = GetGray(borderColor);
                foreColor = GetGray(foreColor);
            }

            using (SmoothingModeGraphics sg = new SmoothingModeGraphics(g))
            {
                ControlPaintEx.DrawScrollBarArraw(
                    g,
                    rect,
                    baseColor,
                    backColor,
                    borderColor,
                    innerBorderColor,
                    foreColor,
                    e.Orientation,
                    direction,
                    changeColor);
            }
        }

        protected virtual void OnPaintScrollBarThumb(
           PaintScrollBarThumbEventArgs e)
        {
            bool bEnabled = e.Enabled;
            if (!bEnabled)
            {
                return;
            }

            Graphics g = e.Graphics;
            Rectangle rect = e.ThumbRectangle;
            ControlState controlState = e.ControlState;

            Color backColor = BackNormal;
            Color baseColor = Base;
            Color borderColor = Border;
            Color innerBorderColor = InnerBorder;

            bool changeColor = false;

            switch (controlState)
            {
                case ControlState.Hover:
                    baseColor = BackHover;
                    break;
                case ControlState.Pressed:
                    baseColor = BackPressed;
                    changeColor = true;
                    break;
                default:
                    baseColor = Base;
                    break;
            }

            using (SmoothingModeGraphics sg = new SmoothingModeGraphics(g))
            {
                ControlPaintEx.DrawScrollBarThumb(
                    g,
                    rect,
                    baseColor,
                    backColor,
                    borderColor,
                    innerBorderColor,
                    e.Orientation,
                    changeColor);
            }
        }

        private Color GetGray(Color color)
        {
            return ColorConverterEx.RgbToGray(
                new RGB(color)).Color;
        }

        #region IScrollBarPaint 成员

        void IScrollBarPaint.OnPaintScrollBarArrow(PaintScrollBarArrowEventArgs e)
        {
            OnPaintScrollBarArrow(e);
        }

        void IScrollBarPaint.OnPaintScrollBarThumb(PaintScrollBarThumbEventArgs e)
        {
            OnPaintScrollBarThumb(e);
        }

        void IScrollBarPaint.OnPaintScrollBarTrack(PaintScrollBarTrackEventArgs e)
        {
            OnPaintScrollBarTrack(e);
        }

        #endregion
    }
}
