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
 * * 说明：SkinMain.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using CCWin.SkinClass;
using CCWin.Win32;

namespace CCWin
{
    //控件层
    public partial class SkinMain : Form
    {
        //绘制层
        public SkinForm skin;
        public SkinMain()
        {
            InitializeComponent();
            //减少闪烁
            SetStyles();
            //初始化
            Init();
        }
        #region 初始化
        private void Init()
        {
            //不显示在Windows任务栏中
            ShowInTaskbar = false;
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

        #region 变量属性
        //不显示FormBorderStyle属性
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FormBorderStyle FormBorderStyle
        {
            get { return base.FormBorderStyle; }
            set { base.FormBorderStyle = FormBorderStyle.None; }
        }

        private Image skinback;
        [Category("Skin")]
        [Description("该窗体的背景图像")]
        public Image SkinBack
        {
            get { return skinback; }
            set
            {
                if (skinback != value)
                {
                    skinback = value;
                    if (value != null && show && !DesignMode)
                    {
                        SkinTools.CreateControlRegion(this, TrankBack(), 255);
                    }
                    this.Invalidate();
                    if (skin != null)
                    {
                        skin.BackgroundImage = TrankBack();
                    }
                }
            }
        }

        private Color _skintrankcolor = Color.Transparent;
        [Category("Skin")]
        [Description("背景需要透明的颜色")]
        [DefaultValue(typeof(Color), "Color.Transparent")]
        public Color SkinTrankColor
        {
            get { return _skintrankcolor; }
            set
            {
                if (_skintrankcolor != value)
                {
                    _skintrankcolor = value;
                    this.Invalidate();
                    if (skin != null)
                    {
                        skin.BackgroundImage = TrankBack();
                    }
                }
            }
        }

        private bool _skinshowintaskbar = true;
        [Category("Skin")]
        [Description("绘图层是否出现在Windows任务栏中。")]
        [DefaultValue(typeof(bool), "true")]
        public bool SkinShowInTaskbar
        {
            get { return _skinshowintaskbar; }
            set
            {
                if (_skinshowintaskbar != value)
                {
                    _skinshowintaskbar = value;
                }
            }
        }

        private bool _skinmobile = true;
        [Category("Skin")]
        [Description("窗体是否可以移动")]
        [DefaultValue(typeof(bool), "true")]
        public bool SkinMobile
        {
            get { return _skinmobile; }
            set
            {
                if (_skinmobile != value)
                {
                    _skinmobile = value;
                }
            }
        }

        //获取窗体应用的背景
        public Bitmap TrankBack()
        {
            Bitmap bitmap = new Bitmap(this.SkinBack);
            if (SkinTrankColor != Color.Transparent)
            {
                bitmap.MakeTransparent(SkinTrankColor);
            }
            Bitmap btm = new Bitmap(bitmap, this.Size);
            return btm;
        }
        #endregion

        #region 重载事件
        //重绘时
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (SkinBack != null)
            {
                if (DesignMode)
                    g.DrawImage(TrankBack(), 0, 0);
            }
            base.OnPaint(e);
        }

        //窗体关闭时
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Owner.Close();
            base.OnClosing(e);
        }

        //Visble值改变时
        bool show = false;
        protected override void OnVisibleChanged(EventArgs e)
        {
            if (!DesignMode)
            {
                if (skin != null)
                {
                    skin.Visible = this.Visible;
                }
                else
                {
                    SkinTools.CreateControlRegion(this, TrankBack(), 255);
                    show = true;
                    skin = new SkinForm(this);
                    skin.Show();
                }
            }
            base.OnVisibleChanged(e);
        }

        //大小改变时
        protected override void OnSizeChanged(EventArgs e)
        {
            if (SkinBack != null && show)
            {
                SkinTools.CreateControlRegion(this, TrankBack(), 255);
                skin.Size = this.Size;
            }
            base.OnSizeChanged(e);
        }

        //点击移动
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //释放鼠标焦点捕获
                NativeMethods.ReleaseCapture();
                //向当前窗体发送拖动消息
                NativeMethods.SendMessage(skin.Handle, 0x0112, 0xF011, 0);
                OnMouseUp(e);
            }
            base.OnMouseDown(e);
        }
        #endregion
    }
}
