using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Teleware.ZPG.Client
{
    public partial class ToolTipForm : SkinForm
    {
        private string caption;
        private int SPACING = 4;
        private Size MIN_SIZE = new Size(181, 37);
        private Size MAX_SIZE = new Size(400, 160);
        private Rectangle textRect = Rectangle.Empty;
        private TextFormatFlags TEXT_FLAGS =
                    TextFormatFlags.HidePrefix | TextFormatFlags.ExternalLeading |
                    TextFormatFlags.WordBreak | TextFormatFlags.EndEllipsis;

        public ToolTipForm()
        {
            InitializeComponent();
        }

        public void Show(string text, Control control)
        {
            this.Show(text, control, 0);
        }

        public void Show(string text, Control control, int duration)
        {
            if (text == null) throw new ArgumentNullException("control");
            this.caption = text;
            CalcFinalSizes();
            var point = control.PointToScreen(control.Location);
            int x = point.X;
            int y = point.Y - this.Height;
            this.Location = new Point(x, 200);
            this.Show();
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            //this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //画字
            if (!string.IsNullOrEmpty(this.caption))
            {
                TextRenderer.DrawText(e.Graphics, this.caption, this.Font, textRect, this.ForeColor, TEXT_FLAGS);
            }
        }

        private void CalcFinalSizes()
        {
            Size textSize = GetTextSize();
            var width = 2 * SPACING + textSize.Width;
            var height = 2 * SPACING + textSize.Height + 6;
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
            var textWidth = Math.Min(this.Width - 2 * SPACING, textSize.Width);
            var textHeight = Math.Min(this.Height - 2 * SPACING, textSize.Height);
            var textLeft = (this.Width - textWidth) / 2;
            var textTop = (this.Height - textHeight - 6) / 2;
            this.textRect = new Rectangle(textLeft, textTop, textWidth, textHeight);
        }

        private Size GetTextSize()
        {
            if (string.IsNullOrEmpty(this.caption)) return Size.Empty;
            int maxTextWidth = MAX_SIZE.Width - 2 * SPACING;
            int maxTextHeight = MAX_SIZE.Height - (2 * SPACING);
            Size textSize = TextRenderer.MeasureText(this.caption, this.Font, new Size(maxTextWidth, maxTextHeight), TEXT_FLAGS);
            return textSize;
        }
    }
}
