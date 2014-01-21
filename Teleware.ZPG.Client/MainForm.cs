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
        private Controls.NetDisconnectControl netDisconnectControl;
        private Controls.TradeUnStartControl tradeUnStartControl;
        private Controls.TradeFinishControl tradeFinishControl;
        
        public MainForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(MainForm_Load);
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            var list = Model.Create();
            this.listView1.SuspendLayout();
            foreach (var item in list)
            {
                var viewItem = new ListViewItem();
                viewItem.Tag = item;
                viewItem.Text = item.Num;
                var subItem = new ListViewItem.ListViewSubItem();
                subItem.Text = item.Number;
                viewItem.SubItems.Add(subItem);
                subItem = new ListViewItem.ListViewSubItem();
                subItem.Text = item.Price;
                viewItem.SubItems.Add(subItem);
                subItem = new ListViewItem.ListViewSubItem();
                subItem.Text = item.Date;
                viewItem.SubItems.Add(subItem);
                
                this.listView1.Items.Add(viewItem);
            }
            this.listView1.ResumeLayout();
            this.panel_main.BringToFront();
        }

        private class Model
        {
            public string Num { get; set; }
            public string Number { get; set; }
            public string Price { get; set; }
            public string Date { get; set; }

            public static List<Model> Create()
            {
                List<Model> list = new List<Model>();
                list.Add(new Model() { Date = "14-01-01 12:34", Num = "1000", Number = "088340", Price = "37488883.3" });
                list.Add(new Model() { Date = "14-01-01 12:34", Num = "2000", Number = "014770", Price = "34488883.3" });
                list.Add(new Model() { Date = "14-01-01 12:34", Num = "3000", Number = "035770", Price = "34088883.3" });
                list.Add(new Model() { Date = "14-01-01 12:34", Num = "4000", Number = "045540", Price = "34288883.3" });
                list.Add(new Model() { Date = "14-01-01 12:34", Num = "5000", Number = "055540", Price = "34888893.3" });
                list.Add(new Model() { Date = "14-01-01 12:34", Num = "6000", Number = "036664", Price = "34868853.3" });
                return list;
            }
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
            Teleware.ZPG.Client.LoadingBox.ShowLoading(null, "正在加载数据，请稍后......");
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            Teleware.ZPG.Client.LoadingBox.CloseLoading();
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show(this, "正在加载正在加正在加载正在加", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void skinButton4_Click(object sender, EventArgs e)
        {
            NotifyBox.Notify(this, "正在加载正在加", NotifyBoxIcon.Info, 3000);
        }

        private void skinButton5_Click(object sender, EventArgs e)
        {
            if (netDisconnectControl == null)
            {
                netDisconnectControl = new Controls.NetDisconnectControl();
                netDisconnectControl.Dock = DockStyle.Fill;
                netDisconnectControl.ForeColor = Color.Black;
                panel_switch.Controls.Add(netDisconnectControl);
            }
            foreach (Control item in panel_switch.Controls)
            {
                if (item != netDisconnectControl)
                {
                    item.Visible = false;
                }
            }
            netDisconnectControl.Visible = true;
            panel_switch.BringToFront();
            skinTabControl1.SelectedIndex = 0;
        }

        private void skinButton6_Click(object sender, EventArgs e)
        {
            if (tradeUnStartControl == null)
            {
                tradeUnStartControl = new Controls.TradeUnStartControl();
                tradeUnStartControl.Dock = DockStyle.Fill;
                tradeUnStartControl.ForeColor = Color.Black;
                panel_switch.Controls.Add(tradeUnStartControl);
            }
            foreach (Control item in panel_switch.Controls)
            {
                if (item != tradeUnStartControl)
                {
                    item.Visible = false;
                }
            }
            tradeUnStartControl.Visible = true;
            panel_switch.BringToFront();
            skinTabControl1.SelectedIndex = 0;
        }

        private void skinButton7_Click(object sender, EventArgs e)
        {
            if (tradeFinishControl == null)
            {
                tradeFinishControl = new Controls.TradeFinishControl();
                tradeFinishControl.Dock = DockStyle.Fill;
                tradeFinishControl.ForeColor = Color.Black;
                panel_switch.Controls.Add(tradeFinishControl);
            }
            foreach (Control item in panel_switch.Controls)
            {
                if (item != tradeFinishControl)
                {
                    item.Visible = false;
                }
            }
            tradeFinishControl.Visible = true;
            panel_switch.BringToFront();
            skinTabControl1.SelectedIndex = 0;
        }

        private void skinButton8_Click(object sender, EventArgs e)
        {

        }

        private void skinButton9_Click(object sender, EventArgs e)
        {
            
        }
    }
}
