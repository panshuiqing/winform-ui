using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin.SkinControl;

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

        private bool keyBoardFormShow = false;
        private void txtPwd_IconClick(object sender, EventArgs e)
        {
            if (!keyBoardFormShow)
            {
                var keyBoardFrom = new KeyBoardForm(this.Left + txtPwd.Left - 25, this.Top + txtPwd.Bottom,this.txtPwd.SkinTxt);
                keyBoardFrom.Show(this);
            }
            
            keyBoardFormShow = !keyBoardFormShow;
        }
    }
}
