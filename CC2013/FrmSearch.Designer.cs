/********************************************************************
 * *
 * * 使本项目源码或本项目生成的DLL前请仔细阅读以下协议内容，如果你同意以下协议才能使用本项目所有的功能，
 * * 否则如果你违反了以下协议，有可能陷入法律纠纷和赔偿，作者保留追究法律责任的权利。
 * *
 * * 1、你可以在开发的软件产品中使用和修改本项目的源码和DLL，但是请保留所有相关的版权信息。
 * * 2、不能将本项目源码与作者的其他项目整合作为一个单独的软件售卖给他人使用。
 * * 3、不能传播本项目的源码和DLL，包括上传到网上、拷贝给他人等方式。
 * * 4、以上协议暂时定制，由于还不完善，作者保留以后修改协议的权利。
 * *
 * * Copyright (C) 2013-? cskin Corporation All rights reserved.
 * * 网站：CSkin界面库 http://www.cskin.net
 * * 作者： 乔克斯 QQ：345015918 .Net项目技术组群：306485590
 * * 请保留以上版权信息，否则作者将保留追究法律责任。
 * *
 * * 创建时间：2013-12-08
 * * 说明：FrmSearch.Designer.cs
 * *
********************************************************************/

namespace CC2013
{
    partial class FrmSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSearch));
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(38, 149);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(573, 42);
            this.skinPanel1.TabIndex = 0;
            // 
            // FrmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Back = ((System.Drawing.Image)(resources.GetObject("$this.Back")));
            this.BackLayout = false;
            this.BackShade = false;
            this.BackToColor = false;
            this.BorderPalace = global::CC2013.Properties.Resources.BackPalace;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.ClientSize = new System.Drawing.Size(753, 535);
            this.CloseBoxSize = new System.Drawing.Size(39, 20);
            this.CloseDownBack = global::CC2013.Properties.Resources.btn_close_down;
            this.CloseMouseBack = global::CC2013.Properties.Resources.btn_close_highlight;
            this.CloseNormlBack = global::CC2013.Properties.Resources.btn_close_disable;
            this.ControlBoxOffset = new System.Drawing.Point(-1, 0);
            this.Controls.Add(this.skinPanel1);
            this.DropBack = false;
            this.EffectBack = System.Drawing.Color.Black;
            this.EffectCaption = CCWin.TitleType.None;
            this.EffectWidth = 4;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.InheritBack = true;
            this.MaxDownBack = global::CC2013.Properties.Resources.btn_max_down;
            this.MaxMouseBack = global::CC2013.Properties.Resources.btn_max_highlight;
            this.MaxNormlBack = global::CC2013.Properties.Resources.btn_max_normal;
            this.MaxSize = new System.Drawing.Size(28, 20);
            this.MiniDownBack = global::CC2013.Properties.Resources.btn_mini_down;
            this.MiniMouseBack = global::CC2013.Properties.Resources.btn_mini_highlight;
            this.MiniNormlBack = global::CC2013.Properties.Resources.btn_mini_normal;
            this.MiniSize = new System.Drawing.Size(28, 20);
            this.Name = "FrmSearch";
            this.RestoreDownBack = global::CC2013.Properties.Resources.btn_restore_down;
            this.RestoreMouseBack = global::CC2013.Properties.Resources.btn_restore_highlight;
            this.RestoreNormlBack = global::CC2013.Properties.Resources.btn_restore_normal;
            this.ShowBorder = false;
            this.Text = "查找联系人";
            this.TitleColor = System.Drawing.Color.White;
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel1;
    }
}