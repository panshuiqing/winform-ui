using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Domain.Models.Trading
{
    /// <summary>
    /// 录入保留价异常
    /// </summary>
    public class SetReservePriceException : DomainException
    {
        public SetReservePriceException(string message)
            : base(message)
        {
        }


        public SetReservePriceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
