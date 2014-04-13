namespace Tlw.ZPG.Domain.Models.Bid
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Domain.Enums;
    using Tlw.ZPG.Domain.Models.Bid.Events;
    using Tlw.ZPG.Domain.Models.Admin;
    using Tlw.ZPG.Domain.Models.Trading;
    using Tlw.ZPG.Infrastructure;
    using Tlw.ZPG.Infrastructure.Utils;
    using Tlw.ZPG.Infrastructure.Domain.Events;
    using FluentValidation.Results;
    using Tlw.ZPG.Domain.Validators;

    public partial class Account : EntityBase
    {
        public Account()
        {
            this.AccountVerifies = new HashSet<AccountVerify>();
            this.UnionBidPersons = new HashSet<Person>();
        }

        #region 属性
        public string ApplyNumber { get; internal set; }
        public string Password { get; internal set; }
        public bool PasswordUpdated { get; internal set; }
        public System.DateTime CreateTime { get; internal set; }
        public AccountStatus Status { get; internal set; }
        public string RandomNumber { get; internal set; }
        public int TradeId { get; set; }
        public ApplyType ApplyType { get; set; }
        public int ContactId { get; set; }
        public int? AgentId { get; set; }
        public int? CorporationId { get; set; }
        public int AccountPersonId { get; set; }
        public bool IsOnline { get; set; }
        public Nullable<System.DateTime> OnlineTime { get; set; }
        public AccountVerifyStatus VerifyStatus { get; set; }
        public virtual Trade Trade { get; internal set; }
        public virtual Person Agent { get; set; }
        public virtual Person AccountPerson { get; set; }
        public virtual Person Contact { get; set; }
        public virtual Person Corporation { get; set; }
        public virtual ICollection<AccountVerify> AccountVerifies { get; set; }
        public virtual ICollection<Person> UnionBidPersons { get; set; }
        public virtual ICollection<TradeDetail> TradeDetails { get; set; }
        public virtual ICollection<AccountAttach> Attachments { get; set; }
        #endregion

        #region 方法

        /// <summary>
        /// 生成12位随机码
        /// </summary>
        /// <returns></returns>
        private string GenerateRandomNumber()
        {
            return new Random().NextDouble().ToString().Substring(3, 6) + new Random().NextDouble().ToString().Substring(3, 6);
        }

        /// <summary>
        /// 申请，注册
        /// </summary>
        public void Apply(Trade trade)
        {
            this.Trade = trade;
            this.RandomNumber = GenerateRandomNumber();
            this.CreateTime = DateTime.Now;
            this.Status = AccountStatus.Normal;
            this.VerifyStatus = AccountVerifyStatus.UnSubmit;
        }

        /// <summary>
        /// 获取竞买人名称
        /// </summary>
        /// <returns></returns>
        public string GetAccountName()
        {
            string name = string.Empty;
            if (this.ApplyType == ApplyType.Union)
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

        /// <summary>
        /// 是否能提交审核
        /// </summary>
        public bool CanSubmitVerify()
        {
            return this.VerifyStatus == AccountVerifyStatus.UnSubmit || this.VerifyStatus == AccountVerifyStatus.NotifySupply;
        }

        /// <summary>
        /// 提交审核
        /// </summary>
        public void SubmitVerify()
        {
            DoSubmitVerify(null);
        }

        /// <summary>
        /// 提交审核内容
        /// </summary>
        public void SubmitVerifyContent(string content)
        {
            if (string.IsNullOrEmpty(content)) throw new SubmitApplyException("内容不能为空");
            DoSubmitVerify(content);
        }

        private void DoSubmitVerify(string content)
        {
            if (CanSubmitVerify())
            {
                if (content == null)
                {
                    this.VerifyStatus = AccountVerifyStatus.Submited;
                }
                var verify = new AccountVerify()
                {
                    AccountId = this.ID,
                    CreateTime = DateTime.Now,
                    Content = content,
                    Status = this.VerifyStatus,
                };
                this.AccountVerifies.Add(verify);
                DomainEvents.Publish(new SubmitVerifyEvent() { Account = this, AccountVerify = verify });
            }
            else
            {
                throw new SubmitApplyException("当前不允许提交审核");
            }
        }

        /// <summary>
        /// 后台管理员是否可以审核
        /// </summary>
        public bool CanVerifyByUser()
        {
            return this.VerifyStatus == AccountVerifyStatus.Submited || this.VerifyStatus == AccountVerifyStatus.SuppliedAndSubmited;
        }

        /// <summary>
        /// 后台管理员审核
        /// </summary>
        /// <param name="content"></param>
        /// <param name="user"></param>
        public void VerifyByUser(int userId, string content, VerifyType verifyType)
        {
            if (CanVerifyByUser())
            {
                this.VerifyStatus = (AccountVerifyStatus)Enum.Parse(typeof(AccountVerifyStatus), verifyType.ToString());
                this.AccountVerifies.Add(new AccountVerify()
                {
                    AccountId = this.ID,
                    Content = content,
                    CreateTime = DateTime.Now,
                    Status = this.VerifyStatus,
                    UserId = userId,
                });
                DomainEvents.Publish(new VerifyByUserEvent() { Account = this });
            }
            else
            {
                throw new VerifyApplyException("当前不允许审核");
            }
        }

        private string GeneratePassword()
        {
            return new Random().NextDouble().ToString().Substring(3, 8);
        }

        /// <summary>
        /// 发放竞买号
        /// </summary>
        public void GrantApplyNumber(int userId, string applyNumber)
        {
            if (userId != this.Trade.Affiche.CreatorId) throw new GrantApplyNumberException("挂牌人只能发放自己宗地的竞买号");
            if (this.VerifyStatus != AccountVerifyStatus.Verified) throw new GrantApplyNumberException("未审核通过不允许发放竞买号");
            if (this.Status == AccountStatus.Froze) throw new GrantApplyNumberException("竞买号已冻结不允许发放竞买号");
            CheckGrantTime();
            this.ApplyNumber = applyNumber;
            this.Password = GeneratePassword();
            this.Status = AccountStatus.Normal;
            DomainEvents.Publish(new GrantApplyNumberEvent() { Account = this });
        }

        private void CheckGrantTime()
        {
            var days = AppSettings.GetValue("MinReleaseNum2TEDay", 2);
            if (DateTime.Now > this.Trade.TradeEndTime.AddDays(-days))
            {
                throw new GrantApplyNumberException(string.Format("竞买号只能在交易截止时间前{0}天发放", days));
            }
        }

        /// <summary>
        /// 冻结竞买号
        /// </summary>
        public void Froze(int userId)
        {
            if (this.Status == AccountStatus.Loss) throw new AccountFrozeException("竞买号已挂失，不允许冻结");
            if (this.Status == AccountStatus.Normal)
            {
                if (this.Trade.CreatorId != userId) throw new AccountFrozeException("挂牌人只能冻结自己宗地的竞买号");
                this.Status = AccountStatus.Froze;
                DomainEvents.Publish(new FrozeAccountEvent() { Account = this });
            }
        }

        /// <summary>
        /// 解冻（恢复）
        /// </summary>
        public void Recover(int userId)
        {
            if (this.Status == AccountStatus.Loss) throw new AccountFrozeException("竞买号已挂失，不允许解冻");
            if (this.Status == AccountStatus.Froze)
            {
                if (this.Trade.CreatorId != userId) throw new AccountFrozeException("挂牌人只能解冻自己宗地的竞买号");
                this.Status = AccountStatus.Normal;
                DomainEvents.Publish(new RecoverAccountEvent() { Account = this });
            }
        }

        public bool CheckPassword(string password)
        {
            return this.Password == SecurityUtil.MD5Encrypt(password);
        }

        public void ResetPassword(int userId)
        {
            if (this.Status == AccountStatus.Froze || this.Status == AccountStatus.Loss) 
                throw new AccountFrozeException("竞买号已冻结或挂失，不允许重置密码");
            if (this.Trade.CreatorId != userId) throw new AccountFrozeException("挂牌人只能重置自己宗地的竞买号的密码");
            this.Password = GeneratePassword();
            this.PasswordUpdated = false;
            DomainEvents.Publish(new ResetPasswordEvent() { Account = this });
        }

        /// <summary>
        /// 挂失
        /// </summary>
        /// <param name="userId"></param>
        public void Loss(int userId)
        {
            if (this.Status == AccountStatus.Loss)
            {
                throw new DomainException("该竞买号已经挂失过一次，不能再次挂失");
            }
            else
            {
                if (this.Trade.CreatorId != userId) throw new AccountFrozeException("挂牌人只能挂失自己宗地的竞买号");
                var days = AppSettings.GetValue("MinLoseNum2TEDay", 2);
                if (DateTime.Now > this.Trade.TradeEndTime.AddDays(-days))
                    throw new GrantApplyNumberException(string.Format("现在离挂牌交易截止期限不足{0}日，不能挂失", days));
                this.Status = AccountStatus.Loss;
                DomainEvents.Publish(new LossAccountEvent() { Account = this });
            }
        }

        #endregion

        #region Validate
        public override IEnumerable<BusinessRule> Validate()
        {
            AccountValidator validator = new AccountValidator();
            ValidationResult results = validator.Validate(this);
            foreach (var item in results.Errors)
            {
                yield return new BusinessRule(item.PropertyName, item.ErrorMessage);
            }
        }

        #endregion
    }
}
