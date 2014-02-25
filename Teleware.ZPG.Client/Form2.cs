using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Teleware.ZPG.Client
{
    public partial class Form2 : SkinForm1
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Deactivate(object sender, EventArgs e)
        {
            //this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.webBrowserControl1.WebBrowser.Navigate("http://wwww.baidu.com");
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            this.webBrowserControl1.WebBrowser.Refresh();
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            this.webBrowserControl1.WebBrowser.Navigate("http://wwww.google.com");
        }
    }
}
