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
 * * 说明：MessageBoxForm.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using CCWin.SkinControl;
using System.Drawing.Drawing2D;
using CCWin.SkinClass;
using CCWin.Localization;

namespace Teleware.ZPG.Client
{
    /// <summary>
    /// 实现用于消息框对话框的窗体。
    /// </summary>
    public class MessageBoxForm : SkinForm
    {
        #region 变量
        private MessageBoxArgs message;
        private Rectangle imageRect;
        private Rectangle textRect;
        private int SPACING = 12;
        //按钮底部高度
        private int BOTTOM_HEIGHT = 35;
        //按钮高度
        private int BUTTON_HEIGHT = 26;
        //图片与文字水平间隔
        private int TEXT_IMAGE_SPACING = 4;
        private Size MIN_SIZE = new Size(260, 160);
        private Size MAX_SIZE = new Size(400, 230);
        private TextFormatFlags TEXT_FLAGS =
                    TextFormatFlags.HidePrefix | TextFormatFlags.ExternalLeading |
                    TextFormatFlags.WordBreak | TextFormatFlags.EndEllipsis;
        #endregion

        #region 无参构造函数
        /// <summary>
        /// 初始化 <see cref="MessageBoxForm"/> 类的新实例。
        /// </summary>
        public MessageBoxForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 重载事件

        /// <summary>
        /// 使用 <see cref="MessageBoxArgs"/> 消息对话框参数显示窗体。
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public DialogResult ShowMessageBoxDialog(MessageBoxArgs message)
        {
            this.message = message;
            return ShowMessageBoxDialog();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //响应Ctrl+V案件消息，把消息文本拷贝到剪切板。
            if (e.KeyChar == '\x03')
            {
                e.Handled = true;
                Clipboard.SetDataObject(message.Caption + Environment.NewLine +
                    Environment.NewLine + message.Text, true);
            }
            base.OnKeyPress(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible && !ContainsFocus)
            {
                Activate();
            }
        }

        private void MessageBoxForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //画图标
            if (message.Image != null)
            {
                g.DrawImage(message.Image, imageRect);
            }
            //画字
            if (!string.IsNullOrEmpty(message.Text))
            {
                TextRenderer.DrawText(g, message.Text, this.Font, this.textRect, this.ForeColor, TEXT_FLAGS);
            }
        }

        /// <summary>
        /// 显示消息对话框。
        /// </summary>
        /// <param name="owner">任何实现 <see cref="IWin32Window"/>（表示将拥有模式对话框的顶级窗口）的对象。</param>
        /// <returns><see cref="DialogResult"/> 值之一。</returns>
        protected virtual DialogResult DoShowDialog(IWin32Window owner)
        {
            ShowDialog(owner);
            return DialogResult;
        }

        #endregion

        #region 实现方法
        DialogResult ShowMessageBoxDialog()
        {
            Text = message.Caption;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            MaximizeBox = false;
            IWin32Window owner = message.Owner;

            if (owner == null)
            {
                Form activeForm = Form.ActiveForm;
                if (activeForm != null && !activeForm.InvokeRequired)
                {
                    owner = activeForm;
                }
            }

            if (owner != null)
            {
                Control ownerControl = owner as Control;
                if (ownerControl != null)
                {
                    if (!ownerControl.Visible)
                    {
                        owner = null;
                    }
                    else
                    {
                        Form ownerForm = ownerControl.FindForm();
                        if (ownerForm != null)
                        {
                            if ((!ownerForm.Visible)
                                || ownerForm.WindowState == FormWindowState.Minimized
                                || ownerForm.Right <= 0
                                || ownerForm.Bottom <= 0)
                            {
                                owner = null;
                            }
                        }
                    }
                }
            }

            if (owner == null)
            {
                ShowInTaskbar = true;
                StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                ShowInTaskbar = false;
                StartPosition = FormStartPosition.CenterParent;
            }
            CalcFinalSizes();
            CreateButtons();
            CalcBounds();
            Form frm = owner as Form;
            if (frm != null && frm.TopMost)
            {
                TopMost = true;
            }

            return DoShowDialog(owner);
        }

        private void CreateButtons()
        {
            MessageBoxButtons btns = message.Buttons;
            MessageBoxDefaultButton defaultBtn = message.DefaultButton;
            Button[] buttonArray = null;
            int buttonsTotalWidth = 0;
            switch (btns)
            {
                case MessageBoxButtons.OKCancel:
                    buttonArray = new Button[] {
                        InnerCreateButton("确定", DialogResult.OK), 
                        InnerCreateButton("取消", DialogResult.Cancel) };
                    base.CancelButton = buttonArray[1];
                    break;

                case MessageBoxButtons.AbortRetryIgnore:
                    buttonArray = new Button[] { 
                        InnerCreateButton("中止", DialogResult.Abort),
                        InnerCreateButton("重试", DialogResult.Retry),
                        InnerCreateButton("忽略", DialogResult.Ignore) };
                    base.CancelButton = buttonArray[2];
                    break;
                case MessageBoxButtons.RetryCancel:
                    buttonArray = new Button[] { 
                        InnerCreateButton("重试", DialogResult.Retry),
                        InnerCreateButton("取消", DialogResult.Cancel) };
                    base.CancelButton = buttonArray[1];
                    break;

                case MessageBoxButtons.YesNoCancel:
                    buttonArray = new Button[] {
                        InnerCreateButton("是", DialogResult.Yes), 
                        InnerCreateButton("否", DialogResult.No), 
                        InnerCreateButton("取消", DialogResult.Cancel) };
                    base.CancelButton = buttonArray[2];
                    break;

                case MessageBoxButtons.YesNo:
                    buttonArray = new Button[] {
                        InnerCreateButton("是", DialogResult.Yes), 
                        InnerCreateButton("否", DialogResult.No),};
                    base.CancelButton = buttonArray[1];
                    break;

                default:
                    buttonArray = new Button[] { 
                        InnerCreateButton("确定", DialogResult.OK) };
                    base.CancelButton = buttonArray[0];
                    break;
            }

            switch (defaultBtn)
            {
                case MessageBoxDefaultButton.Button1:
                    base.AcceptButton = buttonArray[0];
                    break;

                case MessageBoxDefaultButton.Button2:
                    if (buttonArray.Length > 1)
                    {
                        base.AcceptButton = buttonArray[1];
                    }
                    break;

                case MessageBoxDefaultButton.Button3:
                    if (buttonArray.Length > 2)
                    {
                        base.AcceptButton = buttonArray[2];
                    }
                    break;
            }

            foreach (SkinButton button in buttonArray)
            {
                if (buttonsTotalWidth != 0)
                {
                    buttonsTotalWidth += SPACING;
                }
                buttonsTotalWidth += button.Width;
            }
            int nextButtonPos = DisplayRectangle.Width - buttonsTotalWidth;
            for (int i = 0; i < buttonArray.Length; ++i)
            {
                buttonArray[i].Location = new Point(nextButtonPos, this.Height - buttonArray[i].Height - 4);
                nextButtonPos += buttonArray[i].Width + SPACING;
            }
        }

        private SkinButton InnerCreateButton(string text, DialogResult result)
        {
            SkinButton button = new SkinButton();
            button.DownBack = Properties.Resources.btn_down;
            button.MouseBack = Properties.Resources.btn_hover;
            button.NormlBack = Properties.Resources.btn_normal;
            button.DrawType = CCWin.SkinControl.DrawStyle.Img;
            button.Palace = true;
            button.Size = new Size(60, BUTTON_HEIGHT);
            button.UseVisualStyleBackColor = false;
            button.InheritColor = true;
            button.ForeColorSuit = true;
            button.Text = text;
            button.DialogResult = result;
            button.Click += new EventHandler(BtnClick);
            base.Controls.Add(button);
            return button;
        }

        private void BtnClick(object sender, EventArgs e)
        {
            base.DialogResult = ((Button)sender).DialogResult;
            base.Close();
        }

        private void CalcBounds()
        {
            var textSize = GetTextSize();
            var imageLeft = SPACING;
            var imageTop = 0;
            var textTop = 0;
            var textLeft = 0;
            var textWidth = 0;
            var textHeight = Math.Min(this.Height - (2 * SPACING + BOTTOM_HEIGHT + CaptionHeight), (int)textSize.Height);
            if (this.message.Image == null)
            {
                textWidth = Math.Min(this.Width - 2 * SPACING, (int)textSize.Width);
                textLeft = Math.Max(SPACING, (this.Width - textSize.Width) / 2);
                textTop = Math.Max(CaptionHeight + SPACING, CaptionHeight + (this.Height - (textSize.Height + BOTTOM_HEIGHT + CaptionHeight)) / 2);
                this.imageRect = new Rectangle(0, 0, 0, 0);
            }
            else
            {
                textWidth = Math.Min(this.Width - (2 * SPACING + TEXT_IMAGE_SPACING + this.message.Image.Width), (int)textSize.Width);
                textLeft = SPACING + this.message.Image.Width + TEXT_IMAGE_SPACING;
                if ((int)textSize.Height < this.Height - (2 * SPACING + BOTTOM_HEIGHT + CaptionHeight))
                {
                    textTop = CaptionHeight + (this.Height - (textSize.Height + BOTTOM_HEIGHT + CaptionHeight)) / 2;
                }
                else
                {
                    textTop = CaptionHeight + SPACING;
                }
                if (this.message.Image.Height > textSize.Height)
                {
                    imageTop = Math.Max(CaptionHeight + SPACING, CaptionHeight + (this.Height - (this.message.Image.Height + BOTTOM_HEIGHT + CaptionHeight)) / 2);
                }
                else
                {
                    imageTop = textTop;
                }
                this.imageRect = new Rectangle(imageLeft, imageTop, this.message.Image.Width, this.message.Image.Height);
            }
            this.textRect = new Rectangle(textLeft, textTop, textWidth, textHeight);

            var rightWidth = this.Width - (SPACING * 2 + this.imageRect.Width + TEXT_IMAGE_SPACING + this.textRect.Width);
            if (rightWidth > 2)
            {
                if (this.message.Image != null)
                {
                    this.imageRect = new Rectangle(imageLeft + rightWidth / 2, imageTop, this.message.Image.Width, this.message.Image.Height);
                }
                this.textRect = new Rectangle(textLeft + rightWidth / 2, textTop, textWidth, textHeight);
            }
        }

        private void CalcFinalSizes()
        {
            Size textSize = GetTextSize();
            var width = 2 * SPACING + textSize.Width;
            var height = 2 * SPACING + textSize.Height + CaptionHeight + BOTTOM_HEIGHT;
            if (this.message.Image != null)
            {
                width += this.message.Image.Width + TEXT_IMAGE_SPACING;
                if (this.message.Image.Height > textSize.Height)
                {
                    height = 2 * SPACING + this.message.Image.Height;
                }
            }
            if (width > MAX_SIZE.Width)
            {
                width = MAX_SIZE.Width;
            }
            else if (width < MIN_SIZE.Width)
            {
                width = MIN_SIZE.Width;
            }
            if (height > MAX_SIZE.Height)
            {
                height = MAX_SIZE.Height;
            }
            else if (height < MIN_SIZE.Height)
            {
                height = MIN_SIZE.Height;
            }
            this.Size = new Size(width, height);
        }

        private Size GetTextSize()
        {
            if (string.IsNullOrEmpty(this.message.Text)) return Size.Empty;
            Size textSize = TextRenderer.MeasureText(this.message.Text, this.Font, new Size(int.MaxValue, int.MaxValue), TEXT_FLAGS);
            return textSize;
        }
        #endregion

        #region InitializeComponent()自动生成的代码
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MessageBoxForm
            // 
            this.Back = global::Teleware.ZPG.Client.Properties.Resources.bluebase;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(234)))), ((int)(((byte)(245)))));
            this.BackgroundImage = null;
            this.BackRectangle = new System.Drawing.Rectangle(50, 30, 200, 100);
            this.BackShade = false;
            this.BorderPalace = null;
            this.ClientSize = new System.Drawing.Size(400, 230);
            this.ControlBoxOffset = new System.Drawing.Point(0, -1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageBoxForm";
            this.Text = "提示";
            this.TitleSuitColor = true;
            this.TopMost = true;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MessageBoxForm_Paint);
            this.ResumeLayout(false);

        }
        #endregion
    }

    #region 消息框对话消息参数
    /// <summary>
    /// 消息框对话消息参数。
    /// </summary>
    public class MessageBoxArgs
    {
        IWin32Window _owner;
        string _text;
        string _caption;
        MessageBoxButtons _buttons;
        Bitmap _icon;
        MessageBoxDefaultButton _defaultButton;

        /// <summary>
        /// 初始化 <see cref="MessageBoxArgs"/> 类的新实例。
        /// </summary>
        public MessageBoxArgs()
        {
        }

        /// <summary>
        ///  初始化 <see cref="MessageBoxArgs"/> 类的新实例。
        /// </summary>
        /// <param name="owner">任何实现 <see cref="IWin32Window"/>（表示将拥有模式对话框的顶级窗口）的对象。</param>
        /// <param name="text">需要显示消息文本。</param>
        /// <param name="caption">需要现实的消息标题。</param>
        /// <param name="buttons"><see cref="MessageBoxButtons"/> 值之一。</param>
        /// <param name="icon">需要显示的消息图标。</param>
        /// <param name="defaultButton"><see cref="MessageBoxDefaultButton"/> 值之一。</param>
        public MessageBoxArgs(IWin32Window owner, string text, string caption,
            MessageBoxButtons buttons, Bitmap icon, MessageBoxDefaultButton defaultButton)
        {
            _owner = owner;
            _text = text;
            _caption = caption;
            _buttons = buttons;
            _icon = icon;
            _defaultButton = defaultButton;
        }

        public IWin32Window Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        public MessageBoxButtons Buttons
        {
            get { return _buttons; }
            set { _buttons = value; }
        }

        public Bitmap Image
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public MessageBoxDefaultButton DefaultButton
        {
            get { return _defaultButton; }
            set { _defaultButton = value; }
        }
    }
    #endregion
}
