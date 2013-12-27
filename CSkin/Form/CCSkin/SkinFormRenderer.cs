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
 * * 说明：SkinFormRenderer.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Security.Permissions;

namespace CCWin
{
    public abstract class SkinFormRenderer
    {
        #region 委托
        private EventHandlerList _events;
        private static readonly object EventRenderSkinFormCaption = new object();
        private static readonly object EventRenderSkinFormBorder = new object();
        private static readonly object EventRenderSkinFormControlBox = new object();
        #endregion

        #region 无参构造

        protected SkinFormRenderer()
        {
        }

        #endregion

        #region 属性

        protected EventHandlerList Events
        {
            get
            {
                if (_events == null)
                {
                    _events = new EventHandlerList();
                }
                return _events;
            }
        }

        #endregion

        #region 事件
        public event SkinFormCaptionRenderEventHandler RenderSkinFormCaption
        {
            add { AddHandler(EventRenderSkinFormCaption, value); }
            remove { RemoveHandler(EventRenderSkinFormCaption, value); }
        }

        public event SkinFormBorderRenderEventHandler RenderSkinFormBorder
        {
            add { AddHandler(EventRenderSkinFormBorder, value); }
            remove { RemoveHandler(EventRenderSkinFormBorder, value); }
        }

        public event SkinFormControlBoxRenderEventHandler RenderSkinFormControlBox
        {
            add { AddHandler(EventRenderSkinFormControlBox, value); }
            remove { RemoveHandler(EventRenderSkinFormControlBox, value); }
        }
        #endregion

        #region 绘画方法

        public abstract Region CreateRegion(CCSkinMain form);

        public abstract void InitSkinForm(CCSkinMain  form);

        public void DrawSkinFormCaption(
            SkinFormCaptionRenderEventArgs e)
        {
            OnRenderSkinFormCaption(e);
            SkinFormCaptionRenderEventHandler handle =
                Events[EventRenderSkinFormCaption]
                as SkinFormCaptionRenderEventHandler;
            if (handle != null)
            {
                handle(this, e);
            }
        }


        public void DrawSkinFormBorder(
            SkinFormBorderRenderEventArgs e)
        {
            OnRenderSkinFormBorder(e);
            SkinFormBorderRenderEventHandler handle =
                Events[EventRenderSkinFormBorder]
                as SkinFormBorderRenderEventHandler;
            if (handle != null)
            {
                handle(this, e);
            }
        }

        public void DrawSkinFormControlBox(
            SkinFormControlBoxRenderEventArgs e)
        {
            OnRenderSkinFormControlBox(e);
            SkinFormControlBoxRenderEventHandler handle =
                Events[EventRenderSkinFormControlBox]
                as SkinFormControlBoxRenderEventHandler;
            if (handle != null)
            {
                handle(this, e);
            }
        }

        #endregion

        #region 抽象方法

        protected abstract void OnRenderSkinFormCaption(
            SkinFormCaptionRenderEventArgs e);

        protected abstract void OnRenderSkinFormBorder(
            SkinFormBorderRenderEventArgs e);

        protected abstract void OnRenderSkinFormControlBox(
            SkinFormControlBoxRenderEventArgs e);

        #endregion

        #region 添加与删除事件

        [UIPermission(SecurityAction.Demand, Window = UIPermissionWindow.AllWindows)]
        protected void AddHandler(object key, Delegate value)
        {
            Events.AddHandler(key, value);
        }

        [UIPermission(SecurityAction.Demand, Window = UIPermissionWindow.AllWindows)]
        protected void RemoveHandler(object key, Delegate value)
        {
            Events.RemoveHandler(key, value);
        }

        #endregion
    }
}
