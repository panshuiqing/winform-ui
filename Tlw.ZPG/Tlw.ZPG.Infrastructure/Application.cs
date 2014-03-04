using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Infrastructure.Events;

namespace Tlw.ZPG.Infrastructure
{
    public static class Application
    {
        public static EventAggregator EventAggregator
        {
            get;
            set;
        }
    }
}
