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
 * * 说明：ClassBoardCast.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace CC2013
{
    class ClassBoardCast
    {
        UdpClient bcUdpClient = new UdpClient();
        IPEndPoint bcIPEndPoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 2425);

        public string localIP = string.Empty;

        //获取本机IP，如果是vista或windows7，取InterNetwork对应的地址
        public void GetLocalIP()
        {
            try
            {
                foreach (IPAddress _ipAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                {
                    if (_ipAddress.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = _ipAddress.ToString();
                        break;
                    }
                    else
                    {
                        localIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //发送自己的信息到广播地址
        public void BoardCast()
        {
            GetLocalIP();
            string computerInfo = ":USER:" + UserLogin.UserItem.NicName + ":" + System.Environment.UserName +
                ":" + localIP + ":" + UserLogin.UserItem.PersonalMsg.Trim();

            byte[] buff = Encoding.Default.GetBytes(computerInfo);
           // while (true)
            //{
                bcUdpClient.Send(buff, buff.Length, bcIPEndPoint);
           //     Thread.Sleep(2000);
            //}
        }

        //用户退出时，发送消息至广播地址
        public void UserQuit()
        {
            GetLocalIP();
            string quitInfo = ":QUIT:" + localIP;
            byte[] bufQuit = Encoding.Default.GetBytes(quitInfo);

            bcUdpClient.Send(bufQuit, bufQuit.Length, bcIPEndPoint);
        }

        //收到别人上线的通知时，回复对方，以便对方将自己加入在线用户列表
        public void BCReply(string ipReply)
        {
            GetLocalIP();
            IPEndPoint EPReply = new IPEndPoint(IPAddress.Parse(ipReply), 2425);
            string computerInfo = ":USER:" + UserLogin.UserItem.NicName + ":" + System.Environment.UserName +
                ":" + localIP + ":" + UserLogin.UserItem.PersonalMsg.Trim();

            byte[] buff = Encoding.Default.GetBytes(computerInfo);
            bcUdpClient.Send(buff, buff.Length, EPReply);
        }
    }
}
