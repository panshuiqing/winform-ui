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
            this.panel_login_btn = new CCWin.SkinControl.SkinPanel();
            this.imgLoadding = new CCWin.SkinControl.SkinPictureBox();
            this.btnDl = new CCWin.SkinControl.SkinButton();
            this.btn_findPassword = new CCWin.SkinControl.SkinButton();
            this.btn_zc = new CCWin.SkinControl.SkinButton();
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            this.skinTextBox1 = new CCWin.SkinControl.SkinTextBox();
            this.pnlImgTX = new CCWin.SkinControl.SkinPanel();
            this.txtPwd = new CCWin.SkinControl.SkinTextBox();
            this.panel_login_btn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadding)).BeginInit();
            this.skinTextBox1.SuspendLayout();
            this.txtPwd.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_login_btn
            // 
            this.panel_login_btn.BackColor = System.Drawing.Color.Transparent;
            this.panel_login_btn.Controls.Add(this.imgLoadding);
            this.panel_login_btn.Controls.Add(this.btnDl);
            this.panel_login_btn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel_login_btn.DownBack = null;
            this.panel_login_btn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel_login_btn.Location = new System.Drawing.Point(2, 218);
            this.panel_login_btn.MouseBack = null;
            this.panel_login_btn.Name = "panel_login_btn";
            this.panel_login_btn.NormlBack = null;
            this.panel_login_btn.Size = new System.Drawing.Size(356, 50);
            this.panel_login_btn.TabIndex = 37;
            // 
            // imgLoadding
            // 
            this.imgLoadding.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.imgLoadding.Dock = System.Windows.Forms.DockStyle.Top;
            this.imgLoadding.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imgLoadding.Image = global::Teleware.ZPG.Client.Properties.Resources.imgLoadding;
            this.imgLoadding.Location = new System.Drawing.Point(0, 0);
            this.imgLoadding.Margin = new System.Windows.Forms.Padding(0);
            this.imgLoadding.Name = "imgLoadding";
            this.imgLoadding.Size = new System.Drawing.Size(356, 2);
            this.imgLoadding.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoadding.TabIndex = 34;
            this.imgLoadding.TabStop = false;
            this.imgLoadding.Visible = false;
            // 
            // btnDl
            // 
            this.btnDl.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDl.BackColor = System.Drawing.Color.Transparent;
            this.btnDl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDl.BackRectangle = new System.Drawing.Rectangle(50, 23, 50, 23);
            this.btnDl.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.btnDl.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnDl.DownBack = global::Teleware.ZPG.Client.Properties.Resources.btn_login_down;
            this.btnDl.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnDl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDl.Location = new System.Drawing.Point(111, 6);
            this.btnDl.Margin = new System.Windows.Forms.Padding(0);
            this.btnDl.MouseBack = global::Teleware.ZPG.Client.Properties.Resources.btn_login_hover;
            this.btnDl.Name = "btnDl";
            this.btnDl.NormlBack = global::Teleware.ZPG.Client.Properties.Resources.btn_login_normal;
            this.btnDl.Palace = true;
            this.btnDl.Size = new System.Drawing.Size(162, 38);
            this.btnDl.TabIndex = 8;
            this.btnDl.Text = "登        录";
            this.btnDl.UseVisualStyleBackColor = false;
            // 
            // btn_findPassword
            // 
            this.btn_findPassword.BackColor = System.Drawing.Color.Transparent;
            this.btn_findPassword.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_findPassword.DownBack = global::Teleware.ZPG.Client.Properties.Resources.btn_mima_press;
            this.btn_findPassword.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btn_findPassword.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_findPassword.Location = new System.Drawing.Point(287, 180);
            this.btn_findPassword.MouseBack = global::Teleware.ZPG.Client.Properties.Resources.btn_mima_hover;
            this.btn_findPassword.Name = "btn_findPassword";
            this.btn_findPassword.NormlBack = global::Teleware.ZPG.Client.Properties.Resources.btn_mima_normal;
            this.btn_findPassword.Size = new System.Drawing.Size(51, 16);
            this.btn_findPassword.TabIndex = 15;
            this.btn_findPassword.UseVisualStyleBackColor = false;
            // 
            // btn_zc
            // 
            this.btn_zc.BackColor = System.Drawing.Color.Transparent;
            this.btn_zc.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_zc.DownBack = global::Teleware.ZPG.Client.Properties.Resources.btn_zhuce_press;
            this.btn_zc.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btn_zc.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_zc.Location = new System.Drawing.Point(288, 145);
            this.btn_zc.MouseBack = global::Teleware.ZPG.Client.Properties.Resources.btn_zhuce_hover;
            this.btn_zc.Name = "btn_zc";
            this.btn_zc.NormlBack = global::Teleware.ZPG.Client.Properties.Resources.btn_zhuce_normal;
            this.btn_zc.Size = new System.Drawing.Size(51, 16);
            this.btn_zc.TabIndex = 15;
            this.btn_zc.UseVisualStyleBackColor = false;
            // 
            // skinButton1
            // 
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.DownBack = global::Teleware.ZPG.Client.Properties.Resources.btn_allow_up;
            this.skinButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton1.Location = new System.Drawing.Point(255, 141);
            this.skinButton1.MouseBack = global::Teleware.ZPG.Client.Properties.Resources.btn_allow_down_hover;
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = global::Teleware.ZPG.Client.Properties.Resources.btn_allow_down_normal;
            this.skinButton1.Size = new System.Drawing.Size(22, 24);
            this.skinButton1.TabIndex = 14;
            this.skinButton1.UseVisualStyleBackColor = false;
            // 
            // skinTextBox1
            // 
            this.skinTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinTextBox1.Icon = null;
            this.skinTextBox1.IconIsButton = false;
            this.skinTextBox1.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox1.Location = new System.Drawing.Point(94, 139);
            this.skinTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox1.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox1.MouseBack = null;
            this.skinTextBox1.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox1.Name = "skinTextBox1";
            this.skinTextBox1.NormlBack = null;
            this.skinTextBox1.Padding = new System.Windows.Forms.Padding(5, 5, 28, 5);
            this.skinTextBox1.Size = new System.Drawing.Size(185, 28);
            // 
            // skinTextBox1.BaseText
            // 
            this.skinTextBox1.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox1.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox1.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox1.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox1.SkinTxt.Name = "BaseText";
            this.skinTextBox1.SkinTxt.Size = new System.Drawing.Size(152, 18);
            this.skinTextBox1.SkinTxt.TabIndex = 0;
            this.skinTextBox1.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox1.SkinTxt.WaterText = "";
            this.skinTextBox1.TabIndex = 13;
            // 
            // pnlImgTX
            // 
            this.pnlImgTX.BackColor = System.Drawing.Color.Transparent;
            this.pnlImgTX.BackgroundImage = global::Teleware.ZPG.Client.Properties.Resources.head_60x60;
            this.pnlImgTX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlImgTX.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.pnlImgTX.DownBack = null;
            this.pnlImgTX.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlImgTX.Location = new System.Drawing.Point(24, 139);
            this.pnlImgTX.Margin = new System.Windows.Forms.Padding(0);
            this.pnlImgTX.MouseBack = null;
            this.pnlImgTX.Name = "pnlImgTX";
            this.pnlImgTX.NormlBack = null;
            this.pnlImgTX.Radius = 4;
            this.pnlImgTX.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.pnlImgTX.Size = new System.Drawing.Size(60, 60);
            this.pnlImgTX.TabIndex = 12;
            // 
            // txtPwd
            // 
            this.txtPwd.BackColor = System.Drawing.Color.Transparent;
            this.txtPwd.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtPwd.Icon = global::Teleware.ZPG.Client.Properties.Resources.btn_keyboard;
            this.txtPwd.IconIsButton = true;
            this.txtPwd.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtPwd.Location = new System.Drawing.Point(94, 174);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(0);
            this.txtPwd.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtPwd.MouseBack = null;
            this.txtPwd.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.NormlBack = null;
            this.txtPwd.Padding = new System.Windows.Forms.Padding(5, 5, 28, 5);
            this.txtPwd.Size = new System.Drawing.Size(185, 28);
            // 
            // txtPwd.BaseText
            // 
            this.txtPwd.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPwd.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPwd.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtPwd.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtPwd.SkinTxt.Name = "BaseText";
            this.txtPwd.SkinTxt.PasswordChar = '*';
            this.txtPwd.SkinTxt.Size = new System.Drawing.Size(152, 18);
            this.txtPwd.SkinTxt.TabIndex = 0;
            this.txtPwd.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtPwd.SkinTxt.WaterText = "密码";
            this.txtPwd.TabIndex = 38;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Teleware.ZPG.Client.Properties.Resources.bg_default;
            this.BackPalace = global::Teleware.ZPG.Client.Properties.Resources.BackPalace;
            this.BorderPalace = global::Teleware.ZPG.Client.Properties.Resources.form_border;
            this.ClientSize = new System.Drawing.Size(360, 270);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.panel_login_btn);
            this.Controls.Add(this.btn_findPassword);
            this.Controls.Add(this.btn_zc);
            this.Controls.Add(this.skinButton1);
            this.Controls.Add(this.skinTextBox1);
            this.Controls.Add(this.pnlImgTX);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form2";
            this.Text = "Form2";
            this.panel_login_btn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadding)).EndInit();
            this.skinTextBox1.ResumeLayout(false);
            this.skinTextBox1.PerformLayout();
            this.txtPwd.ResumeLayout(false);
            this.txtPwd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel pnlImgTX;
        private CCWin.SkinControl.SkinTextBox skinTextBox1;
        private CCWin.SkinControl.SkinButton skinButton1;
        private CCWin.SkinControl.SkinButton btn_zc;
        private CCWin.SkinControl.SkinButton btn_findPassword;
        private CCWin.SkinControl.SkinPanel panel_login_btn;
        private CCWin.SkinControl.SkinPictureBox imgLoadding;
        private CCWin.SkinControl.SkinButton btnDl;
        private CCWin.SkinControl.SkinTextBox txtPwd;
    }
}