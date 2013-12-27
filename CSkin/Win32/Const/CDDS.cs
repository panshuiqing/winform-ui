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
 * * 说明：CDDS.cs
 * *
********************************************************************/

using System;

namespace CCWin.Win32.Const
{
    /// <summary>
    /// drawstage flags
    /// values under 0x00010000 are reserved for global custom draw values.
    /// above that are for specific controls
    /// </summary>
    public static class CDDS
    {
        public const int CDDS_PREPAINT = 0x00000001;
        public const int CDDS_POSTPAINT = 0x00000002;
        public const int CDDS_PREERASE = 0x00000003;
        public const int CDDS_POSTERASE = 0x00000004;
        // the 0x000010000 bit means it's individual item specific
        public const int CDDS_ITEM = 0x00010000;
        public const int CDDS_ITEMPREPAINT = (CDDS_ITEM | CDDS_PREPAINT);
        public const int CDDS_ITEMPOSTPAINT = (CDDS_ITEM | CDDS_POSTPAINT);
        public const int CDDS_ITEMPREERASE = (CDDS_ITEM | CDDS_PREERASE);
        public const int CDDS_ITEMPOSTERASE = (CDDS_ITEM | CDDS_POSTERASE);

#if (_WIN32_IE0400) //>= 0x0400
        public const int CDDS_SUBITEM = 0x00020000;
#endif
    }
}
