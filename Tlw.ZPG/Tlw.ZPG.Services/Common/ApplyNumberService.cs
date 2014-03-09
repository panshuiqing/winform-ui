using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Models;

namespace Tlw.ZPG.Services.Common
{
    public class ApplyNumberService : ServiceBase<ApplyNumber>
    {
        public void Generate()
        {
            int count = 100000;
            List<ApplyNumber> list = new List<ApplyNumber>();
            for (int i = 0; i < count; i++)
            {
                var number = GenerateNumber();
                while (list.Any(a => a.Number == number))
                {
                    number = GenerateNumber();
                }
                list.Add(ApplyNumber.Create(number));
            }
        }
       
        private string GenerateNumber()
        {
            return new Random().NextDouble().ToString().Substring(3, 6);
        }

        public ApplyNumber GetUnUsedApplyNumber()
        {
            return DbSet.First(t => !t.IsUsed);
        }
    }
}
