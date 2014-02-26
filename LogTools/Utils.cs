using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace LogTools
{
    public static class Utils
    {
        public static void InvokeEx(MethodInvoker invoker, Control control)
        {
            if (invoker != null && control != null && !control.IsDisposed)
            {
                while (!control.IsHandleCreated)
                {
                    System.Threading.Thread.Sleep(100);
                }
                control.Invoke(invoker);
            }
        }

    }

    /// <summary> 
    ///  Http操作类 
    /// </summary> 
    public static class HttpRequestUtil
    {
        private static Encoding DEFAULT_ENCODING = Encoding.GetEncoding("GB2312");
        private static string ACCEPT = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
        private static string CONTENT_TYPE = "application/x-www-form-urlencoded";
        private static string USERAGENT = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; InfoPath.2; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; msn OptimizedIE8;ZHCN)";

        /// <summary> 
        ///  获取网址HTML 
        /// </summary> 
        /// <param name="url">网址 </param> 
        /// <returns> </returns> 
        public static string GetHtmlContent(string url)
        {
            return GetHtmlContent(url, DEFAULT_ENCODING);
        }

        /// <summary> 
        ///  获取网址HTML 
        /// </summary> 
        /// <param name="url">网址 </param> 
        /// <returns> </returns> 
        public static string GetHtmlContent(string url, Encoding encoding)
        {
            string html = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = USERAGENT;
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    html = reader.ReadToEnd();
                    reader.Close();
                }
            }
            return html;
        }

        /// <summary> 
        /// 获取网站cookie 
        /// </summary> 
        /// <param name="url">网址 </param> 
        /// <returns> </returns> 
        public static string GetCookie(string url)
        {
            string cookie = string.Empty;
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            using (WebResponse response = request.GetResponse())
            {
                cookie = response.Headers.Get("Set-Cookie");
            }
            return cookie;
        }

        /// <summary> 
        /// Post模式浏览 
        /// </summary> 
        /// <param name="url">网址</param> 
        /// <param name="data">流</param> 
        /// <returns> </returns> 
        public static HttpResult Post(string url, byte[] data)
        {
            return Post(url, data, null);
        }

        private static HttpWebRequest CreateReauest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.ContentType = CONTENT_TYPE;
            request.Accept = ACCEPT;
            request.Referer = url;
            request.UserAgent = USERAGENT;
            request.Method = "Post";
            request.KeepAlive = true;
            request.Headers.Add("Pragma", "no-cache");
            request.Headers.Add("Accept-Encoding", "gzip, deflate");
            request.Headers.Add("Accept-Language", "zh-CN");
            return request;
        }

        /// <summary> 
        /// Post模式浏览 
        /// </summary> 
        /// <param name="server">服务器地址 </param> 
        /// <param name="url">网址</param> 
        /// <param name="data">流</param> 
        /// <param name="cookieHeader">cookieHeader</param> 
        /// <returns> </returns> 
        public static HttpResult Post(string url, byte[] data, string cookieHeader)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException("url");
            Uri uri = new Uri(url);
            HttpResult result = new HttpResult();
            HttpWebRequest request = CreateReauest(url);
            if (!string.IsNullOrEmpty(cookieHeader))
            {
                CookieContainer co = new CookieContainer();
                co.SetCookies(uri, cookieHeader);
                request.CookieContainer = co;
            }
            if (data != null && data.Length > 0)
            {
                request.ContentLength = data.Length;
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                }
            }
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    long contentLength = response.ContentLength;
                    byte[] bytes = new byte[contentLength];
                    bytes = ReadFully(stream);
                    result.Data = bytes;
                    if (response.Cookies != null)
                    {
                        result.Cookies = new Cookie[response.Cookies.Count];
                        response.Cookies.CopyTo(result.Cookies, 0);
                    }
                    stream.Close();
                }
            }

            return result;
        }

        private static byte[] ReadFully(Stream stream)
        {
            byte[] buffer = new byte[128];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }

        /// <summary> 
        /// Get模式浏览 
        /// </summary> 
        /// <param name="url">Get网址</param> 
        /// <returns> </returns> 
        public static HttpResult Get(string url)
        {
            return Get(url, null);
        }

        /// <summary> 
        /// Get模式浏览 
        /// </summary> 
        /// <param name="url">Get网址</param> 
        /// <param name="cookieHeader">cookieHeader</param> 
        /// <param name="server">服务器地址 </param> 
        /// <returns> </returns> 
        public static HttpResult Get(string url, string cookieHeader)
        {
            HttpResult result = new HttpResult();
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException("url");
            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            if (!string.IsNullOrEmpty(cookieHeader))
            {
                CookieContainer co = new CookieContainer();
                co.SetCookies(uri, cookieHeader);
                request.CookieContainer = co;
            }
            request.Accept = "*/*";
            request.Referer = url;
            request.UserAgent = USERAGENT;
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                long contentLength = response.ContentLength;
                byte[] bytes = new byte[contentLength];
                bytes = ReadFully(stream);
                result.Data = bytes;
                if (response.Cookies != null)
                {
                    result.Cookies = new Cookie[response.Cookies.Count];
                    response.Cookies.CopyTo(result.Cookies, 0);
                }
                stream.Close();

            }
            return result;
        }
    }

    public class HttpResult
    {
        public byte[] Data { get; set; }
        public Cookie[] Cookies { get; set; }
    }

}
