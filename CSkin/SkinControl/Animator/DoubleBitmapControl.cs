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
 * * 说明：DoubleBitmapControl.cs
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
    partial class DoubleBitmapControl : Control, IFakeControl
    {
        Bitmap bgBmp;
        Bitmap frame;

        Bitmap IFakeControl.BgBmp { get { return this.bgBmp; } set { this.bgBmp = value; } }
        Bitmap IFakeControl.Frame { get { return this.frame; } set { this.frame = value; } }
        public event EventHandler<TransfromNeededEventArg> TransfromNeeded;
        public event EventHandler<PaintEventArgs> FramePainted;
        public event EventHandler<PaintEventArgs> FramePainting;

        public DoubleBitmapControl()
        {
            InitializeComponent();
            this.Font = CCWin.Localization.Localizer.DefaultFont;
            Visible = false;
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var gr = e.Graphics;

            OnFramePainting(e);

            try
            {
                gr.DrawImage(bgBmp, 0, 0);
                if (frame != null)
                {
                    var ea = new TransfromNeededEventArg(){ ClientRectangle = new Rectangle(0, 0, this.Width, this.Height) };
                    OnTransfromNeeded(ea);
                    gr.SetClip(ea.ClipRectangle);
                    gr.Transform = ea.Matrix;
                    gr.DrawImage(frame, 0, 0);
                }
            }
            catch { }

            OnFramePainted(e);
        }

        private void OnTransfromNeeded(TransfromNeededEventArg ea)
        {
            if (TransfromNeeded != null)
                TransfromNeeded(this, ea);
        }

        protected virtual void OnFramePainting(PaintEventArgs e)
        {
            if (FramePainting != null)
                FramePainting(this, e);
        }

        protected virtual void OnFramePainted(PaintEventArgs e)
        {
            if (FramePainted != null)
                FramePainted(this, e);
        }


        public void InitParent(Control control, Padding padding)
        {
            Parent = control.Parent;
            var i = control.Parent.Controls.GetChildIndex(control);
            control.Parent.Controls.SetChildIndex(this, i);
            Bounds = new Rectangle(
                control.Left - padding.Left,
                control.Top - padding.Top,
                control.Size.Width + padding.Left + padding.Right,
                control.Size.Height + padding.Top + padding.Bottom);
        }
    }

    public interface IFakeControl
    {
        Bitmap BgBmp { get; set; }
        Bitmap Frame { get; set; }
        event EventHandler<TransfromNeededEventArg> TransfromNeeded;
        event EventHandler<PaintEventArgs> FramePainting;
        event EventHandler<PaintEventArgs> FramePainted;
        void InitParent(Control animatedControl, Padding padding);
    }
}
