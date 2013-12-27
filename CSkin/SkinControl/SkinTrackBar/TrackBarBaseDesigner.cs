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
 * * 说明：TrackBarBaseDesigner.cs
 * *
********************************************************************/

using System;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;

namespace CCWin.SkinControl
{
    internal class TrackBarBaseDesigner : ControlDesigner
    {
        public TrackBarBaseDesigner()
        {
            base.AutoResizeHandles = true;
        }

        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules selectionRules = base.SelectionRules;
                object component = base.Component;
                selectionRules |= SelectionRules.AllSizeable;
                PropertyDescriptor pdAutoSize =
                    TypeDescriptor.GetProperties(component)["AutoSize"];
                if (pdAutoSize != null)
                {
                    bool flag = (bool)pdAutoSize.GetValue(component);
                    PropertyDescriptor pdOrientation =
                        TypeDescriptor.GetProperties(component)["Orientation"];
                    Orientation horizontal = Orientation.Horizontal;
                    if (pdOrientation != null)
                    {
                        horizontal = (Orientation)pdOrientation.GetValue(component);
                    }
                    if (!flag)
                    {
                        return selectionRules;
                    }
                    switch (horizontal)
                    {
                        case Orientation.Horizontal:
                            return (selectionRules &
                                ~(SelectionRules.BottomSizeable | SelectionRules.TopSizeable));

                        case Orientation.Vertical:
                            return (selectionRules &
                                ~(SelectionRules.RightSizeable | SelectionRules.LeftSizeable));
                    }
                }
                return selectionRules;
            }
        }

        protected override void PostFilterProperties(IDictionary Properties)
        {
            Properties.Remove("BackgroundImage");
            Properties.Remove("BackgroundImageLayout");
            Properties.Remove("Font");
            Properties.Remove("ForeColor");
            Properties.Remove("ImeMode");
            Properties.Remove("Padding");
            Properties.Remove("Text");
        }

        protected override void PostFilterEvents(IDictionary events)
        {
            events.Remove("BackColorChanged");
            events.Remove("BackgroundImageChanged");

            events.Remove("Click");
            events.Remove("MouseClick");
            events.Remove("DoubleClick");
            events.Remove("MouseDoubleClick");
            events.Remove("FontChanged");
            events.Remove("ForeColorChanged");
            events.Remove("ImeModeChanged");

            events.Remove("PaddingChanged");
            events.Remove("Paint");

            events.Remove("TextChanged");

            base.PostFilterEvents(events);
        }
    }
}
