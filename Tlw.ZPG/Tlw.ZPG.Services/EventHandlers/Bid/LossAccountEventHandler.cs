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
    public class LossAccountEventHandler : IDomainEventHandler<LossAccountEvent>
    {
        public void Handle(LossAccountEvent e)
        {
            SystemLogService service = new SystemLogService();
            service.Insert(new Domain.Models.SystemLog()
            {
                CreateTime = DateTime.Now,
                Ip = UserContext.Current.Ip,
                Url = UserContext.Current.Url,
                UserId = UserContext.Current.UserId,
                UserName = UserContext.Current.UserName,
                Title = "挂失竞买号",
                LogType = Domain.Enums.SystemLogType.ApplyNumber,
                LogCode = SystemLogCodes.L02030,
                Content = "挂失竞买号，宗地号" + e.Account.Trade.Land.LandNumber + "，竞买号" + e.Account.ApplyNumber,
            });
            var content = AppSettings.GetValue("SMS_LossApplyNumber", "")
                .Replace("{landNumber}", e.Account.Trade.Land.LandNumber)
                .Replace("{applyNumber}", e.Account.ApplyNumber);
            Application.Messager.Send(e.Account.Contact.MobilePhone, content);
        }
    }
}
