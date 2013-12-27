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
 * * 说明：SkinHtmlEditor.designer.cs
 * *
********************************************************************/

namespace CCWin.SkinControl
{
    sealed partial class SkinHtmlEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkinHtmlEditor));
            this.tscMain = new System.Windows.Forms.ToolStripContainer();
            this.ssHtml = new System.Windows.Forms.StatusStrip();
            this.tsslWordCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.cmsHtml = new CCWin.SkinControl.SkinContextMenuStrip();
            this.tsmiTable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTableModify = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTableInsertRow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTableDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFind = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTopToolBar = new CCWin.SkinControl.SkinToolStrip();
            this.tsfcbFontName = new CCWin.SkinControl.ToolStripFontComboBox();
            this.tscbFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbPreview = new System.Windows.Forms.ToolStripButton();
            this.tsbShowHTML = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbCut = new System.Windows.Forms.ToolStripButton();
            this.tsbPaste = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbUndo = new System.Windows.Forms.ToolStripButton();
            this.tsbRedo = new System.Windows.Forms.ToolStripButton();
            this.tsbFind = new System.Windows.Forms.ToolStripButton();
            this.tsbRemoveFormat = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsbJustifyCenter = new System.Windows.Forms.ToolStripButton();
            this.tsbJustifyFull = new System.Windows.Forms.ToolStripButton();
            this.tsbJustifyLeft = new System.Windows.Forms.ToolStripButton();
            this.tsbJustifyRight = new System.Windows.Forms.ToolStripButton();
            this.tsbUnderline = new System.Windows.Forms.ToolStripButton();
            this.tsbItalic = new System.Windows.Forms.ToolStripButton();
            this.tsbBold = new System.Windows.Forms.ToolStripButton();
            this.tscpBackColor = new CCWin.SkinControl.ToolStripColorPicker();
            this.tscpForeColor = new CCWin.SkinControl.ToolStripColorPicker();
            this.tsbStrikeThrough = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsbCreateLink = new System.Windows.Forms.ToolStripButton();
            this.tsbUnlink = new System.Windows.Forms.ToolStripButton();
            this.tsddbInsertTable = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbInsertImage = new System.Windows.Forms.ToolStripButton();
            this.tsbInsertHorizontalRule = new System.Windows.Forms.ToolStripButton();
            this.tsbOutdent = new System.Windows.Forms.ToolStripButton();
            this.tsbIndent = new System.Windows.Forms.ToolStripButton();
            this.tsbInsertUnorderedList = new System.Windows.Forms.ToolStripButton();
            this.tsbInsertOrderedList = new System.Windows.Forms.ToolStripButton();
            this.tsbSuperscript = new System.Windows.Forms.ToolStripButton();
            this.tsbSubscript = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tsbWordCount = new System.Windows.Forms.ToolStripButton();
            this.tsbDate = new System.Windows.Forms.ToolStripButton();
            this.tsbTime = new System.Windows.Forms.ToolStripButton();
            this.tsbClearWord = new System.Windows.Forms.ToolStripButton();
            this.tsbAutoLayout = new System.Windows.Forms.ToolStripButton();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.tscMain.ContentPanel.SuspendLayout();
            this.tscMain.TopToolStripPanel.SuspendLayout();
            this.tscMain.SuspendLayout();
            this.ssHtml.SuspendLayout();
            this.cmsHtml.SuspendLayout();
            this.tsTopToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscMain
            // 
            this.tscMain.BottomToolStripPanelVisible = false;
            // 
            // tscMain.ContentPanel
            // 
            this.tscMain.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tscMain.ContentPanel.Controls.Add(this.ssHtml);
            this.tscMain.ContentPanel.Controls.Add(this.wb);
            this.tscMain.ContentPanel.Size = new System.Drawing.Size(1296, 444);
            this.tscMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscMain.Font = CCWin.Localization.Localizer.DefaultFont;
            this.tscMain.LeftToolStripPanelVisible = false;
            this.tscMain.Location = new System.Drawing.Point(0, 0);
            this.tscMain.Name = "tscMain";
            this.tscMain.RightToolStripPanelVisible = false;
            this.tscMain.Size = new System.Drawing.Size(1296, 471);
            this.tscMain.TabIndex = 0;
            this.tscMain.Text = "toolStripContainer1";
            // 
            // tscMain.TopToolStripPanel
            // 
            this.tscMain.TopToolStripPanel.BackColor = System.Drawing.Color.Transparent;
            this.tscMain.TopToolStripPanel.Controls.Add(this.tsTopToolBar);
            // 
            // ssHtml
            // 
            this.ssHtml.BackColor = System.Drawing.Color.Transparent;
            this.ssHtml.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslWordCount});
            this.ssHtml.Location = new System.Drawing.Point(0, 418);
            this.ssHtml.Name = "ssHtml";
            this.ssHtml.Size = new System.Drawing.Size(1292, 22);
            this.ssHtml.TabIndex = 1;
            this.ssHtml.Text = "statusStrip1";
            // 
            // tsslWordCount
            // 
            this.tsslWordCount.BackColor = System.Drawing.Color.Transparent;
            this.tsslWordCount.Name = "tsslWordCount";
            this.tsslWordCount.Size = new System.Drawing.Size(56, 17);
            this.tsslWordCount.Text = "字数统计";
            // 
            // wb
            // 
            this.wb.ContextMenuStrip = this.cmsHtml;
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(0, 0);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(1292, 440);
            this.wb.TabIndex = 0;
            this.wb.Url = new System.Uri("http://-", System.UriKind.Absolute);
            this.wb.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wb_DocumentCompleted);
            this.wb.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.wb_Navigating);
            // 
            // cmsHtml
            // 
            this.cmsHtml.AllowDrop = true;
            this.cmsHtml.Arrow = System.Drawing.Color.Black;
            this.cmsHtml.Back = System.Drawing.Color.White;
            this.cmsHtml.BackRadius = 4;
            this.cmsHtml.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.cmsHtml.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cmsHtml.Fore = System.Drawing.Color.Black;
            this.cmsHtml.HoverFore = System.Drawing.Color.White;
            this.cmsHtml.ItemAnamorphosis = false;
            this.cmsHtml.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsHtml.ItemBorderShow = false;
            this.cmsHtml.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsHtml.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsHtml.ItemRadius = 4;
            this.cmsHtml.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.cmsHtml.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTable,
            this.tsmiSelectAll,
            this.tsmiCopy,
            this.tsmiCut,
            this.tsmiPaste,
            this.tsmiDelete,
            this.tsmiFind,
            this.tsmiRemoveFormat,
            this.toolStripSeparator5,
            this.tsmiSave});
            this.cmsHtml.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cmsHtml.Name = "contextMenuWeb";
            this.cmsHtml.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.cmsHtml.Size = new System.Drawing.Size(125, 208);
            this.cmsHtml.TitleAnamorphosis = false;
            this.cmsHtml.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.cmsHtml.TitleRadius = 4;
            this.cmsHtml.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // tsmiTable
            // 
            this.tsmiTable.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTableModify,
            this.tsmiTableInsertRow,
            this.tsmiTableDeleteRow});
            this.tsmiTable.Name = "tsmiTable";
            this.tsmiTable.Size = new System.Drawing.Size(124, 22);
            this.tsmiTable.Tag = "Table";
            this.tsmiTable.Text = "表格";
            // 
            // tsmiTableModify
            // 
            this.tsmiTableModify.Image = global::CCWin.Properties.Resources.InsertTable;
            this.tsmiTableModify.Name = "tsmiTableModify";
            this.tsmiTableModify.Size = new System.Drawing.Size(148, 22);
            this.tsmiTableModify.Tag = "TableModify";
            this.tsmiTableModify.Text = "编辑表格属性";
            this.tsmiTableModify.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsmiTableInsertRow
            // 
            this.tsmiTableInsertRow.Name = "tsmiTableInsertRow";
            this.tsmiTableInsertRow.Size = new System.Drawing.Size(148, 22);
            this.tsmiTableInsertRow.Tag = "TableInsertRow";
            this.tsmiTableInsertRow.Text = "插入行";
            this.tsmiTableInsertRow.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsmiTableDeleteRow
            // 
            this.tsmiTableDeleteRow.Name = "tsmiTableDeleteRow";
            this.tsmiTableDeleteRow.Size = new System.Drawing.Size(148, 22);
            this.tsmiTableDeleteRow.Tag = "TableDeleteRow";
            this.tsmiTableDeleteRow.Text = "删除行";
            this.tsmiTableDeleteRow.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsmiSelectAll
            // 
            this.tsmiSelectAll.Name = "tsmiSelectAll";
            this.tsmiSelectAll.Size = new System.Drawing.Size(124, 22);
            this.tsmiSelectAll.Tag = "SelectAll";
            this.tsmiSelectAll.Text = "全选";
            this.tsmiSelectAll.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.Image = global::CCWin.Properties.Resources.Copy;
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(124, 22);
            this.tsmiCopy.Tag = "Copy";
            this.tsmiCopy.Text = "复制";
            this.tsmiCopy.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsmiCut
            // 
            this.tsmiCut.Image = global::CCWin.Properties.Resources.Cut;
            this.tsmiCut.Name = "tsmiCut";
            this.tsmiCut.Size = new System.Drawing.Size(124, 22);
            this.tsmiCut.Tag = "Cut";
            this.tsmiCut.Text = "剪切";
            this.tsmiCut.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsmiPaste
            // 
            this.tsmiPaste.Image = global::CCWin.Properties.Resources.Paste;
            this.tsmiPaste.Name = "tsmiPaste";
            this.tsmiPaste.Size = new System.Drawing.Size(124, 22);
            this.tsmiPaste.Tag = "Paste";
            this.tsmiPaste.Text = "粘贴";
            this.tsmiPaste.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Image = global::CCWin.Properties.Resources.Delete;
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(124, 22);
            this.tsmiDelete.Tag = "Delete";
            this.tsmiDelete.Text = "删除";
            this.tsmiDelete.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsmiFind
            // 
            this.tsmiFind.Image = global::CCWin.Properties.Resources.Find;
            this.tsmiFind.Name = "tsmiFind";
            this.tsmiFind.Size = new System.Drawing.Size(124, 22);
            this.tsmiFind.Tag = "Find";
            this.tsmiFind.Text = "查找";
            this.tsmiFind.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsmiRemoveFormat
            // 
            this.tsmiRemoveFormat.Image = global::CCWin.Properties.Resources.RemoveFormat;
            this.tsmiRemoveFormat.Name = "tsmiRemoveFormat";
            this.tsmiRemoveFormat.Size = new System.Drawing.Size(124, 22);
            this.tsmiRemoveFormat.Tag = "RemoveFormat";
            this.tsmiRemoveFormat.Text = "清除格式";
            this.tsmiRemoveFormat.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(121, 6);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Image = global::CCWin.Properties.Resources.HtmlSave;
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(124, 22);
            this.tsmiSave.Tag = "Save";
            this.tsmiSave.Text = "保存";
            this.tsmiSave.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsTopToolBar
            // 
            this.tsTopToolBar.Arrow = System.Drawing.Color.Black;
            this.tsTopToolBar.Back = System.Drawing.Color.White;
            this.tsTopToolBar.BackColor = System.Drawing.Color.Transparent;
            this.tsTopToolBar.BackRadius = 4;
            this.tsTopToolBar.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.tsTopToolBar.Base = System.Drawing.Color.Transparent;
            this.tsTopToolBar.BaseFore = System.Drawing.Color.Black;
            this.tsTopToolBar.BaseForeAnamorphosis = false;
            this.tsTopToolBar.BaseForeAnamorphosisBorder = 4;
            this.tsTopToolBar.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.tsTopToolBar.BaseHoverFore = System.Drawing.Color.White;
            this.tsTopToolBar.BaseItemAnamorphosis = true;
            this.tsTopToolBar.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsTopToolBar.BaseItemBorderShow = true;
            this.tsTopToolBar.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("tsTopToolBar.BaseItemDown")));
            this.tsTopToolBar.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsTopToolBar.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("tsTopToolBar.BaseItemMouse")));
            this.tsTopToolBar.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsTopToolBar.BaseItemRadius = 4;
            this.tsTopToolBar.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.tsTopToolBar.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsTopToolBar.Dock = System.Windows.Forms.DockStyle.None;
            this.tsTopToolBar.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.tsTopToolBar.Fore = System.Drawing.Color.Black;
            this.tsTopToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsTopToolBar.HoverFore = System.Drawing.Color.White;
            this.tsTopToolBar.ItemAnamorphosis = true;
            this.tsTopToolBar.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsTopToolBar.ItemBorderShow = true;
            this.tsTopToolBar.ItemHover = System.Drawing.Color.White;
            this.tsTopToolBar.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsTopToolBar.ItemRadius = 4;
            this.tsTopToolBar.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.tsTopToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsfcbFontName,
            this.tscbFontSize,
            this.tsbNew,
            this.tsbOpen,
            this.tsbPrint,
            this.tsbSave,
            this.tsbPreview,
            this.tsbShowHTML,
            this.toolStripLabel3,
            this.tsbCopy,
            this.tsbCut,
            this.tsbPaste,
            this.tsbDelete,
            this.tsbUndo,
            this.tsbRedo,
            this.tsbFind,
            this.tsbRemoveFormat,
            this.toolStripLabel1,
            this.tsbJustifyCenter,
            this.tsbJustifyFull,
            this.tsbJustifyLeft,
            this.tsbJustifyRight,
            this.tsbUnderline,
            this.tsbItalic,
            this.tsbBold,
            this.tscpBackColor,
            this.tscpForeColor,
            this.tsbStrikeThrough,
            this.toolStripLabel2,
            this.tsbCreateLink,
            this.tsbUnlink,
            this.tsddbInsertTable,
            this.tsbInsertImage,
            this.tsbInsertHorizontalRule,
            this.tsbOutdent,
            this.tsbIndent,
            this.tsbInsertUnorderedList,
            this.tsbInsertOrderedList,
            this.tsbSuperscript,
            this.tsbSubscript,
            this.toolStripLabel4,
            this.tsbWordCount,
            this.tsbDate,
            this.tsbTime,
            this.tsbClearWord,
            this.tsbAutoLayout,
            this.tsbAbout});
            this.tsTopToolBar.Location = new System.Drawing.Point(3, 0);
            this.tsTopToolBar.Name = "tsTopToolBar";
            this.tsTopToolBar.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.tsTopToolBar.Size = new System.Drawing.Size(1293, 27);
            this.tsTopToolBar.TabIndex = 0;
            this.tsTopToolBar.Text = "topToolBar";
            this.tsTopToolBar.TitleAnamorphosis = true;
            this.tsTopToolBar.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.tsTopToolBar.TitleRadius = 4;
            this.tsTopToolBar.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // tsfcbFontName
            // 
            this.tsfcbFontName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tsfcbFontName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tsfcbFontName.InternalCall = false;
            this.tsfcbFontName.Name = "tsfcbFontName";
            this.tsfcbFontName.SelectedFontItem = null;
            this.tsfcbFontName.SelectedFontNameItem = "";
            this.tsfcbFontName.Size = new System.Drawing.Size(200, 27);
            this.tsfcbFontName.Tag = "FontName";
            this.tsfcbFontName.SelectedIndexChanged += new System.EventHandler(this.tsfcbFontName_SelectedIndexChanged);
            // 
            // tscbFontSize
            // 
            this.tscbFontSize.Name = "tscbFontSize";
            this.tscbFontSize.Size = new System.Drawing.Size(75, 27);
            this.tscbFontSize.Tag = "FontSize";
            this.tscbFontSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tscbFontSize_KeyPress);
            // 
            // tsbNew
            // 
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNew.Image = global::CCWin.Properties.Resources.New;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(23, 24);
            this.tsbNew.Tag = "New";
            this.tsbNew.Text = "新建";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = global::CCWin.Properties.Resources.Open;
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(23, 24);
            this.tsbOpen.Tag = "Open";
            this.tsbOpen.Text = "打开文件";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Image = global::CCWin.Properties.Resources.Print;
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(23, 24);
            this.tsbPrint.Tag = "Print";
            this.tsbPrint.Text = "打印";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = global::CCWin.Properties.Resources.HtmlSave;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 24);
            this.tsbSave.Tag = "Save";
            this.tsbSave.Text = "保存为文件";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbPreview
            // 
            this.tsbPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPreview.Image = global::CCWin.Properties.Resources.Preview;
            this.tsbPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPreview.Name = "tsbPreview";
            this.tsbPreview.Size = new System.Drawing.Size(23, 24);
            this.tsbPreview.Tag = "Preview";
            this.tsbPreview.Text = "预览";
            this.tsbPreview.Click += new System.EventHandler(this.tsbPreview_Click);
            // 
            // tsbShowHTML
            // 
            this.tsbShowHTML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShowHTML.Image = global::CCWin.Properties.Resources.ShowHTML;
            this.tsbShowHTML.ImageTransparentColor = System.Drawing.SystemColors.Control;
            this.tsbShowHTML.Name = "tsbShowHTML";
            this.tsbShowHTML.Size = new System.Drawing.Size(23, 24);
            this.tsbShowHTML.Tag = "ShowHTML";
            this.tsbShowHTML.Text = "查看HTML代码";
            this.tsbShowHTML.Click += new System.EventHandler(this.tsbShowHTML_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.AutoSize = false;
            this.toolStripLabel3.BackColor = System.Drawing.Color.Transparent;
            this.toolStripLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel3.Image = global::CCWin.Properties.Resources.pictureBox1_Image;
            this.toolStripLabel3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabel3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(5, 24);
            this.toolStripLabel3.Text = "toolStripButton9";
            // 
            // tsbCopy
            // 
            this.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCopy.Image = global::CCWin.Properties.Resources.Copy;
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(23, 24);
            this.tsbCopy.Tag = "Copy";
            this.tsbCopy.Text = "复制";
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // tsbCut
            // 
            this.tsbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCut.Image = global::CCWin.Properties.Resources.Cut;
            this.tsbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCut.Name = "tsbCut";
            this.tsbCut.Size = new System.Drawing.Size(23, 24);
            this.tsbCut.Tag = "Cut";
            this.tsbCut.Text = "剪切";
            this.tsbCut.Click += new System.EventHandler(this.tsbCut_Click);
            // 
            // tsbPaste
            // 
            this.tsbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPaste.Image = global::CCWin.Properties.Resources.Paste;
            this.tsbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPaste.Name = "tsbPaste";
            this.tsbPaste.Size = new System.Drawing.Size(23, 24);
            this.tsbPaste.Tag = "Paste";
            this.tsbPaste.Text = "粘贴";
            this.tsbPaste.Click += new System.EventHandler(this.tsbPaste_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = global::CCWin.Properties.Resources.Delete;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(23, 24);
            this.tsbDelete.Tag = "Delete";
            this.tsbDelete.Text = "删除";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbUndo
            // 
            this.tsbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUndo.Image = global::CCWin.Properties.Resources.Undo;
            this.tsbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUndo.Name = "tsbUndo";
            this.tsbUndo.Size = new System.Drawing.Size(23, 24);
            this.tsbUndo.Tag = "Undo";
            this.tsbUndo.Text = "撤销";
            this.tsbUndo.Click += new System.EventHandler(this.tsbUndo_Click);
            // 
            // tsbRedo
            // 
            this.tsbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRedo.Image = global::CCWin.Properties.Resources.Redo;
            this.tsbRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRedo.Name = "tsbRedo";
            this.tsbRedo.Size = new System.Drawing.Size(23, 24);
            this.tsbRedo.Tag = "Redo";
            this.tsbRedo.Text = "重做";
            this.tsbRedo.Click += new System.EventHandler(this.tsbRedo_Click);
            // 
            // tsbFind
            // 
            this.tsbFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFind.Image = global::CCWin.Properties.Resources.Find;
            this.tsbFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFind.Name = "tsbFind";
            this.tsbFind.Size = new System.Drawing.Size(23, 24);
            this.tsbFind.Tag = "Find";
            this.tsbFind.Text = "查找";
            this.tsbFind.Click += new System.EventHandler(this.tsbFind_Click);
            // 
            // tsbRemoveFormat
            // 
            this.tsbRemoveFormat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRemoveFormat.Image = global::CCWin.Properties.Resources.RemoveFormat;
            this.tsbRemoveFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveFormat.Name = "tsbRemoveFormat";
            this.tsbRemoveFormat.Size = new System.Drawing.Size(23, 24);
            this.tsbRemoveFormat.Tag = "RemoveFormat";
            this.tsbRemoveFormat.Text = "清除格式";
            this.tsbRemoveFormat.Click += new System.EventHandler(this.tsbRemoveFormat_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel1.Image = global::CCWin.Properties.Resources.pictureBox1_Image;
            this.toolStripLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabel1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(5, 24);
            this.toolStripLabel1.Text = "toolStripButton9";
            // 
            // tsbJustifyCenter
            // 
            this.tsbJustifyCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbJustifyCenter.Image = global::CCWin.Properties.Resources.JustifyCenter;
            this.tsbJustifyCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJustifyCenter.Name = "tsbJustifyCenter";
            this.tsbJustifyCenter.Size = new System.Drawing.Size(23, 24);
            this.tsbJustifyCenter.Tag = "JustifyCenter";
            this.tsbJustifyCenter.Text = "居中对齐0";
            this.tsbJustifyCenter.Click += new System.EventHandler(this.tsbJustifyCenter_Click);
            // 
            // tsbJustifyFull
            // 
            this.tsbJustifyFull.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbJustifyFull.Image = global::CCWin.Properties.Resources.JustifyFull;
            this.tsbJustifyFull.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJustifyFull.Name = "tsbJustifyFull";
            this.tsbJustifyFull.Size = new System.Drawing.Size(23, 24);
            this.tsbJustifyFull.Tag = "JustifyFull";
            this.tsbJustifyFull.Text = "两端对齐";
            this.tsbJustifyFull.Click += new System.EventHandler(this.tsbJustifyFull_Click);
            // 
            // tsbJustifyLeft
            // 
            this.tsbJustifyLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbJustifyLeft.Image = global::CCWin.Properties.Resources.JustifyLeft;
            this.tsbJustifyLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJustifyLeft.Name = "tsbJustifyLeft";
            this.tsbJustifyLeft.Size = new System.Drawing.Size(23, 24);
            this.tsbJustifyLeft.Tag = "JustifyLeft";
            this.tsbJustifyLeft.Text = "左对齐";
            this.tsbJustifyLeft.Click += new System.EventHandler(this.tsbJustifyLeft_Click);
            // 
            // tsbJustifyRight
            // 
            this.tsbJustifyRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbJustifyRight.Image = global::CCWin.Properties.Resources.JustifyRight;
            this.tsbJustifyRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJustifyRight.Name = "tsbJustifyRight";
            this.tsbJustifyRight.Size = new System.Drawing.Size(23, 24);
            this.tsbJustifyRight.Tag = "JustifyRight";
            this.tsbJustifyRight.Text = "右对齐";
            this.tsbJustifyRight.Click += new System.EventHandler(this.tsbJustifyRight_Click);
            // 
            // tsbUnderline
            // 
            this.tsbUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUnderline.Image = global::CCWin.Properties.Resources.Underline;
            this.tsbUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUnderline.Name = "tsbUnderline";
            this.tsbUnderline.Size = new System.Drawing.Size(23, 24);
            this.tsbUnderline.Tag = "Underline";
            this.tsbUnderline.Text = "下划线";
            this.tsbUnderline.Click += new System.EventHandler(this.tsbUnderline_Click);
            // 
            // tsbItalic
            // 
            this.tsbItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbItalic.Image = global::CCWin.Properties.Resources.Italic;
            this.tsbItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbItalic.Name = "tsbItalic";
            this.tsbItalic.Size = new System.Drawing.Size(23, 24);
            this.tsbItalic.Tag = "Italic";
            this.tsbItalic.Text = "斜体";
            this.tsbItalic.Click += new System.EventHandler(this.tsbItalic_Click);
            // 
            // tsbBold
            // 
            this.tsbBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBold.Image = global::CCWin.Properties.Resources.Bold;
            this.tsbBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBold.Name = "tsbBold";
            this.tsbBold.Size = new System.Drawing.Size(23, 24);
            this.tsbBold.Tag = "Bold";
            this.tsbBold.Text = "粗体";
            this.tsbBold.Click += new System.EventHandler(this.tsbBold_Click);
            // 
            // tscpBackColor
            // 
            this.tscpBackColor.AutoSize = false;
            this.tscpBackColor.ButtonDisplayStyle = CCWin.SkinControl.ToolStripColorPickerDisplayType.UnderLineAndImage;
            this.tscpBackColor.Color = System.Drawing.Color.White;
            this.tscpBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tscpBackColor.Image = ((System.Drawing.Image)(resources.GetObject("tscpBackColor.Image")));
            this.tscpBackColor.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tscpBackColor.Name = "tscpBackColor";
            this.tscpBackColor.Size = new System.Drawing.Size(30, 23);
            this.tscpBackColor.Tag = "BackColor";
            this.tscpBackColor.Text = "背景色";
            this.tscpBackColor.ToolTipText = "背景色";
            this.tscpBackColor.SelectedColorChanged += new System.EventHandler(this.tscpBackColor_SelectedColorChanged);
            this.tscpBackColor.ButtonClick += new System.EventHandler(this.tscpBackColor_SelectedColorChanged);
            // 
            // tscpForeColor
            // 
            this.tscpForeColor.AutoSize = false;
            this.tscpForeColor.ButtonDisplayStyle = CCWin.SkinControl.ToolStripColorPickerDisplayType.UnderLineAndImage;
            this.tscpForeColor.Color = System.Drawing.Color.Black;
            this.tscpForeColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.tscpForeColor.Image = ((System.Drawing.Image)(resources.GetObject("tscpForeColor.Image")));
            this.tscpForeColor.ImageTransparentColor = System.Drawing.Color.White;
            this.tscpForeColor.Name = "tscpForeColor";
            this.tscpForeColor.Size = new System.Drawing.Size(30, 23);
            this.tscpForeColor.Tag = "ForeColor";
            this.tscpForeColor.Text = "前景色";
            this.tscpForeColor.ToolTipText = "前景色";
            this.tscpForeColor.SelectedColorChanged += new System.EventHandler(this.tscpForeColor_SelectedColorChanged);
            this.tscpForeColor.ButtonClick += new System.EventHandler(this.tscpForeColor_SelectedColorChanged);
            // 
            // tsbStrikeThrough
            // 
            this.tsbStrikeThrough.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStrikeThrough.Image = global::CCWin.Properties.Resources.StrikeThrough;
            this.tsbStrikeThrough.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStrikeThrough.Name = "tsbStrikeThrough";
            this.tsbStrikeThrough.Size = new System.Drawing.Size(23, 24);
            this.tsbStrikeThrough.Tag = "StrikeThrough";
            this.tsbStrikeThrough.Text = "删除线";
            this.tsbStrikeThrough.Click += new System.EventHandler(this.tsbStrikeThrough_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel2.Image = global::CCWin.Properties.Resources.pictureBox1_Image;
            this.toolStripLabel2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabel2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(5, 24);
            this.toolStripLabel2.Text = "toolStripButton9";
            // 
            // tsbCreateLink
            // 
            this.tsbCreateLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCreateLink.Image = global::CCWin.Properties.Resources.CreateLink;
            this.tsbCreateLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreateLink.Name = "tsbCreateLink";
            this.tsbCreateLink.Size = new System.Drawing.Size(23, 24);
            this.tsbCreateLink.Tag = "CreateLink";
            this.tsbCreateLink.Text = "超链接";
            this.tsbCreateLink.Click += new System.EventHandler(this.tsbCreateLink_Click);
            // 
            // tsbUnlink
            // 
            this.tsbUnlink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUnlink.Image = global::CCWin.Properties.Resources.Unlink;
            this.tsbUnlink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUnlink.Name = "tsbUnlink";
            this.tsbUnlink.Size = new System.Drawing.Size(23, 24);
            this.tsbUnlink.Tag = "Unlink";
            this.tsbUnlink.Text = "取消超链接";
            this.tsbUnlink.Click += new System.EventHandler(this.tsbUnlink_Click);
            // 
            // tsddbInsertTable
            // 
            this.tsddbInsertTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsddbInsertTable.Image = global::CCWin.Properties.Resources.InsertTable;
            this.tsddbInsertTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbInsertTable.Name = "tsddbInsertTable";
            this.tsddbInsertTable.Size = new System.Drawing.Size(29, 24);
            this.tsddbInsertTable.Tag = "InsertTable";
            this.tsddbInsertTable.Text = "插入表格";
            // 
            // tsbInsertImage
            // 
            this.tsbInsertImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInsertImage.Image = global::CCWin.Properties.Resources.InsertImage;
            this.tsbInsertImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsertImage.Name = "tsbInsertImage";
            this.tsbInsertImage.Size = new System.Drawing.Size(23, 24);
            this.tsbInsertImage.Tag = "InsertImage";
            this.tsbInsertImage.Text = "插入图片";
            this.tsbInsertImage.Click += new System.EventHandler(this.tsbInsertImage_Click);
            // 
            // tsbInsertHorizontalRule
            // 
            this.tsbInsertHorizontalRule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInsertHorizontalRule.Image = global::CCWin.Properties.Resources.InsertHorizontalRule;
            this.tsbInsertHorizontalRule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsertHorizontalRule.Name = "tsbInsertHorizontalRule";
            this.tsbInsertHorizontalRule.Size = new System.Drawing.Size(23, 24);
            this.tsbInsertHorizontalRule.Tag = "InsertHorizontalRule";
            this.tsbInsertHorizontalRule.Text = "插入水平线";
            this.tsbInsertHorizontalRule.Click += new System.EventHandler(this.tsbInsertHorizontalRule_Click);
            // 
            // tsbOutdent
            // 
            this.tsbOutdent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOutdent.Image = global::CCWin.Properties.Resources.Outdent;
            this.tsbOutdent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOutdent.Name = "tsbOutdent";
            this.tsbOutdent.Size = new System.Drawing.Size(23, 24);
            this.tsbOutdent.Tag = "Outdent";
            this.tsbOutdent.Text = "减少缩进";
            this.tsbOutdent.Click += new System.EventHandler(this.tsbOutdent_Click);
            // 
            // tsbIndent
            // 
            this.tsbIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbIndent.Image = global::CCWin.Properties.Resources.Indent;
            this.tsbIndent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbIndent.Name = "tsbIndent";
            this.tsbIndent.Size = new System.Drawing.Size(23, 24);
            this.tsbIndent.Tag = "Indent";
            this.tsbIndent.Text = "增加缩进";
            this.tsbIndent.Click += new System.EventHandler(this.tsbIndent_Click);
            // 
            // tsbInsertUnorderedList
            // 
            this.tsbInsertUnorderedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInsertUnorderedList.Image = global::CCWin.Properties.Resources.InsertUnorderedList;
            this.tsbInsertUnorderedList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsertUnorderedList.Name = "tsbInsertUnorderedList";
            this.tsbInsertUnorderedList.Size = new System.Drawing.Size(23, 24);
            this.tsbInsertUnorderedList.Tag = "InsertUnorderedList";
            this.tsbInsertUnorderedList.Text = "插入无序列表";
            this.tsbInsertUnorderedList.Click += new System.EventHandler(this.tsbInsertUnorderedList_Click);
            // 
            // tsbInsertOrderedList
            // 
            this.tsbInsertOrderedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInsertOrderedList.Image = global::CCWin.Properties.Resources.InsertOrderedList;
            this.tsbInsertOrderedList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsertOrderedList.Name = "tsbInsertOrderedList";
            this.tsbInsertOrderedList.Size = new System.Drawing.Size(23, 24);
            this.tsbInsertOrderedList.Tag = "InsertOrderedList";
            this.tsbInsertOrderedList.Text = "插入有序列表";
            this.tsbInsertOrderedList.Click += new System.EventHandler(this.tsbInsertOrderedList_Click);
            // 
            // tsbSuperscript
            // 
            this.tsbSuperscript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSuperscript.Image = global::CCWin.Properties.Resources.Superscript;
            this.tsbSuperscript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSuperscript.Name = "tsbSuperscript";
            this.tsbSuperscript.Size = new System.Drawing.Size(23, 24);
            this.tsbSuperscript.Tag = "Superscript";
            this.tsbSuperscript.Text = "上标";
            this.tsbSuperscript.Click += new System.EventHandler(this.tsbSuperscript_Click);
            // 
            // tsbSubscript
            // 
            this.tsbSubscript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSubscript.Image = global::CCWin.Properties.Resources.Subscript;
            this.tsbSubscript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSubscript.Name = "tsbSubscript";
            this.tsbSubscript.Size = new System.Drawing.Size(23, 24);
            this.tsbSubscript.Tag = "Subscript";
            this.tsbSubscript.Text = "下标";
            this.tsbSubscript.Click += new System.EventHandler(this.tsbSubscript_Click);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.AutoSize = false;
            this.toolStripLabel4.BackColor = System.Drawing.Color.Transparent;
            this.toolStripLabel4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel4.Image = global::CCWin.Properties.Resources.pictureBox1_Image;
            this.toolStripLabel4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabel4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(5, 24);
            this.toolStripLabel4.Text = "toolStripButton9";
            // 
            // tsbWordCount
            // 
            this.tsbWordCount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbWordCount.Image = global::CCWin.Properties.Resources.wordcount;
            this.tsbWordCount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWordCount.Name = "tsbWordCount";
            this.tsbWordCount.Size = new System.Drawing.Size(23, 24);
            this.tsbWordCount.Tag = "WordCount";
            this.tsbWordCount.Text = "字数统计";
            this.tsbWordCount.Click += new System.EventHandler(this.tsbWordCount_Click);
            // 
            // tsbDate
            // 
            this.tsbDate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDate.Image = global::CCWin.Properties.Resources.Date;
            this.tsbDate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDate.Name = "tsbDate";
            this.tsbDate.Size = new System.Drawing.Size(23, 24);
            this.tsbDate.Tag = "InsertDate";
            this.tsbDate.Text = "日期";
            this.tsbDate.Click += new System.EventHandler(this.tsbDate_Click);
            // 
            // tsbTime
            // 
            this.tsbTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTime.Image = global::CCWin.Properties.Resources.Time;
            this.tsbTime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTime.Name = "tsbTime";
            this.tsbTime.Size = new System.Drawing.Size(23, 24);
            this.tsbTime.Tag = "InsertTime";
            this.tsbTime.Text = "时间";
            this.tsbTime.Click += new System.EventHandler(this.tsbTime_Click);
            // 
            // tsbClearWord
            // 
            this.tsbClearWord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClearWord.Image = global::CCWin.Properties.Resources.Wordclean;
            this.tsbClearWord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearWord.Name = "tsbClearWord";
            this.tsbClearWord.Size = new System.Drawing.Size(23, 24);
            this.tsbClearWord.Tag = "ClearWord";
            this.tsbClearWord.Text = "清除Word格式";
            this.tsbClearWord.Click += new System.EventHandler(this.tsbClearWord_Click);
            // 
            // tsbAutoLayout
            // 
            this.tsbAutoLayout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAutoLayout.Image = global::CCWin.Properties.Resources.AutoLayout;
            this.tsbAutoLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAutoLayout.Name = "tsbAutoLayout";
            this.tsbAutoLayout.Size = new System.Drawing.Size(23, 24);
            this.tsbAutoLayout.Tag = "AutoLayout";
            this.tsbAutoLayout.Text = "自动排版";
            this.tsbAutoLayout.Click += new System.EventHandler(this.tsbAutoLayout_Click);
            // 
            // tsbAbout
            // 
            this.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbout.Image")));
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(23, 24);
            this.tsbAbout.Tag = "About";
            this.tsbAbout.Text = "关于";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // SkinHtmlEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(252)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.tscMain);
            this.Name = "SkinHtmlEditor";
            this.Size = new System.Drawing.Size(1296, 471);
            this.Load += new System.EventHandler(this.HtmlEditor_Load);
            this.tscMain.ContentPanel.ResumeLayout(false);
            this.tscMain.ContentPanel.PerformLayout();
            this.tscMain.TopToolStripPanel.ResumeLayout(false);
            this.tscMain.TopToolStripPanel.PerformLayout();
            this.tscMain.ResumeLayout(false);
            this.tscMain.PerformLayout();
            this.ssHtml.ResumeLayout(false);
            this.ssHtml.PerformLayout();
            this.cmsHtml.ResumeLayout(false);
            this.tsTopToolBar.ResumeLayout(false);
            this.tsTopToolBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscMain;
        private SkinContextMenuStrip cmsHtml;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiCut;
        private System.Windows.Forms.ToolStripMenuItem tsmiPaste;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiFind;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveFormat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        internal System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.ToolStripMenuItem tsmiTable;
        private System.Windows.Forms.ToolStripMenuItem tsmiTableModify;
        private System.Windows.Forms.ToolStripMenuItem tsmiTableInsertRow;
        private System.Windows.Forms.ToolStripMenuItem tsmiTableDeleteRow;
        private System.Windows.Forms.StatusStrip ssHtml;
        private System.Windows.Forms.ToolStripStatusLabel tsslWordCount;
        private SkinToolStrip tsTopToolBar;
        private ToolStripFontComboBox tsfcbFontName;
        private System.Windows.Forms.ToolStripComboBox tscbFontSize;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbPreview;
        private System.Windows.Forms.ToolStripButton tsbShowHTML;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbCut;
        private System.Windows.Forms.ToolStripButton tsbPaste;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbUndo;
        private System.Windows.Forms.ToolStripButton tsbRedo;
        private System.Windows.Forms.ToolStripButton tsbFind;
        private System.Windows.Forms.ToolStripButton tsbRemoveFormat;
        private System.Windows.Forms.ToolStripButton tsbJustifyCenter;
        private System.Windows.Forms.ToolStripButton tsbJustifyFull;
        private System.Windows.Forms.ToolStripButton tsbJustifyLeft;
        private System.Windows.Forms.ToolStripButton tsbJustifyRight;
        private System.Windows.Forms.ToolStripButton tsbUnderline;
        private System.Windows.Forms.ToolStripButton tsbItalic;
        private System.Windows.Forms.ToolStripButton tsbBold;
        private ToolStripColorPicker tscpBackColor;
        private ToolStripColorPicker tscpForeColor;
        private System.Windows.Forms.ToolStripButton tsbStrikeThrough;
        private System.Windows.Forms.ToolStripButton tsbCreateLink;
        private System.Windows.Forms.ToolStripButton tsbUnlink;
        private System.Windows.Forms.ToolStripDropDownButton tsddbInsertTable;
        private System.Windows.Forms.ToolStripButton tsbInsertImage;
        private System.Windows.Forms.ToolStripButton tsbInsertHorizontalRule;
        private System.Windows.Forms.ToolStripButton tsbOutdent;
        private System.Windows.Forms.ToolStripButton tsbIndent;
        private System.Windows.Forms.ToolStripButton tsbInsertUnorderedList;
        private System.Windows.Forms.ToolStripButton tsbInsertOrderedList;
        private System.Windows.Forms.ToolStripButton tsbSuperscript;
        private System.Windows.Forms.ToolStripButton tsbSubscript;
        private System.Windows.Forms.ToolStripButton tsbWordCount;
        private System.Windows.Forms.ToolStripButton tsbDate;
        private System.Windows.Forms.ToolStripButton tsbTime;
        private System.Windows.Forms.ToolStripButton tsbClearWord;
        private System.Windows.Forms.ToolStripButton tsbAutoLayout;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton tsbAbout;
    }
}
