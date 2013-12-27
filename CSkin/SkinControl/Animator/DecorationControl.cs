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
 * * 说明：DecorationControl.cs
 * *
********************************************************************/

#define debug

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CCWin.SkinControl
{
    partial class DecorationControl : UserControl
    {
        public DecorationType DecorationType { get; set; }
        public Control DecoratedControl { get; set; }
        public new Padding Padding { get;set;}
        public Bitmap CtrlBmp { get; set; }
        public byte[] CtrlPixels { get; set; }
        public int CtrlStride { get; set; }
        public Bitmap Frame { get; set; }
        public float CurrentTime { get; set; }
        Timer tm;

        public DecorationControl(DecorationType type, Control decoratedControl)
        {
            this.Font = CCWin.Localization.Localizer.DefaultFont;
            this.DecorationType = type;
            this.DecoratedControl = decoratedControl;

            decoratedControl.VisibleChanged += new EventHandler(control_VisibleChanged);
            decoratedControl.ParentChanged += new EventHandler(control_VisibleChanged);
            decoratedControl.LocationChanged += new EventHandler(control_VisibleChanged);

            decoratedControl.Paint += new PaintEventHandler(decoratedControl_Paint);

            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            //BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            InitPadding();

            tm = new Timer();
            tm.Interval = 100;
            tm.Tick += new EventHandler(tm_Tick);
            tm.Enabled = true;
        }

        private void InitPadding()
        {
            switch(DecorationType)
            {
                case CCWin.SkinControl.DecorationType.BottomMirror:
                    Padding = new Padding(0, 0, 0, 20);
                    break;
            }
        }

        void tm_Tick(object sender, EventArgs e)
        {
            switch (DecorationType)
            {
                case CCWin.SkinControl.DecorationType.BottomMirror:
                case CCWin.SkinControl.DecorationType.Custom:
                    Invalidate();
                    break;
            }
        }

        void decoratedControl_Paint(object sender, PaintEventArgs e)
        {
            if (!isSnapshotNow)
            {
                /*
                if (Frame != null)
                {
                    e.Graphics.DrawImage(Frame, new Point(-Padding.Left, -Padding.Top));
                    wasDraw = true;
                }*/
                /*
                CtrlBmp = GetForeground(DecoratedControl);
                CtrlPixels = GetPixels(CtrlBmp);*/ /*does not work for TextBox*/
                //wasRepainted = true;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {           
            CtrlBmp = GetForeground(DecoratedControl);
            CtrlPixels = GetPixels(CtrlBmp);

            if (Frame != null)
                Frame.Dispose();
            Frame = OnNonLinearTransfromNeeded();

            if (Frame != null)
            {
                e.Graphics.DrawImage(Frame, Point.Empty);
            }
        }

        void control_VisibleChanged(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            this.Parent = DecoratedControl.Parent;
            this.Visible = DecoratedControl.Visible;
            this.Location = new Point(DecoratedControl.Left - Padding.Left, DecoratedControl.Top - Padding.Top);

            
            if (Parent != null)
            {
                var i = Parent.Controls.GetChildIndex(DecoratedControl);
                Parent.Controls.SetChildIndex(this, i + 1);
            }
            
            var newSize = new Size(DecoratedControl.Width + Padding.Left + Padding.Right, DecoratedControl.Height + Padding.Top + Padding.Bottom);
            if(newSize != Size)
            {
                this.Size = newSize;
            }
        }

        bool isSnapshotNow = false;

        protected virtual Bitmap GetForeground(Control ctrl)
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);

            if (!ctrl.IsDisposed)
            {
                isSnapshotNow = true;
                ctrl.DrawToBitmap(bmp, new Rectangle(Padding.Left, Padding.Top, ctrl.Width, ctrl.Height));
                isSnapshotNow = false;
            }
            return bmp;
        }

        byte[] GetPixels(Bitmap bmp)
        {
            const int bytesPerPixel = 4;
            PixelFormat pxf = PixelFormat.Format32bppArgb;
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, pxf);
            IntPtr ptr = bmpData.Scan0;
            int numBytes = bmp.Width * bmp.Height * bytesPerPixel;
            byte[] argbValues = new byte[numBytes];
            Marshal.Copy(ptr, argbValues, 0, numBytes);
            //Marshal.Copy(argbValues, 0, ptr, numBytes);
            bmp.UnlockBits(bmpData);
            return argbValues;
        }

        public event EventHandler<NonLinearTransfromNeededEventArg> NonLinearTransfromNeeded;

        protected virtual Bitmap OnNonLinearTransfromNeeded()
        {
            Bitmap bmp = null;
            if (CtrlBmp == null)
                return null;

            try
            {
                bmp = new Bitmap(Width, Height);

                const int bytesPerPixel = 4;
                PixelFormat pxf = PixelFormat.Format32bppArgb;
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, pxf);
                IntPtr ptr = bmpData.Scan0;
                int numBytes = bmp.Width * bmp.Height * bytesPerPixel;
                byte[] argbValues = new byte[numBytes];

                Marshal.Copy(ptr, argbValues, 0, numBytes);

                var e = new NonLinearTransfromNeededEventArg() { CurrentTime = CurrentTime, ClientRectangle = ClientRectangle, Pixels = argbValues, Stride = bmpData.Stride, SourcePixels = CtrlPixels, SourceClientRectangle = new Rectangle(Padding.Left, Padding.Top, DecoratedControl.Width, DecoratedControl.Height), SourceStride = CtrlStride };

                try
                {
                    if (NonLinearTransfromNeeded != null)
                        NonLinearTransfromNeeded(this, e);
                    else
                        e.UseDefaultTransform = true;

                    if (e.UseDefaultTransform)
                    {
                        switch (DecorationType)
                        {
                            case DecorationType.BottomMirror: TransfromHelper.DoBottomMirror(e); break;
                        }
                    }
                }catch{}

                Marshal.Copy(argbValues, 0, ptr, numBytes);
                bmp.UnlockBits(bmpData);
            }
            catch
            {
            }

            return bmp;
        }

        protected override void Dispose(bool disposing)
        {
            tm.Stop();
            tm.Dispose();
            base.Dispose(disposing);
        }
    }
}
