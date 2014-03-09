using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Domain.Models.Trading
{
    /// <summary>
    /// 交易冻结异常
    /// </summary>
    public class TradeFrozeException : DomainException
    {
        public TradeFrozeException(string message)
            : base(message)
        {
        }


        public TradeFrozeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
