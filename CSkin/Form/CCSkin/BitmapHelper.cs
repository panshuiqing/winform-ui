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
 * * 说明：BitmapHelper.cs
 * *
********************************************************************/

using System;
using System.Drawing;
using System.Security.Permissions;
using System.Drawing.Imaging;

namespace CCWin
{
    public static class BitmapHelper
    {
        [SecurityPermission(SecurityAction.LinkDemand,
            Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static unsafe Color GetImageAverageColor(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException("bitmap");
            }

            int width = bitmap.Width;
            int height = bitmap.Height;
            Rectangle rect = new Rectangle(0, 0, width, height);

            try
            {
                BitmapData bitmapData = bitmap.LockBits(
                    rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                byte* scan0 = (byte*)bitmapData.Scan0;
                int strideOffset = bitmapData.Stride - bitmapData.Width * 4;

                int sum = width * height;

                int a = 0;
                int r = 0;
                int g = 0;
                int b = 0;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        b += *scan0++;
                        g += *scan0++;
                        r += *scan0++;
                        a += *scan0++;
                    }
                    scan0 += strideOffset;
                }

                bitmap.UnlockBits(bitmapData);

                a /= sum;
                r /= sum;
                g /= sum;
                b /= sum;

                return Color.FromArgb(255, r, g, b);
            }
            catch
            {
                return Color.FromArgb(127, 127, 127);
            }
        }
    }
}
