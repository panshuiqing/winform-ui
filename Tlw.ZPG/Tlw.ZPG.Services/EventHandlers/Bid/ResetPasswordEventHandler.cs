using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Models.Bid;
using Tlw.ZPG.Domain.Models.Bid.Events;
using Tlw.ZPG.Infrastructure;
using Tlw.ZPG.Infrastructure.Domain.Events;
using Tlw.ZPG.Services.Content;

namespace Tlw.ZPG.Services.EventHandlers.Bid
{
    public class ResetPasswordEventHandler : IDomainEventHandler<ResetPasswordEvent>
    {
        public void Handle(ResetPasswordEvent e)
        {
            SystemLogService service = new SystemLogService();
            service.Insert(new Domain.Models.SystemLog()
            {
                CreateTime = DateTime.Now,
                Ip = UserContext.Current.Ip,
                Url = UserContext.Current.Url,
                UserId = UserContext.Current.UserId,
                UserName = UserContext.Current.UserName,
                Title = "重置密码",
                LogType = Domain.Enums.SystemLogType.ApplyNumber,
                LogCode = SystemLogCodes.L02020,
                Content = "重置密码，竞买号 " + e.Account.ApplyNumber,
            });
            var content = AppSettings.GetValue("SMS_ResetPassword", "")
                .Replace("{applyNumber}", e.Account.ApplyNumber)
                .Replace("{password}", e.Account.Trade.Land.LandNumber);
            Application.Messager.Send(e.Account.Contact.MobilePhone, content);
        }
    }
}
