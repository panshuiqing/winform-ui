using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Tlw.ZPG.Domain.Models.Trading;
using Tlw.ZPG.Infrastructure;

namespace Tlw.ZPG.Domain.Validators
{
    internal class AfficheValidator : AbstractValidator<Affiche> 
    {
        public AfficheValidator()
        {
            RuleFor(t => t.Title).NotEmpty().WithMessage("公告标题不能为空");
            RuleFor(t => t.AfficheNumber).NotEmpty().WithMessage("公告编号不能为空");
            RuleFor(t => t.RatificationOrg).NotEmpty().WithMessage("出让方案批准机关不能为空");
            RuleFor(t => t.ReleaseTime).LessThan(DateTime.Now).WithMessage("发布时间不能早于当前时间");
            RuleFor(t => t.SignBeginTime).LessThan(t => t.ReleaseTime).WithMessage("报名时间不能早于发布时间");
            RuleFor(t => t.TradeEndTime).LessThan(t => t.SignEndTime).WithMessage("交易截止时间不能早于报名截止时间");

            //报名截止时间到交易截止时间最小差 3 天
            var days = AppSettings.GetValue("MinSE2TEDay", 3);
            RuleFor(t => (t.TradeEndTime - t.SignBeginTime).TotalDays).LessThan(days).WithMessage(string.Format("报名截止时间必须在挂牌交易截止时间点前{0}日", days));
            //公告发布时间到交易起始时间最小差 20
            days = AppSettings.GetValue("MinAfficheR2TSDay", 20);
            RuleFor(t => (t.TradeBeginTime - t.ReleaseTime).TotalDays).LessThan(days).WithMessage(string.Format("公告发布时间到交易起始时间最小差{0}日", days));
            //交易起始时间到交易结束时间最小差 10
            days = AppSettings.GetValue("MinTradeS2EDay", 10);
            RuleFor(t => (t.TradeEndTime - t.TradeBeginTime).TotalDays).LessThan(days).WithMessage(string.Format("交易时间段必须大于{0}天", days));
            //公告发布时间到报名截止时间最小差 28
            days = AppSettings.GetValue("MinAfficheR2SEDay", 28);
            RuleFor(t => (t.SignEndTime - t.ReleaseTime).TotalDays).LessThan(days).WithMessage(string.Format("公告发布时间到报名截止时间最小差{0}天", days));

            RuleForEach(t => t.Trades).SetValidator(new LandValidator());
        }
    }

    internal class LandValidator : AbstractValidator<Land> 
    {
        public LandValidator()
        {
            RuleFor(t => t.ProjectName).NotEmpty().WithMessage("宗地项目名称不能为空");
            RuleFor(t => t.LandNumber).NotEmpty().WithMessage("宗地号不能为空");
            RuleFor(t => t.Location).NotEmpty().WithMessage("宗地位置不能为空");
            RuleFor(t => t.LandPurposes).NotEmpty().WithMessage("宗地用途及出让年限不能为空");
        }
    }
}
