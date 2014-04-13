using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Domain.Models.Bid
{
    /// <summary>
    /// 竞买人提交申请审核异常
    /// </summary>
    public class SubmitApplyException : DomainException
    {
        public SubmitApplyException(string message)
            : base(message)
        {
        }


        public SubmitApplyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
