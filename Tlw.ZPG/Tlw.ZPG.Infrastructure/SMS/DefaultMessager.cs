using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Infrastructure.SMS
{
    public class DefaultMessager : IMessager
    {
        public void Send(string number, string content)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = Path.Combine(path, "sms");
            path = Path.Combine(path, "sms.txt");
            if (File.Exists(path))
            {
                File.AppendAllText(path, string.Format("{0},{1}", number, content), Encoding.GetEncoding("gb2312"));
            }
        }
    }
}
