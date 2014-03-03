using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tlw.ZPG.Infrastructure.Events
{
    /// <summary>
    /// 事件参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T data)
        {
            this.Data = data;
        }

        public T Data
        {
            get;
            private set;
        }
    }

    public class ReplayEventArgs : EventArgs
    {
        public ReplayEventArgs()
        {
            this.Success = true;
        }

        public bool Success
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }
    }
}
