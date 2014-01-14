namespace Teleware.ZPG.Client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.netDisconnectControl1 = new Teleware.ZPG.Client.Controls.NetDisconnectControl();
            this.netDisconnectControl2 = new Teleware.ZPG.Client.Controls.NetDisconnectControl();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinPictureBox1 = new CCWin.SkinControl.SkinPictureBox();
            this.skinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.netDisconnectControl1);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinPanel1.Location = new System.Drawing.Point(93, 369);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(402, 207);
            this.skinPanel1.TabIndex = 0;
            // 
            // netDisconnectControl1
            // 
            this.netDisconnectControl1.BackColor = System.Drawing.Color.Transparent;
            this.netDisconnectControl1.Location = new System.Drawing.Point(20, 40);
            this.netDisconnectControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.netDisconnectControl1.Name = "netDisconnectControl1";
            this.netDisconnectControl1.Size = new System.Drawing.Size(340, 140);
            this.netDisconnectControl1.TabIndex = 0;
            // 
            // netDisconnectControl2
            // 
            this.netDisconnectControl2.BackColor = System.Drawing.Color.Transparent;
            this.netDisconnectControl2.Location = new System.Drawing.Point(103, 198);
            this.netDisconnectControl2.Name = "netDisconnectControl2";
            this.netDisconnectControl2.Size = new System.Drawing.Size(340, 140);
            this.netDisconnectControl2.TabIndex = 1;
            this.netDisconnectControl2.Load += new System.EventHandler(this.netDisconnectControl2_Load);
            // 
            // skinLabel1
            // 
            this.skinLabel1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(231, 89);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(230, 60);
            this.skinLabel1.TabIndex = 3;
            this.skinLabel1.Text = "当前网络不稳定，系统正在与服务器连接，请稍后......";
            this.skinLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // skinPictureBox1
            // 
            this.skinPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinPictureBox1.Image = global::Teleware.ZPG.Client.Properties.Resources.wlzd;
            this.skinPictureBox1.Location = new System.Drawing.Point(161, 89);
            this.skinPictureBox1.Name = "skinPictureBox1";
            this.skinPictureBox1.Size = new System.Drawing.Size(60, 60);
            this.skinPictureBox1.TabIndex = 2;
            this.skinPictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 596);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.skinPictureBox1);
            this.Controls.Add(this.netDisconnectControl2);
            this.Controls.Add(this.skinPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.skinPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel1;
        private Controls.NetDisconnectControl netDisconnectControl1;
        private Controls.NetDisconnectControl netDisconnectControl2;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox1;

    }
}