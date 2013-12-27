using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Teleware.ZPG.Client
{
    public partial class LoginForm : SkinForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnDl_Click(object sender, EventArgs e)
        {
            this.Size = new Size(380, 326);
            this.panelError.Visible = true;
            //this.Hide();
            //new MainForm().Show();
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            this.Size = new Size(380, 292);
            this.panelError.Visible = false;
        }
    }
}
