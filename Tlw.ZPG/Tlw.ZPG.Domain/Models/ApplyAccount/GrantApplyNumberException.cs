using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Domain.Models.ApplyAccount
{
    /// <summary>
    /// 发放竞买号异常
    /// </summary>
    public class GrantApplyNumberException : DomainException
    {
        public GrantApplyNumberException(string message)
            : base(message)
        {
        }


        public GrantApplyNumberException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
