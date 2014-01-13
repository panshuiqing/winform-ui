using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Teleware.ZPG.Client
{
    public partial class MainForm : SkinForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(MainForm_Load);
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void skinTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (skinTabControl1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    webBrowser_tradeDetail.Navigate(Common.TradeDetailUrl);
                    break;
                case 2:
                    webBrowser_affiche.Navigate(Common.AfficheUrl);
                    break;
                case 3:
                    webBrowser_tradeResult.Navigate(Common.TradeResultUrl);
                    break;
                case 4:
                    webBrowser_applyInfo.Navigate(Common.ApplyInfoUrl);
                    break;
            }

        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            Teleware.ZPG.Client.Controls.LoadingForm.ShowLoading(this, "正在加载...正在加载...正在加载...\r\n正在加载...   ");
            MessageBoxEx.Show("dfgdfg");
            //new System.Threading.Thread(() =>
            //{
            //    System.Threading.Thread.Sleep(2000);
            //    this.Invoke(new Action<int>(delegate
            //    {
            //        Teleware.ZPG.Client.Controls.LoadingForm.CloseLoading();
            //    }));
            //}).Start();
        }
    }
}
