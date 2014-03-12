using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Models.Bid;
using Tlw.ZPG.Domain.Models.Bid.Events;
using Tlw.ZPG.Infrastructure;
using Tlw.ZPG.Infrastructure.Domain.Events;
using Tlw.ZPG.Services.Common;

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
                Ip = Application.UserContext.Ip,
                Url = Application.UserContext.Url,
                UserId = Application.UserContext.UserId,
                UserName = Application.UserContext.UserName,
                Title = "冻结竞买号：" + e.Account.ApplyNumber,
                LogType = Domain.Enums.SystemLogType.Other,
                EntityName = e.Account.GetType().Name,
                Content = "宗地号为：" + e.Account.Trade.Land.LandNumber + " 的宗地，竞买号 " + e.Account.ApplyNumber + "冻结成功！",
            });
        }
    }
}
