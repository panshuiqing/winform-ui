using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Teleware.ZPG.Client
{
    public static class NotifyBox
    {
        private static MessageIconForm form;
        private static System.Threading.Timer timer;
        private const int minInterval = 2000;

        public static void Notify(string text)
        {
            Notify(null, text);
        }

        public static void Notify(IWin32Window owner, string text)
        {
            Notify(owner, text, NotifyBoxIcon.Info, 3000);
        }

        public static void Notify(IWin32Window owner, string text, NotifyBoxIcon icon, int interval)
        {
            CloseForm();
            var img = GetImage(icon);
            LoadingBoxArgs args = new LoadingBoxArgs(owner, text, img);
            form = new MessageIconForm();
            form.Special = false;
            form.SkinOpacity = 1;
            form.ShowSpecialOnClosed = true;
            form.ShowLoading(args);
            StartTimer(interval);
        }

        private static void StartTimer(int interval)
        {
            var _interval = Math.Max(minInterval, interval);
            timer = new System.Threading.Timer(TimerCallback, null, _interval, _interval);
        }

        private static void TimerCallback(object state)
        {
            CloseForm();
        }

        private static Image GetImage(NotifyBoxIcon icon)
        {
            switch (icon)
            {
                case NotifyBoxIcon.Fail:
                    return Properties.Resources.notify_fail;
                case NotifyBoxIcon.Info:
                    return Properties.Resources.notify_info;
                case NotifyBoxIcon.Success:
                    return Properties.Resources.notify_success;
                default:
                    return null;
            }
        }

        private static void CloseForm()
        {
            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }
            if (form != null)
            {
                if (form.InvokeRequired)
                {
                    form.Invoke(new MethodInvoker(delegate
                    {
                        form.Close();
                    }));
                }
                else
                {
                    form.Close();
                }
            }
        }
    }
}
