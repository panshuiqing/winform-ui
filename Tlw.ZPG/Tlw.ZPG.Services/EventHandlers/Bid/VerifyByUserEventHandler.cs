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
    public class VerifyByUserEventHandler : IDomainEventHandler<VerifyByUserEvent>
    {
        public void Handle(VerifyByUserEvent e)
        {
            SystemLogService service = new SystemLogService();
            service.Insert(new Domain.Models.SystemLog()
            {
                CreateTime = DateTime.Now,
                Ip = UserContext.Current.Ip,
                Url = UserContext.Current.Url,
                UserId = UserContext.Current.UserId,
                UserName = UserContext.Current.UserName,
                Title = "审核竞买申请",
                LogType = Domain.Enums.SystemLogType.ApplyNumber,
                LogCode = SystemLogCodes.L02030,
                Content = "审核竞买申请，宗地号" + e.Account.Trade.Land.LandNumber + "，竞买号" + e.Account.ApplyNumber,
            });
            var content = AppSettings.GetValue("SMS_VerifyApply", "")
                .Replace("{landNumber}", e.Account.Trade.Land.LandNumber)
                .Replace("{verifyStatus}", Tlw.ZPG.Infrastructure.Utils.EnumUtil.GetDescription(e.VerifyType));
            Application.Messager.Send(e.Account.Contact.MobilePhone, content);
        }
    }
}
