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
            this.unStartControl1 = new Teleware.ZPG.Client.Controls.TradeUnStartControl();
            this.SuspendLayout();
            // 
            // unStartControl1
            // 
            this.unStartControl1.BackColor = System.Drawing.Color.Transparent;
            this.unStartControl1.Location = new System.Drawing.Point(46, 81);
            this.unStartControl1.Name = "unStartControl1";
            this.unStartControl1.Size = new System.Drawing.Size(898, 494);
            this.unStartControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 722);
            this.Controls.Add(this.unStartControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TradeUnStartControl unStartControl1;


    }
}