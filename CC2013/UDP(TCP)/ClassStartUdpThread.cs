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
 * * 说明：ClassStartUdpThread.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Runtime.InteropServices;
using CCWin.SkinControl;
using System.Drawing;

namespace CC2013
{
    class ClassStartUdpThread
    {
        private ChatListBox Chat;
        private ChatListItem ListItem;
        private ChatListItem MyNameItem;
        private ChatListItem HNameItem;
        public ClassStartUdpThread(ChatListBox chat)
        {
            this.Chat = chat;
            ListItem = new ChatListItem("我的好友");
            MyNameItem = new ChatListItem("自己");
            HNameItem = new ChatListItem("黑名单");
            Chat.Items.Add(ListItem);
            Chat.Items.Add(MyNameItem);
            Chat.Items.Add(HNameItem);
        }

        //在程序运行后保持监听2425端口，负责处理各种类型消息
        public void StartUdpThread()
        {
            UdpClient udpClient = new UdpClient(2425);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                byte[] buff = udpClient.Receive(ref ipEndPoint);
                string userInfo = Encoding.Default.GetString(buff);
                string msgHead = userInfo.Substring(0, 6);//消息前6位为消息类型标识符
                string msgBody = userInfo.Substring(6);//第7位开始为消息实体内容

                switch(msgHead)
                {
                    /*用户第一次登录时发送USER消息到广播地址，收到此类消息会将对方
                     * 加入到自己的在线好友列表中，并回复对方消息，告诉对方自己在线 */
                    case ":USER:" :
                        try
                        {
                            string[] sBody = msgBody.Split(':');
                            //New一个用户
                            ChatListSubItem subItem = new ChatListSubItem(sBody[0], sBody[1], sBody[3]);
                            subItem.HeadImage = Image.FromFile("head/4.png");
                            subItem.IpAddress = sBody[2];
                            //在集合中查找用户，没有则加，有则更新信息
                            if (Chat.GetSubItemsByIp(sBody[2]).Length > 0)
                            {
                                Chat.GetSubItemsByIp(sBody[2])[0] = subItem;
                            }
                            else
                            {
                                if (UserLogin.UserItem.NicName == sBody[0])
                                {
                                    MyNameItem.SubItems.Add(subItem);
                                }
                                else 
                                {
                                    ListItem.SubItems.Add(subItem);
                                }
                            }

                            //回复消息
                            ClassBoardCast CReply = new ClassBoardCast();
                            CReply.BCReply(subItem.IpAddress);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;

                    //聊天消息MESG
                    case ":MESG:":
                        try
                        {
                            string[] mBody = msgBody.Split('|');
                            string msgName = mBody[0];
                            string msgID = mBody[1];
                            string msgIP = mBody[2];
                            string msgDetail = mBody[3];
                            
                            //创建一条新线程接收消息
                            ClassReceiveMsg cRecMsg = new ClassReceiveMsg(msgIP, msgName,msgID, msgDetail);
                            Thread tRecMsg = new Thread(new ThreadStart(cRecMsg.StartRecMsg));
                            tRecMsg.Start();
                        }
                        catch
                        {
                        }
                        break; 

                    //用户退出时发送QUIT开头的消息
                    case ":QUIT:":
                        try
                        {
                            //在集合中查找用户，没有则加，有则更新信息
                            if (Chat.GetSubItemsByIp(msgBody).Length > 0)
                            {
                                Chat.GetSubItemsByIp(msgBody)[0].OwnerListItem.SubItems.Remove(Chat.GetSubItemsByIp(msgBody)[0]);
                            }
                        }
                        catch
                        { 
                        }
                        break;

                    /*自己上线时会向广播发送消息，在接到别人以REPY开头的回复消息时，
                    将对方加入自己的在线好友列表中*/        
                    case ":REPY:":
                        try
                        {
                            string[] sBody = msgBody.Split(':');
                            //New一个用户
                            ChatListSubItem subItem = new ChatListSubItem(sBody[0], sBody[1], sBody[3]);
                            subItem.HeadImage = Image.FromFile("head/4.png");
                            subItem.IpAddress = sBody[2];
                            //在集合中查找用户，没有则加，有则更新信息
                            if (Chat.GetSubItemsByIp(sBody[2]).Length > 0)
                            {
                                Chat.GetSubItemsByIp(sBody[2])[0] = subItem;
                            }
                            else
                            {
                                if (UserLogin.UserItem.NicName == sBody[0])
                                {
                                    MyNameItem.SubItems.Add(subItem);
                                }
                                else
                                {
                                    ListItem.SubItems.Add(subItem);
                                }
                            }
                           
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;

                    //以DATA开头的消息，表示有人发送文件
                    case ":DATA:":
                        try
                        {
                            string[] mBody = msgBody.Split('|');
                            string msgName = mBody[0];
                            string msgID = mBody[1];
                            string msgIP = mBody[2];
                            string msgFileName = mBody[3];
                            string msgFileLen = mBody[4];
                            
                            string msgDetail = "【发送文件】" + msgFileName+"("+msgFileLen+")";
                            //创建一条新线程接收消息
                            ClassReceiveMsg cRecMsg = new ClassReceiveMsg(msgIP, msgName, msgID, msgDetail);
                            Thread tRecMsg = new Thread(new ThreadStart(cRecMsg.StartRecMsg));
                            tRecMsg.Start();
                        }
                        catch
                        { 
                        }
                        break;

                    //接到以ACEP开头的消息，表示对方同意接收文件
                    case ":ACEP:":
                        try
                        {
                            string[] mFileBody = msgBody.Split('|');
                            string mFilePath = mFileBody[3];
                            string mIP = mFileBody[2];

                            ClassSendFile cSendFile = new ClassSendFile(mFilePath, mIP);
                            Thread tSendFile = new Thread(new ThreadStart(cSendFile.SendFile));
                            tSendFile.IsBackground = true;
                            tSendFile.Start();
                        }
                        catch
                        { 
                        }
                        break;
                }
                Thread.Sleep(200);
            }
        }       
    }
}
