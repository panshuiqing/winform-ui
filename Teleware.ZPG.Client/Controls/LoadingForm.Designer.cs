namespace Teleware.ZPG.Client.Controls
{
    partial class LoadingForm
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
            this.skinPictureBox1 = new CCWin.SkinControl.SkinPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // skinPictureBox1
            // 
            this.skinPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinPictureBox1.Image = global::Teleware.ZPG.Client.Properties.Resources.loading;
            this.skinPictureBox1.Location = new System.Drawing.Point(108, 20);
            this.skinPictureBox1.Name = "skinPictureBox1";
            this.skinPictureBox1.Size = new System.Drawing.Size(31, 31);
            this.skinPictureBox1.TabIndex = 0;
            this.skinPictureBox1.TabStop = false;
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackShade = false;
            this.BackToColor = false;
            this.BorderPalace = null;
            this.CaptionHeight = 4;
            this.ClientSize = new System.Drawing.Size(300, 90);
            this.ControlBox = false;
            this.Controls.Add(this.skinPictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Mobile = CCWin.MobileStyle.None;
            this.Name = "LoadingForm";
            this.Radius = 1;
            this.RoundStyle = CCWin.SkinClass.RoundStyle.None;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPictureBox skinPictureBox1;


    }
}