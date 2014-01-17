namespace Teleware.ZPG.Client.Controls
{
    partial class WaitControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_loading = new CCWin.SkinControl.SkinPanel();
            this.skinPictureBox3 = new CCWin.SkinControl.SkinPictureBox();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.skinPictureBox1 = new CCWin.SkinControl.SkinPictureBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.panel_loading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox3)).BeginInit();
            this.skinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_loading
            // 
            this.panel_loading.BackColor = System.Drawing.Color.Transparent;
            this.panel_loading.Controls.Add(this.skinPictureBox3);
            this.panel_loading.Controls.Add(this.skinLabel5);
            this.panel_loading.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel_loading.DownBack = null;
            this.panel_loading.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel_loading.Location = new System.Drawing.Point(240, 227);
            this.panel_loading.MouseBack = null;
            this.panel_loading.Name = "panel_loading";
            this.panel_loading.NormlBack = null;
            this.panel_loading.Size = new System.Drawing.Size(418, 40);
            this.panel_loading.TabIndex = 7;
            // 
            // skinPictureBox3
            // 
            this.skinPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinPictureBox3.Image = global::Teleware.ZPG.Client.Properties.Resources.loading;
            this.skinPictureBox3.Location = new System.Drawing.Point(1, 4);
            this.skinPictureBox3.Name = "skinPictureBox3";
            this.skinPictureBox3.Size = new System.Drawing.Size(32, 32);
            this.skinPictureBox3.TabIndex = 7;
            this.skinPictureBox3.TabStop = false;
            // 
            // skinLabel5
            // 
            this.skinLabel5.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(35, 8);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(361, 20);
            this.skinLabel5.TabIndex = 3;
            this.skinLabel5.Text = "交易结束，正在从服务器获取交易结果...";
            this.skinLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.skinPictureBox1);
            this.skinPanel1.Controls.Add(this.skinLabel1);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinPanel1.Location = new System.Drawing.Point(240, 289);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(418, 40);
            this.skinPanel1.TabIndex = 7;
            // 
            // skinPictureBox1
            // 
            this.skinPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinPictureBox1.Image = global::Teleware.ZPG.Client.Properties.Resources.loading;
            this.skinPictureBox1.Location = new System.Drawing.Point(1, 4);
            this.skinPictureBox1.Name = "skinPictureBox1";
            this.skinPictureBox1.Size = new System.Drawing.Size(32, 32);
            this.skinPictureBox1.TabIndex = 7;
            this.skinPictureBox1.TabStop = false;
            // 
            // skinLabel1
            // 
            this.skinLabel1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(35, 8);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(361, 20);
            this.skinLabel1.TabIndex = 3;
            this.skinLabel1.Text = "正在加载数据...";
            this.skinLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WaitControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.skinPanel1);
            this.Controls.Add(this.panel_loading);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "WaitControl";
            this.Size = new System.Drawing.Size(898, 494);
            this.panel_loading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox3)).EndInit();
            this.skinPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel panel_loading;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox3;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox1;
        private CCWin.SkinControl.SkinLabel skinLabel1;
    }
}
