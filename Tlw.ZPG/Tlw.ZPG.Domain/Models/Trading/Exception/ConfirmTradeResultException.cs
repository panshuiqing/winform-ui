using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Domain.Models.Trading
{
    /// <summary>
    /// 竞买人确认异常
    /// </summary>
    public class ConfirmTradeResultException : DomainException
    {
        public ConfirmTradeResultException(string message)
            : base(message)
        {
        }


        public ConfirmTradeResultException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
