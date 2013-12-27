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
 * * 说明：SkinGroupBox.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using CCWin.SkinClass;

namespace CCWin.SkinControl
{
    [ToolboxBitmap(typeof(GroupBox))]
    public partial class SkinGroupBox : GroupBox
    {
        public SkinGroupBox()
        {
            this.Font = CCWin.Localization.Localizer.DefaultFont;
            InitializeComponent();
            //初始化
            Init();
            this.ResizeRedraw = true;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.Blue;
        }
        #region 初始化
        public void Init()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.StandardDoubleClick, false);
            this.SetStyle(ControlStyles.Selectable, true);
            this.UpdateStyles();
        }
        #endregion

        #region 变量与属性
        private RoundStyle _roundStyle = RoundStyle.All;
        [Category("Skin")]
        [DefaultValue(typeof(RoundStyle), "1")]
        [Description("设置或获取按钮圆角的样式")]
        public RoundStyle RoundStyle
        {
            get { return _roundStyle; }
            set
            {
                if (_roundStyle != value)
                {
                    _roundStyle = value;
                    base.Invalidate();
                }
            }
        }

        private int radius = 4;
        /// <summary>
        /// 圆角大小
        /// </summary>
        [DefaultValue(typeof(int), "4")]
        [Category("Skin")]
        [Description("圆角大小")]
        public int Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (radius != value)
                {
                    radius = value < 4 ? 4 : value;
                    this.Invalidate();
                }
            }
        }

        private Color borderColor = Color.Red;
        [Browsable(true), Category("Skin"), Description("边框颜色")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        private Color rectBackColor = Color.White;
        [Browsable(true), Category("Skin"), Description("框内颜色填充")]
        public Color RectBackColor
        {
            get { return rectBackColor; }
            set
            {
                rectBackColor = value;
                Invalidate();
            }
        }

        private RoundStyle titleroundStyle = RoundStyle.All;
        [Category("Title")]
        [DefaultValue(typeof(RoundStyle), "1")]
        [Description("Title设置或获取按钮圆角的样式")]
        public RoundStyle TitleRoundStyle
        {
            get { return titleroundStyle; }
            set
            {
                if (titleroundStyle != value)
                {
                    titleroundStyle = value;
                    base.Invalidate();
                }
            }
        }

        private int titleradius = 4;
        /// <summary>
        /// 圆角大小
        /// </summary>
        [DefaultValue(typeof(int), "4")]
        [Category("Title")]
        [Description("Title圆角大小")]
        public int TitleRadius
        {
            get
            {
                return titleradius;
            }
            set
            {
                if (titleradius != value)
                {
                    titleradius = value < 4 ? 4 : value;
                    this.Invalidate();
                }
            }
        }

        private Color titleborderColor = Color.Red;
        [Browsable(true), Category("Title"), Description("Title边框颜色")]
        public Color TitleBorderColor
        {
            get { return titleborderColor; }
            set
            {
                titleborderColor = value;
                Invalidate();
            }
        }

        private Color titlerectBackColor = Color.White;
        [Browsable(true), Category("Title"), Description("Title框内颜色填充")]
        public Color TitleRectBackColor
        {
            get { return titlerectBackColor; }
            set
            {
                titlerectBackColor = value;
                Invalidate();
            }
        }
        #endregion

        #region 重绘事件
        protected override void OnPaint(PaintEventArgs e)
        {
            //测量文字大小
            Size szFont = Text.Length != 0 ? TextRenderer.MeasureText(Text, this.Font) : TextRenderer.MeasureText("空", this.Font);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //最高质量绘制文字
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            //画背景
            g.FillRectangle(new SolidBrush(base.BackColor), this.ClientRectangle);
            //取得轮廓
            using (GraphicsPath path =
                          GraphicsPathHelper.CreatePath(new Rectangle(1, 1 + szFont.Height / 2, Width - 2, Height - 2 - szFont.Height / 2), Radius, RoundStyle, false))
            {
                //画框内填充
                using (SolidBrush br = new SolidBrush(RectBackColor))
                {
                    g.FillPath(br, path);
                }
                //画框内边框
                using (Pen pen = new Pen(BorderColor))
                {
                    g.DrawPath(pen, path);
                }
            }

            //判断标题是否为空
            if (Text.Length != 0)
            {
                //取得轮廓
                using (GraphicsPath path =
                              GraphicsPathHelper.CreatePath(new Rectangle(new Point(7, 1), new Size(szFont.Width, szFont.Height)), TitleRadius, TitleRoundStyle, false))
                {
                    //画字框内填充
                    using (SolidBrush br = new SolidBrush(TitleRectBackColor))
                    {
                        g.FillPath(br, path);
                    }
                    //画字框内边框
                    using (Pen pen = new Pen(TitleBorderColor))
                    {
                        g.DrawPath(pen, path);
                    }
                }
                //画字
                e.Graphics.DrawString(Text, this.Font, new SolidBrush(this.ForeColor), new Point(7,1));
            }
        }
        #endregion
    }
}
