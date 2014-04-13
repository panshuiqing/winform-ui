using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Tlw.ZPG.Domain.Models.Bid;
using Tlw.ZPG.Infrastructure.Utils;

namespace Tlw.ZPG.Domain.Validators
{
    internal class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(t => t.Trade).NotNull().WithMessage("不存在此宗地");
            RuleFor(t => t.Trade.SignBeginTime).GreaterThan(DateTime.Now).WithMessage("还未到报名时间");
            RuleFor(t => t.Trade.SignEndTime).LessThan(DateTime.Now).WithMessage("已过报名时间");
            RuleFor(t => t.AccountPerson).SetValidator(new PersonValidator("自然人")).When(t => t.AccountPerson != null && t.ApplyType == Enums.ApplyType.Natural);
            RuleFor(t => t.AccountPerson).SetValidator(new OrgValidator("")).When(t => t.AccountPerson != null && (t.ApplyType == Enums.ApplyType.OtherOrg) || t.ApplyType == Enums.ApplyType.Corporation);
            RuleFor(t => t.Corporation).SetValidator(new PersonValidator("法定代表人")).When(t => t.Corporation != null);
            RuleFor(t => t.Corporation).SetValidator(new PersonValidator("委托代理人")).When(t => t.Agent != null);
            RuleFor(t => t.Contact).NotNull().WithMessage("联系人不能为空");
            RuleFor(t => t.Corporation).SetValidator(new ContactValidator()).When(t => t.Contact != null);
            RuleForEach(t => t.UnionBidPersons).SetValidator(new PersonValidator("自然人（联合竞买）")).When(t => t.ApplyType == Enums.ApplyType.Natural);
            RuleForEach(t => t.UnionBidPersons).SetValidator(new OrgValidator("联合竞买")).When(t => t.ApplyType != Enums.ApplyType.Natural);
        }
    }

    internal class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator(string prefix)
        {
            RuleFor(t => t.PersonName).NotNull().Length(2, 50).WithMessage(prefix + "姓名填写不完整");
            RuleFor(t => t.PassportNumber).NotNull().Length(5, 50).WithMessage(prefix + "证件号码填写不完整").When(t => t.PassportType != "身份证");
            RuleFor(t => t.PassportNumber).Must(StringUtil.IsCardNo).WithMessage(prefix + "身份证填写不完整").When(t => t.PassportType == "身份证");
            RuleFor(t => t.Address).NotNull().Length(12, 100).WithMessage(prefix + "地址填写不完整");
            RuleFor(t => t.Telephone).NotNull().Length(7, 50).WithMessage(prefix + "电话填写不完整");
            RuleFor(t => t.PostalCode).Must(StringUtil.IsPostalCode).WithMessage(prefix + "邮编不正确");
        }
    }

    internal class ContactValidator : AbstractValidator<Person>
    {
        public ContactValidator()
        {
            RuleFor(t => t.PersonName).NotNull().Length(2, 50).WithMessage("联系人姓名填写不完整");
            RuleFor(t => t.Telephone).NotNull().Length(7, 50).WithMessage("联系人固定电话填写不完整");
            RuleFor(t => t.MobilePhone).Must(StringUtil.IsMobilePhone).WithMessage("联系人手机号码不正确");
            RuleFor(t => t.Address).NotNull().Length(12, 100).WithMessage("联系人地址填写不完整");
            RuleFor(t => t.PostalCode).Must(StringUtil.IsPostalCode).WithMessage("联系人邮编不正确");
        }
    }

    internal class OrgValidator : AbstractValidator<Person>
    {
        public OrgValidator(string prefix)
        {
            RuleFor(t => t.Unit).NotNull().Length(8, 50).WithMessage(prefix + "单位名称填写不完整");
            RuleFor(t => t.UnitCode).NotNull().Length(5, 50).WithMessage(prefix + "单位注册代码填写不完整");
            RuleFor(t => t.Telephone).NotNull().Length(7, 50).WithMessage(prefix + "电话号码不正确");
            RuleFor(t => t.PostalCode).Must(StringUtil.IsPostalCode).WithMessage(prefix + "邮编不正确");
        }
    }
}
