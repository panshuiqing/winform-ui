using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Domain.Models.Trading
{
    /// <summary>
    /// 交易终止异常
    /// </summary>
    public class TradeTerminateException : DomainException
    {
        public TradeTerminateException(string message)
            : base(message)
        {
        }


        public TradeTerminateException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
