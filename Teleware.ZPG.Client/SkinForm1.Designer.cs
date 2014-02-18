namespace Teleware.ZPG.Client
{
    partial class SkinForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkinForm1));
            this.SuspendLayout();
            // 
            // SkinForm1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Back = global::Teleware.ZPG.Client.Properties.Resources.background_mainwnd;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.BackShade = false;
            this.CanResize = false;
            this.CaptionHeight = 30;
            this.ClientSize = new System.Drawing.Size(677, 586);
            this.CloseBoxSize = new System.Drawing.Size(27, 22);
            this.CloseButtonToolTip = "关闭";
            this.CloseDownBack = global::Teleware.ZPG.Client.Properties.Resources.CloseDownBack;
            this.CloseMouseBack = global::Teleware.ZPG.Client.Properties.Resources.CloseMouseBack;
            this.CloseNormlBack = global::Teleware.ZPG.Client.Properties.Resources.CloseNormlBack;
            this.DropBack = false;
            this.EffectCaption = CCWin.TitleType.Title;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaxButtonToolTip = "最大化";
            this.MaxDownBack = global::Teleware.ZPG.Client.Properties.Resources.MaxDownBack;
            this.MaxMouseBack = global::Teleware.ZPG.Client.Properties.Resources.MaxMouseBack;
            this.MaxNormlBack = global::Teleware.ZPG.Client.Properties.Resources.MaxNormlBack;
            this.MaxSize = new System.Drawing.Size(27, 22);
            this.MinButtonToolTip = "最小化";
            this.MiniDownBack = global::Teleware.ZPG.Client.Properties.Resources.MiniDownBack;
            this.MiniMouseBack = global::Teleware.ZPG.Client.Properties.Resources.MiniMouseBack;
            this.MiniNormlBack = global::Teleware.ZPG.Client.Properties.Resources.MiniNormlBack;
            this.MiniSize = new System.Drawing.Size(27, 22);
            this.Name = "SkinForm1";
            this.RestoreButtonToolTip = "还原";
            this.RestoreDownBack = global::Teleware.ZPG.Client.Properties.Resources.RestoreDownBack;
            this.RestoreMouseBack = global::Teleware.ZPG.Client.Properties.Resources.RestoreMouseBack;
            this.RestoreNormlBack = global::Teleware.ZPG.Client.Properties.Resources.RestoreNormlBack;
            this.RoundStyle = CCWin.SkinClass.RoundStyle.None;
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SkinForm";
            this.TitleColor = System.Drawing.Color.White;
            this.ResumeLayout(false);

        }

        #endregion
    }
}