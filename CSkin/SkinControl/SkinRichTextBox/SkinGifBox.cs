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
 * * 说明：SkinGifBox.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CCWin.SkinControl
{
    partial class SkinGifBox : Control
    {
        #region 变量

        private Image _image;
        private Rectangle _imageRectangle;
        private EventHandler _eventAnimator;
        private bool _canAnimate;
        private Color _borderColor = Color.Transparent;

        #endregion

        #region 构造函数

        public SkinGifBox()
            : base()
        {
            this.Font = CCWin.Localization.Localizer.DefaultFont;
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.CacheText |
                ControlStyles.ResizeRedraw, true);

            SetStyle(ControlStyles.Opaque, false);
        }

        #endregion

        #region 属性

        public Image Image
        {
            get { return _image; }
            set
            {
                StopAnimate();
                _image = value;
                _imageRectangle = Rectangle.Empty;
                if (value != null)
                    _canAnimate = ImageAnimator.CanAnimate(_image);
                else
                    _canAnimate = false;
                Size = Image.Size;
                Invalidate(ImageRectangle);
                if (!DesignMode)
                    StartAnimate();
            }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                base.Invalidate();
            }
        }

        private Rectangle ImageRectangle
        {
            get
            {
                if (_imageRectangle == Rectangle.Empty &&
                    _image != null)
                {
                    _imageRectangle.X = (Width - _image.Width) / 2;
                    _imageRectangle.Y = (Height - _image.Height) / 2;
                    _imageRectangle.Width = _image.Width;
                    _imageRectangle.Height = _image.Height;
                }
                return _imageRectangle;
            }
        }

        private bool CanAnimate
        {
            get { return _canAnimate; }
        }

        private EventHandler EventAnimator
        {
            get
            {
                if (_eventAnimator == null)
                    _eventAnimator = delegate(object sender, EventArgs e)
                    {
                        Invalidate(ImageRectangle);
                    };
                return _eventAnimator;
            }
        }

        #endregion

        #region Override

        protected override void OnSizeChanged(EventArgs e)
        {
            _imageRectangle = Rectangle.Empty;
            base.OnSizeChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            if (_image != null)
            {
                //每次画之前更新到图片的下一帧。
                UpdateImage();
                e.Graphics.DrawImage(
                    _image,
                    ImageRectangle,
                    0,
                    0,
                    _image.Width,
                    _image.Height,
                    GraphicsUnit.Pixel);
            }

            ControlPaint.DrawBorder(
                    e.Graphics,
                    ClientRectangle,
                    _borderColor,
                    ButtonBorderStyle.Solid);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _eventAnimator = null;
                _canAnimate = false;
                if (_image != null)
                    _image = null;
            }

        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            StopAnimate();
        }

        #endregion

        #region Private Method

        private void StartAnimate()
        {
            if (CanAnimate)
            {
                ImageAnimator.Animate(_image, EventAnimator);
            }
        }

        private void StopAnimate()
        {
            if (CanAnimate)
            {
                ImageAnimator.StopAnimate(_image, EventAnimator);
            }
        }

        private void UpdateImage()
        {
            if (CanAnimate)
            {
                ImageAnimator.UpdateFrames(_image);
            }
        }

        #endregion
    }
}
