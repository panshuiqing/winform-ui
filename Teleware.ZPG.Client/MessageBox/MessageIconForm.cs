using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin.Win32;
using CCWin.Win32.Const;

namespace Teleware.ZPG.Client
{
    /// <summary>
    /// 左边显示图片，右边显示文字的窗体
    /// <para>图片文字四周的空白距离固定，并且文字始终在垂直方向和水平方向居中对齐</para>
    /// </summary>
    public partial class MessageIconForm : SkinForm
    {
        //图片或者文字相对窗体的margin值
        private static int SPACING = 20;
        //文字修饰
        private TextFormatFlags TEXT_FLAGS = TextFormatFlags.HidePrefix | TextFormatFlags.ExternalLeading | TextFormatFlags.WordBreak | TextFormatFlags.EndEllipsis;
        //窗体最大大小
        private Size MAX_SIZE = new Size(400, 180);
        //最小大小
        private Size MIN_SIZE = new Size(180, 70);
        //图片与文字水平间隔
        private int TEXT_IMAGE_SPACING = 4;
        private Rectangle textRect;

        private LoadingBoxArgs loadingBoxArgs;

        public MessageIconForm()
        {
            this.FadeOutSecond = 2;
            InitializeComponent();
        }

        public void ShowLoading(LoadingBoxArgs loadingBoxArgs)
        {
            if (loadingBoxArgs == null) throw new ArgumentNullException("loadingBoxArgs");
            this.loadingBoxArgs = loadingBoxArgs;
            var ownerForm = loadingBoxArgs.Owner;
            if (this.loadingBoxArgs.LoadingImage != null)
            {
                this.pic_loading.Size = new Size(loadingBoxArgs.LoadingImage.Width, loadingBoxArgs.LoadingImage.Height);
                this.pic_loading.Image = loadingBoxArgs.LoadingImage;
                this.pic_loading.Visible = true;
                if (this.pic_loading.Width > MAX_SIZE.Width)
                {
                    this.pic_loading.Width = MAX_SIZE.Width;
                }
                if (this.pic_loading.Height > MAX_SIZE.Height)
                {
                    this.pic_loading.Height = MAX_SIZE.Height;
                }
            }
            else
            {
                this.pic_loading.Visible = false;
            }
            this.CalcFinalSizes();
            this.CalcBounds();
            if (ownerForm == null)
            {
                Form activeForm = Form.ActiveForm;
                if (activeForm != null && !activeForm.InvokeRequired)
                {
                    ownerForm = activeForm;
                }
            }
            if (ownerForm == null)
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.StartPosition = FormStartPosition.Manual;
                var ctrl = ownerForm as Control;
                var left = (ctrl.Width - this.Width) / 2 + ctrl.Location.X;
                var top = (ctrl.Height - this.Height) / 2 + ctrl.Location.Y;
                this.Location = new Point(left, top);
            }
            this.TopMost = true;
            this.Show(ownerForm);
        }

        private Size GetTextSize()
        {
            if (string.IsNullOrEmpty(this.loadingBoxArgs.LoadingText)) return Size.Empty;
            Size textSize = TextRenderer.MeasureText(this.loadingBoxArgs.LoadingText, this.Font, new Size(int.MaxValue, int.MaxValue), TEXT_FLAGS);
            return textSize;
        }

        private void CalcFinalSizes()
        {
            Size textSize = GetTextSize();
            var width = 2 * SPACING + textSize.Width;
            var height = 2 * SPACING + textSize.Height;
            var loadingImage = this.loadingBoxArgs.LoadingImage;
            if (loadingImage != null)
            {
                width += loadingImage.Width + TEXT_IMAGE_SPACING;
                if (loadingImage.Height > textSize.Height)
                {
                    height = 2 * SPACING + loadingImage.Height;
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

        private void CalcBounds()
        {
            var loadingImage = this.loadingBoxArgs.LoadingImage;
            var textSize = GetTextSize();
            var imageLeft = SPACING;
            var imageTop = 0;
            var textTop = 0;
            var textLeft = 0;
            var textWidth = 0;
            var textHeight = Math.Min(this.Height - 2 * SPACING, (int)textSize.Height);

            if (loadingImage == null)
            {
                textWidth = Math.Min(this.Width - 2 * SPACING, (int)textSize.Width);
                textLeft = Math.Max(SPACING, (this.Width - textSize.Width) / 2);
                textTop = Math.Max(SPACING, (this.Height - textSize.Height) / 2);
                this.pic_loading.Visible = false;
            }
            else
            {
                textWidth = Math.Min(this.Width - (2 * SPACING + TEXT_IMAGE_SPACING + loadingImage.Width), (int)textSize.Width);
                textLeft = SPACING + loadingImage.Width + TEXT_IMAGE_SPACING;
                if (loadingImage.Height > textSize.Height)
                {
                    imageTop = SPACING;
                    textTop = (this.Height - textSize.Height) / 2;
                }
                else
                {
                    textTop = SPACING;
                    imageTop = (this.Height - loadingImage.Height) / 2;
                }
                this.pic_loading.Visible = true;
                this.pic_loading.Location = new Point(imageLeft, imageTop);

            }

            this.textRect = new Rectangle(textLeft, textTop, textWidth, textHeight);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.loadingBoxArgs != null)
            {
                TextRenderer.DrawText(e.Graphics, this.loadingBoxArgs.LoadingText, this.Font, this.textRect, this.ForeColor, TEXT_FLAGS);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            NativeMethods.AnimateWindow(this.Handle, FadeOutSecond * 1000, AW.AW_BLEND | AW.AW_HIDE | AW.AW_SLIDE);
            base.OnFormClosing(e);
        }

        /// <summary>
        /// 淡出的时间 秒
        /// </summary>
        public int FadeOutSecond
        {
            get;
            set;
        }
    }
}
