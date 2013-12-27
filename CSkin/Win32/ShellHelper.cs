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
 * * 说明：ShellHelper.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace CCWin.Win32
{
    public static class ShellHelper
    {
        private static readonly Regex r = new Regex(
            @"c=\[c:(?<key>.+)\]", RegexOptions.Compiled);

        public static void ApplicationExit()
        {
            ApplicationExit(0);
        }

        public static void ApplicationExit(int exitCode)
        {
            try
            {
                Environment.Exit(exitCode);
            }
            catch
            {
            }
        }

        public static string ParseUrl(string url, IDictionary<string, string> credentials)
        {
            if (credentials != null)
            {
                Match match = r.Match(url);
                if (!match.Success)
                {
                    return url;
                }
                string str = "";
                string str2 = match.Result("${key}");
                if (string.IsNullOrEmpty(str2))
                {
                    return url;
                }
                if (credentials.ContainsKey(str2))
                {
                    str = HttpWebRequestHelper.UrlEncode(credentials[str2]);
                }
                url = r.Replace(url, "c=" + str);
            }
            return url;
        }

        public static void StartUrl(string url)
        {
            try
            {
                StringBuilder builder = new StringBuilder(
                    ParseString((string)Registry.ClassesRoot.OpenSubKey(
                    @"HTTP\shell\open\command", false).GetValue(string.Empty, string.Empty)));
                builder.Append(" ");
                builder.Append(url);
                NativeMethods.WinExec(builder.ToString(), 5);
            }
            catch
            {
                try
                {
                    StringBuilder builder2 = new StringBuilder(
                        ParseString((string)Registry.ClassesRoot.OpenSubKey(
                        @"Applications\iexplore.exe\shell\open\command", false).GetValue(
                        string.Empty, string.Empty)));
                    builder2.Append(" ");
                    builder2.Append(url);
                    NativeMethods.WinExec(builder2.ToString(), 5);
                }
                catch
                {
                }
            }
        }

        public static void StartUrl(string url, IDictionary<string, string> credentials)
        {
            StartUrl(ParseUrl(url, credentials));
        }

        private static string ParseString(string value)
        {
            if (value.Substring(0, 1) == "\"")
            {
                int index = value.IndexOf("\"", 1);
                return value.Substring(0, index + 1);
            }
            return value.Split(new char[] { ' ' })[0];
        }
    }
}
