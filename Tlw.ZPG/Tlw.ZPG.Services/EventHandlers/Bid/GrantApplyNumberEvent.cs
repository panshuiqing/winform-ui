using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Models.Bid;
using Tlw.ZPG.Domain.Models.Bid.Events;
using Tlw.ZPG.Infrastructure.Domain.Events;

namespace Tlw.ZPG.Services.EventHandlers.Bid
{
    public class GrantApplyNumberEventHandler : IDomainEventHandler<GrantApplyNumberEvent>
    {
        public void Handle(GrantApplyNumberEvent domainEvent)
        {

        }
    }
}
