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
    public partial class MessageIconForm : SkinForm
    {
        private TextFormatFlags flags = TextFormatFlags.HidePrefix | TextFormatFlags.ExternalLeading | TextFormatFlags.WordBreak | TextFormatFlags.EndEllipsis;
        private int maxWidth = 400;
        private int minWidth = 200;
        private int fixHeight = 90;
        private Size maxTextSize = new Size(370, 90);
        private int spacing = 10;
        private int textImageSpacing = 4;
        private LoadingBoxArgs loadingBoxArgs;

        public MessageIconForm()
        {
            InitializeComponent();
        }

        public void ShowLoading(LoadingBoxArgs loadingBoxArgs)
        {
            if (loadingBoxArgs == null) throw new ArgumentNullException("loadingBoxArgs");
            this.loadingBoxArgs = loadingBoxArgs;
            this.pic_loading.Size = new Size(loadingBoxArgs.LoadingImage.Width, loadingBoxArgs.LoadingImage.Height);
            this.pic_loading.Image = loadingBoxArgs.LoadingImage;
            var ownerForm = loadingBoxArgs.Owner;

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
            this.CalcFinalSizes();
            this.TopMost = true;
            this.Show(ownerForm);
        }

        private void CalcFinalSizes()
        {
            if (!string.IsNullOrEmpty(this.loadingBoxArgs.LoadingText))
            {
                Size textSize = TextRenderer.MeasureText(this.loadingBoxArgs.LoadingText, this.Font, this.maxTextSize, this.flags);
                Size imgSize = this.pic_loading.Size;
                var width = this.spacing + imgSize.Width + this.textImageSpacing + textSize.Width + spacing;
                if (width > this.maxWidth)
                {
                    width = this.maxWidth;
                }
                else if (width < this.minWidth)
                {
                    width = this.minWidth;
                }
                this.Size = new Size(width, fixHeight);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.loadingBoxArgs != null)
            {
                var g = e.Graphics;
                var fontSize = g.MeasureString(this.loadingBoxArgs.LoadingText, this.Font);
                var loadingImage = this.loadingBoxArgs.LoadingImage;
                var left = Math.Max(spacing, (this.Width - (loadingImage.Width + (int)fontSize.Width + textImageSpacing)) / 2);
                var imageTop = (this.Height - loadingImage.Height) / 2;
                var textTop = Math.Max(this.spacing, (this.Height - (int)fontSize.Height) / 2);
                this.pic_loading.Location = new Point(left, imageTop);
                var textLeft = left + loadingImage.Width + textImageSpacing;
                var textWidth = Math.Min((int)fontSize.Width, this.Width - textLeft - spacing);
                var textHeight = Math.Min((int)fontSize.Height, this.Height - spacing - spacing);
                var rect = new Rectangle(textLeft, textTop, textWidth, textHeight);
                TextRenderer.DrawText(g, this.loadingBoxArgs.LoadingText, this.Font, rect, this.ForeColor, flags);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            if (ShowSpecialOnClosed)
            {
                this.Special = false;
                this.SkinOpacity = 1;
            }
            base.OnClosed(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (ShowSpecialOnClosed)
            {
                NativeMethods.AnimateWindow(this.Handle, 3000, AW.AW_BLEND | AW.AW_HIDE | AW.AW_SLIDE);
            }
            base.OnFormClosing(e);
        }

        public bool ShowSpecialOnClosed
        {
            get;
            set;
        }
    }
}
