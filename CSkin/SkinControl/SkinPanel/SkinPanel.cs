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
 * * 说明：SkinPanel.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Drawing.Drawing2D;
using CCWin.SkinClass;

namespace CCWin.SkinControl
{
    [ToolboxBitmap(typeof(Panel))]
    public partial class SkinPanel : Panel
    {
        public SkinPanel()
        {
            this.Font = CCWin.Localization.Localizer.DefaultFont;
            //初始化
            Init();
            this.ResizeRedraw = true;
            this.BackColor = System.Drawing.Color.Transparent;//背景设为透明
        }
        #region 初始化
        public void Init()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);//调整大小时重绘
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);// 双缓冲
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);// 禁止擦除背景.
            this.SetStyle(ControlStyles.UserPaint, true);//自行绘制
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();
        }
        #endregion

        #region 属性与变量
        private ControlState _controlState;
        /// <summary>
        /// 控件状态
        /// </summary>
        public ControlState ControlState
        {
            get { return _controlState; }
            set
            {
                if (_controlState != value)
                {
                    _controlState = value;
                    base.Invalidate();
                }
            }
        }

        private bool palace = false;
        /// <summary>
        /// 是否开启九宫绘图
        /// </summary>
        [Category("Skin")]
        [DefaultValue(typeof(bool), "false")]
        [Description("是否开启九宫绘图")]
        public bool Palace
        {
            get { return palace; }
            set
            {
                if (palace != value)
                {
                    palace = value;
                    this.Invalidate();
                }
            }
        }

        private Rectangle backrectangle = new Rectangle(10, 10, 10, 10);
        /// <summary>
        /// 九宫绘画区域
        /// </summary>
        [Category("Skin")]
        [DefaultValue(typeof(Rectangle), "10,10,10,10")]
        [Description("九宫绘画区域")]
        public Rectangle BackRectangle
        {
            get { return backrectangle; }
            set
            {
                if (backrectangle != value)
                {
                    backrectangle = value;
                }
                this.Invalidate();
            }
        }

        private Image mouseback;
        /// <summary>
        /// 悬浮时
        /// </summary>
        [Category("MouseEnter")]
        [Description("悬浮时背景")]
        public Image MouseBack
        {
            get { return mouseback; }
            set
            {
                if (mouseback != value)
                {
                    mouseback = value;
                    this.Invalidate();
                }
            }
        }

        private Image downback;
        /// <summary>
        /// 点击时
        /// </summary>
        [Category("MouseDown")]
        [Description("点击时背景")]
        public Image DownBack
        {
            get { return downback; }
            set
            {
                if (downback != value)
                {
                    downback = value;
                    this.Invalidate();
                }
            }
        }

        private Image normlback;
        /// <summary>
        /// 初始时
        /// </summary>
        [Category("MouseNorml")]
        [Description("初始时背景")]
        public Image NormlBack
        {
            get { return normlback; }
            set
            {
                if (normlback != value)
                {
                    normlback = value;
                    this.Invalidate();
                }
            }
        }

        private int radius = 8;
        /// <summary>
        /// 圆角大小
        /// </summary>
        [DefaultValue(typeof(int), "8")]
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

        private RoundStyle _roundStyle = RoundStyle.None;
        [Category("Skin")]
        [DefaultValue(typeof(RoundStyle), "0")]
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
        #endregion

        #region 重载事件
        //鼠标悬浮时
        protected override void OnMouseEnter(EventArgs e)
        {
            ControlState = ControlState.Hover;
            base.OnMouseEnter(e);
        }

        //鼠标离开时
        protected override void OnMouseLeave(EventArgs e)
        {
            ControlState = ControlState.Normal;
            base.OnMouseLeave(e);
        }

        //鼠标点击时
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ControlState = ControlState.Pressed;
            }
            base.OnMouseDown(e);
        }

        //鼠标按下时
        protected override void OnMouseUp(MouseEventArgs e)
        {
            ControlState = ControlState.Hover;
            base.OnMouseUp(e);
        }

        protected override void OnCreateControl()
        {
            //绘制圆角
            SkinTools.CreateRegion(this, this.ClientRectangle, radius, RoundStyle);
            base.OnCreateControl();
        }

        //重绘
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //取得当前需要绘画的图像
            Bitmap btm = null;
            switch (_controlState)
            {
                case ControlState.Pressed:
                    btm = (Bitmap)DownBack;
                    break;
                case ControlState.Hover:
                    btm = (Bitmap)MouseBack;
                    break;
                default:
                    btm = (Bitmap)NormlBack;
                    break;
            }
            if (btm != null)
            {
                //是否启用九宫绘图
                if (Palace)
                {
                    ImageDrawRect.DrawRect(g, btm, new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height), Rectangle.FromLTRB(BackRectangle.X, BackRectangle.Y, BackRectangle.Width, BackRectangle.Height), 1, 1);
                }
                else
                {
                    g.DrawImage(btm,this.ClientRectangle);
                }
            }
            //绘制圆角
            SkinTools.CreateRegion(this, this.ClientRectangle, radius, RoundStyle);
            base.OnPaint(e);
        }
        #endregion
    }
}