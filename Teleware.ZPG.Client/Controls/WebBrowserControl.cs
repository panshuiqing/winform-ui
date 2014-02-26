using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Teleware.ZPG.Client.Controls
{
    public partial class WebBrowserControl : UserControl
    {
        public WebBrowserControl()
        {
            InitializeComponent();
        }

        void webBrowserEx1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            this.skinPictureBox1.Visible = true;
        }

        private void webBrowserEx1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.skinPictureBox1.Visible = false;
        }

        public WebBrowser WebBrowser
        {
            get
            {
                return webBrowserEx1;
            }
        }
    }
}
