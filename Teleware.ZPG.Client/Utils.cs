using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Teleware.ZPG.Client
{
    public static class Utils
    {
        public static void InvokeEx(MethodInvoker invoker,Control control)
        {
            if (invoker != null && control != null && !control.IsDisposed)
            {
                while (!control.IsHandleCreated)
                {
                    System.Threading.Thread.Sleep(100);
                }
                control.Invoke(invoker);
            }
        }

    }
}
