namespace Teleware.ZPG.Client.Controls
{
    partial class MessageIconForm
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
            this.pic_loading = new CCWin.SkinControl.SkinPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_loading)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_loading
            // 
            this.pic_loading.BackColor = System.Drawing.Color.Transparent;
            this.pic_loading.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pic_loading.Location = new System.Drawing.Point(48, 24);
            this.pic_loading.Name = "pic_loading";
            this.pic_loading.Size = new System.Drawing.Size(32, 32);
            this.pic_loading.TabIndex = 0;
            this.pic_loading.TabStop = false;
            // 
            // MessageIconForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = null;
            this.BorderPalace = global::Teleware.ZPG.Client.Properties.Resources.form_border;
            this.CaptionHeight = 4;
            this.ClientSize = new System.Drawing.Size(180, 70);
            this.ControlBox = false;
            this.Controls.Add(this.pic_loading);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Mobile = CCWin.MobileStyle.None;
            this.Name = "MessageIconForm";
            this.Radius = 1;
            this.RoundStyle = CCWin.SkinClass.RoundStyle.None;
            this.Shadow = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Special = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.pic_loading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPictureBox pic_loading;


    }
}