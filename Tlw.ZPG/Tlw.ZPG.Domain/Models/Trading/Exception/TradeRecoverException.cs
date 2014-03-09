using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Domain.Models.Trading
{
    /// <summary>
    /// 交易恢复、解冻异常
    /// </summary>
    public class TradeRecoverException : DomainException
    {
        public TradeRecoverException(string message)
            : base(message)
        {
        }


        public TradeRecoverException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
