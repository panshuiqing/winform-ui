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
 * * 说明：WryLocator.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace CC2013
{
    public class IPLocation
    {
        public string IP { get; set; }
        public string Country { get; set; }
        public string Local { get; set; }
    }
    public class WryLocator
    {
        private byte[] data;
        Regex regex = new Regex(@"(((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))");
        long firstStartIpOffset;
        long lastStartIpOffset;
        long ipCount;
        public long Count { get { return ipCount; } }
        public WryLocator(string dataPath)
        {
            using (FileStream fs = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
            }
            byte[] buffer = new byte[8];
            Array.Copy(data, 0, buffer, 0, 8);
            firstStartIpOffset = ((buffer[0] + (buffer[1] * 0x100)) + ((buffer[2] * 0x100) * 0x100)) + (((buffer[3] * 0x100) * 0x100) * 0x100);
            lastStartIpOffset = ((buffer[4] + (buffer[5] * 0x100)) + ((buffer[6] * 0x100) * 0x100)) + (((buffer[7] * 0x100) * 0x100) * 0x100);
            ipCount = Convert.ToInt64((double)(((double)(lastStartIpOffset - firstStartIpOffset)) / 7.0));

            if (ipCount <= 1L)
            {
                throw new ArgumentException("ip FileDataError");
            }
        }
        private static long IpToInt(string ip)
        {
            char[] separator = new char[] { '.' };
            if (ip.Split(separator).Length == 3)
            {
                ip = ip + ".0";
            }
            string[] strArray = ip.Split(separator);
            long num2 = ((long.Parse(strArray[0]) * 0x100L) * 0x100L) * 0x100L;
            long num3 = (long.Parse(strArray[1]) * 0x100L) * 0x100L;
            long num4 = long.Parse(strArray[2]) * 0x100L;
            long num5 = long.Parse(strArray[3]);
            return (((num2 + num3) + num4) + num5);
        }
        private static string IntToIP(long ip_Int)
        {
            long num = (long)((ip_Int & 0xff000000L) >> 0x18);
            if (num < 0L)
            {
                num += 0x100L;
            }
            long num2 = (ip_Int & 0xff0000L) >> 0x10;
            if (num2 < 0L)
            {
                num2 += 0x100L;
            }
            long num3 = (ip_Int & 0xff00L) >> 8;
            if (num3 < 0L)
            {
                num3 += 0x100L;
            }
            long num4 = ip_Int & 0xffL;
            if (num4 < 0L)
            {
                num4 += 0x100L;
            }
            return (num.ToString() + "." + num2.ToString() + "." + num3.ToString() + "." + num4.ToString());
        }
        public IPLocation Query(string ip)
        {
            if (!regex.Match(ip).Success)
            {
                throw new ArgumentException("IP格式错误");
            }
            IPLocation ipLocation = new IPLocation() { IP = ip };
            long intIP = IpToInt(ip);
            if ((intIP >= IpToInt("127.0.0.1") && (intIP <= IpToInt("127.255.255.255"))))
            {
                ipLocation.Country = "本机内部环回地址";
                ipLocation.Local = "";
            }
            else
            {
                if ((((intIP >= IpToInt("0.0.0.0")) && (intIP <= IpToInt("2.255.255.255"))) || ((intIP >= IpToInt("64.0.0.0")) && (intIP <= IpToInt("126.255.255.255")))) ||
                ((intIP >= IpToInt("58.0.0.0")) && (intIP <= IpToInt("60.255.255.255"))))
                {
                    ipLocation.Country = "网络保留地址";
                    ipLocation.Local = "";
                }
            }
            long right = ipCount;
            long left = 0L;
            long middle = 0L;
            long startIp = 0L;
            long endIpOff = 0L;
            long endIp = 0L;
            int countryFlag = 0;
            while (left < (right - 1L))
            {
                middle = (right + left) / 2L;
                startIp = GetStartIp(middle, out endIpOff);
                if (intIP == startIp)
                {
                    left = middle;
                    break;
                }
                if (intIP > startIp)
                {
                    left = middle;
                }
                else
                {
                    right = middle;
                }
            }
            startIp = GetStartIp(left, out endIpOff);
            endIp = GetEndIp(endIpOff, out countryFlag);
            if ((startIp <= intIP) && (endIp >= intIP))
            {
                string local;
                ipLocation.Country = GetCountry(endIpOff, countryFlag, out local);
                ipLocation.Local = local;
            }
            else
            {
                ipLocation.Country = "未知";
                ipLocation.Local = "";
            }
            return ipLocation;
        }
        private long GetStartIp(long left, out long endIpOff)
        {
            long leftOffset = firstStartIpOffset + (left * 7L);
            byte[] buffer = new byte[7];
            Array.Copy(data, leftOffset, buffer, 0, 7);
            endIpOff = (Convert.ToInt64(buffer[4].ToString()) + (Convert.ToInt64(buffer[5].ToString()) * 0x100L)) + ((Convert.ToInt64(buffer[6].ToString()) * 0x100L) * 0x100L);
            return ((Convert.ToInt64(buffer[0].ToString()) + (Convert.ToInt64(buffer[1].ToString()) * 0x100L)) + ((Convert.ToInt64(buffer[2].ToString()) * 0x100L) * 0x100L)) + (((Convert.ToInt64(buffer[3].ToString()) * 0x100L) * 0x100L) * 0x100L);
        }
        private long GetEndIp(long endIpOff, out int countryFlag)
        {
            byte[] buffer = new byte[5];
            Array.Copy(data, endIpOff, buffer, 0, 5);
            countryFlag = buffer[4];
            return ((Convert.ToInt64(buffer[0].ToString()) + (Convert.ToInt64(buffer[1].ToString()) * 0x100L)) + ((Convert.ToInt64(buffer[2].ToString()) * 0x100L) * 0x100L)) + (((Convert.ToInt64(buffer[3].ToString()) * 0x100L) * 0x100L) * 0x100L);
        }
        /// <summary>
        /// Gets the country.
        /// </summary>
        /// <param name="endIpOff">The end ip off.</param>
        /// <param name="countryFlag">The country flag.</param>
        /// <param name="local">The local.</param>
        /// <returns>country</returns>
        private string GetCountry(long endIpOff, int countryFlag, out string local)
        {
            string country = "";
            long offset = endIpOff + 4L;
            switch (countryFlag)
            {
                case 1:
                case 2:
                    country = GetFlagStr(ref offset, ref countryFlag, ref endIpOff);
                    offset = endIpOff + 8L;
                    local = (1 == countryFlag) ? "" : GetFlagStr(ref offset, ref countryFlag, ref endIpOff);
                    break;
                default:
                    country = GetFlagStr(ref offset, ref countryFlag, ref endIpOff);
                    local = GetFlagStr(ref offset, ref countryFlag, ref endIpOff);
                    break;
            }
            return country;
        }
        private string GetFlagStr(ref long offset, ref int countryFlag, ref long endIpOff)
        {
            int flag = 0;
            byte[] buffer = new byte[3];

            while (true)
            {
                //用于向前累加偏移量
                long forwardOffset = offset;
                flag = data[forwardOffset++];
                //没有重定向
                if (flag != 1 && flag != 2)
                {
                    break;
                }
                Array.Copy(data, forwardOffset, buffer, 0, 3);
                forwardOffset += 3;
                if (flag == 2)
                {
                    countryFlag = 2;
                    endIpOff = offset - 4L;
                }
                offset = (Convert.ToInt64(buffer[0].ToString()) + (Convert.ToInt64(buffer[1].ToString()) * 0x100L)) + ((Convert.ToInt64(buffer[2].ToString()) * 0x100L) * 0x100L);
            }
            if (offset < 12L)
            {
                return "";
            }
            return GetStr(ref offset);
        }
        private string GetStr(ref long offset)
        {
            byte lowByte = 0;
            byte highByte = 0;
            StringBuilder stringBuilder = new StringBuilder();
            byte[] bytes = new byte[2];
            Encoding encoding = Encoding.GetEncoding("GB2312");
            while (true)
            {
                lowByte = data[offset++];
                if (lowByte == 0)
                {
                    return stringBuilder.ToString();
                }
                if (lowByte > 0x7f)
                {
                    highByte = data[offset++];
                    bytes[0] = lowByte;
                    bytes[1] = highByte;
                    if (highByte == 0)
                    {
                        return stringBuilder.ToString();
                    }
                    stringBuilder.Append(encoding.GetString(bytes));
                }
                else
                {
                    stringBuilder.Append((char)lowByte);
                }
            }
        }
    }
}
