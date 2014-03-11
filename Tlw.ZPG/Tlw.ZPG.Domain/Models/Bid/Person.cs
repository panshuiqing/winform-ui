namespace Tlw.ZPG.Domain.Models.Bid
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Domain.Enums;
    using Tlw.ZPG.Infrastructure;
    using Tlw.ZPG.Infrastructure.Utils;

    public partial class Person : EntityBase
    {
        public int AccountId { get; set; }
        public string PersonName { get; set; }
        public string PassportType { get; set; }
        public string PassportNumber { get; set; }
        public string Unit { get; set; }
        public string UnitCode { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Business { get; set; }
        public string PostalCode { get; set; }
        public ApplyType ApplyType { get; set; }

        /// <summary>
        /// 创建法人，其他组织
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="unitCode"></param>
        /// <param name="address"></param>
        /// <param name="postallCode"></param>
        /// <returns></returns>
        public static Person CreateOrg(string unit, string unitCode, string address, string postallCode)
        {
            return new Person()
            {
                UnitCode = unitCode,
                Unit = unit,
                Address = address,
                PostalCode = postallCode
            };
        }

        /// <summary>
        /// 创建联系人
        /// </summary>
        /// <param name="name"></param>
        /// <param name="telephone"></param>
        /// <param name="mobilePhone"></param>
        /// <param name="email"></param>
        /// <param name="unit"></param>
        /// <param name="address"></param>
        /// <param name="postallCode"></param>
        /// <returns></returns>
        public static Person CreateContact(string name, string telephone, string mobilePhone, string email, string unit, string address, string postallCode)
        {
            return new Person()
            {
                PersonName = name,
                Telephone = telephone,
                MobilePhone = mobilePhone,
                Email = email,
                Unit = unit,
                Address = address,
                PostalCode = postallCode
            };
        }

        /// <summary>
        /// 创建自然人，委托人
        /// </summary>
        /// <param name="name"></param>
        /// <param name="passportType"></param>
        /// <param name="passportNumber"></param>
        /// <param name="unit"></param>
        /// <param name="address"></param>
        /// <param name="mobilePhone"></param>
        /// <param name="postallCode"></param>
        /// <returns></returns>
        public static Person CreatePerson(string name, string passportType, string passportNumber, string unit, string address, string mobilePhone, string postallCode)
        {
            return new Person()
            {
                PersonName = name,
                MobilePhone = mobilePhone,
                Unit = unit,
                Address = address,
                PostalCode = postallCode,
                PassportNumber = passportNumber,
                PassportType = passportType,
            };
        }

        /// <summary>
        /// 创建法定代表人
        /// </summary>
        /// <param name="name"></param>
        /// <param name="passportType"></param>
        /// <param name="passportNumber"></param>
        /// <param name="business"></param>
        /// <param name="address"></param>
        /// <param name="mobilePhone"></param>
        /// <param name="postallCode"></param>
        /// <returns></returns>
        public static Person CreateCorporation(string name, string passportType, string passportNumber, string business, string address, string mobilePhone, string postallCode)
        {
            return new Person()
            {
                PersonName = name,
                MobilePhone = mobilePhone,
                Business = business,
                Address = address,
                PostalCode = postallCode,
                PassportNumber = passportNumber,
                PassportType = passportType,
            };
        }
    }
}
