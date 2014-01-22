using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Drawing;

namespace Teleware.ZPG.Client.Controls
{
    public class ListViewEx : ListView
    {
        public ListViewEx()
        {
            //设置自定义控件Style
            this.SetStyle(ControlStyles.ResizeRedraw, true);//调整大小时重绘
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);// 双缓冲
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);// 禁止擦除背景.
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
        }

        /// <summary>
        /// 是否允许改变表头宽度
        /// </summary>
        [DefaultValue(true)]
        [Category("自定义属性")]
        [Description("是否允许改变表头宽度")]
        public bool AllowChangeHeaderWidth
        {
            get;
            set;
        }

        protected override void OnColumnWidthChanging(ColumnWidthChangingEventArgs e)
        {
            if (!AllowChangeHeaderWidth)
            {
                e.Cancel = true;
                e.NewWidth = this.Columns[e.ColumnIndex].Width;
            }
            base.OnColumnWidthChanging(e);
        }
    }
}
