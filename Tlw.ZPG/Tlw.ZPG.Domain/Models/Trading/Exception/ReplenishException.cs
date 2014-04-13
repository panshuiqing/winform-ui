using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Domain.Models.Trading
{
    /// <summary>
    /// 补充公告异常
    /// </summary>
    public class ReplenishException : DomainException
    {
        public ReplenishException(string message)
            : base(message)
        {
        }


        public ReplenishException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
