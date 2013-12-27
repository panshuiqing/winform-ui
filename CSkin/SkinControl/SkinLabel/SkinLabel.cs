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
 * * 说明：SkinLabel.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using CCWin.SkinClass;

namespace CCWin.SkinControl
{
    [ToolboxBitmap(typeof(Label))]
    public class SkinLabel : Label
    {
        #region 变量
        private ArtTextStyle _artTextStyle = ArtTextStyle.Border;
        private int _borderSize = 1;
        private Color _borderColor = Color.White;
        #endregion

        #region 无参构造
        public SkinLabel()
            : base()
        {
            this.Font = CCWin.Localization.Localizer.DefaultFont;
            SetStyles();
            this.Font = CCWin.Localization.Localizer.DefaultFont;
        }
        #endregion

        #region 属性
        private bool foreColorSuit = false;
        [DefaultValue(false)]
        [Category("Skin")]
        [Description("是否根据所在容器背景色自动适应文本颜色。\n(背景色为暗色时文本显示白色，背景为亮色时文本显示黑色。)")]
        public bool ForeColorSuit
        {
            get { return foreColorSuit; }
            set
            {
                if (foreColorSuit != value)
                {
                    foreColorSuit = value;
                    base.Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Skin")]
        [DefaultValue(typeof(ArtTextStyle), "1")]
        [Description("字体样式（None:正常样式,Border:边框样式,Relievo:浮雕样式,Forme:印版样式,Anamorphosis:渐变样式）")]
        public ArtTextStyle ArtTextStyle
        {
            get { return _artTextStyle; }
            set
            {
                if (_artTextStyle != value)
                {
                    _artTextStyle = value;
                    base.Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Skin")]
        [DefaultValue(1)]
        [Description("样式效果宽度")]
        public int BorderSize
        {
            get { return _borderSize; }
            set
            {
                if (_borderSize != value)
                {
                    _borderSize = value;
                    base.Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Skin")]
        [DefaultValue(typeof(Color), "80, 0, 0, 0")]
        [Description("样式效果颜色")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                if (_borderColor != value)
                {
                    _borderColor = value;
                    base.Invalidate();
                }
            }
        }

        #endregion

        #region 重载事件
        protected override void OnParentBackColorChanged(EventArgs e)
        {
            base.OnParentBackColorChanged(e);
            if (ArtTextStyle != ArtTextStyle.None)
            {
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (ArtTextStyle == ArtTextStyle.None)
            {
                base.OnPaint(e);
                return;
            }
            if (base.Text.Length == 0)
            {
                return;
            }
            //绘画文字
            RenderText(e.Graphics);
        }
        #endregion

        #region 根据范围宽度截取字符串(SetStrLeng)
        //根据范围宽度截取字符串
        public string SetStrLeng(string txt, Font font, int width)
        {
            Size sizef = TextRenderer.MeasureText(txt, font);
            while (sizef.Width > width && txt.Length != 0)
            {
                txt = txt.Substring(0, txt.Length - 1);
                sizef = TextRenderer.MeasureText(txt, font);
            }
            return txt;
        }
        #endregion

        #region 绘画方法
        private void RenderText(Graphics g)
        {
            using (TextRenderingHintGraphics textRenderGraphics
                = new TextRenderingHintGraphics(g))
            {
                PointF point = CalculateRenderTextStartPoint(g);
                Color fc = ForeColor;
                Color bc = BorderColor;
                if (ForeColorSuit)
                {
                    bool Base = SkinTools.ColorSlantsDarkOrBright(this.Parent.BackColor);
                    if (Base)
                    {
                        fc = Color.White;
                        bc = Color.Black;
                    }
                    else
                    {
                        fc = Color.Black;
                        bc = Color.White;

                    }
                }
                switch (_artTextStyle)
                {
                    case ArtTextStyle.Border:
                        RenderBordText(g, point, fc, bc);
                        break;
                    case ArtTextStyle.Relievo:
                        RenderRelievoText(g, point, fc, bc);
                        break;
                    case ArtTextStyle.Forme:
                        RenderFormeText(g, point, fc, bc);
                        break;
                    case ArtTextStyle.Anamorphosis:
                        RenderAnamorphosisText(g, point, fc, bc);
                        break;
                }
            }
        }

        private void RenderAnamorphosisText(Graphics g, PointF point, Color fc, Color bc)
        {
            using (Brush brush = new SolidBrush(base.ForeColor))
            {
                Rectangle rc = new Rectangle(new Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y)), ClientRectangle.Size);
                Image img = SkinTools.ImageLightEffect(Text, base.Font, fc, bc, BorderSize, rc, !AutoSize);
                g.DrawImage(img, point.X - (BorderSize / 2), point.Y - (BorderSize / 2));
            }
        }


        private void RenderFormeText(Graphics g, PointF point, Color fc, Color bc)
        {
            StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);
            sf.Trimming = AutoSize ? StringTrimming.None : StringTrimming.EllipsisWord;
            Rectangle rc = new Rectangle(new Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y)), ClientRectangle.Size);

            using (Brush brush = new SolidBrush(bc))
            {
                for (int i = 1; i <= _borderSize; i++)
                {
                    g.DrawString(
                        Text,
                        base.Font,
                        brush,
                        new Rectangle(new Point(
                            Convert.ToInt32(point.X - i),
                            Convert.ToInt32(point.Y + i)),
                            ClientRectangle.Size),
                        sf);
                }
            }

            using (Brush brush = new SolidBrush(fc))
            {
                g.DrawString(Text, Font, brush, rc, sf);
            }
        }

        private void RenderRelievoText(Graphics g, PointF point, Color fc, Color bc)
        {
            StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);
            sf.Trimming = AutoSize ? StringTrimming.None : StringTrimming.EllipsisWord;
            Rectangle rc = new Rectangle(new Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y)), ClientRectangle.Size);
            using (Brush brush = new SolidBrush(bc))
            {
                for (int i = 1; i <= _borderSize; i++)
                {
                    g.DrawString(
                        Text,
                        base.Font,
                        brush,
                        new Rectangle(new Point(
                            Convert.ToInt32(point.X + i),
                            Convert.ToInt32(point.Y)),
                            ClientRectangle.Size),
                        sf);
                    g.DrawString(
                        Text,
                        base.Font,
                        brush,
                        new Rectangle(new Point(
                            Convert.ToInt32(point.X),
                            Convert.ToInt32(point.Y + i)),
                            ClientRectangle.Size),
                        sf);
                }
            }

            using (Brush brush = new SolidBrush(fc))
            {
                g.DrawString(
                    Text, base.Font, brush, rc, sf);
            }
        }

        private void RenderBordText(Graphics g, PointF point, Color fc, Color bc)
        {
            StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);
            sf.Trimming = AutoSize ? StringTrimming.None : StringTrimming.EllipsisWord;
            Rectangle rc = new Rectangle(new Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y)), ClientRectangle.Size);
            using (Brush brush = new SolidBrush(bc))
            {
                for (int i = 1; i <= _borderSize; i++)
                {
                    g.DrawString(
                        Text,
                        base.Font,
                        brush,
                        new Rectangle(new Point(
                            Convert.ToInt32(point.X - i),
                            Convert.ToInt32(point.Y)),
                            ClientRectangle.Size),
                        sf);
                    g.DrawString(
                        Text,
                        base.Font,
                        brush,
                        new Rectangle(new Point(
                            Convert.ToInt32(point.X),
                            Convert.ToInt32(point.Y - i)),
                            ClientRectangle.Size),
                        sf);
                    g.DrawString(
                        Text,
                        base.Font,
                        brush,
                        new Rectangle(new Point(
                            Convert.ToInt32(point.X + i),
                            Convert.ToInt32(point.Y)),
                            ClientRectangle.Size),
                        sf);
                    g.DrawString(
                        Text,
                        base.Font,
                        brush,
                        new Rectangle(new Point(
                            Convert.ToInt32(point.X),
                            Convert.ToInt32(point.Y + i)),
                            ClientRectangle.Size),
                        sf);
                }
            }

            using (Brush brush = new SolidBrush(fc))
            {
                g.DrawString(
                    Text, base.Font, brush, rc, sf);
            }
        }

        private PointF CalculateRenderTextStartPoint(Graphics g)
        {
            PointF point = PointF.Empty;

            SizeF textSize = g.MeasureString(
                base.Text,
                base.Font,
                PointF.Empty,
                StringFormat.GenericTypographic);

            if (AutoSize)
            {
                point.X = Padding.Left;
                point.Y = Padding.Top;
            }
            else
            {
                ContentAlignment align = base.TextAlign;
                if (align == ContentAlignment.TopLeft ||
                    align == ContentAlignment.MiddleLeft ||
                    align == ContentAlignment.BottomLeft)
                {
                    point.X = Padding.Left;
                }

                else if (align == ContentAlignment.TopCenter ||
                         align == ContentAlignment.MiddleCenter ||
                         align == ContentAlignment.BottomCenter)
                {
                    point.X = (Width - textSize.Width) / 2f;
                }
                else
                {
                    point.X = Width - (Padding.Right + textSize.Width);
                }

                if (align == ContentAlignment.TopLeft ||
                    align == ContentAlignment.TopCenter ||
                    align == ContentAlignment.TopRight)
                {
                    point.Y = Padding.Top;
                }
                else if (align == ContentAlignment.MiddleLeft ||
                         align == ContentAlignment.MiddleCenter ||
                         align == ContentAlignment.MiddleRight)
                {
                    point.Y = (Height - textSize.Height) / 2f;
                }
                else
                {
                    point.Y = Height - (Padding.Bottom + textSize.Height);
                }
            }

            return point;
        }

        #endregion

        #region 减少闪烁方法
        private void SetStyles()
        {
            //设置自定义控件Style
            this.SetStyle(ControlStyles.ResizeRedraw, true);//调整大小时重绘
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);// 双缓冲
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);// 禁止擦除背景.
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            UpdateStyles();
        }
        #endregion
    }
}
