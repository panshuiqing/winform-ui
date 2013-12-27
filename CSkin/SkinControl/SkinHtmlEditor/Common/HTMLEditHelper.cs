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
 * * 说明：HTMLEditHelper.cs
 * *
********************************************************************/

using System.Runtime.InteropServices;
using mshtml;

namespace CCWin.SkinControl
{
    #region HTMLEditHelper class
    public static class HTMLEditHelper
    {
        private static IHTMLDocument2 _mPDoc2;

        public static IHTMLDocument2 DOMDocument
        {
            get { return _mPDoc2; }
            set { _mPDoc2 = value; }
        }

        #region Table specific

        /// <summary>
        /// The currently selected text/controls will be replaced by the given HTML code.
        /// If nothing is selected, the HTML code is inserted at the cursor position
        /// </summary>
        /// <param name="sHtml"></param>
        /// <returns></returns>
        public static bool PasteIntoSelection(string sHtml)
        {
            if (_mPDoc2.IsNull())
                return false;
            var sel = _mPDoc2.selection as IHTMLSelectionObject;
            if (sel.IsNull())
                return false;
            var range = sel.createRange() as IHTMLTxtRange;
            if (range.IsNull())
                return false;
            //none
            //text
            //control
            if ((!sel.EventType.IsNullOrEmpty()) &&
                (sel.EventType == "control"))
            {
                var ctlrange = range as IHTMLControlRange;
                if (!ctlrange.IsNull()) //Control(s) selected
                {
                    int ctls = ctlrange.length;
                    for (int i = 0; i < ctls; i++)
                    {
                        //Remove all selected controls
                        IHTMLElement elem = ctlrange.item(i);
                        if (!elem.IsNull())
                        {
                            RemoveNode(elem, true);
                        }
                    }
                    // Now get the textrange after deleting all selected controls
                    range = sel.createRange() as IHTMLTxtRange;
                }
            }

            if (!range.IsNull())
            {
                // range will be valid if nothing is selected or if text is selected
                // or if multiple elements are seleted
                range.pasteHTML(sHtml);
                range.collapse(false);
                range.select();
            }
            return true;
        }

        /// <summary>
        /// Removes node element
        /// If RemoveAllChildren == true, Removes this element and all it's children from the document
        /// else it just strips this element but does not remove its children
        /// E.g.  "<BIG><b>Hello World</b></BIG>"  ---> strip BIG tag --> "<b>Hello World</b>"
        /// </summary>
        /// <param name="elem">element to remove</param>
        /// <param name="removeAllChildren"></param>
        public static IHTMLDOMNode RemoveNode(IHTMLElement elem, bool removeAllChildren)
        {
            var node = elem as IHTMLDOMNode;
            if (!node.IsNull())
                return node.removeNode(removeAllChildren);
            return null;
        }

        #endregion

    }
    #endregion

    [ComVisible(true), ComImport]
    [TypeLibType((short)4160)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f25A-98b5-11cf-bb82-00aa00bdce0b")]
    interface IHTMLSelectionObject
    {
        [return: MarshalAs(UnmanagedType.IDispatch)]
        [DispId(HTMLDispIDs.DispidIhtmlselectionobjectCreaterange)]
        object createRange();
        [DispId(HTMLDispIDs.DispidIhtmlselectionobjectEmpty)]
        void empty();
        [DispId(HTMLDispIDs.DispidIhtmlselectionobjectClear)]
        void clear();
        [DispId(HTMLDispIDs.DispidIhtmlselectionobjectType)]
        string EventType { [return: MarshalAs(UnmanagedType.BStr)] get; }
    }

    /// <summary>
    /// Dispids taken from MsHtmdid.h
    /// </summary>
    sealed class HTMLDispIDs
    {
        //    DISPIDs for interface IHTMLSelectionObject
        public const int DispidNormalFirst = 1000;
        public const int DispidSelectobj = DispidNormalFirst;

        public const int DispidIhtmlselectionobjectCreaterange = DispidSelectobj + 1;
        public const int DispidIhtmlselectionobjectEmpty = DispidSelectobj + 2;
        public const int DispidIhtmlselectionobjectClear = DispidSelectobj + 3;
        public const int DispidIhtmlselectionobjectType = DispidSelectobj + 4;
    }
}
