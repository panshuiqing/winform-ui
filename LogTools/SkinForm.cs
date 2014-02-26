using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LogTools
{
    public partial class SkinForm : CCWin.CCSkinMain
    {
        public SkinForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            //处理鼠标点击事件，关闭tooltip
            if (m.Msg == CCWin.Win32.Const.WM.WM_LBUTTONDOWN || m.Msg == CCWin.Win32.Const.WM.WM_RBUTTONDOWN)
            {
                ToolTipEx.CloseToolTip();
            }
            base.WndProc(ref m);
        }

        public void InvokeEx(MethodInvoker invoker)
        {
            if (invoker != null && !this.IsDisposed)
            {
                Utils.InvokeEx(invoker, this);
            }
        }
    }
}
