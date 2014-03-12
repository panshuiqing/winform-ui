using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Models.Bid.Events;
using Tlw.ZPG.Infrastructure.Domain.Events;
using Tlw.ZPG.Services.EventHandlers.Bid;

namespace Tlw.ZPG.Services
{
    public class BootStrapper
    {
        public static void Configure()
        {
            //account
            DomainEvents.Subscribe(new FrozeAccountEventHandler());
            DomainEvents.Subscribe(new GrantApplyNumberEventHandler());
            DomainEvents.Subscribe(new LossAccountEventHandler());
            DomainEvents.Subscribe(new RecoverAccountEventHandler());
            DomainEvents.Subscribe(new ResetPasswordEventHandler());
            DomainEvents.Subscribe(new SubmitVerifyEventHandler());
            DomainEvents.Subscribe(new VerifyByUserEventHandler());
        }
    }
}
