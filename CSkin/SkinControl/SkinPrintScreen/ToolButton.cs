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
 * * 说明：ToolButton.cs
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
    [Designer(typeof(ToolButtonDesigner))]
    internal partial class ToolButton : Control
    {
        public ToolButton() {
            InitializeComponent();
        }

        private Image btnImage;
        public Image BtnImage {
            get { return btnImage; }
            set {
                btnImage = value;
                this.Invalidate();
            }
        }

        private bool isSelectedBtn;
        public bool IsSelectedBtn {
            get { return isSelectedBtn; }
            set { 
                isSelectedBtn = value;
                if (!isSelectedBtn) this.isSingleSelectedBtn = false;
            }
        }

        private bool isSingleSelectedBtn;
        public bool IsSingleSelectedBtn {
            get { return isSingleSelectedBtn; }
            set { 
                isSingleSelectedBtn = value;
                if (isSingleSelectedBtn) this.isSelectedBtn = true;
            }
        }

        private bool isSelected;
        public bool IsSelected {
            get { return isSelected; }
            set {
                //if (!this.isSelectedBtn) return;
                if (value == isSelected) return;
                isSelected = value;
                this.Invalidate();
            }
        }

        public override string Text {
            get {
                return base.Text;
            }
            set {
                base.Text = value;
                Size se = TextRenderer.MeasureText(this.Text, this.Font);
                this.Width = se.Width + 21;
            }
        }

        private bool m_bMouseEnter;

        protected override void OnMouseEnter(EventArgs e) {
            m_bMouseEnter = true;
            this.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e) {
            m_bMouseEnter = false;
            this.Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnClick(EventArgs e) {
            if (this.isSelectedBtn) {
                if (this.isSelected) {
                    if (!this.isSingleSelectedBtn) {
                        this.isSelected = false;
                        this.Invalidate();
                    }
                } else {
                    this.isSelected = true; this.Invalidate();
                    for (int i = 0, len = this.Parent.Controls.Count; i < len; i++) {
                        if (this.Parent.Controls[i] is ToolButton && this.Parent.Controls[i] != this) {
                            if (((ToolButton)(this.Parent.Controls[i])).isSelected)
                                ((ToolButton)(this.Parent.Controls[i])).IsSelected = false;
                        }
                    }
                }
            }
            this.Focus();
            base.OnClick(e);
        }

        protected override void OnDoubleClick(EventArgs e) {
            this.OnClick(e);
            base.OnDoubleClick(e);
        }

        protected override void OnPaint(PaintEventArgs e) {
            Graphics g = e.Graphics;
            if (m_bMouseEnter) {
                g.FillRectangle(Brushes.LightBlue, this.ClientRectangle);
                g.DrawRectangle(Pens.DarkCyan, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
            if (this.btnImage == null)
                g.DrawImage(global::CCWin.Properties.Resources.none, new Rectangle(2, 2, 17, 17));
            else
                g.DrawImage(this.btnImage, new Rectangle(2, 2, 17, 17));
            g.DrawString(this.Text, this.Font, Brushes.Black, 21, (this.Height - this.Font.Height) / 2);
            if (this.isSelected)
                g.DrawRectangle(Pens.DarkCyan, new Rectangle(0, 0, this.Width - 1, this.Height - 1));

            base.OnPaint(e);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified) {
            base.SetBoundsCore(x, y, TextRenderer.MeasureText(this.Text, this.Font).Width + 21, 21, specified);
        }
    }
}
