using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Teleware.ZPG.Client.Controls
{
    public class PanelEx : Panel
    {

        /// <summary>
        /// 背景图片九宫格绘制区域
        /// </summary>
        [Category("Skin")]
        [Description("背景图片九宫格绘制区域")]
        public Rectangle BackgroundImageRectangle
        {
            get;
            set;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //不绘制背景
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // 设置显示的效果质量属性
            e.Graphics.TextRenderingHint =
                System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            e.Graphics.PixelOffsetMode =
                System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            OnDraw(e.Graphics);
            base.OnPaint(e);
        }

        protected virtual void OnDraw(Graphics g)
        {
            if (this.BackgroundImage != null)
            {
                if (this.BackgroundImageRectangle == Rectangle.Empty)
                {
                    int width = this.BackgroundImage.Size.Width;
                    int height = this.BackgroundImage.Size.Height;
                    Rectangle big = new Rectangle(0, 0, width, height);
                    g.DrawImage(this.BackgroundImage, big);
                }
                else
                {
                    CCWin.SkinClass.ImageDrawRect.DrawRect(g, (Bitmap)this.BackgroundImage, this.ClientRectangle,
                        Rectangle.FromLTRB(this.BackgroundImageRectangle.X,
                        this.BackgroundImageRectangle.Y,
                        this.BackgroundImageRectangle.Width,
                        this.BackgroundImageRectangle.Height), 1, 1);
                }
            }
        }
    }
}
