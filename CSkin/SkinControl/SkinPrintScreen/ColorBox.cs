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
 * * 说明：ColorBox.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CCWin.SkinControl
{
    [Designer(typeof(ColorBoxDesginer))]
    partial class ColorBox : Control
    {
        public ColorBox()
        {
            InitializeComponent();
            selectedColor = Color.Red;
            m_rectSelected = new Rectangle(-100, -100, 14, 14);

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private Color selectedColor;
        public Color SelectedColor
        {
            get { return selectedColor; }
        }

        private Point m_ptCurrent;
        private Rectangle m_rectSelected;
        private Bitmap m_clrImage = global::CCWin.Properties.Resources.color;
        private Color m_lastColor;

        public delegate void ColorChangedHandler(object sender, ColorChangedEventArgs e);
        public event ColorChangedHandler ColorChanged;
        protected virtual void OnColorChanged(ColorChangedEventArgs e)
        {
            if (this.ColorChanged != null)
                ColorChanged(this, e);
        }

        protected override void OnClick(EventArgs e)
        {
            Color clr = m_clrImage.GetPixel(m_ptCurrent.X, m_ptCurrent.Y);
            if (clr.ToArgb() != Color.FromArgb(255, 254, 254, 254).ToArgb()
                && clr.ToArgb() != Color.FromArgb(255, 133, 141, 151).ToArgb()
                && clr.ToArgb() != Color.FromArgb(255, 110, 126, 149).ToArgb())
            {
                if (this.selectedColor != clr)
                    this.selectedColor = clr;
                this.Invalidate();
                this.OnColorChanged(new ColorChangedEventArgs(clr));
            }
            base.OnClick(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            m_ptCurrent = e.Location;
            try
            {
                if (this.ClientRectangle.Contains(m_ptCurrent))
                {
                    Color clr = m_clrImage.GetPixel(m_ptCurrent.X, m_ptCurrent.Y);
                    if (clr != m_lastColor)
                    {
                        if (clr.ToArgb() != Color.FromArgb(255, 254, 254, 254).ToArgb()
                            && clr.ToArgb() != Color.FromArgb(255, 133, 141, 151).ToArgb()
                            && clr.ToArgb() != Color.FromArgb(255, 110, 126, 149).ToArgb()
                            && e.X > 39)
                        {
                            m_rectSelected.Y = e.Y > 17 ? 17 : 2;
                            m_rectSelected.X = ((e.X - 39) / 15) * 15 + 38;
                            this.Invalidate();
                        }
                        else
                        {
                            m_rectSelected.X = m_rectSelected.Y = -100;
                            this.Invalidate();
                        }
                    }
                    m_lastColor = clr;
                }
            }
            finally
            {
                base.OnMouseMove(e);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            m_rectSelected.X = m_rectSelected.Y = -100;
            this.Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(global::CCWin.Properties.Resources.color,
                new Rectangle(0, 0, 165, 35));
            g.DrawRectangle(Pens.SteelBlue, 0, 0, 164, 34);
            SolidBrush sb = new SolidBrush(selectedColor);
            g.FillRectangle(sb, 9, 5, 24, 24);
            g.DrawRectangle(Pens.DarkCyan, m_rectSelected);
            base.OnPaint(e);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, 165, 35, specified);
        }
    }

    public class ColorChangedEventArgs : EventArgs
    {
        private Color color;
        public Color Color
        {
            get { return color; }
        }

        public ColorChangedEventArgs(Color clr)
        {
            this.color = clr;
        }
    }
}
