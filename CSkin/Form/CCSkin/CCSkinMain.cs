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
 * * 说明：CCSkinMain.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;
using CCWin.SkinClass;
using CCWin.Win32;
using CCWin.Win32.Const;
using CCWin.Win32.Struct;
using System.Reflection;
using System.Collections.Specialized;
using CCWin.SkinControl;
using System.ComponentModel.Design;

namespace CCWin
{
    public partial class CCSkinMain : Form
    {
        #region 变量
        //绘制层
        public CCSkinForm skin = null;
        private SkinFormRenderer _renderer;
        private RoundStyle _roundStyle = RoundStyle.All;
        private Rectangle _deltaRect;
        private int _radius = 6;
        private int _captionHeight = 24;
        private Font _captionFont = SystemFonts.CaptionFont;
        private Size _miniSize = new Size(32, 18);
        private Size _maxBoxSize = new Size(32, 18);
        private Size _closeBoxSize = new Size(32, 18);
        private Point _controlBoxOffset = new Point(6, 0);
        private int _controlBoxSpace = 0;
        private bool _active = false;
        private bool _showSystemMenu = false;
        private ControlBoxManager _controlBoxManager;
        private Padding _padding;
        private bool _canResize = true;
        private ToolTip _toolTip;
        private MobileStyle _mobile = MobileStyle.Mobile;
        private static readonly object EventRendererChanged = new object();
        private bool _clientSizeSet;
        private int _inWmWindowPosChanged;
        #endregion

        #region 无参构造函数
        public CCSkinMain()
            : base()
        {
            SetStyles();
            Init();
        }
        #endregion

        #region 属性
        private CustomSysButtonCollection sysButtonItems;
        /// <summary>
        /// 获取自定义系统按钮的集合
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("SysButton")]
        [Description("自定义系统按钮集合的项")]
        public CustomSysButtonCollection SysButtonItems
        {
            get
            {
                if (sysButtonItems == null)
                    sysButtonItems = new CustomSysButtonCollection(this);
                return sysButtonItems;
            }
        }

        private bool inheritBack = false;
        /// <summary>
        /// 是否继承所属窗体的背景
        /// </summary>
        [Category("Skin")]
        [DefaultValue(false)]
        [Description("是否继承所属窗体的背景")]
        public bool InheritBack
        {
            get { return inheritBack; }
            set { inheritBack = value; }
        }

        private Padding _borderPadding = new Padding(4);
        /// <summary>
        /// 获取或设置窗体的边框大小。
        /// </summary>
        internal protected Padding BorderPadding
        {
            get { return _borderPadding; }
            set { _borderPadding = value; }
        }

        private double skinOpacity = 1;
        /// <summary>
        /// 窗体渐变后透明度
        /// </summary>
        [Category("Skin")]
        [Description("窗体渐变后透明度")]
        public double SkinOpacity
        {
            get { return skinOpacity; }
            set
            {
                if (skinOpacity != value)
                {
                    skinOpacity = value;
                }
            }
        }

        private Image back;
        /// <summary>
        /// 背景
        /// </summary>
        [Category("Skin")]
        [Description("背景")]
        public Image Back
        {
            get { return back; }
            set
            {
                if (back != value)
                {
                    back = value;
                    if (BackToColor && back != null)
                    {
                        //渐变背景
                        BackColor = BitmapHelper.GetImageAverageColor((Bitmap)back);
                    }
                    this.Invalidate();
                    //引发事件
                    OnBackChanged(new BackEventArgs(back, value));
                }
            }
        }

        private bool backLayout = true;
        /// <summary>
        /// 是否从左绘制背景
        /// </summary>
        [Category("Skin")]
        [Description("是否从左绘制背景")]
        public bool BackLayout
        {
            get { return backLayout; }
            set
            {
                if (backLayout != value)
                {
                    backLayout = value;
                    this.Invalidate();
                }
            }
        }

        private Image backpalace;
        /// <summary>
        /// 质感层背景
        /// </summary>
        [Category("Skin")]
        [Description("质感层背景")]
        public Image BackPalace
        {
            get { return backpalace; }
            set
            {
                if (backpalace != value)
                {
                    backpalace = value;
                    this.Invalidate();
                }
            }
        }

        private Image borderpalace;
        /// <summary>
        /// 边框层背景
        /// </summary>
        [Category("Skin")]
        [Description("边框层背景")]
        public Image BorderPalace
        {
            get { return borderpalace; }
            set
            {
                if (borderpalace != value)
                {
                    borderpalace = value;
                    this.Invalidate();
                }
            }
        }

        private bool showborder = true;
        /// <summary>
        /// 是否在窗体上绘画边框
        /// </summary>
        [Category("Skin")]
        [DefaultValue(true)]
        [Description("是否在窗体上绘画边框")]
        public bool ShowBorder
        {
            get { return showborder; }
            set
            {
                if (showborder != value)
                {
                    showborder = value;
                    this.Invalidate();
                }
            }
        }

        private bool showdrawicon = true;
        /// <summary>
        /// 是否在窗体上绘画ICO图标
        /// </summary>
        [Category("窗口样式")]
        [DefaultValue(true)]
        [Description("是否在窗体上绘画ICO图标")]
        public bool ShowDrawIcon
        {
            get { return showdrawicon; }
            set
            {
                if (showdrawicon != value)
                {
                    showdrawicon = value;
                    this.Invalidate();
                }
            }
        }

        private bool special = true;
        /// <summary>
        /// 是否启用窗口淡入淡出
        /// </summary>
        [Category("Skin")]
        [DefaultValue(true)]
        [Description("是否启用窗口淡入淡出")]
        public bool Special
        {
            get { return special; }
            set
            {
                if (special != value)
                {
                    special = value;
                }
            }
        }

        private bool shadow = true;
        /// <summary>
        /// 是否启用窗体阴影
        /// </summary>
        [Category("Shadow")]
        [DefaultValue(true)]
        [Description("是否启用窗体阴影")]
        public bool Shadow
        {
            get { return shadow; }
            set
            {
                if (shadow != value)
                {
                    shadow = value;
                }
            }
        }

        private Color shadowColor = Color.Black;
        /// <summary>
        /// 窗体阴影颜色
        /// </summary>
        [Category("Shadow")]
        [DefaultValue(typeof(Color), "Black")]
        [Description("窗体阴影颜色")]
        public Color ShadowColor
        {
            get { return shadowColor; }
            set
            {
                if (shadowColor != value)
                {
                    shadowColor = value;
                    //更新阴影
                    if (skin != null)
                        skin.SetBits();
                }
            }
        }

        private int shadowWidth = 4;
        /// <summary>
        /// 窗体阴影宽度
        /// </summary>
        [Category("Shadow")]
        [DefaultValue(typeof(int), "4")]
        [Description("窗体阴影宽度")]
        public int ShadowWidth
        {
            get { return shadowWidth; }
            set
            {
                if (shadowWidth != value)
                {
                    shadowWidth = value < 1 ? 1 : value;
                    //更新阴影
                    if (skin != null)
                        skin.SetBits();
                }
            }
        }

        private Rectangle backrectangle = new Rectangle(10, 10, 10, 10);
        /// <summary>
        /// 质感层九宫绘画区域
        /// </summary>
        [Category("Skin")]
        [DefaultValue(typeof(Rectangle), "10,10,10,10")]
        [Description("质感层九宫绘画区域")]
        public Rectangle BackRectangle
        {
            get { return backrectangle; }
            set
            {
                if (backrectangle != value)
                {
                    backrectangle = value;
                    this.Invalidate();
                }
            }
        }


        private Rectangle borderrectangle = new Rectangle(10, 10, 10, 10);
        /// <summary>
        /// 边框质感层九宫绘画区域
        /// </summary>
        [Category("Skin")]
        [DefaultValue(typeof(Rectangle), "10,10,10,10")]
        [Description("边框质感层九宫绘画区域")]
        public Rectangle BorderRectangle
        {
            get { return borderrectangle; }
            set
            {
                if (borderrectangle != value)
                {
                    borderrectangle = value;
                    this.Invalidate();
                }
            }
        }

        //系统按钮激活时色调颜色
        [Category("Skin")]
        [DefaultValue(typeof(Color), "51, 153, 204")]
        [Description("系统按钮激活时色调颜色")]
        public Color ControlBoxActive
        {
            get { return Colortable.ControlBoxActive; }
            set
            {
                Colortable.ControlBoxActive = value;
                Renderer = new SkinFormProfessionalRenderer(Colortable);
            }
        }

        //系统按钮停用时色调颜色
        [Category("Skin")]
        [DefaultValue(typeof(Color), "88, 172, 218")]
        [Description("系统按钮停用时色调颜色")]
        public Color ControlBoxDeactive
        {
            get { return Colortable.ControlBoxDeactive; }
            set
            {
                Colortable.ControlBoxDeactive = value;
                Renderer = new SkinFormProfessionalRenderer(Colortable);
            }
        }

        private SkinFormColorTable _colorTable;
        public SkinFormColorTable Colortable
        {
            get
            {
                if (_colorTable == null)
                {
                    _colorTable = new SkinFormColorTable();
                }
                return _colorTable;
            }
            set { _colorTable = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("设置或获取窗体的绘制方法")]
        public SkinFormRenderer Renderer
        {
            get
            {

                if (_renderer == null)
                {
                    _renderer = new SkinFormProfessionalRenderer(Colortable);
                }
                return _renderer;
            }
            set
            {
                _renderer = value;
                OnRendererChanged(EventArgs.Empty);
            }
        }

        [Category("Caption")]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                base.Invalidate(new Rectangle(
                    0,
                    0,
                    Width,
                    CaptionHeight + 1));
            }
        }

        private bool backtocolor = true;
        [DefaultValue(true)]
        [Category("Skin")]
        [Description("是否根据背景图决定背景色")]
        public bool BackToColor
        {
            get { return backtocolor; }
            set
            {
                if (backtocolor != value)
                {
                    backtocolor = value;
                    base.Invalidate();
                }
            }
        }

        private bool backshade = true;
        [DefaultValue(true)]
        [Category("Skin")]
        [Description("是否加入背景渐变效果")]
        public bool BackShade
        {
            get { return backshade; }
            set
            {
                if (backshade != value)
                {
                    backshade = value;
                    base.Invalidate();
                }
            }
        }

        private TitleType effectcaption = TitleType.EffectTitle;
        [DefaultValue(TitleType.EffectTitle)]
        [Category("Caption")]
        [Description("获取或设置标题的绘制模式")]
        public TitleType EffectCaption
        {
            get { return effectcaption; }
            set
            {
                if (effectcaption != value)
                {
                    effectcaption = value;
                    base.Invalidate();
                }
            }
        }

        private bool titleSuitColor = false;
        [DefaultValue(false)]
        [Category("Caption")]
        [Description("是否根据背景色自动适应标题颜色。\n(背景色为暗色时标题显示白色，背景为亮色时标题显示黑色。)")]
        public bool TitleSuitColor
        {
            get { return titleSuitColor; }
            set
            {
                if (titleSuitColor != value)
                {
                    titleSuitColor = value;
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Font), "CaptionFont")]
        [Category("Caption")]
        [Description("设置或获取窗体标题的字体")]
        public Font CaptionFont
        {
            get { return _captionFont; }
            set
            {
                if (value == null)
                {
                    _captionFont = SystemFonts.CaptionFont;
                }
                else
                {
                    _captionFont = value;
                }
                base.Invalidate(CaptionRect);
            }
        }

        private Color effectback = Color.White;
        /// <summary>
        /// 发光字体背景色
        /// </summary>
        [Category("Caption")]
        [DefaultValue(typeof(Color), "White")]
        [Description("发光字体背景色")]
        public Color EffectBack
        {
            get { return effectback; }
            set
            {
                if (effectback != value)
                {
                    effectback = value;
                    this.Invalidate();
                }
            }
        }

        private Color titleColor = Color.Black;
        /// <summary>
        /// 标题颜色
        /// </summary>
        [Category("Caption")]
        [DefaultValue(typeof(Color), "Black")]
        [Description("标题颜色")]
        public Color TitleColor
        {
            get { return titleColor; }
            set
            {
                if (titleColor != value)
                {
                    titleColor = value;
                    this.Invalidate();
                }
            }
        }

        private Point titleOffset = new Point(0, 0);
        /// <summary>
        /// 设置或获取标题的偏移
        /// </summary>
        [Category("Caption")]
        [DefaultValue(typeof(Point), "0,0")]
        [Description("设置或获取标题的偏移")]
        public Point TitleOffset
        {
            get { return titleOffset; }
            set
            {
                if (titleOffset != value)
                {
                    titleOffset = value;
                    this.Invalidate();
                }
            }
        }

        private int effectWidth = 6;
        /// <summary>
        /// 光圈大小
        /// </summary>
        [Category("Caption")]
        [DefaultValue(typeof(int), "6")]
        [Description("光圈大小")]
        public int EffectWidth
        {
            get { return effectWidth; }
            set
            {
                if (effectWidth != value)
                {
                    effectWidth = value;
                    this.Invalidate();
                }
            }
        }

        private bool dropback = true;
        [DefaultValue(true)]
        [Category("Skin")]
        [Description("指示控件是否可以将用户拖动到背景上的图片作为背景(注意:开启前请设置AllowDrop为true,否则无效)")]
        public bool DropBack
        {
            get { return dropback; }
            set
            {
                if (dropback != value)
                {
                    dropback = value;
                }
            }
        }

        [DefaultValue(typeof(RoundStyle), "1")]
        [Category("Skin")]
        [Description("设置或获取窗体的圆角样式")]
        public RoundStyle RoundStyle
        {
            get { return _roundStyle; }
            set
            {
                if (_roundStyle != value)
                {
                    _roundStyle = value;
                    SetReion();
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(MobileStyle), "2")]
        [Category("Skin")]
        [Description("移动窗体的条件")]
        public MobileStyle Mobile
        {
            get { return _mobile; }
            set
            {
                if (_mobile != value)
                {
                    _mobile = value;
                }
            }
        }

        [DefaultValue(6)]
        [Category("Skin")]
        [Description("设置或获取窗体的圆角的大小")]
        public int Radius
        {
            get { return _radius; }
            set
            {
                if (_radius != value)
                {
                    _radius = value < 1 ? 1 : value;
                    SetReion();
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(24)]
        [Category("Skin")]
        [Description("设置或获取窗体标题栏的高度")]
        public int CaptionHeight
        {
            get { return _captionHeight; }
            set
            {
                if (_captionHeight != value)
                {
                    _captionHeight = value < BorderPadding.Left ?
                                    BorderPadding.Left : value;
                    base.Invalidate();
                }
            }
        }

        [Category("MinimizeBox")]
        [DefaultValue(typeof(Size), "32, 18")]
        [Description("设置或获取最小化按钮的大小")]
        public Size MiniSize
        {
            get { return _miniSize; }
            set
            {
                if (_miniSize != value)
                {
                    _miniSize = value;
                    base.Invalidate();
                }
            }
        }

        private Image minimouseback;
        /// <summary>
        /// 最小化按钮悬浮时
        /// </summary>
        [Category("MinimizeBox")]
        [Description("最小化按钮悬浮时背景")]
        public Image MiniMouseBack
        {
            get { return minimouseback; }
            set
            {
                if (minimouseback != value)
                {
                    minimouseback = value;
                    this.Invalidate();
                }
            }
        }

        private Image minidownback;
        /// <summary>
        /// 最小化按钮点击时
        /// </summary>
        [Category("MinimizeBox")]
        [Description("最小化按钮点击时背景")]
        public Image MiniDownBack
        {
            get { return minidownback; }
            set
            {
                if (minidownback != value)
                {
                    minidownback = value;
                    this.Invalidate();
                }
            }
        }

        private Image mininormlback;
        /// <summary>
        /// 最小化按钮初始时
        /// </summary>
        [Category("MinimizeBox")]
        [Description("最小化按钮初始时背景")]
        public Image MiniNormlBack
        {
            get { return mininormlback; }
            set
            {
                if (mininormlback != value)
                {
                    mininormlback = value;
                    this.Invalidate();
                }
            }
        }

        [Category("MaximizeBox")]
        [DefaultValue(typeof(Size), "32, 18")]
        [Description("设置或获取最大化（还原）按钮的大小")]
        public Size MaxSize
        {
            get { return _maxBoxSize; }
            set
            {
                if (_maxBoxSize != value)
                {
                    _maxBoxSize = value;
                    base.Invalidate();
                }
            }
        }

        private Image maxmouseback;
        /// <summary>
        /// 最大化按钮悬浮时背景
        /// </summary>
        [Category("MaximizeBox")]
        [Description("最大化按钮悬浮时背景")]
        public Image MaxMouseBack
        {
            get { return maxmouseback; }
            set
            {
                if (maxmouseback != value)
                {
                    maxmouseback = value;
                    this.Invalidate();
                }
            }
        }

        private Image maxdownback;
        /// <summary>
        /// 最大化按钮点击时背景
        /// </summary>
        [Category("MaximizeBox")]
        [Description("最大化按钮点击时背景")]
        public Image MaxDownBack
        {
            get { return maxdownback; }
            set
            {
                if (maxdownback != value)
                {
                    maxdownback = value;
                    this.Invalidate();
                }
            }
        }

        private Image maxnormlback;
        /// <summary>
        /// 最大化按钮初始时背景
        /// </summary>
        [Category("MaximizeBox")]
        [Description("最大化按钮初始时背景")]
        public Image MaxNormlBack
        {
            get { return maxnormlback; }
            set
            {
                if (maxnormlback != value)
                {
                    maxnormlback = value;
                    this.Invalidate();
                }
            }
        }

        private Image restoremouseback;
        /// <summary>
        /// 还原按钮悬浮时背景
        /// </summary>
        [Category("MaximizeBox")]
        [Description("还原按钮悬浮时背景")]
        public Image RestoreMouseBack
        {
            get { return restoremouseback; }
            set
            {
                if (restoremouseback != value)
                {
                    restoremouseback = value;
                    this.Invalidate();
                }
            }
        }

        private Image restoredownback;
        /// <summary>
        /// 还原按钮点击时背景
        /// </summary>
        [Category("MaximizeBox")]
        [Description("还原按钮点击时背景")]
        public Image RestoreDownBack
        {
            get { return restoredownback; }
            set
            {
                if (restoredownback != value)
                {
                    restoredownback = value;
                    this.Invalidate();
                }
            }
        }

        private Image restorenormlback;
        /// <summary>
        /// 还原按钮初始时背景
        /// </summary>
        [Category("MaximizeBox")]
        [Description("还原按钮初始时背景")]
        public Image RestoreNormlBack
        {
            get { return restorenormlback; }
            set
            {
                if (restorenormlback != value)
                {
                    restorenormlback = value;
                    this.Invalidate();
                }
            }
        }

        [Category("CloseBox")]
        [DefaultValue(typeof(Size), "32, 18")]
        [Description("设置或获取关闭按钮的大小")]
        public Size CloseBoxSize
        {
            get { return _closeBoxSize; }
            set
            {
                if (_closeBoxSize != value)
                {
                    _closeBoxSize = value;
                    base.Invalidate();
                }
            }
        }

        private Image closemouseback;
        /// <summary>
        /// 关闭按钮悬浮时背景
        /// </summary>
        [Category("CloseBox")]
        [Description("关闭按钮悬浮时背景")]
        public Image CloseMouseBack
        {
            get { return closemouseback; }
            set
            {
                if (closemouseback != value)
                {
                    closemouseback = value;
                    this.Invalidate();
                }
            }
        }

        private Image closedownback;
        /// <summary>
        /// 关闭按钮点击时背景
        /// </summary>
        [Category("CloseBox")]
        [Description("关闭按钮点击时背景")]
        public Image CloseDownBack
        {
            get { return closedownback; }
            set
            {
                if (closedownback != value)
                {
                    closedownback = value;
                    this.Invalidate();
                }
            }
        }

        private Image closenormlback;
        /// <summary>
        /// 关闭按钮初始时背景
        /// </summary>
        [Category("CloseBox")]
        [Description("关闭按钮初始时背景")]
        public Image CloseNormlBack
        {
            get { return closenormlback; }
            set
            {
                if (closenormlback != value)
                {
                    closenormlback = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// 获取或设置窗体是否显示系统菜单。
        /// </summary>
        [DefaultValue(false)]
        [Category("Skin")]
        [Description("获取或设置窗体是否显示系统菜单")]
        public bool ShowSystemMenu
        {
            get { return _showSystemMenu; }
            set { _showSystemMenu = value; }
        }

        [DefaultValue(typeof(Point), "6, 0")]
        [Category("Skin")]
        [Description("设置或获取控制按钮的偏移")]
        public Point ControlBoxOffset
        {
            get { return _controlBoxOffset; }
            set
            {
                if (_controlBoxOffset != value)
                {
                    _controlBoxOffset = value;
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(0)]
        [Category("Skin")]
        [Description("设置或获取控制按钮的间距")]
        public int ControlBoxSpace
        {
            get { return _controlBoxSpace; }
            set
            {
                if (_controlBoxSpace != value)
                {
                    _controlBoxSpace = value;
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(true)]
        [Category("Skin")]
        [Description("设置或获取窗体是否可以改变大小")]
        public bool CanResize
        {
            get { return _canResize; }
            set { _canResize = value; }
        }
        [DefaultValue("关闭")]
        [Category("Skin")]
        [Description("关闭按钮鼠标提示文本")]
        public string CloseButtonToolTip
        {
            get;
            set;
        }
        [DefaultValue("最小化")]
        [Category("Skin")]
        [Description("最小化按钮鼠标提示文本")]
        public string MinButtonToolTip
        {
            get;
            set;
        }
        [DefaultValue("最大化")]
        [Category("Skin")]
        [Description("最大化按钮鼠标提示文本")]
        public string MaxButtonToolTip
        {
            get;
            set;
        }
        [DefaultValue("还原")]
        [Category("Skin")]
        [Description("还原按钮鼠标提示文本")]
        public string RestoreButtonToolTip
        {
            get;
            set;
        }

        [DefaultValue(typeof(Padding), "0")]
        public new Padding Padding
        {
            get { return _padding; }
            set
            {
                _padding = value;
                base.Padding = new Padding(
                    BorderPadding.Left + _padding.Left,
                    CaptionHeight + _padding.Top,
                    BorderPadding.Left + _padding.Right,
                    BorderPadding.Left + _padding.Bottom);
            }
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle rect = RealClientRect;
                rect.X += (_borderPadding.Left + Padding.Left);
                rect.Y += (_borderPadding.Top + _captionHeight + Padding.Top);
                rect.Width -= (_borderPadding.Horizontal + Padding.Horizontal);
                rect.Height -= (_borderPadding.Vertical + _captionHeight + Padding.Vertical);
                return rect;
            }
        }

        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FormBorderStyle FormBorderStyle
        {
            get { return base.FormBorderStyle; }
            set { base.FormBorderStyle = value; }
        }

        protected override Padding DefaultPadding
        {
            get
            {
                return new Padding(
                    BorderPadding.Left,
                    CaptionHeight,
                    BorderPadding.Left,
                    BorderPadding.Left);
            }
        }

        public Rectangle CaptionRect
        {
            get { return new Rectangle(0, 0, Width, CaptionHeight); }
        }

        public ControlBoxManager ControlBoxManager
        {
            get
            {
                if (_controlBoxManager == null)
                {
                    _controlBoxManager = new ControlBoxManager(this);
                }
                return _controlBoxManager;
            }
        }

        public Rectangle IconRect
        {
            get
            {
                if (this.ShowDrawIcon && base.Icon != null)
                {
                    int width = SystemInformation.SmallIconSize.Width;
                    if (CaptionHeight - BorderPadding.Left - 4 < width)
                    {
                        width = CaptionHeight - BorderPadding.Left - 4;
                    }
                    return new Rectangle(
                        BorderPadding.Left,
                        BorderPadding.Left + (CaptionHeight - BorderPadding.Left - width) / 2,
                        width,
                        width);
                }
                return Rectangle.Empty;
            }
        }

        public ToolTip ToolTip
        {
            get { return _toolTip; }
        }

        /// <summary>
        /// 获取窗体的真实客户区大小。
        /// </summary>
        protected Rectangle RealClientRect
        {
            get
            {
                if (base.WindowState == FormWindowState.Maximized)
                {
                    return new Rectangle(
                        _deltaRect.X, _deltaRect.Y,
                        base.Width - _deltaRect.Width, base.Height - _deltaRect.Height);
                }
                else
                {
                    return new Rectangle(Point.Empty, base.Size);
                }
            }
        }

        protected Size MaximumSizeFromMaximinClientSize()
        {
            Size maximumSize = Size.Empty;
            if (MaximumSize != Size.Empty)
            {
                maximumSize.Width = MaximumSize.Width + _borderPadding.Horizontal;
                maximumSize.Height = MaximumSize.Height +
                    _borderPadding.Vertical + _captionHeight;

            }
            return maximumSize;
        }

        /// <summary>
        /// 所以自定义系统按钮的总宽度
        /// </summary>
        /// <param name="space">宽度是否包括ControlBoxSpace间隔值</param>
        /// <returns>总宽度</returns>
        protected int AllSysButtonWidth(bool space)
        {
            int SysWidth = 0;
            foreach (CmSysButton item in ControlBoxManager.SysButtonItems)
            {
                if (item.Visibale)
                {
                    SysWidth += item.Size.Width;
                    if (space)
                    {
                        SysWidth += this.ControlBoxSpace;
                    }
                }
            }
            return SysWidth;
        }

        /// <summary>
        /// 所有系统按钮的总宽度
        /// </summary>
        /// <param name="space">宽度是否包括ControlBoxSpace间隔值</param>
        /// <returns>总宽度</returns>
        protected int AllButtonWidth(bool space)
        {
            int SysWidth = 0;
            foreach (CmSysButton item in ControlBoxManager.SysButtonItems)
            {
                if (item.Visibale)
                {
                    SysWidth += item.Size.Width;
                    if (space)
                    {
                        SysWidth += this.ControlBoxSpace;
                    }
                }
            }
            SysWidth +=
                CloseBoxSize.Width +
                (MinimizeBox ? MiniSize.Width + (space ? ControlBoxSpace : 0) : 0) +
                (MaximizeBox ? MaxSize.Width + (space ? ControlBoxSpace : 0) : 0);
            return SysWidth;
        }

        protected virtual Size GetDefaultMinTrackSize()
        {

            return new Size(
                    AllButtonWidth(true) + _borderPadding.Horizontal +
                    SystemInformation.SmallIconSize.Width + 20,
                    CaptionHeight + _borderPadding.Vertical + 2);
        }

        protected Size MinimumSizeFromMiniminClientSize()
        {
            Size minimumSize = GetDefaultMinTrackSize();
            if (MinimumSize != Size.Empty)
            {
                minimumSize.Width = MinimumSize.Width + _borderPadding.Horizontal;
                minimumSize.Height = MinimumSize.Height +
                    _borderPadding.Vertical + _captionHeight;
            }
            return minimumSize;
        }
        #endregion

        #region 自定义事件
        public delegate void BackEventHandler(object sender, BackEventArgs e);
        public delegate void SysBottomEventHandler(object sender, SysButtonEventArgs e);

        [Description("自定义按钮被点击时引发的事件")]
        [Category("Skin")]
        public event SysBottomEventHandler SysBottomClick;
        protected virtual void OnSysBottomClick(object sender, SysButtonEventArgs e)
        {
            if (this.SysBottomClick != null)
                SysBottomClick(this, e);
        }

        public void SysbottomAv(object sender, SysButtonEventArgs e)
        {
            //引发事件
            OnSysBottomClick(sender, e);
        }

        [Description("Back属性值更改时引发的事件")]
        [Category("Skin")]
        public event BackEventHandler BackChanged;
        protected virtual void OnBackChanged(BackEventArgs e)
        {
            if (this.BackChanged != null)
                BackChanged(this, e);
        }

        public event EventHandler RendererChangled
        {
            add { base.Events.AddHandler(EventRendererChanged, value); }
            remove { base.Events.RemoveHandler(EventRendererChanged, value); }
        }
        #endregion

        #region 重载事件
        //控件首次创建时被调用
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetReion();
            if (this.Owner is CCSkinMain && this.InheritBack)
            {
                CCSkinMain main = (CCSkinMain)this.Owner;
                this.BackToColor = true;
                this.Back = main.Back;
                this.BackLayout = main.BackLayout;
                main.BackChanged += new BackEventHandler(main_BackChanged);
            }
            else if (this.Owner is Form && this.InheritBack)
            {
                Form main = (Form)this.Owner;
                this.Back = main.BackgroundImage;
                this.BackLayout = true;
                this.BackColor = main.BackgroundImage == null ? main.BackColor : SkinTools.GetImageAverageColor((Bitmap)main.BackgroundImage);
                main.BackgroundImageChanged += new EventHandler(main_BackgroundImageChanged);
            }
        }

        void main_BackChanged(object sender, BackEventArgs e)
        {
            if (this.InheritBack)
            {
                CCSkinMain main = (CCSkinMain)sender;
                this.BackToColor = true;
                this.Back = main.Back;
                this.BackLayout = main.BackLayout;
            }
        }

        void main_BackgroundImageChanged(object sender, EventArgs e)
        {
            if (InheritBack)
            {
                Form main = (Form)sender;
                this.Back = main.BackgroundImage;
                this.BackLayout = true;
                this.BackColor = main.BackgroundImage == null ? main.BackColor : SkinTools.GetImageAverageColor((Bitmap)main.BackgroundImage);
            }
        }

        //窗体关闭时
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            //先关闭阴影窗体
            if (skin != null)
            {
                skin.Close();
            }
            //启用窗口淡入淡出
            if (Special && !DesignMode)
            {
                //在Form_FormClosing中添加代码实现窗体的淡出
                NativeMethods.AnimateWindow(this.Handle, 150, AW.AW_BLEND | AW.AW_HIDE);
                Update();
            }
        }

        //Show或Hide被调用时
        private bool OneVisibles = true;
        protected override void OnVisibleChanged(EventArgs e)
        {
            if (Visible)
            {
                //启用窗口淡入淡出
                if (Special && !DesignMode)
                {
                    int House = OneVisibles && Shadow ? 300 : 150;
                    //淡入特效
                    NativeMethods.AnimateWindow(this.Handle, House, AW.AW_BLEND | AW.AW_ACTIVATE);
                    Opacity = SkinOpacity;
                    Update();
                }
                //判断不是在设计器中
                if (!DesignMode && skin == null && Shadow)
                {
                    skin = new CCSkinForm(this);
                    skin.Show(this);
                }
                OneVisibles = false;
                base.OnVisibleChanged(e);
            }
            else
            {
                base.OnVisibleChanged(e);
                //启用窗口淡入淡出
                if (Special && !DesignMode)
                {
                    Opacity = 1;
                    //实现窗体的淡出
                    NativeMethods.AnimateWindow(this.Handle, 150, AW.AW_BLEND | AW.AW_HIDE);
                    Update();
                }
            }
        }

        //窗口加载时
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ResizeCore();
        }

        //窗体绘画样式变了的时候
        protected virtual void OnRendererChanged(EventArgs e)
        {
            Renderer.InitSkinForm(this);
            EventHandler handler =
                base.Events[EventRendererChanged] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
            base.Invalidate();
        }

        //移动时
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            ControlBoxManager.ProcessMouseOperate(
                e.Location, MouseOperate.Move);
        }

        //点击时
        public bool isMouseDown = false;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Point point = e.Location;
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                bool flag = true;
                foreach (CmSysButton item in ControlBoxManager.SysButtonItems)
                {
                    if (item.Bounds.Contains(point))
                    {
                        flag = false;
                        break;
                    }
                }
                //除系统按钮区域以外才能移动窗体
                if (!ControlBoxManager.CloseBoxRect.Contains(point) &&
                    !ControlBoxManager.MaximizeBoxRect.Contains(point) &&
                    !ControlBoxManager.MinimizeBoxRect.Contains(point) &&
                    Mobile != MobileStyle.None && flag)
                {
                    //记录开始移动
                    isMouseDown = true;
                    //标题栏以外也可以移动
                    if (Mobile == MobileStyle.Mobile)
                    {
                        //释放鼠标焦点捕获
                        NativeMethods.ReleaseCapture();
                        //向当前窗体发送拖动消息
                        NativeMethods.SendMessage(this.Handle, 0x0112, 0xF011, 0);
                    }
                    else if (Mobile == MobileStyle.TitleMobile && point.Y < CaptionHeight)
                    {
                        //释放鼠标焦点捕获
                        NativeMethods.ReleaseCapture();
                        //向当前窗体发送拖动消息
                        NativeMethods.SendMessage(this.Handle, 0x0112, 0xF011, 0);
                    }
                    OnClick(e);
                    OnMouseClick(e);
                    OnMouseUp(e);
                }
                else
                {
                    //画窗体按钮的按下样式
                    ControlBoxManager.ProcessMouseOperate(
                        e.Location, MouseOperate.Down);
                }
            }
        }

        //点击并释放按钮时
        protected override void OnMouseUp(MouseEventArgs e)
        {
            //停止移动
            isMouseDown = false;
            base.OnMouseUp(e);
            //画窗体按钮按下并释放鼠标时样式
            ControlBoxManager.ProcessMouseOperate(
                e.Location, MouseOperate.Up);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && MaximizeBox)
            {
                bool flag = true;
                Point point = e.Location;
                foreach (CmSysButton item in ControlBoxManager.SysButtonItems)
                {
                    if (item.Bounds.Contains(point))
                    {
                        flag = false;
                        break;
                    }
                }
                //除系统按钮区域以外才能移动窗体
                if (!ControlBoxManager.CloseBoxRect.Contains(point) &&
                    !ControlBoxManager.MaximizeBoxRect.Contains(point) &&
                    !ControlBoxManager.MinimizeBoxRect.Contains(point) && flag)
                {
                    if (Mobile == MobileStyle.Mobile)
                    {
                        WindowState = WindowState == FormWindowState.Maximized ?
                            this.WindowState = FormWindowState.Normal :
                            WindowState = FormWindowState.Maximized;
                    }
                    else if (Mobile == MobileStyle.TitleMobile && e.Y < CaptionHeight)
                    {
                        WindowState = WindowState == FormWindowState.Maximized ?
                            this.WindowState = FormWindowState.Normal :
                            WindowState = FormWindowState.Maximized;
                    }
                }
            }
            base.OnMouseDoubleClick(e);
        }

        //离开时
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            ControlBoxManager.ProcessMouseOperate(
                Point.Empty, MouseOperate.Leave);
        }

        //悬浮时
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            ControlBoxManager.ProcessMouseOperate(
                PointToClient(MousePosition), MouseOperate.Hover);
        }

        //窗体移动时
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            mStopAnthor();
        }

        public AnchorStyles Aanhor = AnchorStyles.None;
        //更新状态
        private void mStopAnthor()
        {
            if (this.Left <= 0)
            {
                Aanhor = AnchorStyles.Left;
            }
            else if (this.Left >= Screen.PrimaryScreen.Bounds.Width - this.Width)
            {
                Aanhor = AnchorStyles.Right;
            }
            else if (this.Top <= 0)
            {
                Aanhor = AnchorStyles.Top;
            }
            else
            {
                Aanhor = AnchorStyles.None;
            }
        }

        //重绘
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality; //高质量
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            if (Back != null)
            {
                if (BackLayout)
                {
                    g.DrawImage(Back, 0, 0, Back.Width, Back.Height);
                }
                else
                {
                    g.DrawImage(Back, -(Back.Width - Width), 0, Back.Width, Back.Height);
                }
            }
            //渐变背景
            if (Back != null && BackShade)
            {
                //背景从左绘制，阴影右画
                if (BackLayout)
                {
                    LinearGradientBrush brush = new LinearGradientBrush(
                        new Rectangle(Back.Width - 50, 0, 50, Back.Height), BackColor,
                        Color.Transparent, 180);
                    LinearGradientBrush brushTwo = new LinearGradientBrush(
                        new Rectangle(0, Back.Height - 50, Back.Width, 50), BackColor,
                        Color.Transparent, 270);
                    g.FillRectangle(brush, Back.Width - brush.Rectangle.Width + 1, 0, brush.Rectangle.Width, brush.Rectangle.Height);
                    g.FillRectangle(brushTwo, 0, Back.Height - brushTwo.Rectangle.Height + 1, brushTwo.Rectangle.Width, brushTwo.Rectangle.Height);
                }
                else //背景从右绘制，阴影左画
                {
                    LinearGradientBrush brush = new LinearGradientBrush(
                        new Rectangle(-(Back.Width - Width), 0, 50, Back.Height), BackColor,
                        Color.Transparent, 360);
                    LinearGradientBrush brushTwo = new LinearGradientBrush(
                        new Rectangle(-(Back.Width - Width), Back.Height - 50, Back.Width, 50), BackColor,
                        Color.Transparent, 270);
                    g.FillRectangle(brush, -(Back.Width - Width), 0, brush.Rectangle.Width, brush.Rectangle.Height);
                    g.FillRectangle(brushTwo, -(Back.Width - Width), Back.Height - 50, brushTwo.Rectangle.Width, brushTwo.Rectangle.Height);
                }
            }
            base.OnPaint(e);
            Rectangle rect = ClientRectangle;
            SkinFormRenderer renderer = Renderer;
            //画关闭按钮
            if (ControlBoxManager.CloseBoxVisibale)
            {
                renderer.DrawSkinFormControlBox(
                    new SkinFormControlBoxRenderEventArgs(
                    this,
                    g,
                    ControlBoxManager.CloseBoxRect,
                    _active,
                    ControlBoxStyle.Close,
                    ControlBoxManager.CloseBoxState));
            }
            //画最大化按钮
            if (ControlBoxManager.MaximizeBoxVisibale)
            {
                renderer.DrawSkinFormControlBox(
                    new SkinFormControlBoxRenderEventArgs(
                    this,
                    g,
                    ControlBoxManager.MaximizeBoxRect,
                    _active,
                    ControlBoxStyle.Maximize,
                    ControlBoxManager.MaximizeBoxState));
            }
            //画最小化按钮
            if (ControlBoxManager.MinimizeBoxVisibale)
            {
                renderer.DrawSkinFormControlBox(
                    new SkinFormControlBoxRenderEventArgs(
                    this,
                    g,
                    ControlBoxManager.MinimizeBoxRect,
                    _active,
                    ControlBoxStyle.Minimize,
                    ControlBoxManager.MinimizeBoxState));
            }
            //画自定义系统按钮
            foreach (CmSysButton item in ControlBoxManager.SysButtonItems)
            {
                if (item.Visibale)
                {
                    renderer.DrawSkinFormControlBox(
                        new SkinFormControlBoxRenderEventArgs(
                        this,
                        g,
                        item.Bounds,
                        _active,
                        ControlBoxStyle.CmSysBottom,
                        item.BoxState,
                        item));
                }
            }
            if (ShowBorder)
            {
                //画边框
                renderer.DrawSkinFormBorder(
                  new SkinFormBorderRenderEventArgs(
                  this, g, rect, _active));
            }
            //画九宫质感层
            if (BackPalace != null)
            {
                ImageDrawRect.DrawRect(g, (Bitmap)BackPalace, new Rectangle(ClientRectangle.X - 5, ClientRectangle.Y - 5, ClientRectangle.Width + 10, ClientRectangle.Height + 10), Rectangle.FromLTRB(BackRectangle.X, BackRectangle.Y, BackRectangle.Width, BackRectangle.Height), 1, 1);
            }
            //画边框质感层
            if (BorderPalace != null)
            {
                ImageDrawRect.DrawRect(g, (Bitmap)BorderPalace, new Rectangle(ClientRectangle.X - 5, ClientRectangle.Y - 5, ClientRectangle.Width + 10, ClientRectangle.Height + 10), Rectangle.FromLTRB(BorderRectangle.X, BorderRectangle.Y, BorderRectangle.Width, BorderRectangle.Height), 1, 1);
            }
            //画标题栏
            renderer.DrawSkinFormCaption(
                new SkinFormCaptionRenderEventArgs(
                this, g, CaptionRect, _active));
        }

        //拦截消息
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM.WM_NCHITTEST:
                    WmNcHitTest(ref m);
                    break;
                case WM.WM_NCPAINT:
                    break;
                case WM.WM_NCCALCSIZE:
                    WmNcCalcSize(ref m);
                    break;
                case WM.WM_WINDOWPOSCHANGED:
                    WmWindowPosChanged(ref m);
                    break;
                case WM.WM_GETMINMAXINFO:
                    WmGetMinMaxInfo(ref m);
                    break;
                case WM.WM_NCACTIVATE:
                    WmNcActive(ref m);
                    break;
                case WM.WM_NCRBUTTONUP:
                    WmNcRButtonUp(ref m);
                    break;
                case WM.WM_NCUAHDRAWCAPTION:
                case WM.WM_NCUAHDRAWFRAME:
                    m.Result = Result.TRUE;
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        //释放资源文件
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (_controlBoxManager != null)
                {
                    _controlBoxManager.Dispose();
                    _controlBoxManager = null;
                }

                _renderer = null;
                _toolTip.Dispose();
            }
        }

        //拖到图片至背景时
        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            if (DropBack)
            {
                //捕获到的字符串数组(包含拖放文件的完整路径名)   
                string[] myFiles = (string[])(drgevent.Data.GetData(DataFormats.FileDrop));
                FileInfo f = new FileInfo(myFiles[0]);
                if (myFiles != null)
                {
                    string Type = f.Extension.Substring(1);
                    string[] TypeList = { "png", "bmp", "jpg", "jpeg", "gif" };
                    if (((IList)TypeList).Contains(Type.ToLower()))
                    {
                        //我这里设置捕获到的第一张图片设为背景   
                        this.Back = Image.FromFile(myFiles[0]);
                    }
                }
            }
            base.OnDragDrop(drgevent);
        }

        //拖到图片并悬浮至背景时，鼠标样式
        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            if (DropBack)
            {
                //拖放时显示的效果   
                drgevent.Effect = DragDropEffects.Link;
            }
            base.OnDragEnter(drgevent);
        }

        protected override void OnStyleChanged(EventArgs e)
        {
            if (_clientSizeSet)
            {
                ClientSize = ClientSize;
                _clientSizeSet = false;
            }
            base.OnStyleChanged(e);
        }

        protected override void SetClientSizeCore(int x, int y)
        {
            _clientSizeSet = false;
            Type typeControl = typeof(Control);
            Type typeForm = typeof(Form);
            FieldInfo fiWidth = typeControl.GetField("clientWidth",
                BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo fiHeight = typeControl.GetField("clientHeight",
                BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo fi1 = typeForm.GetField("FormStateSetClientSize",
                BindingFlags.NonPublic | BindingFlags.Static),
            fiFormState = typeForm.GetField("formState",
            BindingFlags.NonPublic | BindingFlags.Instance);

            if (fiWidth != null && fiHeight != null &&
                fiFormState != null && fi1 != null)
            {
                _clientSizeSet = true;
                Size = new Size(x, y);
                fiWidth.SetValue(this, x);
                fiHeight.SetValue(this, y);
                BitVector32.Section bi1 = (BitVector32.Section)fi1.GetValue(this);
                BitVector32 state = (BitVector32)fiFormState.GetValue(this);
                state[bi1] = 1;
                fiFormState.SetValue(this, state);
                OnClientSizeChanged(EventArgs.Empty);
                state[bi1] = 0;
                fiFormState.SetValue(this, state);
            }
            else
            {
                base.SetClientSizeCore(x, y);
            }
        }

        protected override Size SizeFromClientSize(Size clientSize)
        {
            return clientSize;
        }

        protected override Rectangle GetScaledBounds(
            Rectangle bounds, SizeF factor, BoundsSpecified specified)
        {
            Rectangle rect = base.GetScaledBounds(bounds, factor, specified);

            Size sz = SizeFromClientSize(Size.Empty);
            if (!GetStyle(ControlStyles.FixedWidth) &&
                ((specified & BoundsSpecified.Width) != BoundsSpecified.None))
            {
                int clientWidth = bounds.Width - sz.Width;
                rect.Width = ((int)Math.Round(
                    (double)(clientWidth * factor.Width))) + sz.Width;
            }
            if (!GetStyle(ControlStyles.FixedHeight) &&
                ((specified & BoundsSpecified.Height) != BoundsSpecified.None))
            {
                int clientHeight = bounds.Height - sz.Height;
                rect.Height = ((int)Math.Round(
                    (double)(clientHeight * factor.Height))) + sz.Height;
            }
            return rect;
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            Size minSize = MinimumSize;
            Size maxSize = MaximumSize;
            Size sz = SizeFromClientSize(Size.Empty);
            base.ScaleControl(factor, specified);
            if (minSize != Size.Empty)
            {
                minSize -= sz;
                minSize = new Size((int)Math.Round(
                    minSize.Width * factor.Width),
                    (int)Math.Round(minSize.Height * factor.Height)) + sz;
            }
            if (maxSize != Size.Empty)
            {
                maxSize -= sz;
                maxSize = new Size((int)Math.Round(
                    maxSize.Width * factor.Width),
                    (int)Math.Round(maxSize.Height * factor.Height)) + sz;
            }
            MinimumSize = minSize;
            MaximumSize = maxSize;
        }

        protected override void SetBoundsCore(
            int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (_inWmWindowPosChanged != 0)
            {
                try
                {
                    Type type = typeof(Form);
                    FieldInfo fi1 = type.GetField("FormStateExWindowBoundsWidthIsClientSize",
                        BindingFlags.NonPublic | BindingFlags.Static),
                        fiFormState = type.GetField("formStateEx",
                        BindingFlags.NonPublic | BindingFlags.Instance),
                        fiBounds = type.GetField("restoredWindowBounds",
                        BindingFlags.NonPublic | BindingFlags.Instance);

                    if (fi1 != null && fiFormState != null && fiBounds != null)
                    {
                        Rectangle restoredWindowBounds = (Rectangle)fiBounds.GetValue(this);
                        BitVector32.Section bi1 = (BitVector32.Section)fi1.GetValue(this);
                        BitVector32 state = (BitVector32)fiFormState.GetValue(this);
                        if (state[bi1] == 1)
                        {
                            width = restoredWindowBounds.Width;
                            height = restoredWindowBounds.Height;
                        }
                    }
                }
                catch
                {
                }
            }

            base.SetBoundsCore(x, y, width, height, specified);
        }

        protected override void OnResize(EventArgs e)
        {
            ResizeCore();
            base.OnResize(e);
        }

        /// <summary>
        /// 窗体改变大小。
        /// </summary>
        protected virtual void ResizeCore()
        {
            CalcDeltaRect();
            SetReion();
        }

        protected void CalcDeltaRect()
        {
            if (base.WindowState == FormWindowState.Maximized)
            {
                Rectangle bounds = base.Bounds;

                Rectangle realRect = Screen.GetWorkingArea(this);
                realRect.X -= _borderPadding.Left;
                realRect.Y -= _borderPadding.Top;
                realRect.Width += _borderPadding.Horizontal;
                realRect.Height += _borderPadding.Vertical;

                int x = 0;
                int y = 0;
                int width = 0;
                int height = 0;

                if (bounds.Left < realRect.Left)
                {
                    x = realRect.Left - bounds.Left;
                }

                if (bounds.Top < realRect.Top)
                {
                    y = realRect.Top - bounds.Top;
                }

                if (bounds.Width > realRect.Width)
                {
                    width = bounds.Width - realRect.Width;
                }

                if (bounds.Height > realRect.Height)
                {
                    height = bounds.Height - realRect.Height;
                }

                _deltaRect = new Rectangle(x, y, width, height);
            }
            else
            {
                _deltaRect = Rectangle.Empty;
            }
        }
        #endregion

        #region 处理Windows消息的方法
        /// <summary>
        /// 响应 WM_WINDOWPOSCHANGED 消息。
        /// </summary>
        /// <param name="m"></param>
        protected virtual void WmWindowPosChanged(ref Message m)
        {
            _inWmWindowPosChanged++;
            base.WndProc(ref m);
            _inWmWindowPosChanged--;
        }

        /// <summary>
        /// 响应 WM_NCRBUTTONUP 消息。
        /// </summary>
        /// <param name="m"></param>
        protected virtual void WmNcRButtonUp(ref Message m)
        {
            TrackPopupSysMenu(ref m);
            base.WndProc(ref m);
        }

        protected void TrackPopupSysMenu(ref Message m)
        {
            if (m.WParam.ToInt32() == HITTEST.HTCAPTION)
            {
                TrackPopupSysMenu(m.HWnd, new Point(m.LParam.ToInt32()));
            }
        }

        protected void TrackPopupSysMenu(IntPtr hWnd, Point point)
        {
            if (_showSystemMenu && point.Y <= Top + _borderPadding.Top + _deltaRect.Y + _captionHeight)
            {
                IntPtr hMenu = NativeMethods.GetSystemMenu(hWnd, false);
                IntPtr command = NativeMethods.TrackPopupMenu(hMenu,
                   TPM.TPM_RETURNCMD | TPM.TPM_TOPALIGN | TPM.TPM_LEFTALIGN,
                   point.X, point.Y, 0, hWnd, IntPtr.Zero);
                NativeMethods.PostMessage(hWnd, WM.WM_SYSCOMMAND, command, IntPtr.Zero);
            }
        }

        /// <summary>
        /// 响应 WM_NCCALCSIZE 消息。
        /// </summary>
        /// <param name="m"></param>
        protected virtual void WmNcCalcSize(ref Message m)
        {
            if (base.Opacity != 1.0d)
            {
                Invalidate();
            }
        }

        private void WmNcHitTest(ref Message m)
        {
            Point point = new Point(m.LParam.ToInt32());
            point = base.PointToClient(point);
            //是否有菜单
            if (IconRect.Contains(point) && ShowSystemMenu)
            {
                m.Result = new IntPtr(
                    HITTEST.HTSYSMENU);
                return;
            }

            if (_canResize)
            {
                if (point.X < 5 && point.Y < 5)
                {
                    m.Result = new IntPtr(
                        HITTEST.HTTOPLEFT);
                    return;
                }

                if (point.X > Width - 5 && point.Y < 5)
                {
                    m.Result = new IntPtr(
                        HITTEST.HTTOPRIGHT);
                    return;
                }

                if (point.X < 5 && point.Y > Height - 5)
                {
                    m.Result = new IntPtr(
                        HITTEST.HTBOTTOMLEFT);
                    return;
                }

                if (point.X > Width - 5 && point.Y > Height - 5)
                {
                    m.Result = new IntPtr(
                        HITTEST.HTBOTTOMRIGHT);
                    return;
                }

                if (point.Y < 3)
                {
                    m.Result = new IntPtr(
                        HITTEST.HTTOP);
                    return;
                }

                if (point.Y > Height - 3)
                {
                    m.Result = new IntPtr(
                        HITTEST.HTBOTTOM);
                    return;
                }

                if (point.X < 3)
                {
                    m.Result = new IntPtr(
                       HITTEST.HTLEFT);
                    return;
                }

                if (point.X > Width - 3)
                {
                    m.Result = new IntPtr(
                       HITTEST.HTRIGHT);
                    return;
                }
            }
            m.Result = new IntPtr(
                     HITTEST.HTCLIENT);
        }

        private void WmGetMinMaxInfo(ref Message m)
        {
            MINMAXINFO minmax =
                (MINMAXINFO)Marshal.PtrToStructure(
                m.LParam, typeof(MINMAXINFO));

            if (MaximumSize != Size.Empty)
            {
                minmax.maxTrackSize = MaximumSize;
            }
            else
            {
                Rectangle rect = Screen.GetWorkingArea(this);
                int h = this.FormBorderStyle == FormBorderStyle.None ? 0 : -1;
                minmax.maxPosition = new Point(
                    rect.X,
                    rect.Y);
                minmax.maxTrackSize = new Size(
                    rect.Width,
                    rect.Height + h);
            }

            if (MinimumSize != Size.Empty)
            {
                minmax.minTrackSize = MinimumSize;
            }
            else
            {
                GetDefaultMinTrackSize();
                minmax.minTrackSize = new Size(
                    AllButtonWidth(true) + ControlBoxOffset.X +
                    SystemInformation.SmallIconSize.Width +
                    BorderPadding.Left * 2 + 3,
                    CaptionHeight);
            }
            Marshal.StructureToPtr(minmax, m.LParam, false);
        }

        private void WmNcActive(ref Message m)
        {
            if (m.WParam.ToInt32() == 1)
            {
                _active = true;
            }
            else
            {
                _active = false;
            }
            m.Result = Result.TRUE;
            base.Invalidate();
        }
        #endregion

        #region 私有方法
        //减少闪烁
        private void SetStyles()
        {
            base.SetStyle(
              ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.ResizeRedraw |
              ControlStyles.DoubleBuffer, true);
            base.UpdateStyles();
            base.AutoScaleMode = AutoScaleMode.None;
        }

        //窗体圆角
        private void SetReion()
        {
            if (base.Region != null)
            {
                base.Region.Dispose();
            }
            SkinTools.CreateRegion(this, RealClientRect, Radius, RoundStyle);
        }

        //初始化
        private void Init()
        {
            _toolTip = new ToolTip();
            base.FormBorderStyle = FormBorderStyle.Sizable;
            base.BackgroundImageLayout = ImageLayout.None;
            Renderer.InitSkinForm(this);
            base.Padding = DefaultPadding;
        }
        #endregion
    }
}
