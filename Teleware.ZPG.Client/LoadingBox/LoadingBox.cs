using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Teleware.ZPG.Client
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

    public class LoadingBoxArgs
    {
        public LoadingBoxArgs()
        {
        }

        public LoadingBoxArgs(IWin32Window owner, string loadingText, Image loadingImage)
        {
            this.Owner = owner;
            this.LoadingText = loadingText;
            this.LoadingImage = loadingImage;
        }


        public IWin32Window Owner
        {
            get;
            set;
        }

        public string LoadingText
        {
            get;
            set;
        }

        public Image LoadingImage
        {
            get;
            set;
        }
    }
}
