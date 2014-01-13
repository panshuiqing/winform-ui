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
 * * 说明：PassKey.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin.SkinClass;
using CCWin.SkinControl;
using System.Runtime.InteropServices;
using CCWin.Win32.Const;
using CCWin.Win32;

namespace CCWin.SkinControl
{
    public partial class KeyBoardForm : Form
    {
        //需要操作的文本框
        private TextBox txt;
        private int X;
        private int Y;
        //位置显示有问题
        public KeyBoardForm(int x, int y, TextBox txt)
        {
            InitializeComponent();
            this.txt = txt;
            this.X = x;
            this.Y = y;
            //减少闪烁
            SetStyles();
        }

        #region 窗体打开特效 与 重绘
        protected override void OnPaint(PaintEventArgs e)
        {
            //设置圆角矩形窗体
            SkinTools.CreateRegion(this, 4);
            base.OnPaint(e);
        }
        #endregion

        #region 减少闪烁
        private void SetStyles()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer, true);
            //强制分配样式重新应用到控件上
            UpdateStyles();
        }
        #endregion

        #region 窗体停用时
        private void PassKey_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 删除
        private void btnDelet_Click(object sender, EventArgs e)
        {
            if(txt.Text.Length > 0)
            {
                txt.Text = txt.Text.Substring(0, txt.Text.Length - 1);
            }
        }
        #endregion

        #region 追加文本
        private void btn_Click(object sender, EventArgs e)
        {
            SkinButton btn = (SkinButton)sender;
            txt.AppendText(btn.Text);
        }
        #endregion

        #region 大小写变换
        Image Norml;
        Image Mouse;
        bool ToUpper = false;
        bool flag = false;
        private void btnCapsLock_Click(object sender, EventArgs e)
        {
            ToUpper = !ToUpper;
            flag = !flag;
            foreach (SkinButton btn in this.Controls)
            {
                if (btn.Tag.ToString() == "2")
                {
                    btn.Text = ToUpper ? btn.Text.ToUpper() : btn.Text.ToLower();
                }
            }
            if (flag)
            {
                Norml = btnCapsLock.NormlBack;
                Mouse = btnCapsLock.MouseBack;
                btnCapsLock.NormlBack = btnCapsLock.DownBack;
                btnCapsLock.MouseBack = btnCapsLock.DownBack;
            }
            else 
            {
                btnCapsLock.NormlBack = Norml;
                btnCapsLock.MouseBack = Mouse;
            }
        }
        #endregion

        #region 切换键
        Image Norml2;
        Image Mouse2;
        bool flag2 = false;
        private void btnShift_Click(object sender, EventArgs e)
        {
            ToUpper = !ToUpper;
            flag2 = !flag2;
            //变换大小写
            foreach (SkinButton btn in this.Controls)
            {
                if (btn.Tag.ToString() == "2")
                {
                    btn.Text = ToUpper ? btn.Text.ToUpper() : btn.Text.ToLower();
                }
            }

            //变换数字与符号
            foreach (SkinButton btn in this.Controls)
            {
                if (btn.Tag.ToString().Substring(0, 1) == "1")
                {
                    btn.Text = flag2 ? btn.Tag.ToString().Substring(1, 1) : btn.Tag.ToString().Substring(2);
                }
            }
            if (flag2)
            {
                Norml2 = btnShift.NormlBack;
                Mouse2 = btnShift.MouseBack;
                btnShift.NormlBack = btnShift.DownBack;
                btnShift.MouseBack = btnShift.DownBack;
            }
            else
            {
                btnShift.NormlBack = Norml2;
                btnShift.MouseBack = Mouse2;
            }
        }
        #endregion

        #region 关闭窗体时
        private void PassKey_FormClosing(object sender, FormClosingEventArgs e)
        {
            //开始窗体动画
            NativeMethods.AnimateWindow(this.Handle, 0, AW.AW_BLEND + AW.AW_HIDE);
        }
        #endregion

        [DefaultValue("关闭")]
        [Category("Skin")]
        [Description("关闭按钮鼠标提示文本")]
        public string CloseButtonText
        {
            get;
            set;
        }

        #region 窗体加载时
        private void PassKey_Load(object sender, EventArgs e)
        {
            this.toolShow.SetToolTip(this.btnClose, CloseButtonText ?? "关闭");
            this.Location = new Point(X, Y);
            //开始窗体动画
            NativeMethods.AnimateWindow(this.Handle, 0, AW.AW_SLIDE + AW.AW_BLEND);
        }
        #endregion
    }
}
