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
 * * 说明：ProgressIndicator.cs
 * *
********************************************************************/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;

namespace CCWin.SkinControl
{
    /// <summary>
    /// 圆形进度条
    /// </summary>
    public partial class ProgressIndicator : Control
    {
        #region 无参构造
        /// <summary>
        /// 无参构造
        /// </summary>
        public ProgressIndicator()
        {
            this.Font = CCWin.Localization.Localizer.DefaultFont;
            InitializeComponent();
            //减少闪烁
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            //启动计时器
            if (AutoStart)
                timerAnimation.Start();
        }
        #endregion

        #region 变量
        private int _value = 1;
        private int _interval = 100;
        private Color _circleColor = Color.FromArgb(20, 20, 20);
        private bool _autoStart;
        private bool _stopped = true;
        private float _circleSize = 1.0F;
        private int _numberOfCircles = 8;
        private int _numberOfVisibleCircles = 8;
        private RotationType _rotation = RotationType.Clockwise;
        private float _percentage;
        private bool _showPercentage;
        private bool _showText;
        private TextDisplayModes _textDisplay = TextDisplayModes.None;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置圆形进度条的颜色
        /// </summary>
        [DefaultValue(typeof(Color), "20, 20, 20")]
        [Description("获取或设置圆形进度条的颜色")]
        [Category("Skin")]
        public Color CircleColor
        {
            get { return _circleColor; }
            set
            {
                _circleColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 获取或设置一个值，指示是否应自动启动动画
        /// </summary>
        [DefaultValue(false)]
        [Description("获取或设置一个值，指示是否应自动启动动画。")]
        [Category("Skin")]
        public bool AutoStart
        {
            get { return _autoStart; }
            set
            {
                _autoStart = value;

                if (_autoStart && !DesignMode)
                    Start();
                else 
                    Stop();
            }
        }

        /// <summary>
        /// 获取或设置小圆形的大小，从0.1到1。
        /// </summary>
        [DefaultValue(1.0F)]
        [Description("获取或设置小圆形的大小，从0.1到1。")]
        [Category("Skin")]
        public float CircleSize
        {
            get { return _circleSize; }
            set
            {
                if (value <= 0.0F)
                    _circleSize = 0.1F;
                else 
                    _circleSize = value > 1.0F ? 1.0F : value;

                Invalidate();
            }
        }

        /// <summary>
        /// 获取或设置动画速度。
        /// </summary>
        [DefaultValue(75)]
        [Description("获取或设置动画速度。")]
        [Category("Skin")]
        public int AnimationSpeed
        {
            get { return (-_interval + 400) / 4; }
            set
            {
                checked
                {
                    int interval = 400 - (value * 4);

                    if (interval < 10)
                        _interval = 10;
                    else
                        _interval = interval > 400 ? 400 : interval;

                    timerAnimation.Interval = _interval;
                }
            }
        }

        /// <summary>
        /// 获取或设置用于在动画圈里的速率圈数。
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><c>NumberOfCircles</c> is out of range.</exception>
        [DefaultValue(8)]
        [Description("获取或设置用于在动画圈里的速率圈数。")]
        [Category("Skin")]
        public int NumberOfCircles
        {
            get { return _numberOfCircles; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value", "圈数必须是一个正整数。");

                _numberOfCircles = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 获取或设置用于在动画圈的残影数量。
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><c>NumberOfCircles</c> is out of range.</exception>
        [DefaultValue(8)]
        [Description("获取或设置用于在动画圈的残影数量。")]
        [Category("Skin")]
        public int NumberOfVisibleCircles
        {
            get { return _numberOfVisibleCircles; }
            set
            {
                if (value <= 0 || value > _numberOfCircles)
                    throw new ArgumentOutOfRangeException("value", "圈数必须是一个正整数，且小于或等于圆的数目。");

                _numberOfVisibleCircles = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 获取或设置一个值，指示是否应顺时针或逆时针旋转。
        /// </summary>
        [DefaultValue(RotationType.Clockwise)]
        [Description("获取或设置一个值，指示是否应顺时针或逆时针旋转。")]
        [Category("Skin")]
        public RotationType Rotation 
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        /// <summary>
        /// 获取或设置百分比值。
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><c>Percentage</c> is out of range.</exception>
        [DefaultValue(0)]
        [Description("获取或设置百分比值。")]
        [Category("Skin")]
        public float Percentage
        {
            get { return _percentage; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("value", "Percentage must be a positive integer between 0 and 100.");

                _percentage = value;
            }
        }

        /// <summary>
        /// 获取或设置一个值，指示是否应显示百分比值。
        /// </summary>
        [DefaultValue(false)]
        [Description("获取或设置一个值，指示是否应显示百分比值。")]
        [Category("Skin")]
        public bool ShowPercentage
        {
            get { return _showPercentage; }
            set
            {
                _showPercentage = value;

                _textDisplay = _showPercentage
                                   ? _textDisplay | TextDisplayModes.Percentage
                                   : _textDisplay & ~TextDisplayModes.Percentage;
                Invalidate();
            }
        }

        /// <summary>
        /// 获取或设置一个值，指示是否控制要显示的文字。
        /// </summary>
        [DefaultValue(false)]
        [Description("获取或设置一个值，指示是否控制要显示的文字。")]
        [Category("Skin")]
        public bool ShowText
        {
            get { return _showText; }
            set
            {
                _showText = value;

                _textDisplay = _showText
                                   ? _textDisplay | TextDisplayModes.Text
                                   : _textDisplay & ~TextDisplayModes.Text;
                Invalidate();
            }
        }

        /// <summary>
        /// 获取或设置将在控件显示的文本显示模式。
        /// </summary>
        [DefaultValue(TextDisplayModes.None)]
        [Description("获取或设置将在控件显示的文本显示模式。")]
        [Category("Skin")]
        public TextDisplayModes TextDisplay
        {
            get { return _textDisplay; }
            set
            {
                _textDisplay = value;

                _showText = (_textDisplay & TextDisplayModes.Text) == TextDisplayModes.Text;
                _showPercentage = (_textDisplay & TextDisplayModes.Percentage) == TextDisplayModes.Percentage;
                Invalidate();
            }
        }

        #endregion

        #region 开始暂停方法

        /// <summary>
        /// Starts the animation.
        /// </summary>
        public void Start()
        {
            timerAnimation.Interval = _interval;
            _stopped = false;
            timerAnimation.Start();
        }

        /// <summary>
        /// Stops the animation.
        /// </summary>
        public void Stop()
        {
            timerAnimation.Stop();
            _value = 1;
            _stopped = true;
            Invalidate();
        }

        #endregion

        #region 重载事件

        protected override void OnPaint(PaintEventArgs e)
        {
            float angle = 360.0F / _numberOfCircles;

            GraphicsState oldState = e.Graphics.Save();

            e.Graphics.TranslateTransform(Width / 2.0F, Height / 2.0F);
            e.Graphics.RotateTransform(angle * _value * (int)_rotation);
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            for (int i = 1; i <= _numberOfCircles; i++)
            {
                int alphaValue = (255.0F * (i / (float)_numberOfVisibleCircles)) > 255.0 ? 0 : (int)(255.0F * (i / (float)_numberOfVisibleCircles));
                int alpha = _stopped ? (int)(255.0F * (1.0F / 8.0F)) : alphaValue;

                Color drawColor = Color.FromArgb(alpha, _circleColor);

                using (SolidBrush brush = new SolidBrush(drawColor))
                {
                    float sizeRate = 4.5F / _circleSize;
                    float size = Width / sizeRate;

                    float diff = (Width / 4.5F) - size;

                    float x = (Width / 9.0F) + diff;
                    float y = (Height / 9.0F) + diff;
                    e.Graphics.FillEllipse(brush, x, y, size, size);
                    e.Graphics.RotateTransform(angle * (int)_rotation);
                }
            }

            e.Graphics.Restore(oldState);

            string percent = GetDrawText();

            if (!string.IsNullOrEmpty(percent))
            {
                SizeF textSize = e.Graphics.MeasureString(percent, Font);
                float textX = (Width / 2.0F) - (textSize.Width / 2.0F);
                float textY = (Height / 2.0F) - (textSize.Height / 2.0F);
                StringFormat format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                RectangleF rectangle = new RectangleF(textX, textY, textSize.Width, textSize.Height);
                    

                using (SolidBrush textBrush = new SolidBrush(ForeColor))
                {
                    e.Graphics.DrawString(percent, Font, textBrush, rectangle, format);
                } 
            }

            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            SetNewSize();
            base.OnResize(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            SetNewSize();
            base.OnSizeChanged(e);
        }

        #endregion

        #region 私有方法

        private string GetDrawText()
        {
            string percent = string.Format(CultureInfo.CurrentCulture, "{0:0.##} %", _percentage);

            if (_showText && _showPercentage)
                return string.Format("{0}{1}{2}", percent, Environment.NewLine, Text);

            if (_showText)
                return Text;

            if (_showPercentage)
                return percent;

            return string.Empty;
        }

        private void SetNewSize()
        {
            int size = Math.Max(Width, Height);
            Size = new Size(size, size);
        }

        private void IncreaseValue()
        {
            if (_value + 1 <= _numberOfCircles)
                _value++;
            else
                _value = 1;
        }

        #endregion

        #region 计时器事件

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                IncreaseValue();
                Invalidate();
            }
        }

        #endregion
    }
}
