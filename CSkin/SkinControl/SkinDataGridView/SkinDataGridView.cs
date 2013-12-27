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
 * * 说明：SkinDataGridView.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CCWin.SkinControl
{
    [ToolboxBitmap(typeof(DataGridView))]
    public partial class SkinDataGridView : DataGridView
    {
        public SkinDataGridView()
        {
            this.Font = CCWin.Localization.Localizer.DefaultFont;
            InitializeComponent();
            //减少闪烁
            Init();
        }
        #region 属性
        [DefaultValue(typeof(Color), "White")]
        [Category("Cell")]
        [Description("默认行颜色")]
        public Color DefaultCellBackColor
        {
            get { return this.DefaultCellStyle.BackColor; }
            set
            {
                this.DefaultCellStyle.BackColor = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "231, 246, 253")]
        [Category("Cell")]
        [Description("奇数行颜色")]
        public Color AlternatingCellBackColor
        {
            get { return this.AlternatingRowsDefaultCellStyle.BackColor; }
            set
            {
                this.AlternatingRowsDefaultCellStyle.BackColor = value;
                base.Invalidate();
            }
        }

        private Color mouseCellBackColor = Color.FromArgb(197, 235, 252);
        [DefaultValue(typeof(Color), "197, 235, 252")]
        [Category("Cell")]
        [Description("悬浮行颜色")]
        public Color MouseCellBackColor
        {
            get { return mouseCellBackColor; }
            set
            {
                mouseCellBackColor = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "WindowText")]
        [Category("Column")]
        [Description("单元格字体颜色")]
        public Color ColumnForeColor
        {
            get { return this.ColumnHeadersDefaultCellStyle.ForeColor; }
            set
            {
                this.ColumnHeadersDefaultCellStyle.ForeColor = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "WindowText")]
        [Category("Column")]
        [Description("单元格被选中时的字体颜色")]
        public Color ColumnSelectForeColor
        {
            get { return this.ColumnHeadersDefaultCellStyle.SelectionForeColor; }
            set
            {
                this.ColumnHeadersDefaultCellStyle.SelectionForeColor = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "Highlight")]
        [Category("Column")]
        [Description("单元格被选中时的背景颜色")]
        public Color ColumnSelectBackColor
        {
            get { return this.ColumnHeadersDefaultCellStyle.SelectionBackColor; }
            set
            {
                this.ColumnHeadersDefaultCellStyle.SelectionBackColor = value;
                base.Invalidate();
            }
        }

        private bool lineNumber = true;
        [DefaultValue(typeof(bool), "true")]
        [Category("LineNumber")]
        [Description("是否显示行号")]
        public bool LineNumber
        {
            get { return lineNumber; }
            set
            {
                lineNumber = value;
                base.Invalidate();
            }
        }

        private Color lineNumberForeColor = Color.Blue;
        [DefaultValue(typeof(Color), "Blue")]
        [Category("LineNumber")]
        [Description("行号字体颜色")]
        public Color LineNumberForeColor
        {
            get { return lineNumberForeColor; }
            set
            {
                lineNumberForeColor = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "GradientActiveCaption")]
        [Category("Skin")]
        [Description("网格线的颜色")]
        public Color SkinGridColor
        {
            get { return this.GridColor; }
            set
            {
                this.GridColor = value;
                base.Invalidate();
            }
        }
        #endregion

        #region 减少闪烁
        public void Init()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.StandardDoubleClick, false);
            this.SetStyle(ControlStyles.Selectable, true);
            this.UpdateStyles();
        }
        #endregion

        #region 控件创建时
        protected override void OnCreateControl()
        {
            //指示在为应用程序启用视觉样式的情况下，行标题和列标题是否使用用户当前主题的视觉样式
            this.EnableHeadersVisualStyles = false;
            //获取或设置默认列标题BackColor样式
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(247, 246, 239);
            //列标题的单行方框样式
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //列标题行的高度
            this.ColumnHeadersHeight = 26;
            //用户不能使用鼠标调整列标题的高度
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //单元格内字体位置
            this.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //单元格字体色
            this.ColumnForeColor = SystemColors.WindowText;
            //单元格在被选中时的背景颜色
            ColumnSelectBackColor = System.Drawing.SystemColors.Highlight;
            //单元格在被选中时的字体颜色
            ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            //单元格内的单元格内容的位置
            this.RowHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //行标题单元格的默认背景色
            DefaultCellBackColor = System.Drawing.SystemColors.Window;
            //行标题单元格的默认字体色
            this.RowHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            //无边框
            this.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            //点击编辑时框框的背景颜色
            this.DefaultCellStyle.SelectionBackColor = Color.FromArgb(59, 188, 240);
            //点击编辑时框框的字体颜色
            this.DefaultCellStyle.SelectionForeColor = Color.White;
            //默认列颜色
            this.DefaultCellStyle.BackColor = Color.White;
            //用户不能用鼠标调整列标头的宽度
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            //网格线的颜色
            this.SkinGridColor = System.Drawing.SystemColors.GradientActiveCaption;
            //控件背景
            this.BackgroundColor = System.Drawing.SystemColors.Window;
            //控件边框样式
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            //是否启用手动列重新放置
            this.AllowUserToOrderColumns = true;
            //是否自动产生列
            this.AutoGenerateColumns = true;
            //奇数行的颜色
            AlternatingCellBackColor = Color.FromArgb(231, 246, 253);
            base.OnCreateControl();
        }
        #endregion

        #region 默认行重绘
        protected override void OnCellPainting(
            DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                Color begin = Color.White;
                Color end = Color.FromArgb(0x53, 0xc4, 0xf2);
                using (Brush brush = new LinearGradientBrush(
                    e.CellBounds, begin, end, LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                DataGridViewPaintParts pa =
                    DataGridViewPaintParts.Border |
                    DataGridViewPaintParts.ContentBackground |
                    DataGridViewPaintParts.ContentForeground |
                    DataGridViewPaintParts.ErrorIcon |
                    DataGridViewPaintParts.Focus |
                    DataGridViewPaintParts.SelectionBackground;
                e.Paint(e.ClipBounds, pa);
                e.Handled = true;
            }
            base.OnCellPainting(e);
        }
        #endregion

        #region 悬浮行颜色
        //悬浮时，保存默认颜色
        private Color defaultcolor;
        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseEnter(e);
            try
            {
                defaultcolor = Rows[e.RowIndex].DefaultCellStyle.BackColor;
            }
            catch (Exception)
            {
            }
        }

        //移到单元格时的颜色
        protected override void OnCellMouseMove(DataGridViewCellMouseEventArgs e)
        {
            base.OnCellMouseMove(e);
            try
            {
                Rows[e.RowIndex].DefaultCellStyle.BackColor = MouseCellBackColor;
            }
            catch (Exception)
            {
            }
        }

        //离开时还原颜色
        protected override void OnCellMouseLeave(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseLeave(e);
            try
            {
                Rows[e.RowIndex].DefaultCellStyle.BackColor = defaultcolor;
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region 在生成列表时添加一个行号，颜色默认为红色
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            base.OnRowPostPaint(e);
            if (LineNumber)
            {
                //自动编号与数据库无关
                Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, RowHeadersWidth - 4, e.RowBounds.Height);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), RowHeadersDefaultCellStyle.Font, rectangle,
                 LineNumberForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }
        }
        #endregion
    }
}
