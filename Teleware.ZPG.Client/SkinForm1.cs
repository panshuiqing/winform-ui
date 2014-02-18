using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Teleware.ZPG.Client
{
    public partial class SkinForm1 : CCWin.CCSkinMain
    {
        public SkinForm1()
        {
            InitializeComponent();
        }

        public void InvokeEx(MethodInvoker invoker)
        {
            Utils.InvokeEx(invoker, this);
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
    }
}
