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
        private Size MIN_SIZE = new Size(121,45);
        private Size MAX_SIZE = new Size(300, 80);
        private int SPACING = 4;
        private TextFormatFlags TEXT_FLAGS =
                    TextFormatFlags.HidePrefix | TextFormatFlags.ExternalLeading |
                    TextFormatFlags.WordBreak | TextFormatFlags.EndEllipsis;
        private string caption;
        private Rectangle textRect;

        public ToolTipForm()
        {
            InitializeComponent();
        }


    
        public void SetToolTip(Control control,string caption)
        {
            if (caption == null) throw new ArgumentNullException("control");
            this.caption = caption;
            CalcFinalSizes();
            var point = control.Parent.PointToScreen(control.Location);
            int x = point.X + (control.Width / 2) - (this.Width / 2);
            int y = point.Y - this.Height - 2;
            this.Location = new Point(x, y);
            this.StartPosition = FormStartPosition.Manual;
            this.Show();
        }

        protected override void OnDeactivate(EventArgs e)
        {
            //this.Close();
            base.OnDeactivate(e);
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
            var height = 2 * SPACING + textSize.Height;
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
            this.TopMost = true;
            var textWidth = Math.Min(this.Width - 2 * SPACING, textSize.Width);
            var textHeight = Math.Min(this.Height - 2 * SPACING, textSize.Height);
            var textLeft = (this.Width - textWidth) / 2;
            var textTop = (this.Height - textHeight) / 2;
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
