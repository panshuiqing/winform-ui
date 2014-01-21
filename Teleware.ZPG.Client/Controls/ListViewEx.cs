using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

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
    }
}
