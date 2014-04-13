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
    public class FrozeAccountEventHandler : IDomainEventHandler<FrozeAccountEvent>
    {
        public void Handle(FrozeAccountEvent e)
        {
            SystemLogService service = new SystemLogService();
            service.Insert(new Domain.Models.SystemLog()
            {
                CreateTime = DateTime.Now,
                Ip = UserContext.Current.Ip,
                Url = UserContext.Current.Url,
                UserId = UserContext.Current.UserId,
                UserName = UserContext.Current.UserName,
                Title = "冻结竞买号",
                LogType = Domain.Enums.SystemLogType.ApplyNumber,
                LogCode= SystemLogCodes.L02000,
                Content = "宗地号为" + e.Account.Trade.Land.LandNumber + " 的宗地，竞买号" + e.Account.ApplyNumber + "冻结成功！",
            });
            var content = AppSettings.GetValue("SMS_FrozenAccount", "")
                .Replace("{applyNumber}", e.Account.ApplyNumber)
                .Replace("{landNumber}", e.Account.Trade.Land.LandNumber);
            Application.Messager.Send(e.Account.Contact.MobilePhone, content);
        }
    }
}
