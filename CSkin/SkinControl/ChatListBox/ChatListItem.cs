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
 * * 说明：ChatListItem.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;
using System.ComponentModel;

namespace CCWin.SkinControl
{
    //TypeConverter未解决
    //[DefaultProperty("Text"),TypeConverter(typeof(ChatListItemConverter))]
    public class ChatListItem
    {
        /// <summary>
        /// 深拷贝
        /// </summary>
        /// <returns>深度克隆的ChatListItem</returns>
        public ChatListItem Clone()
        {
            ChatListItem ListItem = new ChatListItem();
            ListItem.Bounds = this.Bounds;
            ListItem.IsOpen = this.IsOpen;
            ListItem.IsTwinkleHide = this.IsTwinkleHide;
            ListItem.OwnerChatListBox = this.OwnerChatListBox;
            ListItem.SubItems = this.SubItems;
            ListItem.Text = this.text;
            ListItem.TwinkleSubItemNumber = this.TwinkleSubItemNumber;
            return ListItem;
        }
        private string text = "Item";
        /// <summary>
        /// 获取或者设置列表项的显示文本
        /// </summary>
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Text {
            get { return text; }
            set {
                text = value;
                if (this.ownerChatListBox != null)
                    this.ownerChatListBox.Invalidate(this.bounds);
            }
        }

        private bool isOpen;
        /// <summary>
        /// 获取或者设置列表项是否展开
        /// </summary>
        [DefaultValue(false)]
        public bool IsOpen {
            get { return isOpen; }
            set {
                isOpen = value;
                if (this.ownerChatListBox != null)
                    this.ownerChatListBox.Invalidate();
            }
        }

        private int twinkleSubItemNumber;
        /// <summary>
        /// 当前列表项下面闪烁图标的个数
        /// </summary>
        [Browsable(false)]
        public int TwinkleSubItemNumber {
            get { return twinkleSubItemNumber; }
            set { twinkleSubItemNumber = value; }
        }

        private bool isTwinkleHide;
        public bool IsTwinkleHide {
            get { return isTwinkleHide; }
            set { isTwinkleHide = value; }
        }

        private Rectangle bounds;
        /// <summary>
        /// 获取列表项的显示区域
        /// </summary>
        [Browsable(false)]
        public Rectangle Bounds {
            get { return bounds; }
            set { bounds = value; }
        }

        private ChatListBox ownerChatListBox;
        /// <summary>
        /// 获取列表项所在的控件
        /// </summary>
        [Browsable(false)]
        public ChatListBox OwnerChatListBox {
            get { return ownerChatListBox; }
            set { ownerChatListBox = value; }
        }

        private ChatListSubItemCollection subItems;
        /// <summary>
        /// 获取当前列表项所有子项的集合
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ChatListSubItemCollection SubItems {
            get {
                if (subItems == null)
                    subItems = new ChatListSubItemCollection(this);
                return subItems;
            }
            set 
            {
                if (subItems != value)
                {
                    subItems = value;
                }
            }
        }

        public ChatListItem() { if (this.text == null) this.text = string.Empty; }
        public ChatListItem(string text) { this.text = text; }
        public ChatListItem(string text, bool bOpen) {
            this.text = text;
            this.isOpen = bOpen;
        }
        public ChatListItem(ChatListSubItem[] subItems) {
            this.subItems.AddRange(subItems);
        }
        public ChatListItem(string text, ChatListSubItem[] subItems) {
            this.text = text;
            this.subItems.AddRange(subItems);
        }
        public ChatListItem(string text, bool bOpen, ChatListSubItem[] subItems) {
            this.text = text;
            this.isOpen = bOpen;
            this.subItems.AddRange(subItems);
        }
        //自定义列表子项的集合 注释同 自定义列表项的集合
        public class ChatListSubItemCollection : IList, ICollection, IEnumerable
        {
            private int count;
            public int Count { get { return count; } }
            private ChatListSubItem[] m_arrSubItems;
            private ChatListItem owner;

            public ChatListSubItemCollection(ChatListItem owner) { this.owner = owner; }
            /// <summary>
            /// 对列表进行排序
            /// </summary>
            public void Sort() {
                Array.Sort<ChatListSubItem>(m_arrSubItems, 0, this.count, null);
                if (this.owner.ownerChatListBox != null)
                    this.owner.ownerChatListBox.Invalidate(this.owner.bounds);
            }
            /// <summary>
            /// 获取在线人数
            /// </summary>
            /// <returns>在线人数</returns>
            public int GetOnLineNumber() {
                int num = 0;
                for (int i = 0, len = this.count; i < len; i++) {
                    if (m_arrSubItems[i].Status != ChatListSubItem.UserStatus.OffLine)
                        num++;
                }
                return num;
            }
            //确认存储空间
            private void EnsureSpace(int elements) {
                if (m_arrSubItems == null)
                    m_arrSubItems = new ChatListSubItem[Math.Max(elements, 4)];
                else if (elements + this.count > m_arrSubItems.Length) {
                    ChatListSubItem[] arrTemp = new ChatListSubItem[Math.Max(m_arrSubItems.Length * 2, elements + this.count)];
                    m_arrSubItems.CopyTo(arrTemp, 0);
                    m_arrSubItems = arrTemp;
                }
            }
            /// <summary>
            /// 获取索引位置
            /// </summary>
            /// <param name="subItem">要获取索引的子项</param>
            /// <returns>索引</returns>
            public int IndexOf(ChatListSubItem subItem) {
                return Array.IndexOf<ChatListSubItem>(m_arrSubItems, subItem);
            }
            /// <summary>
            /// 添加一个子项
            /// </summary>
            /// <param name="subItem">要添加的子项</param>
            public void Add(ChatListSubItem subItem) {
                if (subItem == null)
                    throw new ArgumentNullException("SubItem cannot be null");
                this.EnsureSpace(1);
                if (-1 == IndexOf(subItem)) {
                    subItem.OwnerListItem = owner;
                    m_arrSubItems[this.count++] = subItem;
                    if (this.owner.OwnerChatListBox != null)
                        this.owner.OwnerChatListBox.Invalidate();
                }
            }
            /// <summary>
            /// 添加一组子项
            /// </summary>
            /// <param name="subItems">要添加子项的数组</param>
            public void AddRange(ChatListSubItem[] subItems) {
                if (subItems == null)
                    throw new ArgumentNullException("SubItems cannot be null");
                this.EnsureSpace(subItems.Length);
                try {
                    foreach (ChatListSubItem subItem in subItems) {
                        if (subItem == null)
                            throw new ArgumentNullException("SubItem cannot be null");
                        if (-1 == this.IndexOf(subItem)) {
                            subItem.OwnerListItem = this.owner;
                            m_arrSubItems[this.count++] = subItem;
                        }
                    }
                } finally {
                    if (this.owner.OwnerChatListBox != null)
                        this.owner.OwnerChatListBox.Invalidate();
                }
            }
            /// <summary>
            /// 根据在线状态添加一个子项
            /// </summary>
            /// <param name="subItem">要添加的子项</param>
            public void AddAccordingToStatus(ChatListSubItem subItem) {
                if (subItem.Status == ChatListSubItem.UserStatus.OffLine) {
                    this.Add(subItem);
                    return;
                }
                for (int i = 0, len = this.count; i < len; i++) {
                    if (subItem.Status <= m_arrSubItems[i].Status) {
                        this.Insert(i, subItem);
                        return;
                    }
                }
                this.Add(subItem);
            }
            /// <summary>
            /// 移除一个子项
            /// </summary>
            /// <param name="subItem">要移除的子项</param>
            public void Remove(ChatListSubItem subItem) {
                int index = this.IndexOf(subItem);
                if (-1 != index)
                    this.RemoveAt(index);
            }
            /// <summary>
            /// 根据索引移除一个子项
            /// </summary>
            /// <param name="index">要移除子项的索引</param>
            public void RemoveAt(int index) {
                if (index < 0 || index > this.count)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array");
                this.count--;
                for (int i = index, Len = this.count; i < Len; i++)
                    m_arrSubItems[i] = m_arrSubItems[i + 1];
                if (this.owner.OwnerChatListBox != null)
                    this.owner.OwnerChatListBox.Invalidate();
            }
            /// <summary>
            /// 清空所有子项
            /// </summary>
            public void Clear() {
                this.count = 0;
                m_arrSubItems = null;
                if (this.owner.OwnerChatListBox != null)
                    this.owner.OwnerChatListBox.Invalidate();
            }
            /// <summary>
            /// 根据索引插入一个子项
            /// </summary>
            /// <param name="index">索引位置</param>
            /// <param name="subItem">要插入的子项</param>
            public void Insert(int index, ChatListSubItem subItem) {
                if (index < 0 || index > this.count)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array");
                if (subItem == null)
                    throw new ArgumentNullException("SubItem cannot be null");
                this.EnsureSpace(1);
                for (int i = this.count; i > index; i--)
                    m_arrSubItems[i] = m_arrSubItems[i - 1];
                subItem.OwnerListItem = this.owner;
                m_arrSubItems[index] = subItem;
                this.count++;
                if (this.owner.OwnerChatListBox != null)
                    this.owner.OwnerChatListBox.Invalidate();
            }
            /// <summary>
            /// 将集合类的子项拷贝至数组
            /// </summary>
            /// <param name="array">要拷贝的数组</param>
            /// <param name="index">拷贝的索引位置</param>
            public void CopyTo(Array array, int index) {
                if (array == null)
                    throw new ArgumentNullException("Array cannot be null");
                m_arrSubItems.CopyTo(array, index);
            }
            /// <summary>
            /// 判断子项是否在集合内
            /// </summary>
            /// <param name="subItem">要判断的子项</param>
            /// <returns>是否在集合内</returns>
            public bool Contains(ChatListSubItem subItem) {
                return this.IndexOf(subItem) != -1;
            }
            /// <summary>
            /// 根据索引获取一个列表子项
            /// </summary>
            /// <param name="index">索引位置</param>
            /// <returns>列表子项</returns>
            public ChatListSubItem this[int index] {
                get {
                    if (index < 0 || index > this.count)
                    {
                        throw new IndexOutOfRangeException("Index was outside the bounds of the array");
                    }
                    return m_arrSubItems[index];
                }
                set {
                    if (index < 0 || index > this.count)
                        throw new IndexOutOfRangeException("Index was outside the bounds of the array");
                    m_arrSubItems[index] = value;
                    if (this.owner.OwnerChatListBox != null)
                        this.owner.OwnerChatListBox.Invalidate(m_arrSubItems[index].Bounds);
                }
            }
            //接口实现
            int IList.Add(object value) {
                if (!(value is ChatListSubItem))
                    throw new ArgumentException("Value cannot convert to ListSubItem");
                this.Add((ChatListSubItem)value);
                return this.IndexOf((ChatListSubItem)value);
            }

            void IList.Clear() {
                this.Clear();
            }

            bool IList.Contains(object value) {
                if (!(value is ChatListSubItem))
                    throw new ArgumentException("Value cannot convert to ListSubItem");
                return this.Contains((ChatListSubItem)value);
            }

            int IList.IndexOf(object value) {
                if (!(value is ChatListSubItem))
                    throw new ArgumentException("Value cannot convert to ListSubItem");
                return this.IndexOf((ChatListSubItem)value);
            }

            void IList.Insert(int index, object value) {
                if (!(value is ChatListSubItem))
                    throw new ArgumentException("Value cannot convert to ListSubItem");
                this.Insert(index, (ChatListSubItem)value);
            }

            bool IList.IsFixedSize {
                get { return false; }
            }

            bool IList.IsReadOnly {
                get { return false; }
            }

            void IList.Remove(object value) {
                if (!(value is ChatListSubItem))
                    throw new ArgumentException("Value cannot convert to ListSubItem");
                this.Remove((ChatListSubItem)value);
            }

            void IList.RemoveAt(int index) {
                this.RemoveAt(index);
            }

            object IList.this[int index] {
                get {
                    return this[index];
                }
                set {
                    if (!(value is ChatListSubItem))
                        throw new ArgumentException("Value cannot convert to ListSubItem");
                    this[index] = (ChatListSubItem)value;
                }
            }

            void ICollection.CopyTo(Array array, int index) {
                this.CopyTo(array, index);
            }

            int ICollection.Count {
                get { return this.count; }
            }

            bool ICollection.IsSynchronized {
                get { return true; }
            }

            object ICollection.SyncRoot {
                get { return this; }
            }

            IEnumerator IEnumerable.GetEnumerator() {
                for (int i = 0, Len = this.count; i < Len; i++)
                    yield return m_arrSubItems[i];
            }
        }
    }
}
