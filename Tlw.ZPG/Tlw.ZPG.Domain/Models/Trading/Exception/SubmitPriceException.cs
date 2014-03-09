using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Domain.Models.Trading
{
    /// <summary>
    /// 竞买人报价异常
    /// </summary>
    public class SubmitPriceException : DomainException
    {
        public SubmitPriceException(string message)
            : base(message)
        {
        }


        public SubmitPriceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
