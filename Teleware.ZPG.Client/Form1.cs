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
    public partial class Form1 : SkinForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button1_Click");

            ToolTipEx.ShowToolTip("请输入用户名再登陆请输入用户名再登陆123", this.textBox2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.skinRichTextBox1.InsertLink("link");

        }


        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
