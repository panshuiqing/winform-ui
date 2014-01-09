using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Teleware.ZPG.Client.Controls
{
    public class WebBrowserEx : WebBrowser
    {
        public WebBrowserEx()
        {
            this.IsWebBrowserContextMenuEnabled = false;
            this.ScrollBarsEnabled = false;
        }
    }
}
