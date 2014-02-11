using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Teleware.ZPG.Client.Module
{
    public partial class TradeHangControl : UserControl
    {
        public TradeHangControl()
        {
            InitializeComponent();
        }

        private void TradeHangControl_Load(object sender, EventArgs e)
        {
            var list = Model.Create();
            this.listView1.SuspendLayout();
            int i = 1;
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


                if (i == 1)
                {
                    viewItem.ForeColor = Color.Red;
                }
                if (i % 2 == 0)
                {
                    viewItem.ForeColor = Color.Green;
                }
                i++;
                this.listView1.Items.Add(viewItem);
            }
            this.listView1.ResumeLayout();
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
    }
}
