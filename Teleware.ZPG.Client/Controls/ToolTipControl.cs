using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CCWin.SkinClass;

namespace Teleware.ZPG.Client.Controls
{
    public partial class ToolTipControl : UserControl
    {
        private Size MIN_SIZE = new Size(181, 37);
        private Size MAX_SIZE = new Size(150, 32);
        private int SPACING = 4;
        private TextFormatFlags TEXT_FLAGS =
                    TextFormatFlags.HidePrefix | TextFormatFlags.ExternalLeading |
                    TextFormatFlags.WordBreak | TextFormatFlags.EndEllipsis;
        private string caption;
        private Rectangle textRect;
        private int duration = 0;

        public ToolTipControl()
        {
            InitializeComponent();
            this.skinPanel1.Paint += new PaintEventHandler(skinPanel1_Paint);
        }

        void skinPanel1_Paint(object sender, PaintEventArgs e)
        {
            //画字
            if (!string.IsNullOrEmpty(this.caption))
            {
                TextRenderer.DrawText(e.Graphics, this.caption, this.Font, textRect, this.ForeColor, TEXT_FLAGS);
            }
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
            var point = control.Parent.PointToScreen(control.Location);
            int x = point.X + (control.Width / 2) - (this.Width / 2);
            int y = point.Y - this.Height;
            this.Location = new Point(x, y);
            this.BringToFront();
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            
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
