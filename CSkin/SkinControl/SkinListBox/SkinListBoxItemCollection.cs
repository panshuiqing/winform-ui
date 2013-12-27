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
 * * 说明：SkinListBoxItemCollection.cs
 * *
********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel;

namespace CCWin.SkinControl
{
    [ListBindable(false)]
    public class SkinListBoxItemCollection 
        : IList,ICollection,IEnumerable
    {
        #region 变量

        private SkinListBox _owner;

        #endregion

        #region 无参构造
        public SkinListBoxItemCollection(SkinListBox owner)
        {
            _owner = owner;
        }
        #endregion

        #region 属性

        internal SkinListBox Owner
        {
            get { return _owner; }
        }

        public SkinListBoxItem this[int index]
        {
            get { return Owner.OldItems[index] as SkinListBoxItem; }
            set { Owner.OldItems[index] = value; }
        }

        public int Count
        {
            get { return Owner.OldItems.Count; }
        }

        public bool IsReadOnly 
        {
            get { return Owner.OldItems.IsReadOnly; }
        }

        #endregion

        #region 操作方法

        public int Add(SkinListBoxItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            return Owner.OldItems.Add(item);
        }

        public void AddRange(SkinListBoxItemCollection value)
        {
            foreach (SkinListBoxItem item in value)
            {
                Add(item);
            }
        }

        public void AddRange(SkinListBoxItem[] items)
        {
            Owner.OldItems.AddRange(items);
        }

        public void Clear()
        {
            Owner.OldItems.Clear();
        }

        public bool Contains(SkinListBoxItem item)
        {
            return Owner.OldItems.Contains(item);
        }

        public void CopyTo(
            SkinListBoxItem[] destination, 
            int arrayIndex)
        {
            Owner.OldItems.CopyTo(destination, arrayIndex);
        }

        public int IndexOf(SkinListBoxItem item)
        {
            return Owner.OldItems.IndexOf(item);
        }

        public void Insert(int index, SkinListBoxItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            Owner.OldItems.Insert(index, item);
        }

        public void Remove(SkinListBoxItem item)
        {
            Owner.OldItems.Remove(item);
        }

        public void RemoveAt(int index)
        {
            Owner.OldItems.RemoveAt(index);
        }

        public IEnumerator GetEnumerator()
        {
            return Owner.OldItems.GetEnumerator();
        }

        #endregion

        #region IList 成员

        int IList.Add(object value)
        {
            if (!(value is SkinListBoxItem))
            {
                throw new ArgumentException();
            }
            return Add(value as SkinListBoxItem);
        }

        void IList.Clear()
        {
            Clear();
        }

        bool IList.Contains(object value)
        {
            return Contains(value as SkinListBoxItem);
        }

        int IList.IndexOf(object value)
        {
            return IndexOf(value as SkinListBoxItem);
        }

        void IList.Insert(int index, object value)
        {
            if (!(value is SkinListBoxItem))
            {
                throw new ArgumentException();
            }
            Insert(index, value as SkinListBoxItem);
        }

        bool IList.IsFixedSize
        {
            get { return false; }
        }

        bool IList.IsReadOnly
        {
            get { return IsReadOnly; }
        }

        void IList.Remove(object value)
        {
            Remove(value as SkinListBoxItem);
        }

        void IList.RemoveAt(int index)
        {
            RemoveAt(index);
        }

        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                if (!(value is SkinListBoxItem))
                {
                    throw new ArgumentException();
                }
                this[index] = value as SkinListBoxItem;
            }
        }

        #endregion

        #region ICollection 成员

        void ICollection.CopyTo(Array array, int index)
        {
            CopyTo((SkinListBoxItem[])array, index);
        }

        int ICollection.Count
        {
            get { return Count; }
        }

        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        object ICollection.SyncRoot
        {
            get { return this; }
        }

        #endregion

        #region IEnumerable 成员

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
