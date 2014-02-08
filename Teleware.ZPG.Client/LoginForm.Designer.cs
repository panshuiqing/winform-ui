namespace Teleware.ZPG.Client
{
    partial class LoginForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuUsers = new CCWin.SkinControl.SkinContextMenuStrip();
            this.skinToolTip1 = new CCWin.SkinToolTip(this.components);
            this.panel_login_btn = new CCWin.SkinControl.SkinPanel();
            this.imgLoadding = new CCWin.SkinControl.SkinPictureBox();
            this.btnDl = new CCWin.SkinControl.SkinButton();
            this.pnlImgTX = new CCWin.SkinControl.SkinPanel();
            this.txtPwd = new CCWin.SkinControl.SkinTextBox();
            this.btn_mima = new CCWin.SkinControl.SkinButton();
            this.btnZc = new CCWin.SkinControl.SkinButton();
            this.btnId = new CCWin.SkinControl.SkinButton();
            this.txtId = new CCWin.SkinControl.SkinTextBox();
            this.panelError = new CCWin.SkinControl.SkinPanel();
            this.pic_icon = new CCWin.SkinControl.SkinPictureBox();
            this.lab_info = new CCWin.SkinControl.SkinLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel_login_btn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadding)).BeginInit();
            this.txtPwd.SuspendLayout();
            this.txtId.SuspendLayout();
            this.panelError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon)).BeginInit();
            this.SuspendLayout();
            // 
            // menuUsers
            // 
            this.menuUsers.Arrow = System.Drawing.Color.Black;
            this.menuUsers.AutoSize = false;
            this.menuUsers.Back = System.Drawing.Color.White;
            this.menuUsers.BackRadius = 4;
            this.menuUsers.Base = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(165)))), ((int)(((byte)(215)))));
            this.menuUsers.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(181)))), ((int)(((byte)(229)))));
            this.menuUsers.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuUsers.Fore = System.Drawing.Color.Black;
            this.menuUsers.HoverFore = System.Drawing.Color.White;
            this.menuUsers.ImageScalingSize = new System.Drawing.Size(2, 2);
            this.menuUsers.ItemAnamorphosis = false;
            this.menuUsers.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(165)))), ((int)(((byte)(215)))));
            this.menuUsers.ItemBorderShow = false;
            this.menuUsers.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(165)))), ((int)(((byte)(215)))));
            this.menuUsers.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(165)))), ((int)(((byte)(215)))));
            this.menuUsers.ItemRadius = 4;
            this.menuUsers.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.menuUsers.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.menuUsers.Name = "menuUsers";
            this.menuUsers.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.menuUsers.ShowImageMargin = false;
            this.menuUsers.Size = new System.Drawing.Size(183, 18);
            this.menuUsers.SkinAllColor = false;
            this.menuUsers.TitleAnamorphosis = false;
            this.menuUsers.TitleColor = System.Drawing.Color.White;
            this.menuUsers.TitleRadius = 4;
            this.menuUsers.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.menuUsers.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.menuUsers_Closing);
            // 
            // skinToolTip1
            // 
            this.skinToolTip1.AutoPopDelay = 5000;
            this.skinToolTip1.Image = global::Teleware.ZPG.Client.Properties.Resources.store_guide_bkg;
            this.skinToolTip1.InitialDelay = 500;
            this.skinToolTip1.OwnerDraw = true;
            this.skinToolTip1.ReshowDelay = 800;
            this.skinToolTip1.TitleFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.skinToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.skinToolTip1.ToolTipTitle = "111";
            // 
            // panel_login_btn
            // 
            this.panel_login_btn.BackColor = System.Drawing.Color.Transparent;
            this.panel_login_btn.Controls.Add(this.imgLoadding);
            this.panel_login_btn.Controls.Add(this.btnDl);
            this.panel_login_btn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel_login_btn.DownBack = null;
            this.panel_login_btn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel_login_btn.Location = new System.Drawing.Point(2, 240);
            this.panel_login_btn.MouseBack = null;
            this.panel_login_btn.Name = "panel_login_btn";
            this.panel_login_btn.NormlBack = null;
            this.panel_login_btn.Size = new System.Drawing.Size(356, 50);
            this.panel_login_btn.TabIndex = 36;
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
            this.btnDl.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.btnDl.Click += new System.EventHandler(this.btnDl_Click);
            // 
            // pnlImgTX
            // 
            this.pnlImgTX.BackColor = System.Drawing.Color.Transparent;
            this.pnlImgTX.BackgroundImage = global::Teleware.ZPG.Client.Properties.Resources.head;
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
            this.pnlImgTX.TabIndex = 11;
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
            this.txtPwd.TabIndex = 33;
            this.txtPwd.IconClick += new System.EventHandler(this.txtPwd_IconClick);
            // 
            // btn_mima
            // 
            this.btn_mima.BackColor = System.Drawing.Color.Transparent;
            this.btn_mima.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.btn_mima.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_mima.Create = true;
            this.btn_mima.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_mima.DownBack = global::Teleware.ZPG.Client.Properties.Resources.btn_mima_press;
            this.btn_mima.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btn_mima.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_mima.Location = new System.Drawing.Point(287, 180);
            this.btn_mima.Margin = new System.Windows.Forms.Padding(0);
            this.btn_mima.MouseBack = global::Teleware.ZPG.Client.Properties.Resources.btn_mima_hover;
            this.btn_mima.Name = "btn_mima";
            this.btn_mima.NormlBack = global::Teleware.ZPG.Client.Properties.Resources.btn_mima_normal;
            this.btn_mima.Size = new System.Drawing.Size(51, 16);
            this.btn_mima.TabIndex = 6;
            this.btn_mima.UseVisualStyleBackColor = false;
            // 
            // btnZc
            // 
            this.btnZc.BackColor = System.Drawing.Color.Transparent;
            this.btnZc.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.btnZc.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnZc.Create = true;
            this.btnZc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZc.DownBack = global::Teleware.ZPG.Client.Properties.Resources.btn_zhuce_press;
            this.btnZc.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnZc.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnZc.Location = new System.Drawing.Point(288, 145);
            this.btnZc.Margin = new System.Windows.Forms.Padding(0);
            this.btnZc.MouseBack = global::Teleware.ZPG.Client.Properties.Resources.btn_zhuce_hover;
            this.btnZc.Name = "btnZc";
            this.btnZc.NormlBack = global::Teleware.ZPG.Client.Properties.Resources.btn_zhuce_normal;
            this.btnZc.Size = new System.Drawing.Size(51, 16);
            this.btnZc.TabIndex = 6;
            this.btnZc.UseVisualStyleBackColor = false;
            // 
            // btnId
            // 
            this.btnId.BackColor = System.Drawing.Color.White;
            this.btnId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnId.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnId.DownBack = global::Teleware.ZPG.Client.Properties.Resources.btn_allow_up;
            this.btnId.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnId.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnId.Location = new System.Drawing.Point(255, 141);
            this.btnId.Margin = new System.Windows.Forms.Padding(0);
            this.btnId.MouseBack = global::Teleware.ZPG.Client.Properties.Resources.btn_allow_down_hover;
            this.btnId.Name = "btnId";
            this.btnId.NormlBack = global::Teleware.ZPG.Client.Properties.Resources.btn_allow_down_normal;
            this.btnId.Size = new System.Drawing.Size(22, 24);
            this.btnId.TabIndex = 37;
            this.btnId.UseVisualStyleBackColor = false;
            this.btnId.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnId_MouseDown);
            this.btnId.MouseEnter += new System.EventHandler(this.btnId_MouseEnter);
            this.btnId.MouseLeave += new System.EventHandler(this.btnId_MouseLeave);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.Transparent;
            this.txtId.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtId.Icon = null;
            this.txtId.IconIsButton = false;
            this.txtId.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtId.Location = new System.Drawing.Point(94, 139);
            this.txtId.Margin = new System.Windows.Forms.Padding(0);
            this.txtId.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtId.MouseBack = null;
            this.txtId.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtId.Name = "txtId";
            this.txtId.NormlBack = null;
            this.txtId.Padding = new System.Windows.Forms.Padding(5, 5, 28, 5);
            this.txtId.Size = new System.Drawing.Size(185, 28);
            // 
            // txtId.BaseText
            // 
            this.txtId.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtId.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtId.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtId.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtId.SkinTxt.Name = "BaseText";
            this.txtId.SkinTxt.Size = new System.Drawing.Size(152, 18);
            this.txtId.SkinTxt.TabIndex = 0;
            this.txtId.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtId.SkinTxt.WaterText = "竞买号";
            this.txtId.TabIndex = 32;
            // 
            // panelError
            // 
            this.panelError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(243)))), ((int)(((byte)(212)))));
            this.panelError.Controls.Add(this.pic_icon);
            this.panelError.Controls.Add(this.lab_info);
            this.panelError.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelError.DownBack = null;
            this.panelError.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelError.Location = new System.Drawing.Point(2, 211);
            this.panelError.MouseBack = null;
            this.panelError.Name = "panelError";
            this.panelError.NormlBack = null;
            this.panelError.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.panelError.Size = new System.Drawing.Size(356, 28);
            this.panelError.TabIndex = 35;
            // 
            // pic_icon
            // 
            this.pic_icon.BackColor = System.Drawing.Color.Transparent;
            this.pic_icon.BackgroundImage = global::Teleware.ZPG.Client.Properties.Resources.tipicon;
            this.pic_icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_icon.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pic_icon.Location = new System.Drawing.Point(3, 7);
            this.pic_icon.Name = "pic_icon";
            this.pic_icon.Size = new System.Drawing.Size(16, 16);
            this.pic_icon.TabIndex = 2;
            this.pic_icon.TabStop = false;
            // 
            // lab_info
            // 
            this.lab_info.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lab_info.BackColor = System.Drawing.Color.Transparent;
            this.lab_info.BorderColor = System.Drawing.Color.White;
            this.lab_info.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_info.Location = new System.Drawing.Point(20, 6);
            this.lab_info.Name = "lab_info";
            this.lab_info.Size = new System.Drawing.Size(286, 16);
            this.lab_info.TabIndex = 0;
            this.lab_info.Text = "登录失败，用户名或密码错误";
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackPalace = global::Teleware.ZPG.Client.Properties.Resources.BackPalace;
            this.ClientSize = new System.Drawing.Size(360, 292);
            this.Controls.Add(this.panel_login_btn);
            this.Controls.Add(this.pnlImgTX);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.btn_mima);
            this.Controls.Add(this.btnZc);
            this.Controls.Add(this.btnId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.panelError);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Shadow = true;
            this.ShadowWidth = 1;
            this.ShowInTaskbar = false;
            this.Text = "";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel_login_btn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadding)).EndInit();
            this.txtPwd.ResumeLayout(false);
            this.txtPwd.PerformLayout();
            this.txtId.ResumeLayout(false);
            this.txtId.PerformLayout();
            this.panelError.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel pnlImgTX;
        private CCWin.SkinControl.SkinTextBox txtId;
        private CCWin.SkinControl.SkinButton btnZc;
        private CCWin.SkinControl.SkinButton btn_mima;
        private CCWin.SkinControl.SkinTextBox txtPwd;
        private CCWin.SkinControl.SkinPictureBox imgLoadding;
        private CCWin.SkinControl.SkinButton btnDl;
        private CCWin.SkinControl.SkinPanel panelError;
        private CCWin.SkinControl.SkinLabel lab_info;
        private CCWin.SkinControl.SkinPictureBox pic_icon;
        private CCWin.SkinControl.SkinContextMenuStrip menuUsers;
        private CCWin.SkinControl.SkinPanel panel_login_btn;
        private CCWin.SkinControl.SkinButton btnId;
        private CCWin.SkinToolTip skinToolTip1;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}

