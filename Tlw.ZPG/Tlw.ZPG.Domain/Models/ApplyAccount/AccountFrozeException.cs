using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Domain.Models.ApplyAccount
{
    /// <summary>
    /// 竞买号冻结异常
    /// </summary>
    public class AccountFrozeException : DomainException
    {
        public AccountFrozeException(string message)
            : base(message)
        {
        }


        public AccountFrozeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
