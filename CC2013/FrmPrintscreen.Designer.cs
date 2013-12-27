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
 * * 说明：FrmPrintscreen.Designer.cs
 * *
********************************************************************/

namespace CC2013
{
    partial class FrmPrintscreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrintscreen));
            this.btnTs = new CCWin.SkinControl.SkinButton();
            this.btnRightImg = new CCWin.SkinControl.SkinButton();
            this.btnLeftImg = new CCWin.SkinControl.SkinButton();
            this.pnlTools = new CCWin.SkinControl.SkinPanel();
            this.ToolTools = new CCWin.SkinControl.SkinToolStrip();
            this.toolOneToOne = new System.Windows.Forms.ToolStripButton();
            this.toolMaxMin = new System.Windows.Forms.ToolStripButton();
            this.toolLeftXY = new System.Windows.Forms.ToolStripButton();
            this.toolRightXY = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripButton();
            this.toolSaveImg = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.timShowTools = new System.Windows.Forms.Timer(this.components);
            this.QQMenu = new CCWin.SkinControl.SkinContextMenuStrip();
            this.toolCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSave = new System.Windows.Forms.ToolStripMenuItem();
            this.添加到表情EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.涂鸦编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.分享到微博ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上传到空间相册ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTools.SuspendLayout();
            this.ToolTools.SuspendLayout();
            this.QQMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTs
            // 
            this.btnTs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTs.BackColor = System.Drawing.Color.Transparent;
            this.btnTs.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnTs.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnTs.DownBack = ((System.Drawing.Image)(resources.GetObject("btnTs.DownBack")));
            this.btnTs.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnTs.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.btnTs.ForeColor = System.Drawing.Color.White;
            this.btnTs.InheritColor = false;
            this.btnTs.Location = new System.Drawing.Point(254, 185);
            this.btnTs.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnTs.MouseBack")));
            this.btnTs.Name = "btnTs";
            this.btnTs.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnTs.NormlBack")));
            this.btnTs.Size = new System.Drawing.Size(107, 44);
            this.btnTs.TabIndex = 1;
            this.btnTs.Text = "100%";
            this.btnTs.UseVisualStyleBackColor = false;
            this.btnTs.Visible = false;
            // 
            // btnRightImg
            // 
            this.btnRightImg.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRightImg.BackColor = System.Drawing.Color.Transparent;
            this.btnRightImg.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnRightImg.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnRightImg.DownBack = ((System.Drawing.Image)(resources.GetObject("btnRightImg.DownBack")));
            this.btnRightImg.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnRightImg.FadeGlow = false;
            this.btnRightImg.InheritColor = false;
            this.btnRightImg.Location = new System.Drawing.Point(560, 181);
            this.btnRightImg.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnRightImg.MouseBack")));
            this.btnRightImg.Name = "btnRightImg";
            this.btnRightImg.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnRightImg.NormlBack")));
            this.btnRightImg.Size = new System.Drawing.Size(48, 48);
            this.btnRightImg.TabIndex = 2;
            this.btnRightImg.UseVisualStyleBackColor = false;
            this.btnRightImg.Visible = false;
            this.btnRightImg.Click += new System.EventHandler(this.btnRightImg_Click);
            // 
            // btnLeftImg
            // 
            this.btnLeftImg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLeftImg.BackColor = System.Drawing.Color.Transparent;
            this.btnLeftImg.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnLeftImg.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnLeftImg.DownBack = ((System.Drawing.Image)(resources.GetObject("btnLeftImg.DownBack")));
            this.btnLeftImg.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnLeftImg.FadeGlow = false;
            this.btnLeftImg.InheritColor = false;
            this.btnLeftImg.Location = new System.Drawing.Point(12, 181);
            this.btnLeftImg.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnLeftImg.MouseBack")));
            this.btnLeftImg.Name = "btnLeftImg";
            this.btnLeftImg.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnLeftImg.NormlBack")));
            this.btnLeftImg.Size = new System.Drawing.Size(48, 48);
            this.btnLeftImg.TabIndex = 3;
            this.btnLeftImg.UseVisualStyleBackColor = false;
            this.btnLeftImg.Visible = false;
            this.btnLeftImg.Click += new System.EventHandler(this.btnLeftImg_Click);
            // 
            // pnlTools
            // 
            this.pnlTools.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlTools.BackColor = System.Drawing.Color.Transparent;
            this.pnlTools.BackRectangle = new System.Drawing.Rectangle(15, 15, 15, 15);
            this.pnlTools.Controls.Add(this.ToolTools);
            this.pnlTools.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.pnlTools.DownBack = ((System.Drawing.Image)(resources.GetObject("pnlTools.DownBack")));
            this.pnlTools.Location = new System.Drawing.Point(167, 1);
            this.pnlTools.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTools.MouseBack = ((System.Drawing.Image)(resources.GetObject("pnlTools.MouseBack")));
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.NormlBack = ((System.Drawing.Image)(resources.GetObject("pnlTools.NormlBack")));
            this.pnlTools.Palace = true;
            this.pnlTools.Size = new System.Drawing.Size(281, 47);
            this.pnlTools.TabIndex = 124;
            // 
            // ToolTools
            // 
            this.ToolTools.Arrow = System.Drawing.Color.White;
            this.ToolTools.AutoSize = false;
            this.ToolTools.Back = System.Drawing.Color.White;
            this.ToolTools.BackColor = System.Drawing.Color.Transparent;
            this.ToolTools.BackRadius = 16;
            this.ToolTools.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.ToolTools.Base = System.Drawing.Color.Transparent;
            this.ToolTools.BaseFore = System.Drawing.Color.Black;
            this.ToolTools.BaseForeAnamorphosis = false;
            this.ToolTools.BaseForeAnamorphosisBorder = 4;
            this.ToolTools.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.ToolTools.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.ToolTools.BaseHoverFore = System.Drawing.Color.White;
            this.ToolTools.BaseItemAnamorphosis = true;
            this.ToolTools.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.ToolTools.BaseItemBorderShow = true;
            this.ToolTools.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("ToolTools.BaseItemDown")));
            this.ToolTools.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ToolTools.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("ToolTools.BaseItemMouse")));
            this.ToolTools.BaseItemPressed = System.Drawing.Color.Transparent;
            this.ToolTools.BaseItemRadius = 2;
            this.ToolTools.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.ToolTools.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.ToolTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolTools.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.ToolTools.Fore = System.Drawing.Color.Black;
            this.ToolTools.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.ToolTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolTools.HoverFore = System.Drawing.Color.White;
            this.ToolTools.ItemAnamorphosis = false;
            this.ToolTools.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.ToolTools.ItemBorderShow = false;
            this.ToolTools.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.ToolTools.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.ToolTools.ItemRadius = 1;
            this.ToolTools.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.ToolTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOneToOne,
            this.toolMaxMin,
            this.toolLeftXY,
            this.toolRightXY,
            this.toolStripSeparator1,
            this.toolSaveImg,
            this.toolStripButton6});
            this.ToolTools.Location = new System.Drawing.Point(0, 0);
            this.ToolTools.Name = "ToolTools";
            this.ToolTools.RadiusStyle = CCWin.SkinClass.RoundStyle.Bottom;
            this.ToolTools.Size = new System.Drawing.Size(281, 47);
            this.ToolTools.TabIndex = 124;
            this.ToolTools.Text = "skinToolStrip2";
            this.ToolTools.TitleAnamorphosis = false;
            this.ToolTools.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.ToolTools.TitleRadius = 4;
            this.ToolTools.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.ToolTools.MouseLeave += new System.EventHandler(this.ToolTools_MouseLeave);
            // 
            // toolOneToOne
            // 
            this.toolOneToOne.AutoSize = false;
            this.toolOneToOne.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolOneToOne.Image = ((System.Drawing.Image)(resources.GetObject("toolOneToOne.Image")));
            this.toolOneToOne.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolOneToOne.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOneToOne.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolOneToOne.Name = "toolOneToOne";
            this.toolOneToOne.Size = new System.Drawing.Size(33, 24);
            this.toolOneToOne.Text = "toolStripButton1";
            this.toolOneToOne.ToolTipText = "实际大小";
            this.toolOneToOne.Click += new System.EventHandler(this.toolOneToOne_Click);
            // 
            // toolMaxMin
            // 
            this.toolMaxMin.AutoSize = false;
            this.toolMaxMin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMaxMin.Image = ((System.Drawing.Image)(resources.GetObject("toolMaxMin.Image")));
            this.toolMaxMin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolMaxMin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMaxMin.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolMaxMin.Name = "toolMaxMin";
            this.toolMaxMin.Size = new System.Drawing.Size(33, 24);
            this.toolMaxMin.Text = "toolStripButton1";
            this.toolMaxMin.ToolTipText = "查看全屏";
            this.toolMaxMin.Click += new System.EventHandler(this.toolMaxMin_Click);
            // 
            // toolLeftXY
            // 
            this.toolLeftXY.AutoSize = false;
            this.toolLeftXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolLeftXY.Image = ((System.Drawing.Image)(resources.GetObject("toolLeftXY.Image")));
            this.toolLeftXY.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolLeftXY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLeftXY.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolLeftXY.Name = "toolLeftXY";
            this.toolLeftXY.Size = new System.Drawing.Size(33, 24);
            this.toolLeftXY.Text = "toolStripButton1";
            this.toolLeftXY.ToolTipText = "左旋转";
            this.toolLeftXY.Click += new System.EventHandler(this.toolLeftXY_Click);
            // 
            // toolRightXY
            // 
            this.toolRightXY.AutoSize = false;
            this.toolRightXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolRightXY.Image = ((System.Drawing.Image)(resources.GetObject("toolRightXY.Image")));
            this.toolRightXY.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolRightXY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRightXY.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolRightXY.Name = "toolRightXY";
            this.toolRightXY.Size = new System.Drawing.Size(33, 24);
            this.toolRightXY.Text = "toolStripButton1";
            this.toolRightXY.ToolTipText = "右旋转";
            this.toolRightXY.Click += new System.EventHandler(this.toolRightXY_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSeparator1.Enabled = false;
            this.toolStripSeparator1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSeparator1.Image")));
            this.toolStripSeparator1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSeparator1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(23, 44);
            // 
            // toolSaveImg
            // 
            this.toolSaveImg.AutoSize = false;
            this.toolSaveImg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSaveImg.Image = ((System.Drawing.Image)(resources.GetObject("toolSaveImg.Image")));
            this.toolSaveImg.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolSaveImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveImg.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.toolSaveImg.Name = "toolSaveImg";
            this.toolSaveImg.Size = new System.Drawing.Size(33, 24);
            this.toolSaveImg.Text = "toolStripButton1";
            this.toolSaveImg.ToolTipText = "保存";
            this.toolSaveImg.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.AutoSize = false;
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(33, 24);
            this.toolStripButton6.Text = "toolStripButton1";
            this.toolStripButton6.ToolTipText = "分享";
            // 
            // timShowTools
            // 
            this.timShowTools.Interval = 1;
            this.timShowTools.Tick += new System.EventHandler(this.timShowTools_Tick);
            // 
            // QQMenu
            // 
            this.QQMenu.Arrow = System.Drawing.Color.Black;
            this.QQMenu.Back = System.Drawing.Color.White;
            this.QQMenu.BackRadius = 4;
            this.QQMenu.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.QQMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.QQMenu.Fore = System.Drawing.Color.Black;
            this.QQMenu.HoverFore = System.Drawing.Color.White;
            this.QQMenu.ImageScalingSize = new System.Drawing.Size(11, 11);
            this.QQMenu.ItemAnamorphosis = false;
            this.QQMenu.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(136)))), ((int)(((byte)(200)))));
            this.QQMenu.ItemBorderShow = false;
            this.QQMenu.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(136)))), ((int)(((byte)(200)))));
            this.QQMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(136)))), ((int)(((byte)(200)))));
            this.QQMenu.ItemRadius = 4;
            this.QQMenu.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.QQMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCopy,
            this.toolSave,
            this.添加到表情EToolStripMenuItem,
            this.涂鸦编辑ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.分享到微博ToolStripMenuItem,
            this.上传到空间相册ToolStripMenuItem});
            this.QQMenu.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.QQMenu.Name = "MenuState";
            this.QQMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.QQMenu.Size = new System.Drawing.Size(161, 142);
            this.QQMenu.TitleAnamorphosis = false;
            this.QQMenu.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.QQMenu.TitleRadius = 4;
            this.QQMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolCopy
            // 
            this.toolCopy.Name = "toolCopy";
            this.toolCopy.Size = new System.Drawing.Size(160, 22);
            this.toolCopy.Text = "复制(&C)";
            this.toolCopy.Click += new System.EventHandler(this.toolCopy_Click);
            // 
            // toolSave
            // 
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(160, 22);
            this.toolSave.Text = "另存为(&S)...";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // 添加到表情EToolStripMenuItem
            // 
            this.添加到表情EToolStripMenuItem.Name = "添加到表情EToolStripMenuItem";
            this.添加到表情EToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.添加到表情EToolStripMenuItem.Text = "添加到表情(&E)";
            // 
            // 涂鸦编辑ToolStripMenuItem
            // 
            this.涂鸦编辑ToolStripMenuItem.Name = "涂鸦编辑ToolStripMenuItem";
            this.涂鸦编辑ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.涂鸦编辑ToolStripMenuItem.Text = "涂鸦编辑";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(157, 6);
            // 
            // 分享到微博ToolStripMenuItem
            // 
            this.分享到微博ToolStripMenuItem.Name = "分享到微博ToolStripMenuItem";
            this.分享到微博ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.分享到微博ToolStripMenuItem.Text = "分享到微博";
            // 
            // 上传到空间相册ToolStripMenuItem
            // 
            this.上传到空间相册ToolStripMenuItem.Name = "上传到空间相册ToolStripMenuItem";
            this.上传到空间相册ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.上传到空间相册ToolStripMenuItem.Text = "上传到空间相册";
            // 
            // FrmPrintscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BackShade = false;
            this.BackToColor = false;
            this.BorderPalace = global::CC2013.Properties.Resources.BackPalace;
            this.ClientSize = new System.Drawing.Size(615, 415);
            this.CloseBoxSize = new System.Drawing.Size(25, 25);
            this.CloseDownBack = global::CC2013.Properties.Resources.icon_close_down;
            this.CloseMouseBack = global::CC2013.Properties.Resources.icon_close_hover;
            this.CloseNormlBack = global::CC2013.Properties.Resources.icon_close_normal;
            this.ContextMenuStrip = this.QQMenu;
            this.ControlBoxOffset = new System.Drawing.Point(4, 4);
            this.Controls.Add(this.pnlTools);
            this.Controls.Add(this.btnLeftImg);
            this.Controls.Add(this.btnRightImg);
            this.Controls.Add(this.btnTs);
            this.DropBack = false;
            this.EffectCaption = CCWin.TitleType.None;
            this.HelpButton = true;
            this.MaxDownBack = ((System.Drawing.Image)(resources.GetObject("$this.MaxDownBack")));
            this.MaxMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.MaxMouseBack")));
            this.MaxNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.MaxNormlBack")));
            this.MaxSize = new System.Drawing.Size(5, 5);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(615, 415);
            this.Name = "FrmPrintscreen";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.RestoreDownBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreDownBack")));
            this.RestoreMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreMouseBack")));
            this.RestoreNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreNormlBack")));
            this.ShadowWidth = 8;
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.ShowInTaskbar = false;
            this.SkinOpacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.MouseLeave += new System.EventHandler(this.FrmPrintscreen_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmPrintscreen_MouseMove);
            this.pnlTools.ResumeLayout(false);
            this.ToolTools.ResumeLayout(false);
            this.ToolTools.PerformLayout();
            this.QQMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinButton btnTs;
        private CCWin.SkinControl.SkinButton btnRightImg;
        private CCWin.SkinControl.SkinButton btnLeftImg;
        private CCWin.SkinControl.SkinPanel pnlTools;
        private CCWin.SkinControl.SkinToolStrip ToolTools;
        private System.Windows.Forms.ToolStripButton toolOneToOne;
        private System.Windows.Forms.ToolStripButton toolMaxMin;
        private System.Windows.Forms.ToolStripButton toolLeftXY;
        private System.Windows.Forms.ToolStripButton toolRightXY;
        private System.Windows.Forms.ToolStripButton toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.Timer timShowTools;
        private CCWin.SkinControl.SkinContextMenuStrip QQMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolCopy;
        private System.Windows.Forms.ToolStripMenuItem toolSave;
        private System.Windows.Forms.ToolStripMenuItem 添加到表情EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 涂鸦编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分享到微博ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上传到空间相册ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolSaveImg;
    }
}