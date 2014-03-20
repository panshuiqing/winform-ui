using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Domain.Models.Trading
{
    /// <summary>
    /// 公告发布异常
    /// </summary>
    public class AfficheReleaseException : DomainException
    {
        public AfficheReleaseException(string message)
            : base(message)
        {
        }


        public AfficheReleaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
