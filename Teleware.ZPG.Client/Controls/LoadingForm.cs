using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Teleware.ZPG.Client.Controls
{
    public partial class LoadingForm : SkinForm
    {
        private static LoadingForm loadingForm;
        private static object locker = new object();
        private string loadingText;

        private LoadingForm(string text)
        {
            this.loadingText = text;
            InitializeComponent();
        }

        public static void ShowLoading(Form owner, string text)
        {
            lock (locker)
            {
                CloseLoading();
                loadingForm = new LoadingForm(text);
                var ownerForm = owner;

                if (ownerForm == null)
                {
                    Form activeForm = Form.ActiveForm;
                    if (activeForm != null && !activeForm.InvokeRequired)
                    {
                        ownerForm = activeForm;
                    }
                }

                if (owner == null)
                {
                    loadingForm.StartPosition = FormStartPosition.CenterScreen;
                }
                else
                {
                    loadingForm.Owner = ownerForm;
                    loadingForm.StartPosition = FormStartPosition.Manual;
                    var left = (ownerForm.Width - loadingForm.Width) / 2 + ownerForm.Location.X;
                    var top = (ownerForm.Height - loadingForm.Height) / 2 + ownerForm.Location.Y;
                    loadingForm.Location = new Point(left, top);
                }
                loadingForm.TopMost = true;
                loadingForm.Show(ownerForm);
            }
        }

        public static void CloseLoading()
        {
            if (loadingForm != null)
            {
                loadingForm.Dispose();
                loadingForm = null;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            var fontSize = g.MeasureString(this.loadingText, this.Font);
            var loadingImage = Teleware.ZPG.Client.Properties.Resources.loading;
            //图片与文字的水平间隔
            int imageTextSpace = 10;
            var left = Math.Max(10, (this.Width - (loadingImage.Width + (int)fontSize.Width + imageTextSpace)) / 2);
            var imageTop = Math.Max(3, (this.Height - loadingImage.Height) / 2);
            var textTop = Math.Max(3, (this.Height - (int)fontSize.Height) / 2);
            this.skinPictureBox1.Location = new Point(left,imageTop);
            g.DrawString(this.loadingText, this.Font, Brushes.Black, new RectangleF(left + loadingImage.Width + imageTextSpace, textTop, fontSize.Width, fontSize.Height), new StringFormat(StringFormatFlags.MeasureTrailingSpaces));
        }
    }
}
