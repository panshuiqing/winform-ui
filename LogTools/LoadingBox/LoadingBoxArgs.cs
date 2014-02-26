using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogTools
{
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
