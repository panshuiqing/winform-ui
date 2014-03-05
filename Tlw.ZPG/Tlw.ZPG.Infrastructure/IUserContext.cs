using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Infrastructure
{
    public interface IUserContext
    {
        string Ip { get; }
        string Url { get; }
        int UserId { get; }
        string UserName { get;}
    }
}
