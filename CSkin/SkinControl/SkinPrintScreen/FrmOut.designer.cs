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
 * * 说明：FrmOut.designer.cs
 * *
********************************************************************/

namespace CCWin.SkinControl
{
    partial class FrmOut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOut));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TMenuItem_OriginalToClip = new System.Windows.Forms.ToolStripMenuItem();
            this.TMenuItem_CurrentToClip = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOringinalToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.TMenuItem_SaveOriginal = new System.Windows.Forms.ToolStripMenuItem();
            this.TMenuItem_SaveCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TMenuItem_Size = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.TMenuItem_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TMenuItem_OriginalToClip,
            this.TMenuItem_CurrentToClip,
            this.saveOringinalToolStripMenuItem,
            this.TMenuItem_SaveOriginal,
            this.TMenuItem_SaveCurrent,
            this.toolStripSeparator1,
            this.TMenuItem_Size,
            this.toolStripSeparator2,
            this.TMenuItem_Help,
            this.TMenuItem_Close});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 198);
            // 
            // TMenuItem_OriginalToClip
            // 
            this.TMenuItem_OriginalToClip.Name = "TMenuItem_OriginalToClip";
            this.TMenuItem_OriginalToClip.Size = new System.Drawing.Size(184, 22);
            this.TMenuItem_OriginalToClip.Text = "Original to ClipBoard";
            this.TMenuItem_OriginalToClip.Click += new System.EventHandler(this.TMenuItem_OriginalToClip_Click);
            // 
            // TMenuItem_CurrentToClip
            // 
            this.TMenuItem_CurrentToClip.Name = "TMenuItem_CurrentToClip";
            this.TMenuItem_CurrentToClip.Size = new System.Drawing.Size(184, 22);
            this.TMenuItem_CurrentToClip.Text = "Current to ClipBoard";
            this.TMenuItem_CurrentToClip.Click += new System.EventHandler(this.TMenuItem_CurrentToClip_Click);
            // 
            // saveOringinalToolStripMenuItem
            // 
            this.saveOringinalToolStripMenuItem.Name = "saveOringinalToolStripMenuItem";
            this.saveOringinalToolStripMenuItem.Size = new System.Drawing.Size(181, 6);
            // 
            // TMenuItem_SaveOriginal
            // 
            this.TMenuItem_SaveOriginal.Name = "TMenuItem_SaveOriginal";
            this.TMenuItem_SaveOriginal.Size = new System.Drawing.Size(184, 22);
            this.TMenuItem_SaveOriginal.Text = "Save Original";
            this.TMenuItem_SaveOriginal.Click += new System.EventHandler(this.TMenuItem_SaveOriginal_Click);
            // 
            // TMenuItem_SaveCurrent
            // 
            this.TMenuItem_SaveCurrent.Name = "TMenuItem_SaveCurrent";
            this.TMenuItem_SaveCurrent.Size = new System.Drawing.Size(184, 22);
            this.TMenuItem_SaveCurrent.Text = "Save Current";
            this.TMenuItem_SaveCurrent.Click += new System.EventHandler(this.TMenuItem_SaveCurrent_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // TMenuItem_Size
            // 
            this.TMenuItem_Size.Name = "TMenuItem_Size";
            this.TMenuItem_Size.Size = new System.Drawing.Size(184, 22);
            this.TMenuItem_Size.Text = "Set Size";
            this.TMenuItem_Size.Click += new System.EventHandler(this.TMenuItem_Size_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // TMenuItem_Help
            // 
            this.TMenuItem_Help.Name = "TMenuItem_Help";
            this.TMenuItem_Help.Size = new System.Drawing.Size(184, 22);
            this.TMenuItem_Help.Text = "Help";
            this.TMenuItem_Help.Click += new System.EventHandler(this.TMenuItem_Help_Click);
            // 
            // TMenuItem_Close
            // 
            this.TMenuItem_Close.Name = "TMenuItem_Close";
            this.TMenuItem_Close.Size = new System.Drawing.Size(184, 22);
            this.TMenuItem_Close.Text = "Close";
            this.TMenuItem_Close.Click += new System.EventHandler(this.TMenuItem_Close_Click);
            // 
            // FrmOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 268);
            this.Font = CCWin.Localization.Localizer.DefaultFont;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmOut";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TMenuItem_OriginalToClip;
        private System.Windows.Forms.ToolStripMenuItem TMenuItem_CurrentToClip;
        private System.Windows.Forms.ToolStripMenuItem TMenuItem_SaveOriginal;
        private System.Windows.Forms.ToolStripSeparator saveOringinalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TMenuItem_SaveCurrent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem TMenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem TMenuItem_Close;
        private System.Windows.Forms.ToolStripMenuItem TMenuItem_Size;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}