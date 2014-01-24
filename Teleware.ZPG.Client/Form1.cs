using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Teleware.ZPG.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ToolTipForm tipForm = null;

        private void button1_Click(object sender, EventArgs e)
        {
            if (tipForm != null)
            {
                tipForm.Close();
            }
            tipForm = new ToolTipForm();
            tipForm.SetToolTip(this.textBox1, "登录登录");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
