namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Domain.Models.Enums;
    using Tlw.ZPG.Infrastructure;
    using Tlw.ZPG.Infrastructure.Utils;

    public partial class Account : EntityBase
    {
        public Account()
        {
            this.AccountVerifies = new HashSet<AccountVerify>();
            this.UnionBidPersons = new HashSet<Person>();
        }

        #region 属性
        public string ApplyNumber { get; set; }
        public string Password { get; set; }
        public bool PasswordUpdated { get; set; }
        public System.DateTime CreateTime { get; set; }
        public AccountStatus Status { get; set; }
        public string RandomNumber { get; set; }
        public int TradeId { get; set; }
        public ApplyType ApplyType { get; set; }
        public int ContactId { get; set; }
        public int AgentId { get; set; }
        public int CorporationId { get; set; }
        public int AccountPersonId { get; set; }
        public bool IsOnline { get; set; }
        public Nullable<System.DateTime> OnlineTime { get; set; }
        public AccountVerifyStatus VerifyStatus { get; set; }
        public virtual Trade Trade { get; set; }
        public virtual Person Agent { get; set; }
        public virtual Person AccountPerson { get; set; }
        public virtual Person Contact { get; set; }
        public virtual Person Corporation { get; set; }
        public virtual ICollection<AccountVerify> AccountVerifies { get; set; }
        public virtual ICollection<Person> UnionBidPersons { get; set; }
        #endregion

        #region 方法
        public static Account Create(int tradeId, ApplyType applyType, Person Contact, Person Corporation, Person Agent, params Person[] unionBidPersons)
        {
            var account = new Account()
            {
                CreateTime = DateTime.Now,
                TradeId = tradeId,
                Status = AccountStatus.UnVerified,
                VerifyStatus = AccountVerifyStatus.NotifySupply,
                ApplyType = applyType,
                Contact = Contact,
                Corporation = Corporation,
                Agent = Agent,
                IsOnline = false
            };
            foreach (var item in unionBidPersons)
            {
                account.UnionBidPersons.Add(item);
            }
            return account;
        }

        public static string GenerateRandomNumber()
        {
            return new Random().NextDouble().ToString().Substring(3, 6) + new Random().NextDouble().ToString().Substring(3, 6);
        }

        /// <summary>
        /// 获取竞买人名称
        /// </summary>
        /// <returns></returns>
        public string GetAccountName()
        {
            string name = string.Empty;
            if (this.ApplyType == Models.ApplyType.Union)
            {
                foreach (var item in this.UnionBidPersons)
                {
                    name += item.PersonName + item.Unit;
                }
            }
            else
            {
                name = this.AccountPerson.PersonName + this.AccountPerson.Unit;
            }
            return name;
        }

        public bool CanSubmitVerify
        {
            get
            {
                return this.VerifyStatus == AccountVerifyStatus.UnSubmit || this.VerifyStatus == AccountVerifyStatus.NotifySupply;
            }
        }

        /// <summary>
        /// 提交审核
        /// </summary>
        /// <param name="content"></param>
        public void SubmitVerify(string content)
        {
            if (CanSubmitVerify)
            {
                this.VerifyStatus = AccountVerifyStatus.Submited;
                this.AccountVerifies.Add(new AccountVerify()
                {
                    AccountId = this.ID,
                    Content = content,
                    CreateTime = DateTime.Now,
                    IsAdmin = false,
                    Status = this.VerifyStatus,
                    VerifyAccountId = this.ID,
                    VerifyAccount = GetAccountName(),
                });
            }
        }

        public bool CanVerifyByUser
        {
            get
            {
                return this.VerifyStatus == AccountVerifyStatus.Submited || this.VerifyStatus == AccountVerifyStatus.SuppliedAndSubmited;
            }
        }

        /// <summary>
        /// 后台管理员审核
        /// </summary>
        /// <param name="content"></param>
        /// <param name="user"></param>
        public void VerifyByUser(string content, User user, VerifyType verifyType)
        {
            if (CanVerifyByUser)
            {
                if (user == null) throw new ArgumentNullException("user");
                this.VerifyStatus = (AccountVerifyStatus)Enum.Parse(typeof(AccountVerifyStatus), verifyType.ToString());
                this.AccountVerifies.Add(new AccountVerify()
                {
                    AccountId = this.ID,
                    Content = content,
                    CreateTime = DateTime.Now,
                    IsAdmin = true,
                    Status = this.VerifyStatus,
                    VerifyAccountId = user.ID,
                    VerifyAccount = user.UserName,
                });
                if (verifyType == VerifyType.Verified)
                {
                    this.Status = AccountStatus.Normal;
                }
            }
        }

        #endregion

        #region Validate
        public override IEnumerable<BusinessRule> Validate()
        {
            List<BusinessRule> list = new List<BusinessRule>();
            ValidateTrade(list);
            if (this.AccountPerson != null)
            {
                if (this.ApplyType == Models.ApplyType.Natural)
                {
                    ValidatePerson(list, this.AccountPerson, "自然人");
                }
                else if (this.ApplyType == Models.ApplyType.Corporation || this.ApplyType == Models.ApplyType.OtherOrg)
                {
                    ValidateOrg(list, this.AccountPerson, "");
                }
            }
            if (this.Corporation != null)
            {
                ValidatePerson(list, this.Corporation, "法定代表人");
            }
            if (this.Agent != null)
            {
                ValidatePerson(list, this.Agent, "委托代理人");
            }
            ValidateContact(list);
            if (this.ApplyType == Models.ApplyType.Union)
            {
                foreach (var item in this.UnionBidPersons)
                {
                    if (item.ApplyType == Models.ApplyType.Natural)
                    {
                        ValidatePerson(list, item, "自然人（联合竞买）");
                    }
                    else
                    {
                        ValidateOrg(list, item, "联合竞买");
                    }
                }
            }
            return list;
        }

        private void ValidateTrade(List<BusinessRule> list)
        {
            if (this.Trade == null)
            {
                list.Add(new BusinessRule("不存在此宗地"));
            }
            else
            {
                if (this.Trade.SignBeginTime > DateTime.Now)
                {
                    list.Add(new BusinessRule("还未到报名时间"));
                }
                if (this.Trade.SignEndTime < DateTime.Now)
                {
                    list.Add(new BusinessRule("已过报名时间"));
                }
            }
        }

        private void ValidateOrg(List<BusinessRule> list, Person person, string prefix)
        {
            if (string.IsNullOrEmpty(this.Agent.Unit) || this.Agent.Unit.Length < 8)
            {
                list.Add(new BusinessRule(prefix + "单位名称填写不完整"));
            }
            if (string.IsNullOrEmpty(this.Agent.UnitCode) || this.Agent.UnitCode.Length < 5)
            {
                list.Add(new BusinessRule(prefix + "单位注册代码填写不完整"));
            }
            if (string.IsNullOrEmpty(this.Agent.MobilePhone) || this.Agent.MobilePhone.Length < 7)
            {
                list.Add(new BusinessRule(prefix + "电话填写不完整"));
            }
            if (!StringUtil.IsPostalCode(this.Agent.PostalCode))
            {
                list.Add(new BusinessRule(prefix + "邮编不正确"));
            }
        }

        private void ValidatePerson(List<BusinessRule> list, Person person, string prefix)
        {
            if (person != null)
            {
                if (string.IsNullOrEmpty(person.PersonName) || person.PersonName.Length < 2)
                {
                    list.Add(new BusinessRule(prefix + "姓名填写不完整"));
                }
                if (string.IsNullOrEmpty(person.PassportNumber) || person.PassportNumber.Length < 5)
                {
                    list.Add(new BusinessRule(prefix + "证件号码填写不完整"));
                }
                else if (person.PassportType == "身份证" && !StringUtil.IsCardNo(person.PassportType))
                {
                    list.Add(new BusinessRule(prefix + "身份证填写不完整"));
                }
                if (string.IsNullOrEmpty(person.Address) || person.Address.Length < 12)
                {
                    list.Add(new BusinessRule(prefix + "地址填写不完整"));
                }
                if (string.IsNullOrEmpty(person.MobilePhone) || person.MobilePhone.Length < 7)
                {
                    list.Add(new BusinessRule(prefix + "电话填写不完整"));
                }
                if (!StringUtil.IsPostalCode(person.PostalCode))
                {
                    list.Add(new BusinessRule(prefix + "邮编不正确"));
                }
            }
        }

        private void ValidateContact(List<BusinessRule> list)
        {
            if (string.IsNullOrEmpty(this.Contact.PersonName) || this.Contact.PersonName.Length < 2)
            {
                list.Add(new BusinessRule("联系人姓名填写不完整"));
            }
            if (string.IsNullOrEmpty(this.Contact.Telephone) || this.Contact.Telephone.Length < 7)
            {
                list.Add(new BusinessRule("联系人固定电话填写不完整"));
            }
            if (!StringUtil.IsMobilePhone(this.Contact.MobilePhone))
            {
                list.Add(new BusinessRule("联系人手机号码不正确"));
            }
            if (string.IsNullOrEmpty(this.Contact.Address) || this.Contact.Address.Length < 12)
            {
                list.Add(new BusinessRule("联系人地址填写不完整"));
            }
            if (!StringUtil.IsPostalCode(this.Contact.PostalCode))
            {
                list.Add(new BusinessRule("联系人邮编不正确"));
            }
        } 
        #endregion
    }
}
