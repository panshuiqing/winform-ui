using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Teleware.ZPG.Client.Controls
{
    public class WebBrowserEx : WebBrowser
    {
        private SHDocVw.IWebBrowser2 _iwb2;
        
        public WebBrowserEx()
        {
            this.IsWebBrowserContextMenuEnabled = false;
            this.ScrollBarsEnabled = false;
            this.ScriptErrorsSuppressed = false;
        }
        
        protected override void AttachInterfaces(object nativeActiveXObject)
        {
            _iwb2 = (SHDocVw.IWebBrowser2)nativeActiveXObject;
            _iwb2.Silent = true;
            base.AttachInterfaces(nativeActiveXObject);
        }

        protected override void DetachInterfaces()
        {
            _iwb2 = null;
            base.DetachInterfaces();
        }
    }
}
