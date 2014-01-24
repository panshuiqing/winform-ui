using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Teleware.ZPG.Controls
{
    /// <summary>
    /// 一个Panel类，当设置背景图片时，控制其不会闪屏
    /// </summary>
    public class BackgroundPanel : Panel
    {
        
        public BackgroundPanel()
        {
            this.DoubleBuffered = true;//设置本窗体
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            return;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.BackgroundImage != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                e.Graphics.DrawImage(this.BackgroundImage, new System.Drawing.Rectangle(0, 0, this.Width, this.Height),
                0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height,
                System.Drawing.GraphicsUnit.Pixel);
            }
            base.OnPaint(e);
        }
    }
}
