using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using CCWin;

namespace Teleware.ZPG.Client.Controls
{
    [ToolboxBitmap(typeof(ToolTip))]
    public class ToolTipEx : ToolTip
    {
        private int textOffset = 4;
        private Image image;
        private string caption;
        private TextFormatFlags TEXT_FLAGS = TextFormatFlags.HidePrefix | TextFormatFlags.ExternalLeading | TextFormatFlags.WordBreak | TextFormatFlags.EndEllipsis;

        public ToolTipEx()
        {
            base.OwnerDraw = true;
            base.ReshowDelay = 800;
            base.InitialDelay = 500;
            this.Font = new Font(CCWin.Localization.Localizer.DefaultFont, FontStyle.Regular);
            this.image = Properties.Resources.store_guide_bkg;
            base.Draw += new DrawToolTipEventHandler(ToolTipEx_Draw);
            base.Popup += new PopupEventHandler(ToolTipEx_Popup);
        }

        public new void SetToolTip(Control control, string caption)
        {
            this.caption = caption;
            base.SetToolTip(control, caption);
        }

        public Font Font
        {
            get;
            set;
        }

        private Size GetTextSize()
        {
            if (string.IsNullOrEmpty(this.caption)) return Size.Empty;
            Size textSize = TextRenderer.MeasureText(this.caption, this.Font, new Size(int.MaxValue, int.MaxValue), TEXT_FLAGS);
            return textSize;
        }

        void ToolTipEx_Popup(object sender, PopupEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.caption))
            {
                var textSize = GetTextSize();
                int width = textSize.Width + 2 * textOffset;
                int height = textSize.Height + 2 * textOffset;
                if (this.image != null)
                {
                    width = Math.Max(width, this.image.Width);
                    height = Math.Max(height, this.image.Height);
                }
                e.ToolTipSize = new Size(width, height);
                
            }
        }

        void ToolTipEx_Draw(object sender, DrawToolTipEventArgs e)
        {
            if (this.image != null)
            {
                ImageDrawRect.DrawRect(e.Graphics, (Bitmap)this.image, e.Bounds, Rectangle.FromLTRB(10, 15, 100, 15), 1, 1);
            }
            if (!string.IsNullOrEmpty(e.ToolTipText))
            {
                var tipRect = new Rectangle(
                    e.Bounds.X + textOffset,
                    e.Bounds.Y + textOffset,
                    e.Bounds.Width - textOffset * 2,
                    e.Bounds.Height - textOffset * 2);

                TextRenderer.DrawText(e.Graphics, e.ToolTipText, this.Font, tipRect, this.ForeColor, TEXT_FLAGS);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (this.image != null)
                {
                    this.image.Dispose();
                    this.image = null;
                }
            }
        }
    }
}
