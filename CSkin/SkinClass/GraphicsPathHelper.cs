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
 * * 说明：GraphicsPathHelper.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CCWin.SkinClass
{
    public static class GraphicsPathHelper
    {
        /// <summary>
        /// 建立带有圆角样式的路径。
        /// </summary>
        /// <param name="rect">用来建立路径的矩形。</param>
        /// <param name="_radius">圆角的大小。</param>
        /// <param name="style">圆角的样式。</param>
        /// <param name="correction">是否把矩形长宽减 1,以便画出边框。</param>
        /// <returns>建立的路径。</returns>
        public static GraphicsPath CreatePath(
            Rectangle rect, int radius, RoundStyle style, bool correction)
        {
            GraphicsPath path = new GraphicsPath();
            int radiusCorrection = correction ? 1 : 0;
            switch (style)
            {
                case RoundStyle.None:
                    path.AddRectangle(rect);
                    break;
                case RoundStyle.All:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Y,
                        radius,
                        radius,
                        270,
                        90);
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius, 0, 90);
                    path.AddArc(
                        rect.X,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius,
                        90,
                        90);
                    break;
                case RoundStyle.Left:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddLine(
                        rect.Right - radiusCorrection, rect.Y,
                        rect.Right - radiusCorrection, rect.Bottom - radiusCorrection);
                    path.AddArc(
                        rect.X,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius,
                        90,
                        90);
                    break;
                case RoundStyle.Right:
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Y,
                        radius,
                        radius,
                        270,
                        90);
                    path.AddArc(
                       rect.Right - radius - radiusCorrection,
                       rect.Bottom - radius - radiusCorrection,
                       radius,
                       radius,
                       0,
                       90);
                    path.AddLine(rect.X, rect.Bottom - radiusCorrection, rect.X, rect.Y);
                    break;
                case RoundStyle.Top:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Y,
                        radius,
                        radius,
                        270,
                        90);
                    path.AddLine(
                        rect.Right - radiusCorrection, rect.Bottom - radiusCorrection,
                        rect.X, rect.Bottom - radiusCorrection);
                    break;
                case RoundStyle.Bottom:
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius,
                        0,
                        90);
                    path.AddArc(
                        rect.X,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius,
                        90,
                        90);
                    path.AddLine(rect.X, rect.Y, rect.Right - radiusCorrection, rect.Y);
                    break;
                case RoundStyle.BottomLeft:
                    path.AddArc(
                        rect.X,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius,
                        90,
                        90);
                    path.AddLine(rect.X, rect.Y, rect.Right - radiusCorrection, rect.Y);
                    path.AddLine(
                        rect.Right - radiusCorrection, 
                        rect.Y, 
                        rect.Right - radiusCorrection, 
                        rect.Bottom - radiusCorrection);
                    break;
                case RoundStyle.BottomRight:
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius,
                        0,
                        90);
                    path.AddLine(rect.X, rect.Bottom - radiusCorrection, rect.X, rect.Y);
                    path.AddLine(rect.X, rect.Y, rect.Right - radiusCorrection, rect.Y);
                    break;
            }
            path.CloseFigure();
            return path;
        }

        public static GraphicsPath CreateTrackBarThumbPath(
           Rectangle rect, ThumbArrowDirection arrowDirection)
        {
            GraphicsPath path = new GraphicsPath();
            PointF centerPoint = new PointF(
                rect.X + rect.Width / 2f, rect.Y + rect.Height / 2f);
            float offset = 0;

            switch (arrowDirection)
            {
                case ThumbArrowDirection.Left:
                case ThumbArrowDirection.Right:
                    offset = rect.Width / 2f - 4;
                    break;
                case ThumbArrowDirection.Up:
                case ThumbArrowDirection.Down:
                    offset = rect.Height / 2f - 4;
                    break;
            }

            switch (arrowDirection)
            {
                case ThumbArrowDirection.Left:
                    path.AddLine(
                        rect.X, centerPoint.Y, rect.X + offset, rect.Y);
                    path.AddLine(
                        rect.Right, rect.Y, rect.Right, rect.Bottom);
                    path.AddLine(
                        rect.X + offset, rect.Bottom, rect.X, centerPoint.Y);
                    break;
                case ThumbArrowDirection.Right:
                    path.AddLine(
                        rect.Right, centerPoint.Y, rect.Right - offset, rect.Bottom);
                    path.AddLine(
                        rect.X, rect.Bottom, rect.X, rect.Y);
                    path.AddLine(
                        rect.Right - offset, rect.Y, rect.Right, centerPoint.Y);
                    break;
                case ThumbArrowDirection.Up:
                    path.AddLine(
                        centerPoint.X, rect.Y, rect.X, rect.Y + offset);
                    path.AddLine(
                        rect.X, rect.Bottom, rect.Right, rect.Bottom);
                    path.AddLine(
                        rect.Right, rect.Y + offset, centerPoint.X, rect.Y);
                    break;
                case ThumbArrowDirection.Down:
                    path.AddLine(
                         centerPoint.X, rect.Bottom, rect.X, rect.Bottom - offset);
                    path.AddLine(
                        rect.X, rect.Y, rect.Right, rect.Y);
                    path.AddLine(
                        rect.Right, rect.Bottom - offset, centerPoint.X, rect.Bottom);
                    break;
                case ThumbArrowDirection.LeftRight:
                    break;
                case ThumbArrowDirection.UpDown:
                    break;
                case ThumbArrowDirection.None:
                    path.AddRectangle(rect);
                    break;
            }

            path.CloseFigure();
            return path;
        }
    }
}