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
 * * 说明：SkinForm.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using CCWin.SkinClass;
using CCWin.Win32;
using CCWin.Win32.Const;

namespace CCWin
{
    //绘图层
    public partial class SkinForm : Form
    {
        //控件层
        private SkinMain Main;
        //带参构造
        public SkinForm(SkinMain main)
        {
            InitializeComponent();
            //将控制层传值过来
            this.Main = main;
            //减少闪烁
            SetStyles();
            //初始化
            Init();
        }
        #region 初始化
        private void Init()
        {
            //最顶层
            TopMost = Main.TopMost;
            Main.TopMost = TopMost;
            //是否在任务栏显示
            ShowInTaskbar = Main.SkinShowInTaskbar;
            //无边框模式
            FormBorderStyle = FormBorderStyle.None;
            //自动拉伸背景图以适应窗口
            BackgroundImageLayout = ImageLayout.Stretch;
            //设置绘图层显示位置
            this.Location = Main.Location;
            //设置ICO
            Icon = Main.Icon;
            //是否显示ICO
            ShowIcon = Main.ShowIcon;
            //设置大小
            Size = Main.Size;
            //设置标题名
            Text = Main.Text;
            //设置背景
            Bitmap bitmaps = new Bitmap(Main.SkinBack, Size);
            if (Main.SkinTrankColor != Color.Transparent)
            {
                bitmaps.MakeTransparent(Main.SkinTrankColor);
            }
            BackgroundImage = bitmaps;
            //控制层与绘图层合为一体
            Main.Owner = this;
            //绘制层窗体移动
            this.LocationChanged += new EventHandler(Frm_LocationChanged);
            //控制层层窗体移动
            Main.LocationChanged += new EventHandler(Frm_LocationChanged);
        }
        #endregion

        #region 窗体移动时
        //窗体移动时
        private void Frm_LocationChanged(object sender, EventArgs e)
        { 
            //将调用此事件的窗口保存下
            Form frm = (Form)sender;
            if (frm == this)
            {
                Main.Location = frm.Location;
            }
            else 
            {
                this.Location = frm.Location;
            }
        }
        #endregion

        #region 减少闪烁
        private void SetStyles()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer, true);
            //强制分配样式重新应用到控件上
            UpdateStyles();
            base.AutoScaleMode = AutoScaleMode.None;
        }
        #endregion

        #region 不规则无毛边方法
        public void SetBits()
        {
            if (BackgroundImage != null)
            {
                //绘制绘图层背景
                Bitmap bitmap = new Bitmap(BackgroundImage, base.Width, base.Height);
                if (!Bitmap.IsCanonicalPixelFormat(bitmap.PixelFormat) || !Bitmap.IsAlphaPixelFormat(bitmap.PixelFormat))
                    throw new ApplicationException("图片必须是32位带Alhpa通道的图片。");
                IntPtr oldBits = IntPtr.Zero;
                IntPtr screenDC = NativeMethods.GetDC(IntPtr.Zero);
                IntPtr hBitmap = IntPtr.Zero;
                IntPtr memDc = NativeMethods.CreateCompatibleDC(screenDC);

                try
                {
                    NativeMethods.Point topLoc = new NativeMethods.Point(Left, Top);
                    NativeMethods.Size bitMapSize = new NativeMethods.Size(Width, Height);
                    NativeMethods.BLENDFUNCTION blendFunc = new NativeMethods.BLENDFUNCTION();
                    NativeMethods.Point srcLoc = new NativeMethods.Point(0, 0);

                    hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                    oldBits = NativeMethods.SelectObject(memDc, hBitmap);

                    blendFunc.BlendOp = AC.AC_SRC_OVER;
                    blendFunc.SourceConstantAlpha = Byte.Parse("255");
                    blendFunc.AlphaFormat = AC.AC_SRC_ALPHA;
                    blendFunc.BlendFlags = 0;

                    NativeMethods.UpdateLayeredWindow(Handle, screenDC, ref topLoc, ref bitMapSize, memDc, ref srcLoc, 0, ref blendFunc, NativeMethods.ULW_ALPHA);
                }
                finally
                {
                    if (hBitmap != IntPtr.Zero)
                    {
                        NativeMethods.SelectObject(memDc, oldBits);
                        NativeMethods.DeleteObject(hBitmap);
                    }
                    NativeMethods.ReleaseDC(IntPtr.Zero, screenDC);
                    NativeMethods.DeleteDC(memDc);
                }
            }
        }
        #endregion

        #region 重载事件
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cParms = base.CreateParams;
                cParms.ExStyle |= 0x00080000; // WS_EX_LAYERED
                return cParms;
            }
        }

        //点击移动
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //释放鼠标焦点捕获
                NativeMethods.ReleaseCapture();
                //向当前窗体发送拖动消息
                NativeMethods.SendMessage(this.Handle, 0x0112, 0xF011, 0);
                OnMouseUp(e);
            }
            base.OnMouseDown(e);
        }

        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);
            SetBits();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetBits();
        }
        #endregion
    }
}
