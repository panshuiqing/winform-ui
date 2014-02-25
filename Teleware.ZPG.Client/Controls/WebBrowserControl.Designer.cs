namespace Teleware.ZPG.Client.Controls
{
    partial class WebBrowserControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.picLoading = new CCWin.SkinControl.SkinPictureBox();
            this.webBrowserEx1 = new Teleware.ZPG.Client.Controls.WebBrowserEx();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // picLoading
            // 
            this.picLoading.BackColor = System.Drawing.Color.Transparent;
            this.picLoading.Dock = System.Windows.Forms.DockStyle.Top;
            this.picLoading.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.picLoading.Image = global::Teleware.ZPG.Client.Properties.Resources.imgLoadding;
            this.picLoading.Location = new System.Drawing.Point(0, 0);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(373, 2);
            this.picLoading.TabIndex = 1;
            this.picLoading.TabStop = false;
            // 
            // webBrowserEx1
            // 
            this.webBrowserEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserEx1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserEx1.Location = new System.Drawing.Point(0, 0);
            this.webBrowserEx1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserEx1.Name = "webBrowserEx1";
            this.webBrowserEx1.ScrollBarsEnabled = false;
            this.webBrowserEx1.Size = new System.Drawing.Size(373, 330);
            this.webBrowserEx1.TabIndex = 0;
            this.webBrowserEx1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserEx1_DocumentCompleted);
            // 
            // WebBrowserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picLoading);
            this.Controls.Add(this.webBrowserEx1);
            this.Name = "WebBrowserControl";
            this.Size = new System.Drawing.Size(373, 330);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WebBrowserEx webBrowserEx1;
        private CCWin.SkinControl.SkinPictureBox picLoading;
    }
}
