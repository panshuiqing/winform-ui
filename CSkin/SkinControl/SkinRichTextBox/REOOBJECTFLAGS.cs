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
 * * 说明：REOOBJECTFLAGS.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CCWin.SkinControl
{
    [Flags, ComVisible(false)]
    public enum REOOBJECTFLAGS : uint
    {
        REO_NULL = 0x00000000,	// No flags
        REO_READWRITEMASK = 0x0000003F,	// Mask out RO bits
        REO_DONTNEEDPALETTE = 0x00000020,	// Object doesn't need palette
        REO_BLANK = 0x00000010,	// Object is blank
        REO_DYNAMICSIZE = 0x00000008,	// Object defines size always
        REO_INVERTEDSELECT = 0x00000004,	// Object drawn all inverted if sel
        REO_BELOWBASELINE = 0x00000002,	// Object sits below the baseline
        REO_RESIZABLE = 0x00000001,	// Object may be resized
        REO_LINK = 0x80000000,	// Object is a link (RO)
        REO_STATIC = 0x40000000,	// Object is static (RO)
        REO_SELECTED = 0x08000000,	// Object selected (RO)
        REO_OPEN = 0x04000000,	// Object open in its server (RO)
        REO_INPLACEACTIVE = 0x02000000,	// Object in place active (RO)
        REO_HILITED = 0x01000000,	// Object is to be hilited (RO)
        REO_LINKAVAILABLE = 0x00800000,	// Link believed available (RO)
        REO_GETMETAFILE = 0x00400000	// Object requires metafile (RO)
    }
}
