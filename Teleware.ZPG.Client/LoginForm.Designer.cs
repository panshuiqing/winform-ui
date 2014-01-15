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
            this.pnlTX = new CCWin.SkinControl.SkinPanel();
            this.pnlImgTX = new CCWin.SkinControl.SkinPanel();
            this.txtId = new CCWin.SkinControl.SkinTextBox();
            this.btnId = new CCWin.SkinControl.SkinButton();
            this.btnZc = new CCWin.SkinControl.SkinButton();
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            this.txtPwd = new CCWin.SkinControl.SkinTextBox();
            this.skinCheckBox1 = new CCWin.SkinControl.SkinCheckBox();
            this.skinCheckBox2 = new CCWin.SkinControl.SkinCheckBox();
            this.imgLoadding = new CCWin.SkinControl.SkinPictureBox();
            this.btnDl = new CCWin.SkinControl.SkinButton();
            this.panelError = new CCWin.SkinControl.SkinPanel();
            this.skinPictureBox1 = new CCWin.SkinControl.SkinPictureBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinButton2 = new CCWin.SkinControl.SkinButton();
            this.menuUsers = new CCWin.SkinControl.SkinContextMenuStrip();
            this.pnlTX.SuspendLayout();
            this.txtId.SuspendLayout();
            this.txtPwd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadding)).BeginInit();
            this.panelError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTX
            // 
            this.pnlTX.BackColor = System.Drawing.Color.Transparent;
            this.pnlTX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlTX.Controls.Add(this.pnlImgTX);
            this.pnlTX.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.pnlTX.DownBack = null;
            this.pnlTX.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTX.Location = new System.Drawing.Point(15, 140);
            this.pnlTX.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTX.MouseBack = null;
            this.pnlTX.Name = "pnlTX";
            this.pnlTX.NormlBack = null;
            this.pnlTX.Size = new System.Drawing.Size(87, 87);
            this.pnlTX.TabIndex = 12;
            // 
            // pnlImgTX
            // 
            this.pnlImgTX.BackColor = System.Drawing.Color.Transparent;
            this.pnlImgTX.BackgroundImage = global::Teleware.ZPG.Client.Properties.Resources.head;
            this.pnlImgTX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlImgTX.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.pnlImgTX.DownBack = null;
            this.pnlImgTX.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlImgTX.Location = new System.Drawing.Point(1, 1);
            this.pnlImgTX.Margin = new System.Windows.Forms.Padding(0);
            this.pnlImgTX.MouseBack = null;
            this.pnlImgTX.Name = "pnlImgTX";
            this.pnlImgTX.NormlBack = null;
            this.pnlImgTX.Radius = 4;
            this.pnlImgTX.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.pnlImgTX.Size = new System.Drawing.Size(85, 85);
            this.pnlImgTX.TabIndex = 11;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.Transparent;
            this.txtId.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtId.Icon = null;
            this.txtId.IconIsButton = false;
            this.txtId.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtId.Location = new System.Drawing.Point(112, 139);
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
            // btnId
            // 
            this.btnId.BackColor = System.Drawing.Color.White;
            this.btnId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnId.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.btnId.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnId.DownBack = global::Teleware.ZPG.Client.Properties.Resources.btn_up;
            this.btnId.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnId.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnId.Location = new System.Drawing.Point(273, 141);
            this.btnId.Margin = new System.Windows.Forms.Padding(0);
            this.btnId.MouseBack = global::Teleware.ZPG.Client.Properties.Resources.btn_down_hover;
            this.btnId.Name = "btnId";
            this.btnId.NormlBack = global::Teleware.ZPG.Client.Properties.Resources.btn_down_normal;
            this.btnId.Size = new System.Drawing.Size(22, 24);
            this.btnId.TabIndex = 5;
            this.btnId.UseVisualStyleBackColor = false;
            this.btnId.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnId_MouseDown);
            this.btnId.MouseEnter += new System.EventHandler(this.btnId_MouseEnter);
            this.btnId.MouseLeave += new System.EventHandler(this.btnId_MouseLeave);
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
            this.btnZc.Location = new System.Drawing.Point(309, 145);
            this.btnZc.Margin = new System.Windows.Forms.Padding(0);
            this.btnZc.MouseBack = global::Teleware.ZPG.Client.Properties.Resources.btn_zhuce_hover;
            this.btnZc.Name = "btnZc";
            this.btnZc.NormlBack = global::Teleware.ZPG.Client.Properties.Resources.btn_zhuce_normal;
            this.btnZc.Size = new System.Drawing.Size(51, 16);
            this.btnZc.TabIndex = 6;
            this.btnZc.UseVisualStyleBackColor = false;
            // 
            // skinButton1
            // 
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.Create = true;
            this.skinButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.skinButton1.DownBack = global::Teleware.ZPG.Client.Properties.Resources.btn_mima_press;
            this.skinButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton1.Location = new System.Drawing.Point(308, 180);
            this.skinButton1.Margin = new System.Windows.Forms.Padding(0);
            this.skinButton1.MouseBack = global::Teleware.ZPG.Client.Properties.Resources.btn_mima_hover;
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = global::Teleware.ZPG.Client.Properties.Resources.btn_mima_normal;
            this.skinButton1.Size = new System.Drawing.Size(51, 16);
            this.skinButton1.TabIndex = 6;
            this.skinButton1.UseVisualStyleBackColor = false;
            // 
            // txtPwd
            // 
            this.txtPwd.BackColor = System.Drawing.Color.Transparent;
            this.txtPwd.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtPwd.Icon = global::Teleware.ZPG.Client.Properties.Resources.btn_keyboard;
            this.txtPwd.IconIsButton = true;
            this.txtPwd.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtPwd.Location = new System.Drawing.Point(112, 174);
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
            // skinCheckBox1
            // 
            this.skinCheckBox1.AutoSize = true;
            this.skinCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox1.DefaultCheckButtonWidth = 15;
            this.skinCheckBox1.DownBack = null;
            this.skinCheckBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox1.ForeColor = System.Drawing.Color.Black;
            this.skinCheckBox1.LightEffect = false;
            this.skinCheckBox1.Location = new System.Drawing.Point(112, 208);
            this.skinCheckBox1.MouseBack = null;
            this.skinCheckBox1.Name = "skinCheckBox1";
            this.skinCheckBox1.NormlBack = null;
            this.skinCheckBox1.SelectedDownBack = null;
            this.skinCheckBox1.SelectedMouseBack = null;
            this.skinCheckBox1.SelectedNormlBack = null;
            this.skinCheckBox1.Size = new System.Drawing.Size(75, 21);
            this.skinCheckBox1.TabIndex = 3;
            this.skinCheckBox1.Text = "记住密码";
            this.skinCheckBox1.UseVisualStyleBackColor = false;
            // 
            // skinCheckBox2
            // 
            this.skinCheckBox2.AutoSize = true;
            this.skinCheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox2.DefaultCheckButtonWidth = 15;
            this.skinCheckBox2.DownBack = null;
            this.skinCheckBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox2.ForeColor = System.Drawing.Color.Black;
            this.skinCheckBox2.LightEffect = false;
            this.skinCheckBox2.Location = new System.Drawing.Point(193, 208);
            this.skinCheckBox2.MouseBack = null;
            this.skinCheckBox2.Name = "skinCheckBox2";
            this.skinCheckBox2.NormlBack = null;
            this.skinCheckBox2.SelectedDownBack = null;
            this.skinCheckBox2.SelectedMouseBack = null;
            this.skinCheckBox2.SelectedNormlBack = null;
            this.skinCheckBox2.Size = new System.Drawing.Size(75, 21);
            this.skinCheckBox2.TabIndex = 4;
            this.skinCheckBox2.Text = "自动登录";
            this.skinCheckBox2.UseVisualStyleBackColor = false;
            // 
            // imgLoadding
            // 
            this.imgLoadding.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.imgLoadding.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imgLoadding.Image = global::Teleware.ZPG.Client.Properties.Resources.imgLoadding;
            this.imgLoadding.Location = new System.Drawing.Point(1, 242);
            this.imgLoadding.Margin = new System.Windows.Forms.Padding(0);
            this.imgLoadding.Name = "imgLoadding";
            this.imgLoadding.Size = new System.Drawing.Size(377, 2);
            this.imgLoadding.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoadding.TabIndex = 34;
            this.imgLoadding.TabStop = false;
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
            this.btnDl.Location = new System.Drawing.Point(112, 248);
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
            // panelError
            // 
            this.panelError.BackColor = System.Drawing.Color.Transparent;
            this.panelError.Controls.Add(this.skinPictureBox1);
            this.panelError.Controls.Add(this.skinLabel1);
            this.panelError.Controls.Add(this.skinButton2);
            this.panelError.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelError.DownBack = null;
            this.panelError.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelError.Location = new System.Drawing.Point(1, 245);
            this.panelError.MouseBack = null;
            this.panelError.Name = "panelError";
            this.panelError.NormlBack = null;
            this.panelError.Size = new System.Drawing.Size(378, 28);
            this.panelError.TabIndex = 35;
            this.panelError.Visible = false;
            // 
            // skinPictureBox1
            // 
            this.skinPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox1.BackgroundImage = global::Teleware.ZPG.Client.Properties.Resources.icon_info;
            this.skinPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.skinPictureBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinPictureBox1.Location = new System.Drawing.Point(3, 6);
            this.skinPictureBox1.Name = "skinPictureBox1";
            this.skinPictureBox1.Size = new System.Drawing.Size(16, 16);
            this.skinPictureBox1.TabIndex = 2;
            this.skinPictureBox1.TabStop = false;
            // 
            // skinLabel1
            // 
            this.skinLabel1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(25, 4);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(326, 20);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = "登录失败，用户名或密码错误";
            this.skinLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // skinButton2
            // 
            this.skinButton2.BackColor = System.Drawing.Color.Transparent;
            this.skinButton2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton2.DownBack = null;
            this.skinButton2.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton2.Location = new System.Drawing.Point(352, 1);
            this.skinButton2.MouseBack = null;
            this.skinButton2.Name = "skinButton2";
            this.skinButton2.NormlBack = null;
            this.skinButton2.Size = new System.Drawing.Size(22, 24);
            this.skinButton2.TabIndex = 1;
            this.skinButton2.UseVisualStyleBackColor = false;
            this.skinButton2.Click += new System.EventHandler(this.skinButton2_Click);
            // 
            // menuUsers
            // 
            this.menuUsers.Arrow = System.Drawing.Color.Black;
            this.menuUsers.AutoSize = false;
            this.menuUsers.Back = System.Drawing.Color.White;
            this.menuUsers.BackRadius = 4;
            this.menuUsers.Base = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(181)))), ((int)(((byte)(229)))));
            this.menuUsers.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(181)))), ((int)(((byte)(229)))));
            this.menuUsers.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuUsers.Fore = System.Drawing.Color.Black;
            this.menuUsers.HoverFore = System.Drawing.Color.White;
            this.menuUsers.ImageScalingSize = new System.Drawing.Size(2, 2);
            this.menuUsers.ItemAnamorphosis = false;
            this.menuUsers.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(181)))), ((int)(((byte)(229)))));
            this.menuUsers.ItemBorderShow = false;
            this.menuUsers.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(181)))), ((int)(((byte)(229)))));
            this.menuUsers.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(181)))), ((int)(((byte)(229)))));
            this.menuUsers.ItemRadius = 4;
            this.menuUsers.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.menuUsers.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.menuUsers.Name = "menuUsers";
            this.menuUsers.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.menuUsers.ShowImageMargin = false;
            this.menuUsers.Size = new System.Drawing.Size(183, 4);
            this.menuUsers.SkinAllColor = false;
            this.menuUsers.TitleAnamorphosis = false;
            this.menuUsers.TitleColor = System.Drawing.Color.White;
            this.menuUsers.TitleRadius = 4;
            this.menuUsers.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.menuUsers.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.menuUsers_Closing);
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackPalace = global::Teleware.ZPG.Client.Properties.Resources.BackPalace;
            this.ClientSize = new System.Drawing.Size(380, 292);
            this.Controls.Add(this.panelError);
            this.Controls.Add(this.btnDl);
            this.Controls.Add(this.imgLoadding);
            this.Controls.Add(this.skinCheckBox2);
            this.Controls.Add(this.skinCheckBox1);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.skinButton1);
            this.Controls.Add(this.btnZc);
            this.Controls.Add(this.btnId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.pnlTX);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.ShowInTaskbar = false;
            this.Text = "";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.pnlTX.ResumeLayout(false);
            this.txtId.ResumeLayout(false);
            this.txtId.PerformLayout();
            this.txtPwd.ResumeLayout(false);
            this.txtPwd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadding)).EndInit();
            this.panelError.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinPanel pnlTX;
        private CCWin.SkinControl.SkinPanel pnlImgTX;
        private CCWin.SkinControl.SkinTextBox txtId;
        private CCWin.SkinControl.SkinButton btnId;
        private CCWin.SkinControl.SkinButton btnZc;
        private CCWin.SkinControl.SkinButton skinButton1;
        private CCWin.SkinControl.SkinTextBox txtPwd;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox1;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox2;
        private CCWin.SkinControl.SkinPictureBox imgLoadding;
        private CCWin.SkinControl.SkinButton btnDl;
        private CCWin.SkinControl.SkinPanel panelError;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinButton skinButton2;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox1;
        private CCWin.SkinControl.SkinContextMenuStrip menuUsers;

    }
}

