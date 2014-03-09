using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Domain
{
    /// <summary>
    /// 修改密码异常
    /// </summary>
    public class ChangePasswordException : DomainException
    {
        public ChangePasswordException(string message)
            : base(message)
        {
        }


        public ChangePasswordException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
