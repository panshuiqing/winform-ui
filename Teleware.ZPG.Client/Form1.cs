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
            if (tip != null)
            {
                tip.Close();
            }
            tip = new ToolTipForm();
            tip.Show("谢谢谢谢谢谢谢谢谢谢谢谢谢谢谢谢谢谢谢谢123", this.textBox2, 3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
