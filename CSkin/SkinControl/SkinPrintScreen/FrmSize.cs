/********************************************************************
 * *
 * * 使本项目源码或本项目生成的DLL前请仔细阅读以下协议内容，如果你同意以下协议才能使用本项目所有的功能，
 * * 否则如果你违反了以下协议，有可能陷入法律纠纷和赔偿，作者保留追究法律责任的权利。
 * *
 * * 1、你可以在开发的软件产品中使用和修改本项目的源码和DLL，但是请保留所有相关的版权信息。
 * * 2、不能将本项目源码与作者的其他项目整合作为一个单独的软件售卖给他人使用。
 * * 3、不能传播本项目的源码和DLL，包括上传到网上、拷贝给他人等方式。
 * * 4、以上协议暂时定制，由于还不完善，作者保留以后修改协议的权利。
 * *
 * * Copyright (C) 2013-? cskin Corporation All rights reserved.
 * * 网站：CSkin界面库 http://www.cskin.net
 * * 作者： 乔克斯 QQ：345015918 .Net项目技术组群：306485590
 * * 请保留以上版权信息，否则作者将保留追究法律责任。
 * *
 * * 创建时间：2013-12-08
 * * 说明：FrmSize.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCWin.SkinControl
{
    public partial class FrmSize : Form
    {
        public FrmSize(Size se) {
            InitializeComponent();
            imageSize = se;
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.TopMost = true;
        }

        private Size imageSize;
        public Size ImageSize {
            get { return imageSize; }
            set { imageSize = value; }
        }

        private void FrmSize_Load(object sender, EventArgs e) {
            textBox1.Text = imageSize.Width.ToString();
            textBox2.Text = imageSize.Height.ToString();
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            button1.Text = "OK";
            button2.Text = "Cancel";
            this.AcceptButton = button1;
            this.CancelButton = button2;
        }

        private void button1_Click(object sender, EventArgs e) {
            if (textBox1.BackColor != Color.White || textBox2.BackColor != Color.White) {
                MessageBox.Show("The input value is invalid!");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox_Validating(object sender, CancelEventArgs e) {
            TextBox tbx = sender as TextBox;
            try {
                int v = int.Parse(tbx.Text);
                if (tbx == textBox1)
                    this.imageSize.Width = v;
                else
                    this.imageSize.Height = v;
                tbx.BackColor = Color.White;
            } catch {
                tbx.BackColor = Color.Yellow;
            }
        }
    }
}
