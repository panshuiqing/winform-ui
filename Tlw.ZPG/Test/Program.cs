using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Infrastructure.Events;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            EventAggregator ev = new EventAggregator();
           
            ev.GetEvent<TestEvent>().Subscribe(d => {
                Console.WriteLine(d.FileName);
            });
            ev.GetEvent<TestEvent>().Publish(new Tlw.ZPG.Domain.Models.Download() { FileName = "aa" });
        }
    }

    public class TestEvent:CompositePresentationEvent<Tlw.ZPG.Domain.Models.Download>
    {
    }
}
