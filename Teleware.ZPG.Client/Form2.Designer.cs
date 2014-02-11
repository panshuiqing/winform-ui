using Teleware.ZPG.Client.Controls;
namespace Teleware.ZPG.Client
{
    partial class Form2
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
            this.tradeHangControl1 = new Teleware.ZPG.Client.Module.TradeHangControl();
            this.SuspendLayout();
            // 
            // tradeHangControl1
            // 
            this.tradeHangControl1.BackColor = System.Drawing.Color.Transparent;
            this.tradeHangControl1.Location = new System.Drawing.Point(0, 0);
            this.tradeHangControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tradeHangControl1.Name = "tradeHangControl1";
            this.tradeHangControl1.Size = new System.Drawing.Size(898, 494);
            this.tradeHangControl1.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(886, 594);
            this.Controls.Add(this.tradeHangControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Deactivate += new System.EventHandler(this.Form2_Deactivate);
            this.ResumeLayout(false);

        }

        #endregion

        private Teleware.ZPG.Client.Module.TradeHangControl tradeHangControl1;


    }
}