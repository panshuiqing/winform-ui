namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class ApplyNumber : EntityBase
    {
        public static ApplyNumber Create(string number)
        {
            return new ApplyNumber() { Number = number };
        }

        public string Number { get; set; }
        public bool IsUsed { get; set; }
        public Nullable<System.DateTime> UsedTime { get; set; }

        public static ApplyNumber[] Generate(int count)
        {
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
            return list.ToArray();
        }

        private static string GenerateNumber()
        {
            return new Random().NextDouble().ToString().Substring(3, 4);
        }
    }
}
