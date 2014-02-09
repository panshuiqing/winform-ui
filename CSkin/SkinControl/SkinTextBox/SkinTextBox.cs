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
 * * 说明：SkinTextBox.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CCWin.SkinClass;
using System.Drawing.Drawing2D;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;

namespace CCWin.SkinControl
{
    [Designer(typeof(SkinTextBoxDesigner))]
    //[Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    [ToolboxBitmap(typeof(TextBox))]
    public partial class SkinTextBox : UserControl
    {
        public SkinTextBox()
        {
            InitializeComponent();
            //初始化
            Init();
            this.InitEvents();
            this.BackColor = Color.Transparent;
        }
        #region 初始化
        public void Init()
        {
            this.SetStyle(
                    ControlStyles.UserPaint |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.ResizeRedraw |
                    ControlStyles.DoubleBuffer, true);
            this.UpdateStyles();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 加载事件
        /// </summary>
        private void InitEvents()
        {
            this.BaseText.MouseEnter += new EventHandler(BaseText_MouseEnter);
            this.BaseText.MouseLeave += new EventHandler(BaseText_MouseLeave);
            this.BaseText.MouseMove += new MouseEventHandler(BaseText_MouseMove);
        }

        void BaseText_MouseMove(object sender, MouseEventArgs e)
        {
            this.MouseState = ControlState.Hover;
        }

        /// <summary>
        /// 偏移文本框
        /// </summary>
        bool flag = false;
        protected virtual void PositionTextBox()
        {
            if (this._icon != null && !flag)
            {
                this.Padding = new Padding(this.Padding.Left, this.Padding.Top, this.Padding.Right + 23, this.Padding.Bottom);
                flag = true;
            }
            else if (this._icon == null && flag)
            {
                this.Padding = new Padding(this.Padding.Left, this.Padding.Top, this.Padding.Right - 23, this.Padding.Bottom);
                flag = false;
            }
        }
        #endregion

        #region 自定义事件
        public event EventHandler IconClick;
        private void OnIconClick()
        {
            if (this.IconClick != null)
                this.IconClick(this, EventArgs.Empty);
        }
        #endregion

        #region 变量
        private Cursor _cursor = Cursors.IBeam;
        private ControlState _mouseState = ControlState.Normal;
        private ControlState _iconMouseState = ControlState.Normal;
        private Bitmap mouseback;
        private Bitmap normlback;
        private bool _iconIsButton;
        private Image _icon;
        #endregion

        #region 属性
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("透明水印文本框。"), Category("Skin")]
        public SkinWaterTextBox SkinTxt
        {
            get { return this.BaseText; }
        }

        [Description("文本。"), Category("Skin")]
        public string Text
        {
            get
            {
                return this.SkinTxt.Text;
            }
            set
            {
                this.SkinTxt.Text = value;
            }
        }

        [Description("悬浮时背景框。"), Category("Skin")]
        public Bitmap MouseBack
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

        [Description("正常状态时背景框。"), Category("Skin")]
        public Bitmap NormlBack
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

        [Description("文本框的图标"), Category("Skin")]
        public Image Icon
        {
            get { return this._icon; }
            set
            {
                if (this._icon != value)
                {
                    this._icon = value;
                    base.Invalidate(this.IconRect);
                    this.PositionTextBox();
                }
            }
        }

        [Description("文本框的图标是否是按钮"), Category("Skin")]
        public bool IconIsButton
        {
            get { return this._iconIsButton; }
            set { this._iconIsButton = value; }
        }

        public override Cursor Cursor
        {
            get { return this._cursor; }
            set { this._cursor = value; }
        }

        public ControlState MouseState
        {
            get { return this._mouseState; }
            set
            {
                this._mouseState = value;
                base.Invalidate();
            }
        }

        public ControlState IconMouseState
        {
            get { return this._iconMouseState; }
            set
            {
                this._iconMouseState = value;
                base.Invalidate();
            }
        }
        /// <summary>
        /// 图标的绘制区域
        /// </summary>
        protected Rectangle IconRect
        {
            get { return new Rectangle(this.Width - 23, 3, 20, 20); }
        }
        #endregion

        #region 事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BaseText_MouseLeave(object sender, EventArgs e)
        {
            this.MouseState = ControlState.Normal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseText_MouseEnter(object sender, EventArgs e)
        {
            this.MouseState = ControlState.Hover;
        }
        #endregion

        #region 重载事件
        /// <summary>
        /// 当文本框的大小发生改变时，将文本框的类型换成多行文本
        /// </summary>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            //if (this.Height > 28)
            //{
            //    this.BaseText.Multiline = true;
            //}
            //else
            //{
            //    this.BaseText.Multiline = false;
            //}
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Bitmap mouse = MouseBack == null ? Properties.Resources.textbox_mousedown : MouseBack;
            Bitmap norml = NormlBack == null ? Properties.Resources.textbox_normal : NormlBack;
            Bitmap btm = this._mouseState == ControlState.Hover ? mouse : norml;
            if (btm != null)
            {
                DrawHelper.RendererBackground(g, this.ClientRectangle, btm, true);
            }
            if (this._icon != null)
            {
                Rectangle iconRect = this.IconRect;
                if (this._iconMouseState == ControlState.Pressed)
                {
                    iconRect.X += 1;
                    iconRect.Y += 1;
                }
                g.DrawImage(this._icon, iconRect, 0, 0, this._icon.Width, this._icon.Height, GraphicsUnit.Pixel);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        //protected override void OnMouseEnter(EventArgs e)
        //{
        //    base.OnMouseEnter(e);
        //    this.MouseState = ControlState.Hover;

        //}

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this._icon != null && this.IconRect.Contains(e.Location))
            {
                if (this._iconIsButton)
                {
                    this.Cursor = Cursors.Hand;
                }
                else
                {
                    this.Cursor = Cursors.IBeam;
                }
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this._icon != null && this._iconIsButton)
            {
                if (e.Button == MouseButtons.Left && this.IconRect.Contains(e.Location))
                {
                    this.IconMouseState = ControlState.Pressed;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (this._icon != null && this._iconIsButton)
            {
                this.IconMouseState = ControlState.Hover;
                if (e.Button == MouseButtons.Left && this.IconRect.Contains(e.Location))
                    this.OnIconClick();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        //protected override void OnMouseLeave(EventArgs e)
        //{
        //    base.OnMouseLeave(e);
        //    this.MouseState = ControlState.Normal;
        //}
        #endregion
    }

    class SkinTextBoxDesigner : ControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            SkinTextBox uc = component as SkinTextBox;
            this.EnableDesignMode(uc.SkinTxt, "BaseText");
        }
    }
}
