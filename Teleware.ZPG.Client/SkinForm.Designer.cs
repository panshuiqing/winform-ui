namespace Teleware.ZPG.Client
{
    partial class SkinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkinForm));
            this.SuspendLayout();
            // 
            // SkinForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(181)))), ((int)(((byte)(229)))));
            this.BorderPalace = global::Teleware.ZPG.Client.Properties.Resources.form_border;
            this.CanResize = false;
            this.CaptionHeight = 30;
            this.ClientSize = new System.Drawing.Size(405, 408);
            this.CloseBoxSize = new System.Drawing.Size(39, 20);
            this.CloseButtonToolTip = "关闭";
            this.CloseDownBack = global::Teleware.ZPG.Client.Properties.Resources.form_close_down;
            this.CloseMouseBack = global::Teleware.ZPG.Client.Properties.Resources.form_close_hover;
            this.CloseNormlBack = global::Teleware.ZPG.Client.Properties.Resources.form_close_normal;
            this.ControlBoxOffset = new System.Drawing.Point(-2, -1);
            this.DropBack = false;
            this.EffectCaption = CCWin.TitleType.Title;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaxButtonToolTip = "最大化";
            this.MaxDownBack = global::Teleware.ZPG.Client.Properties.Resources.form_max_down;
            this.MaxMouseBack = global::Teleware.ZPG.Client.Properties.Resources.form_max_hover;
            this.MaxNormlBack = global::Teleware.ZPG.Client.Properties.Resources.form_max_normal;
            this.MaxSize = new System.Drawing.Size(28, 20);
            this.MinButtonToolTip = "最小化";
            this.MiniDownBack = global::Teleware.ZPG.Client.Properties.Resources.form_min_down;
            this.MiniMouseBack = global::Teleware.ZPG.Client.Properties.Resources.form_min_hover;
            this.MiniNormlBack = global::Teleware.ZPG.Client.Properties.Resources.form_min_normal;
            this.MiniSize = new System.Drawing.Size(28, 20);
            this.Name = "SkinForm";
            this.RestoreButtonToolTip = "还原";
            this.RestoreDownBack = global::Teleware.ZPG.Client.Properties.Resources.form_restore_down;
            this.RestoreMouseBack = global::Teleware.ZPG.Client.Properties.Resources.form_restore_hover;
            this.RestoreNormlBack = global::Teleware.ZPG.Client.Properties.Resources.form_restore_normal;
            this.ShadowWidth = 6;
            this.ShowDrawIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SkinForm";
            this.TitleColor = System.Drawing.Color.White;
            this.ResumeLayout(false);

        }

        #endregion
    }
}