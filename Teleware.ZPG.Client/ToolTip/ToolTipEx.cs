using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Teleware.ZPG.Client.Controls;

namespace Teleware.ZPG.Client
{
    public static class ToolTipEx
    {
        private static int timerDuration = 7000;
        private static System.Threading.Timer timer;
        private static ToolTipForm tipForm;

        public static void ShowToolTip(string text, Control control)
        {
            ShowToolTip(text, control, timerDuration);
        }

        public static void ShowToolTip(string text, Control control, int duration)
        {
            if (control == null) throw new ArgumentNullException("control");
            CloseToolTip();
            tipForm = new ToolTipForm();
            timerDuration = duration;
            tipForm.Show(text, control);
            SetTimer();
        }

        public static void CloseToolTip()
        {
            if (tipForm != null && !tipForm.IsDisposed && tipForm.IsHandleCreated)
            {
                tipForm.Close();
                tipForm = null;
            }
        }

        private static void SetTimer()
        {
            DisposedTimer();
            timer = new System.Threading.Timer(TimerCallback, null, timerDuration, timerDuration);
        }

        private static void DisposedTimer()
        {
            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }
        }

        private static void TimerCallback(object state)
        {
            DisposedTimer();
            if (tipForm != null)
            {
                Utils.InvokeEx(new MethodInvoker(delegate
                {
                    tipForm.Close();
                }), tipForm);
            }
        }
    }
}
