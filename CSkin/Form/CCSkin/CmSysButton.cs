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
 * * 说明：CmSysButton.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCWin
{
    public class CmSysButton
    {
        //无参构造函数
        public CmSysButton() { }

        /// <summary>
        /// 深拷贝
        /// </summary>
        /// <returns>深度克隆的自定义系统按钮</returns>
        public CmSysButton Clone()
        {
            CmSysButton SysButton = new CmSysButton();
            SysButton.Bounds = this.Bounds;
            SysButton.Location = this.Location;
            SysButton.size = this.Size;
            SysButton.ToolTip = this.ToolTip; ;
            SysButton.SysButtonNorml = this.SysButtonNorml;
            SysButton.SysButtonMouse = this.SysButtonMouse;
            SysButton.SysButtonDown = this.SysButtonDown;
            SysButton.OwnerForm = this.OwnerForm;
            SysButton.Name = this.Name;
            return SysButton;
        }

        private string name;
        /// <summary>
        /// 与对象关联的用户定义数据
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private ControlBoxState boxState;
        /// <summary>
        /// 按钮的状态
        /// </summary>
        [Browsable(false)]
        public ControlBoxState BoxState
        {
            get { return boxState; }
            set
            {
                if (boxState != value)
                {
                    boxState = value;
                    if (OwnerForm != null)
                    {
                        OwnerForm.Invalidate(Bounds);
                    }
                }
            }
        }

        private Rectangle bounds;
        /// <summary>
        /// 获取或设置自定义系统按钮的显示区域
        /// </summary>
        [Browsable(false)]
        public Rectangle Bounds
        {
            get
            {
                if (bounds == Rectangle.Empty)
                {
                    bounds = new Rectangle();
                }
                bounds.Location = Location;
                bounds.Size = Size;
                return bounds;
            }
            set
            {
                bounds = value;
                Location = bounds.Location;
                Size = bounds.Size;
            }
        }

        private Point location = new Point(0, 0);
        /// <summary>
        /// 按钮的位置
        /// </summary>
        [Browsable(false)]
        [Category("按钮的位置")]
        public Point Location
        {
            get { return location; }
            set
            {
                if (location != value)
                {
                    location = value;
                }
            }
        }

        private Size size = new Size(28, 20);
        /// <summary>
        /// 按钮的大小
        /// </summary>
        [DefaultValue(typeof(Size), "28, 20")]
        [Description("设置或获取自定义系统按钮的大小")]
        [Category("按钮大小")]
        public Size Size
        {
            get { return size; }
            set
            {
                if (size != value)
                {
                    size = value;
                }
            }
        }

        private string toolTip;
        /// <summary>
        /// 自定义系统按钮悬浮提示
        /// </summary>
        [Category("悬浮提示")]
        [Description("自定义系统按钮悬浮提示")]
        public string ToolTip
        {
            get { return toolTip; }
            set
            {
                if (toolTip != value)
                {
                    toolTip = value;
                }
            }
        }

        private bool visibale = true;
        /// <summary>
        /// 自定义系统按钮是否显示
        /// </summary>
        [Category("是否显示")]
        [DefaultValue(typeof(bool), "true")]
        [Description("自定义系统按钮是否显示")]
        public bool Visibale
        {
            get { return visibale; }
            set
            {
                if (visibale != value)
                {
                    visibale = value;
                }
            }
        }

        private Image sysButtonMouse;
        /// <summary>
        /// 自定义系统按钮悬浮时
        /// </summary>
        [Category("按钮图像")]
        [Description("自定义系统按钮悬浮时")]
        public Image SysButtonMouse
        {
            get { return sysButtonMouse; }
            set
            {
                if (sysButtonMouse != value)
                {
                    sysButtonMouse = value;
                }
            }
        }

        private Image sysButtonDown;
        /// <summary>
        /// 自定义系统按钮点击时
        /// </summary>
        [Category("按钮图像")]
        [Description("自定义系统按钮点击时")]
        public Image SysButtonDown
        {
            get { return sysButtonDown; }
            set
            {
                if (sysButtonDown != value)
                {
                    sysButtonDown = value;
                }
            }
        }

        private Image sysButtonNorml;
        /// <summary>
        /// 自定义系统按钮初始时
        /// </summary>
        [Category("按钮图像")]
        [Description("自定义系统按钮初始时")]
        public Image SysButtonNorml
        {
            get { return sysButtonNorml; }
            set
            {
                if (sysButtonNorml != value)
                {
                    sysButtonNorml = value;
                }
            }
        }

        private CCSkinMain ownerForm;
        /// <summary>
        /// 获取自定义系统按钮所在的窗体
        /// </summary>
        [Browsable(false)]
        public CCSkinMain OwnerForm
        {
            get { return ownerForm; }
            set { ownerForm = value; }
        }
    }
}
