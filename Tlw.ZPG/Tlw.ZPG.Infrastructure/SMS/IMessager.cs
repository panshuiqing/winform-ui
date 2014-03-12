using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Infrastructure.SMS
{
    public interface IMessager
    {
        void Send(string number, string content);
    }
}
