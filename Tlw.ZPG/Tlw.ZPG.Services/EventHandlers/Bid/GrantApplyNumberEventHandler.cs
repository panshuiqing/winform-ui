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
    public class GrantApplyNumberEventHandler : IDomainEventHandler<GrantApplyNumberEvent>
    {
        public void Handle(GrantApplyNumberEvent e)
        {
            SystemLogService service = new SystemLogService();
            service.Insert(new Domain.Models.SystemLog()
            {
                CreateTime = DateTime.Now,
                Ip = UserContext.Current.Ip,
                Url = UserContext.Current.Url,
                UserId = UserContext.Current.UserId,
                UserName = UserContext.Current.UserName,
                Title = "发放竞买号",
                LogType = Domain.Enums.SystemLogType.ApplyNumber,
                LogCode = SystemLogCodes.L02010,
                Content = "宗地号为" + e.Account.Trade.Land.LandNumber + " 的宗地，竞买号" + e.Account.ApplyNumber + "发放成功！",
            });
            var content = AppSettings.GetValue("SMS_GrantApplyNumber", "")
                .Replace("{applyNumber}", e.Account.ApplyNumber)
                .Replace("{landNumber}", e.Account.Trade.Land.LandNumber);
            Application.Messager.Send(e.Account.Contact.MobilePhone, content);
        }
    }
}
