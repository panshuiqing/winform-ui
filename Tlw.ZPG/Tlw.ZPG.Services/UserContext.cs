using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Tlw.ZPG.Services
{
    public sealed class UserContext
    {
        private static readonly UserContext context = new UserContext();

        public static UserContext Current
        {
            get
            {
                return context;
            }
        }

        private UserContext()
        {
        }

        public string Ip
        {
            get
            {
                string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                {
                    //没有代理IP则直接取连接客户端IP 
                    ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                return ip;
            }
        }

        public string Url
        {
            get
            {
                return HttpContext.Current.Request.Url.ToString();
            }
        }

        public int UserId
        {
            get
            {
                var session = HttpContext.Current.Session;
                if (session != null && session["UserId"] != null)
                {
                    return (int)session["UserId"];
                }
                return 0;
            }
        }

        public string UserName
        {
            get
            {
                var session = HttpContext.Current.Session;
                if (session != null && session["UserName"] != null)
                {
                    return session["UserName"].ToString();
                }
                return "";
            }
        }
    }
}
