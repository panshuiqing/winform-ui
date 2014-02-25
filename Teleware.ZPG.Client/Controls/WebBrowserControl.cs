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
            this.picLoading.SizeMode= PictureBoxSizeMode.StretchImage;
            this.webBrowserEx1.Navigated += new WebBrowserNavigatedEventHandler(webBrowserEx1_Navigated);
            this.webBrowserEx1.Navigating += new WebBrowserNavigatingEventHandler(webBrowserEx1_Navigating);
        }

        void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            this.picLoading.Visible = false;
        }

        void webBrowserEx1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            this.picLoading.Visible = true;
        }

        void webBrowserEx1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.picLoading.Visible = true;
        }

        private void webBrowserEx1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.picLoading.Visible = false;
            this.webBrowserEx1.Document.Window.Error -= new HtmlElementErrorEventHandler(Window_Error); 
            this.webBrowserEx1.Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);
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
