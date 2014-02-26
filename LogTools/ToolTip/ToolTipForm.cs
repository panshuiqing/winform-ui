using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin.SkinControl;

namespace LogTools
{
    public partial class ToolTipForm : SkinForm
    {
        private string tooltipText;
        private int SPACING = 2;
        private Size MIN_SIZE = new Size(121, 45);
        private Size MAX_SIZE = new Size(400, 160);
        private Rectangle textRect = Rectangle.Empty;
        private TextFormatFlags TEXT_FLAGS =
                    TextFormatFlags.HidePrefix | TextFormatFlags.ExternalLeading |
                    TextFormatFlags.WordBreak | TextFormatFlags.EndEllipsis;
        //背景图三角左边宽度
        private const int offsetX = 50;

        public ToolTipForm()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
        }

        public void Show(string text, Control control)
        {
            if (control == null) throw new ArgumentNullException("control");
            this.tooltipText = text;
            this.CalcFinalSizes();
            this.SetLabel();
            var point = control.FindForm().PointToScreen(control.Location);
            int x = point.X - offsetX;
            int y = point.Y - this.Height;
            this.Location = new Point(x, y);
            this.Show(control);
            control.Focus();
            control.LostFocus += new EventHandler(control_LostFocus);
        }

        private void SetLabel()
        {
            this.skinLabel1.ArtTextStyle = ArtTextStyle.None;
            this.skinLabel1.AutoSize = false;
            this.skinLabel1.TextAlign = ContentAlignment.MiddleCenter;
            this.skinLabel1.Text = this.tooltipText;
            this.skinLabel1.Location = new Point(this.textRect.X, this.textRect.Y);
            this.skinLabel1.Size = new Size(this.textRect.Width, this.textRect.Height);
        }
        
        void control_LostFocus(object sender, EventArgs e)
        {
            this.Close();
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
            if (string.IsNullOrEmpty(this.tooltipText)) return Size.Empty;
            Size textSize = TextRenderer.MeasureText(this.tooltipText, this.skinLabel1.Font, new Size(int.MaxValue, int.MaxValue), TEXT_FLAGS);
            return textSize;
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
