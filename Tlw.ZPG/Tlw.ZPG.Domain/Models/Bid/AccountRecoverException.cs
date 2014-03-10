using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Domain.Models.Bid
{
    /// <summary>
    /// 竞买号解冻异常
    /// </summary>
    public class AccountRecoverException : DomainException
    {
        public AccountRecoverException(string message)
            : base(message)
        {
        }


        public AccountRecoverException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
