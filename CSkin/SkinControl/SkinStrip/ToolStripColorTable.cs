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
 * * 说明：ToolStripColorTable.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CCWin.SkinClass;

namespace CCWin.SkinControl
{
    public class ToolStripColorTable
    {
        private Color _base = Color.FromArgb(105, 200, 254);
        private Color _itemborder = Color.FromArgb(60, 148, 212);
        private Color _back = Color.White;
        private Color _itemHover = Color.FromArgb(60, 148, 212);
        private Color _itemPressed = Color.FromArgb(60, 148, 212);
        private Color _fore = Color.Black;
        private Color _dropDownImageSeparator = Color.FromArgb(197, 197, 197);
        private RoundStyle _radiusstyle = RoundStyle.All;
        private int _backradius = 4;
        private Color _titleColor = Color.FromArgb(209, 228, 236);
        private bool _titleAnamorphosis = true;
        private int _titleRadius = 4;
        private RoundStyle _titleRadiusStyle = RoundStyle.All;
        private RoundStyle _itemRadiusStyle = RoundStyle.All;
        private int _itemRadius = 4;
        private bool _itemAnamorphosis = true;
        private bool _itemBorderShow = true;
        private Color _hoverFore = Color.White;
        private Color _arrow = Color.Black;
        private Color _baseFore = Color.Black;
        private Color _baseHoverFore = Color.White;
        private RoundStyle _baseItemRadiusStyle = RoundStyle.All;
        private int _baseItemRadius = 4;
        private bool _baseItemBorderShow = true;
        private bool _baseItemAnamorphosis = true;
        private Color _baseItemBorder = Color.FromArgb(60, 148, 212);
        private Color _baseItemHover = Color.FromArgb(60, 148, 212);
        private Color _baseItemPressed = Color.FromArgb(60, 148, 212);
        private Color _baseItemSplitter = Color.FromArgb(60, 148, 212);
        private bool _baseForeAnamorphosis = false;
        private int _baseForeAnamorphosisBorder = 4;
        private Color _baseForeAnamorphosisColor = Color.White;
        private Image _baseItemMouse = Properties.Resources.allbtn_highlight;
        private Image _baseItemDown = Properties.Resources.allbtn_down;
        private Rectangle _backrectangle = new Rectangle(10, 10, 10, 10);
        private Point _baseForeOffset = new Point(0,0);
        private bool _skinAllColor = true;

        public ToolStripColorTable() { }

        public bool SkinAllColor {
            get { return _skinAllColor; }
            set { _skinAllColor = value; }
        }

        public Rectangle BackRectangle
        {
            get { return _backrectangle; }
            set
            { _backrectangle = value; }
        }

        public Image BaseItemMouse
        {
            get { return _baseItemMouse; }
            set { _baseItemMouse = value; }
        }

        public Image BaseItemDown
        {
            get { return _baseItemDown; }
            set { _baseItemDown = value; }
        }

        public Point BaseForeOffset
        {
            get { return _baseForeOffset; }
            set { _baseForeOffset = value; }
        }

        public bool BaseForeAnamorphosis
        {
            get { return _baseForeAnamorphosis; }
            set { _baseForeAnamorphosis = value; }
        }

        public int BaseForeAnamorphosisBorder
        {
            get { return _baseForeAnamorphosisBorder; }
            set { _baseForeAnamorphosisBorder = value; }
        }

        public Color BaseForeAnamorphosisColor
        {
            get { return _baseForeAnamorphosisColor; }
            set { _baseForeAnamorphosisColor = value; }
        }

        public Color BaseFore
        {
            get { return _baseFore; }
            set { _baseFore = value; }
        }

        public Color BaseItemPressed
        {
            get { return _baseItemPressed; }
            set { _baseItemPressed = value; }
        }

        public Color BaseItemSplitter
        {
            get { return _baseItemSplitter; }
            set { _baseItemSplitter = value; }
        }

        public Color BaseItemBorder
        {
            get { return _baseItemBorder; }
            set { _baseItemBorder = value; }
        }

        public Color BaseItemHover
        {
            get { return _baseItemHover; }
            set { _baseItemHover = value; }
        }

        public int BaseItemRadius
        {
            get { return _baseItemRadius; }
            set { _baseItemRadius = value; }
        }

        public RoundStyle BaseItemRadiusStyle
        {
            get { return _baseItemRadiusStyle; }
            set { _baseItemRadiusStyle = value; }
        }

        public bool BaseItemBorderShow
        {
            get { return _baseItemBorderShow; }
            set { _baseItemBorderShow = value; }
        }

        public bool BaseItemAnamorphosis
        {
            get { return _baseItemAnamorphosis; }
            set { _baseItemAnamorphosis = value; }
        }

        public Color BaseHoverFore
        {
            get { return _baseHoverFore; }
            set { _baseHoverFore = value; }
        }

        public Color TitleColor
        {
            get { return _titleColor; }
            set { _titleColor = value; }
        }

        public Color Arrow
        {
            get { return _arrow; }
            set { _arrow = value; }
        }

        public bool TitleAnamorphosis
        {
            get { return _titleAnamorphosis; }
            set { _titleAnamorphosis = value; }
        }

        public int TitleRadius
        {
            get { return _titleRadius; }
            set { _titleRadius = value; }
        }

        public RoundStyle TitleRadiusStyle
        {
            get { return _titleRadiusStyle; }
            set { _titleRadiusStyle = value; }
        }

        public int BackRadius
        {
            get { return _backradius; }
            set { _backradius = value; }
        }

        public RoundStyle RadiusStyle
        {
            get { return _radiusstyle; }
            set { _radiusstyle = value; }
        }

        public Color Base
        {
            get { return _base; }
            set { _base = value; }
        }

        public Color ItemBorder
        {
            get { return _itemborder; }
            set { _itemborder = value; }
        }

        public bool ItemBorderShow
        {
            get { return _itemBorderShow; }
            set { _itemBorderShow = value; }
        }

        public Color Back
        {
            get { return _back; }
            set { _back = value; }
        }

        public Color ItemHover
        {
            get { return _itemHover; }
            set { _itemHover = value; }
        }

        public Color ItemPressed
        {
            get { return _itemPressed; }
            set { _itemPressed = value; }
        }

        public RoundStyle ItemRadiusStyle
        {
            get { return _itemRadiusStyle; }
            set { _itemRadiusStyle = value; }
        }

        public int ItemRadius
        {
            get { return _itemRadius; }
            set { _itemRadius = value; }
        }

        public bool ItemAnamorphosis
        {
            get { return _itemAnamorphosis; }
            set { _itemAnamorphosis = value; }
        }

        public Color Fore
        {
            get { return _fore; }
            set { _fore = value; }
        }

        public Color HoverFore
        {
            get { return _hoverFore; }
            set { _hoverFore = value; }
        }

        public Color DropDownImageSeparator
        {
            get { return _dropDownImageSeparator; }
            set { _dropDownImageSeparator = value; }
        }
    }
}
