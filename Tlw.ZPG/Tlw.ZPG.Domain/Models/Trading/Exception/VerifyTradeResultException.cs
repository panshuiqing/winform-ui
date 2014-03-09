using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Domain.Models.Trading
{
    /// <summary>
    /// 挂牌人审核交易结果异常
    /// </summary>
    public class VerifyTradeResultException : DomainException
    {
        public VerifyTradeResultException(string message)
            : base(message)
        {
        }


        public VerifyTradeResultException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
