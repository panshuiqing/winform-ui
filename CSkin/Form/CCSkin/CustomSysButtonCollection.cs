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
 * * 说明：CustomSysButtonCollection.cs
 * *
********************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CCWin
{
    //自定义系统按钮集合
    public class CustomSysButtonCollection : IList, ICollection, IEnumerable
    {
        private int count;      //元素个数
        public int Count { get { return count; } }
        private CmSysButton[] m_arrItem;
        private CCSkinMain owner;  //所属的控件

        public CustomSysButtonCollection(CCSkinMain owner) { this.owner = owner; }
        //确认存储空间
        private void EnsureSpace(int elements)
        {
            if (m_arrItem == null)
                m_arrItem = new CmSysButton[Math.Max(elements, 4)];
            else if (this.count + elements > m_arrItem.Length)
            {
                CmSysButton[] arrTemp = new CmSysButton[Math.Max(this.count + elements, m_arrItem.Length * 2)];
                m_arrItem.CopyTo(arrTemp, 0);
                m_arrItem = arrTemp;
            }
        }
        /// <summary>
        /// 获取自定义系统按钮所在的索引位置
        /// </summary>
        /// <param name="item">要获取的自定义系统按钮</param>
        /// <returns>索引位置</returns>
        public int IndexOf(CmSysButton item)
        {
            return Array.IndexOf<CmSysButton>(m_arrItem, item);
        }
        /// <summary>
        /// 添加一个自定义系统按钮
        /// </summary>
        /// <param name="item">要添加的自定义系统按钮</param>
        public void Add(CmSysButton item)
        {
            if (item == null)       //空引用不添加
                throw new ArgumentNullException("Item cannot be null");
            this.EnsureSpace(1);
            if (-1 == this.IndexOf(item))
            {         //进制添加重复对象
                item.OwnerForm = this.owner;
                m_arrItem[this.count++] = item;
                this.owner.Invalidate();            //添加进去是 进行重绘
            }
        }
        /// <summary>
        /// 添加一个列表项的自定义系统按钮
        /// </summary>
        /// <param name="items">要添加的自定义系统按钮的数组</param>
        public void AddRange(CmSysButton[] items)
        {
            if (items == null)
                throw new ArgumentNullException("Items cannot be null");
            this.EnsureSpace(items.Length);
            try
            {
                foreach (CmSysButton item in items)
                {
                    if (item == null)
                        throw new ArgumentNullException("Item cannot be null");
                    if (-1 == this.IndexOf(item))
                    {     //重复数据不添加
                        item.OwnerForm = this.owner;
                        m_arrItem[this.count++] = item;
                    }
                }
            }
            finally
            {
                this.owner.Invalidate();
            }
        }
        /// <summary>
        /// 移除一个自定义系统按钮
        /// </summary>
        /// <param name="item">要移除的自定义系统按钮</param>
        public void Remove(CmSysButton item)
        {
            int index = this.IndexOf(item);
            if (-1 != index)        //如果存在元素 那么根据索引移除
                this.RemoveAt(index);
        }
        /// <summary>
        /// 根据索引位置删除一个自定义系统按钮
        /// </summary>
        /// <param name="index">索引位置</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
                throw new IndexOutOfRangeException("Index was outside the bounds of the array");
            this.count--;
            for (int i = index, Len = this.count; i < Len; i++)
                m_arrItem[i] = m_arrItem[i + 1];
            this.owner.Invalidate();
        }
        /// <summary>
        /// 清空所有列表项
        /// </summary>
        public void Clear()
        {
            this.count = 0;
            m_arrItem = null;
            this.owner.Invalidate();
        }
        /// <summary>
        /// 根据索引位置插入一个自定义系统按钮
        /// </summary>
        /// <param name="index">索引位置</param>
        /// <param name="item">要插入的自定义系统按钮</param>
        public void Insert(int index, CmSysButton item)
        {
            if (index < 0 || index >= this.count)
                throw new IndexOutOfRangeException("Index was outside the bounds of the array");
            if (item == null)
                throw new ArgumentNullException("Item cannot be null");
            this.EnsureSpace(1);
            for (int i = this.count; i > index; i--)
                m_arrItem[i] = m_arrItem[i - 1];
            item.OwnerForm = this.owner;
            m_arrItem[index] = item;
            this.count++;
            this.owner.Invalidate();
        }
        /// <summary>
        /// 判断一个自定义系统按钮是否在集合内
        /// </summary>
        /// <param name="item">要判断的自定义系统按钮</param>
        /// <returns>是否在自定义系统按钮集合内</returns>
        public bool Contains(CmSysButton item)
        {
            return this.IndexOf(item) != -1;
        }
        /// <summary>
        /// 将自定义系统按钮的集合拷贝至一个数组
        /// </summary>
        /// <param name="array">目标数组</param>
        /// <param name="index">拷贝的索引位置</param>
        public void CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException("array cannot be null");
            m_arrItem.CopyTo(array, index);
        }
        /// <summary>
        /// 根据索引获取一个自定义系统按钮
        /// </summary>
        /// <param name="index">索引位置</param>
        /// <returns>自定义系统按钮</returns>
        public CmSysButton this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array");
                return m_arrItem[index];
            }
            set
            {
                if (index < 0 || index >= this.count)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array");
                m_arrItem[index] = value;
            }
        }
        //实现接口
        int IList.Add(object value)
        {
            if (!(value is CmSysButton))
                throw new ArgumentException("Value cannot convert to ListItem");
            this.Add((CmSysButton)value);
            return this.IndexOf((CmSysButton)value);
        }

        void IList.Clear()
        {
            this.Clear();
        }

        bool IList.Contains(object value)
        {
            if (!(value is CmSysButton))
                throw new ArgumentException("Value cannot convert to ListItem");
            return this.Contains((CmSysButton)value);
        }

        int IList.IndexOf(object value)
        {
            if (!(value is CmSysButton))
                throw new ArgumentException("Value cannot convert to ListItem");
            return this.IndexOf((CmSysButton)value);
        }

        void IList.Insert(int index, object value)
        {
            if (!(value is CmSysButton))
                throw new ArgumentException("Value cannot convert to ListItem");
            this.Insert(index, (CmSysButton)value);
        }

        bool IList.IsFixedSize
        {
            get { return false; }
        }

        bool IList.IsReadOnly
        {
            get { return false; }
        }

        void IList.Remove(object value)
        {
            if (!(value is CmSysButton))
                throw new ArgumentException("Value cannot convert to ListItem");
            this.Remove((CmSysButton)value);
        }

        void IList.RemoveAt(int index)
        {
            this.RemoveAt(index);
        }

        object IList.this[int index]
        {
            get { return this[index]; }
            set
            {
                if (!(value is CmSysButton))
                    throw new ArgumentException("Value cannot convert to ListItem");
                this[index] = (CmSysButton)value;
            }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            this.CopyTo(array, index);
        }

        int ICollection.Count
        {
            get { return this.count; }
        }

        bool ICollection.IsSynchronized
        {
            get { return true; }
        }

        object ICollection.SyncRoot
        {
            get { return this; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0, Len = this.count; i < Len; i++)
                yield return m_arrItem[i];
        }
    }
}
