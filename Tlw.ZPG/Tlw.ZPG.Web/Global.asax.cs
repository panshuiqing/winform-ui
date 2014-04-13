using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using Tlw.ZPG.Infrastructure.DbContext;
using Tlw.ZPG.Services;
using Tlw.ZPG.Web;

namespace Tlw.ZPG.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            BootStrapper.Configure();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            var ctx = DbContextFactory.Instance.GetDbContext();
            Tlw.ZPG.Infrastructure.DbContext.DbContextContainer.Bind(ctx);
        }

        void Application_EndRequest(object sender, EventArgs e)
        {
            var ctx = DbContextFactory.Instance.GetCurrentDbContext();
            Tlw.ZPG.Infrastructure.DbContext.DbContextContainer.Unbind(ctx);
            ctx.SaveChanges();
            ctx.Dispose();
        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码
            var ex = Server.GetLastError();
            if (ex != null)
            {
                var baseException = ex.GetBaseException();
                TraceTool.TTrace.Error.Send(baseException.Message, baseException.StackTrace);
                new Tlw.ZPG.Services.Content.SystemLogService().Insert(new Domain.Models.SystemLog
                {
                    Content = baseException.StackTrace,
                    CreateTime = DateTime.Now,
                    LogType = Domain.Enums.SystemLogType.Exception,
                    Title = ex.Message,
                    Url = HttpContext.Current.Request.Url.ToString(),
                    LogCode = SystemLogCodes.L00000,
                    Ip = UserContext.Current.Ip,
                    UserId = UserContext.Current.UserId,
                    UserName = UserContext.Current.UserName,
                });
            }
            HttpContext.Current.Response.Redirect("/Error.aspx");
        }
    }
}
