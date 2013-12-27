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
 * * 说明：FrmUserInformation.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using CCWin.SkinControl;

namespace CC2013
{
    public partial class FrmUserInformation : CCSkinMain
    {
        private ChatListSubItem item;
        private Point point;
        public FrmUserInformation(ChatListSubItem Item,Point point)
        {
            InitializeComponent();
            this.Item = Item;
            this.point = point;
        }

        public ChatListSubItem Item 
        {
            get 
            { 
                return item; 
            }
            set 
            {
                if (item != value)
                {
                    item = value;
                    lblName.Text = item.NicName;
                    lblQm.Text = item.PersonalMsg;
                }
            }
        }

        //悬浮至好友Q名时
        private void lblChatName_MouseEnter(object sender, EventArgs e)
        {
            lblName.Font = new Font("微软雅黑", 16F, FontStyle.Underline);
        }

        //离开好友Q名时
        private void lblChatName_MouseLeave(object sender, EventArgs e)
        {
            lblName.Font = new Font("微软雅黑", 16F);
        }

        //窗口加载时
        private void FrmInformation_Load(object sender, EventArgs e)
        {
            //初始化窗口出现位置
            this.Location = point;

            //渐变效果
            tmShow = new System.Timers.Timer();
            tmShow.Elapsed += new System.Timers.ElapsedEventHandler(tmShow_Elapsed);
            tmShow.Interval = 10;
            //滚动效果
            tmShow1 = new System.Timers.Timer();
            tmShow1.Elapsed += new System.Timers.ElapsedEventHandler(tmShow1_Elapsed);
            tmShow1.Interval = 5;
        }

        //窗体重绘时
        private void FrmUserInformation_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(Color.FromArgb(100, 255, 255, 255));
            g.FillRectangle(sb, new Rectangle(new Point(1, Height - 103), new Size(Width - 2, 80)));
        }

        #region 窗体位置

        private Point loactionPoint;

        public Point LoactionPoint
        {
            get
            {
                return loactionPoint;
            }
            set
            {
                loactionPoint = value;
            }
        }

        public void SetLoaction(Point _Point)
        {
            this.Location = _Point;
        }

        #endregion

        #region 渐变效果

        public bool isOpend = false;
        /// <summary>
        /// 隐藏
        /// </summary>
        public new void Hide()
        {
            if (timShow.Enabled == false)
            {
                timShow.Enabled = true;
            }
        }

        /// <summary>
        /// 显示
        /// </summary>
        public new void Show()
        {
            if (isOpend == false)
            {
                base.Show();
                ShowMove();
            }
            isOpend = true;
        }

        //渐变效果
        System.Timers.Timer tmShow;
        //滚动效果
        System.Timers.Timer tmShow1;

        private void ShowMove()
        {
            this.Location = new Point(loactionPoint.X, loactionPoint.Y - 40);
            this.Opacity = 0.3;
            tmShow.Start();
            tmShow1.Start();
        }

        void tmShow1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //需要显示
            if (isOpend == true)
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    this.Location = new Point(this.Location.X, this.Location.Y + 5);
                    if (this.Location.Y == loactionPoint.Y)
                    {
                        tmShow1.Stop();
                    }
                });
            }
            else//需要隐藏
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    this.Location = new Point(this.Location.X, this.Location.Y - 5);
                    if (this.Location.Y == loactionPoint.Y - 40)
                    {
                        base.Hide();
                        tmShow1.Stop();
                    }
                });
            }

        }

        void tmShow_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //需要显示
            if (isOpend == true)
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    if (this.Opacity < 1)
                    {
                        this.Opacity = this.Opacity + 0.1;
                        if (this.Opacity == 1.0)
                        {
                            tmShow.Stop();
                        }
                    }

                });
            }
            else//需要隐藏
            {
                try
                {
                    this.BeginInvoke((MethodInvoker)delegate()
                    {
                        if (this.Opacity > 0)
                        {
                            this.Opacity = this.Opacity - 0.1;
                            if (this.Opacity == 0.3)
                            {
                                base.Hide();
                                tmShow.Stop();
                            }
                        }
                    });
                }
                catch (Exception)
                {
                    
                }
                
            }
        }

        #endregion

        #region 总计时器

        //计时器
        private void timShow_Tick(object sender, EventArgs e)
        {
            //鼠标不在窗体内时
            if (!this.Bounds.Contains(Cursor.Position))
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    isOpend = false;
                    tmShow.Start();
                    tmShow1.Start();
                    loactionPoint = this.Location;
                    timShow.Enabled = false;
                });
            }
            else if (this.Bounds.Contains(Cursor.Position))
            {
                this.Show();
            }
        }

        #endregion

    }
}
