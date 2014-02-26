using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogTools
{
    public static class LoadingBox
    {
        private static MessageIconForm form;

        public static void ShowLoading(string text)
        {
            ShowLoading(null, text);
        }

        public static void ShowLoading(IWin32Window owner, string text)
        {
            ShowLoading(owner, text, Properties.Resources.loading);
        }

        public static void ShowLoading(IWin32Window owner, string text, Image loadingImage)
        {
            CloseLoading();
            LoadingBoxArgs args = new LoadingBoxArgs(owner, text, loadingImage);
            form = new MessageIconForm();
            form.ShowLoading(args);
        }

        public static void CloseLoading()
        {
            if (form != null)
            {
                form.Close();
            }
        }
    }
}
