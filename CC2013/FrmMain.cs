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
 * * 说明：FrmMain.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using CCWin;
using CCWin.SkinControl;
using System.Runtime.InteropServices;
using CCWin.Win32;

namespace CC2013
{
    public partial class FrmMain : CCSkinMain
    {
        #region 变量

        //变量
        private string Id;
        private Image Title;
        private int form_top_old;
        private int form_left_old;
        private int form_right_old;
        private int SW;
        private int SH;
        private ChatListSubItem UserItem;
        private User_Param userParam; //传递参数

        #endregion

        #region 构造
        public FrmMain()
        {
            FrmMain.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            //订阅自定义事件
            Helper.eventSend += new SendHandler(ReceiveParam);
        }
        #endregion

        #region 带参构造

        public FrmMain(string id, Image title, SkinButton BtnState)
            : this()
        {
            //New一个当前用户的对象
            UserItem = new ChatListSubItem(id, (ChatListSubItem.UserStatus)Convert.ToInt32(BtnState.Tag));
            UserItem.HeadImage = title;
            UserItem.PersonalMsg = lblQm.Text;
            UserLogin.UserItem = UserItem;
            //获取当前登录帐号与头像
            this.Id = lblName.Text = id;
            this.Title = title;
            //获取当前状态
            btnState.Image = BtnState.Image;
            btnState.Tag = BtnState.Tag;
            btnState.Left = lblName.Right;
            lblLv.Left = btnState.Right;
            //获取屏幕宽高
            SW = Screen.PrimaryScreen.Bounds.Width;
            SH = Screen.PrimaryScreen.Bounds.Height;
        }

        public FrmMain(User_Param userParam)
            : this()
        {
            //New一个当前用户的对象
            UserItem = new ChatListSubItem(userParam.Id, (ChatListSubItem.UserStatus)Convert.ToInt32(userParam.BtnState.Tag));
            UserItem.HeadImage = userParam.HeadImg;
            UserItem.PersonalMsg = lblQm.Text;
            UserLogin.UserItem = UserItem;
            //获取当前登录帐号与头像
            this.Id = lblName.Text = userParam.Id;
            this.Title = userParam.HeadImg;
            //获取当前状态
            btnState.Image = userParam.BtnState.Image;
            btnState.Tag = userParam.BtnState.Tag;
            btnState.Left = lblName.Right;
            lblLv.Left = btnState.Right;
            //获取屏幕宽高
            SW = Screen.PrimaryScreen.Bounds.Width;
            SH = Screen.PrimaryScreen.Bounds.Height;

            //
            this.userParam = userParam;
            if (userParam.BackImg != null)
            {
                this.Back = userParam.BackImg;
                this.btnTq.Image = userParam.WeatherImg;
            }
            //else
            //{
            //    btnTq.Visible = false;
            //}

        }

        #endregion

        #region 监听事件
        //监听事件
        void ReceiveParam(object sender, object msg)
        {
            Type t = msg.GetType();
            if (t.IsEnum)
            {
                eFrom e = (eFrom)msg;
                switch (e)
                {
                    case eFrom.Main_BackImg:
                        this.Back = userParam.BackImg;
                        this.btnTq.Image = userParam.WeatherImg;
                        break;
                }
            }
        }

        #endregion

        #region Load事件

        //窗口加载时
        private void FormCSharpWinDemo_Load(object sender, EventArgs e)
        {
            FrmInformation frm = new FrmInformation(Id, Title, userParam.IpStat);
            frm.Show(this);
            string temp = string.Empty;
            //获取屏幕宽高与调节最大大小
            this.MaximumSize = new Size(543, Screen.GetWorkingArea(this).Height);

            //监听消息（广播和聊天）
            ClassStartUdpThread startUdpThread = new ClassStartUdpThread(chatShow);
            Thread tStartUdpThread = new Thread(new ThreadStart(startUdpThread.StartUdpThread));
            tStartUdpThread.IsBackground = true;
            tStartUdpThread.Start();

            //第一次登录时发送广播消息，查看在线用户
            ClassBoardCast boardCast = new ClassBoardCast();
            boardCast.BoardCast();
        }

        #endregion

        #region 计时器贴边隐藏
        //贴边隐藏
        int? hg = null;
        private void timHide_Tick(object sender, EventArgs e)
        {
            //隐藏窗口的方法
            form_top_old = 2 - this.Height;
            form_left_old = 2 - this.Width;
            form_right_old = SW - 2;
            //没点击移动时
            if (!this.isMouseDown)
            {
                //鼠标在窗体内时
                if (this.Bounds.Contains(Cursor.Position))
                {
                    switch (this.Aanhor)
                    {
                        //执行右移特效
                        case AnchorStyles.Left:
                            if (hg == null)
                            {
                                hg = this.Height;
                            }
                            this.Height = MaximumSize.Height;
                            this.Top = 0;
                            int b = this.Left;
                            for (int i = b; i < 0; i += 1)
                            {
                                this.Left = i;
                            }
                            this.Left = 0;
                            break;
                        //执行左移特效
                        case AnchorStyles.Right:
                            if (hg == null)
                            {
                                hg = this.Height;
                            }
                            this.Height = MaximumSize.Height;
                            this.Top = 0;
                            int c = this.Left;
                            for (int i = c; i > SW - this.Width; i -= 1)
                            {
                                this.Left = i;
                            }
                            this.Left = SW - this.Width;
                            break;
                        //执行下移特效
                        case AnchorStyles.Top:
                            int a = this.Top;
                            for (int i = a; i < 0; i += 2)
                            {
                                this.Top = i;
                            }
                            this.Top = 0;
                            break;
                    }
                    //hg不为空的话，恢复成原来高度
                    if (hg != null && this.Left > 0 && this.Left < Screen.PrimaryScreen.Bounds.Width - this.Width)
                    {
                        this.Height = (int)hg;
                        hg = null;
                    }
                }
                else
                {
                    switch (this.Aanhor)
                    {
                        //执行左移特效
                        case AnchorStyles.Left:
                            if (this.Left != form_left_old)
                            {
                                for (int i = 0; i >= form_left_old; i -= 1)
                                {
                                    this.Left = i;
                                }
                                this.Left = form_left_old;
                            }
                            break;
                        //执行右移特效
                        case AnchorStyles.Right:
                            if (this.Left != form_right_old)
                            {
                                for (int i = SW - this.Width; i <= form_right_old; i += 1)
                                {
                                    this.Left = i;
                                }
                                this.Left = form_right_old;
                            }
                            break;
                        //执行上移特效
                        case AnchorStyles.Top:
                            if (this.Top != form_top_old)
                            {
                                for (int i = 0; i >= form_top_old; i -= 2)
                                {
                                    this.Top = i;
                                }
                                this.Top = form_top_old;
                            }
                            break;
                    }
                }
            }
        }

        //窗体关闭时
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClassBoardCast cUserQuit = new ClassBoardCast();
            cUserQuit.UserQuit();
            //Application.Exit();
            System.Environment.Exit(0);
        }

        //双击好有时
        private void chatShow_DoubleClickSubItem(object sender, ChatListEventArgs e)
        {
            ChatListSubItem item = e.SelectSubItem;
            item.IsTwinkle = false;

            //bool isFormexist;
            string windowsName = "与 " + item.NicName + " 对话中";
            IntPtr handle = NativeMethods.FindWindow(null, windowsName);
            if (handle != IntPtr.Zero)
            {
                Form frm = (Form)Form.FromHandle(handle);
                frm.Activate();
            }
            else
            {
                //ipSend为从列表中取出，要发送的对象的IP
                string ipSend = item.IpAddress;
                string nameSend = item.DisplayName;
                string idSend = item.NicName;
                string mesSend = string.Empty;
                FrmChat fChat = new FrmChat(ipSend, nameSend, idSend, mesSend);
                //fChat.Name = lvItem.SubItems[0].Text;
                fChat.Text = "与 " + item.NicName + " 对话中";
                fChat.Show();
            }

        }

        //QQ主菜单悬浮时
        private void toolQQMenu_MouseEnter(object sender, EventArgs e)
        {
            toolQQMenu.Image = Properties.Resources.menu_btn_highlight;
        }

        //QQ主菜单离开时
        private void toolQQMenu_MouseLeave(object sender, EventArgs e)
        {
            if (!QQMenu.Visible)
            {
                toolQQMenu.Image = Properties.Resources.menu_btn_normal;
            }
        }

        //打开QQ主菜单
        private void toolQQMenu_Click(object sender, EventArgs e)
        {
            QQMenu.Show(SkToolCdTwo, new Point(3, -2), ToolStripDropDownDirection.AboveRight);
            toolQQMenu.Image = Properties.Resources.menu_btn_highlight;
            toolQQMenu.Checked = true;
        }

        //QQ主菜单关闭时
        private void QQMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            toolQQMenu.Image = Properties.Resources.menu_btn_normal;
            toolQQMenu.Checked = false;
        }

        //窗体重绘时
        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(Color.FromArgb(100, 255, 255, 255));
            g.FillRectangle(sb, new Rectangle(new Point(1, Height - 60), new Size(Width - 2, 60)));
        }

        //悬浮至头像时
        private FrmUserInformation frm;
        private void chatShow_MouseEnterHead(object sender, ChatListEventArgs e)
        {
            //窗体的TopLeft值
            int UserTop = this.Top + this.ChatTab.Top + this.ChatTab.ItemSize.Height + this.chatShow.Top + (e.MouseOnSubItem.HeadRect.Y - chatShow.chatVScroll.Value);
            int UserLeft = this.Left - 279 - 5;
            //屏幕不包括任务栏的高度
            int PH = Screen.GetWorkingArea(this).Height;
            //判断是否超过屏幕高度
            if (UserTop + 181 > PH)
            {
                UserTop = PH - 181 - 5;
            }
            //判断是否小于屏幕左边
            if (UserLeft < 0)
            {
                UserLeft = this.Right + 5;
            }

            //窗体不为空传值
            if (frm != null)
            {
                frm.Item = e.MouseOnSubItem;
                frm.Location = frm.LoactionPoint = new Point(UserLeft, UserTop);
                frm.Show();
            }
            else  //窗体为空New一个
            {

                frm = new FrmUserInformation(UserItem, new Point(UserLeft, UserTop));
                frm.LoactionPoint = new Point(UserLeft, UserTop);
                frm.Show(this);
            }
        }

        //离开头像时
        private void chatShow_MouseLeaveHead(object sender, ChatListEventArgs e)
        {
            frm.Hide();
        }

        //选择状态
        private void btnState_Click(object sender, EventArgs e)
        {
            MenuState.Show(btnState, new Point(0, btnState.Height), ToolStripDropDownDirection.Right);
        }

        //状态选择项
        private void Item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem Item = (ToolStripMenuItem)sender;
            btnState.Image = Item.Image;
            btnState.Tag = Item.Tag;
            UserItem.Status = (ChatListSubItem.UserStatus)Convert.ToInt32(btnState.Tag);
        }

        //窗体大小改变时
        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            Size sizef = TextRenderer.MeasureText(lblName.SetStrLeng(lblName.Text, lblName.Font, lblName.Width), lblName.Font);
            btnState.Left = sizef.Width + lblName.Left + 10;
            lblLv.Left = btnState.Left + 23;
        }

        //拖动完图片后
        private void FrmMain_DragDrop(object sender, DragEventArgs e)
        {
            BackLayout = true;
        }
        #endregion

        #region 用户名悬浮事件
        //用户名悬浮时
        private void lblName_MouseHover(object sender, EventArgs e)
        {
            //窗体的TopLeft值
            int UserTop = this.Top + lblName.Top;
            int UserLeft = this.Left - 279 - 2;
            //屏幕不包括任务栏的高度
            int PH = Screen.GetWorkingArea(this).Height;
            //判断是否超过屏幕高度
            if (UserTop + 181 > PH)
            {
                UserTop = PH - 181 - 5;
            }
            //判断是否小于屏幕左边
            if (UserLeft < 0)
            {
                UserLeft = this.Right + 5;
            }
            //窗体不为空传值
            if (frm != null)
            {
                frm.Item = UserItem;
                frm.Location = frm.LoactionPoint = new Point(UserLeft, UserTop);
                frm.Show();
            }
            else  //窗体为空New一个
            {

                frm = new FrmUserInformation(UserItem, new Point(UserLeft, UserTop));
                frm.LoactionPoint = new Point(UserLeft, UserTop);
                frm.Show(this);
            }
        }

        //用户名离开时
        private void lblName_MouseLeave(object sender, EventArgs e)
        {
            if (frm != null)
            {
                frm.Hide();
            }
        }

        #endregion

        #region 天气悬浮事件
        //悬浮至头像时
        private FrmWeather frmWeather;
        private void btnTq_MouseHover(object sender, EventArgs e)
        {
            //窗体的TopLeft值
            int UserTop = this.Top;
            //int UserLeft = this.Left - 240 - 2;
            int UserLeft = this.Right + 2;
            //屏幕不包括任务栏的高度
            int PH = Screen.GetWorkingArea(this).Height;
            //判断是否超过屏幕高度
            if (UserTop + 250 > PH)
            {
                UserTop = PH - 250 - 2;
            }
            //判断是否小于屏幕左边
            //if (UserLeft < 0)
            //{
            //    UserLeft = this.Right + 2;
            //}

            int PW = Screen.GetWorkingArea(this).Width;
            //判断是否大于屏幕右边
            if (UserLeft + 240 + 2 > PW)
            {
                UserLeft = this.Left - 240 - 2;
            }
            //窗体不为空传值
            if (frmWeather != null)
            {
                if (this.userParam.BackImg == null && frmWeather.frm.IsDisposed)
                {
                    frmWeather.Special = true;
                    frmWeather.BaseHide();
                    frmWeather.frm = new FrmWeatherFit(frmWeather, new Point(UserLeft, UserTop));
                    frmWeather.frm.Show();
                }
                else if (frmWeather.frm == null || frmWeather.frm.IsDisposed)
                {
                    frmWeather.Location = frmWeather.LoactionPoint = new Point(UserLeft, UserTop);
                    frmWeather.Special = false;
                    frmWeather.Show();
                }
            }
            else
            {
                frmWeather = new FrmWeather(this.userParam, new Point(UserLeft, UserTop));
                frmWeather.Location = new Point(UserLeft, UserTop);
                frmWeather.LoactionPoint = new Point(UserLeft, UserTop);

                if (this.userParam.BackImg == null && (frmWeather.frm == null || frmWeather.frm.IsDisposed))
                {
                    frmWeather.Special = true;
                    frmWeather.BaseHide();
                    frmWeather.frm = new FrmWeatherFit(frmWeather, new Point(UserLeft, UserTop));
                    frmWeather.frm.Show();
                }
                else
                {
                    frmWeather.Show();
                }

            }
        }

        private void btnTq_MouseLeave(object sender, EventArgs e)
        {
            if (frmWeather == null) { return; }
            if (this.userParam.BackImg == null && frmWeather.frm == null)
            {
                //frmWeather.Hide();
                frmWeather.BaseHide();
            }
            else
            {
                if (frmWeather.Visible)
                {
                    frmWeather.Special = false;
                    frmWeather.Hide();
                }

            }
        }

        #endregion

        #region 删除分组
        private void toolDeletGrouping_Click(object sender, EventArgs e)
        {
            chatShow.Items.Remove(chatShow.SelectItem);
        }
        #endregion

        #region 查找好友
        /// <summary>
        /// 
        /// </summary>
        private int searchIndex = 0;
        private ChatListSubItem[] searchItems;
        private string searchText = null;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string findText = txtSearch.Text;
            if (findText != searchText)//搜索内容变化
            {
                searchIndex = 0;
                searchItems = chatShow.GetSubItemsByText(findText);
            }
            if (searchItems != null)
            {
                if (searchIndex < searchItems.Length)
                {
                    chatShow.SelectSubItem = searchItems[searchIndex];
                }
                searchIndex++;
                if (searchIndex == searchItems.Length)
                {
                    searchIndex = 0;
                }
            }
            else//没有查找到
            {
                chatShow.SelectSubItem = null;
            }
        }
        #endregion

        #region 打开与关闭最近菜单组
        bool isCloseAllGroup = false;
        private void toolStripBtnFriend_ButtonClick(object sender, EventArgs e)
        {
            if (chatShow.ListHadOpenGroup == null
                || chatShow.ListHadOpenGroup.Count == 0)
            {
                return;
            }
            isCloseAllGroup = !isCloseAllGroup;
            if (isCloseAllGroup)
            {
                chatShow.CollapseAll();
            }
            else
            {
                chatShow.Regain();
            }
        }
        #endregion

        //删除好友
        private void toolDeletUser_Click(object sender, EventArgs e) {
            this.chatShow.SelectSubItem.OwnerListItem.SubItems.Remove(this.chatShow.SelectSubItem);
        }
    }
}