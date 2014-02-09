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

        ToolTipForm tip;
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button1_Click");
            //new Form2().Show();
            if (tip != null)
            {
                tip.Close();
            }
            tip = new ToolTipForm();
            tip.Show("请输入用户名再登陆123", this.textBox2); this.textBox2.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
