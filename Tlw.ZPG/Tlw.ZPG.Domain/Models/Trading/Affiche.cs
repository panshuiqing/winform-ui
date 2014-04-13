namespace Tlw.ZPG.Domain.Models.Trading
{
    using System;
    using System.Collections.Generic;
    using FluentValidation.Results;
    using Tlw.ZPG.Domain.Enums;
    using Tlw.ZPG.Domain.Models.Admin;
    using Tlw.ZPG.Domain.Validators;
    using Tlw.ZPG.Infrastructure;
    using Tlw.ZPG.Infrastructure.Utils;

    public partial class Affiche : EntityBase
    {
        public Affiche()
        {
            this.Trades = new HashSet<Trade>();
            this.Nodes = new HashSet<Affiche>();
        }

        #region 属性
        /// <summary>
        /// 原公告ID
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 其他内容
        /// </summary>
        public string OtherContent { get; set; }
        /// <summary>
        /// 资质要求
        /// </summary>
        public string QualificationRequire { get; set; }
        /// <summary>
        /// 交易须知
        /// </summary>
        public string Notice { get; set; }
        /// <summary>
        /// 挂牌方式及竞价办法
        /// </summary>
        public string HandModeAndBidMethod { get; set; }
        /// <summary>
        /// 创建用户ID
        /// </summary>
        public int CreatorId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public System.DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 报名起始时间
        /// </summary>
        public System.DateTime SignBeginTime { get; set; }
        /// <summary>
        /// 报名截止时间
        /// </summary>
        public System.DateTime SignEndTime { get; set; }
        /// <summary>
        /// 交易起始时间
        /// </summary>
        public System.DateTime TradeBeginTime { get; set; }
        /// <summary>
        /// 交易截止时间
        /// </summary>
        public System.DateTime TradeEndTime { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public System.DateTime? VerifyTime { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsRelease { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public System.DateTime ReleaseTime { get; set; }
        /// <summary>
        /// 行政区id
        /// </summary>
        public int CountyId { get; set; }
        /// <summary>
        /// 公告类型
        /// </summary>
        public string AfficheType { get; set; }
        /// <summary>
        /// 出让方式
        /// </summary>
        public string SellModel { get; set; }
        /// <summary>
        /// 公告编号
        /// </summary>
        public string AfficheNumber { get; set; }
        /// <summary>
        /// 批准文号
        /// </summary>
        public string RatificationNumber { get; set; }
        /// <summary>
        /// 批准机关
        /// </summary>
        public string RatificationOrg { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public AfficheVerifyStatus VerifyStatus { get; set; }
        /// <summary>
        /// 审核用户id
        /// </summary>
        public int? VerifyUserId { get; set; }
        /// <summary>
        /// 标签，多个,分割
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string ComeForm { get; set; }

        public virtual County County { get; set; }
        public virtual User Creator { get; set; }
        public virtual User VerifyUser { get; set; }
        public virtual Affiche Parent { get; internal set; }
        public virtual ICollection<Affiche> Nodes { get; internal set; }
        public virtual ICollection<Trade> Trades { get; internal set; }
        #endregion

        public override IEnumerable<BusinessRule> Validate()
        {
            AfficheValidator validator = new AfficheValidator();
            ValidationResult results = validator.Validate(this);
            foreach (var item in results.Errors)
            {
                yield return new BusinessRule(item.PropertyName, item.ErrorMessage);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formater"></param>
        public void FormatContent(string formater)
        {
            if (formater == null) throw new DomainException("templete不能为null");
            formater = formater.Replace("{Affiche_Org}", this.ComeForm);
            formater = formater.Replace("{Affiche_Number}", this.AfficheNumber);
            formater = formater.Replace("{RatificationOrg}", this.RatificationOrg);
            formater = formater.Replace("{Affiche_Number}", this.AfficheNumber);
            formater = formater.Replace("{Affiche_QualificationRequire}", this.QualificationRequire);
            formater = formater.Replace("{Affiche_HandModeAndBidMethod}", this.HandModeAndBidMethod);
            formater = formater.Replace("{Affiche_Sign_Time}", this.SignBeginTime.ToString("yyyy年MM月dd日HH点至") + this.SignEndTime.ToString("yyyy年MM月dd日HH点"));
            formater = formater.Replace("{Affiche_Trade_Time}", this.TradeBeginTime.ToString("yyyy年MM月dd日HH点至") + this.TradeEndTime.ToString("yyyy年MM月dd日HH点"));
            formater = formater.Replace("{Other_Content}", this.OtherContent);
            formater = formater.Replace("{Land_Count}", this.Trades.Count.ToString());
            formater = formater.Replace("{Afiche_Release_Time}", StringUtil.DateToUpper(this.ReleaseTime));
            this.Content = formater;
        }

        /// <summary>
        /// 补充公告
        /// </summary>
        /// <param name="affiche">新公告</param>
        public void Supply(int userId, Affiche affiche)
        {
            if (affiche == null)
            {
                throw new ReplenishException("补充公告不能为空");
            }
            if (userId != this.CreatorId)
            {
                throw new ReplenishException("你不是公告创建者，不能补充公告");
            }
            if (!this.IsRelease)
            {
                throw new ReplenishException("原公告没有发布之前不能补充公告");
            }
            //不能对已经补充的公告再次进行补充，系统自动对原公告进行补充
            if (this.ParentId.HasValue)
            {
                affiche.Parent = this.Parent;
            }
            else
            {
                affiche.Parent = this;
            }
        }

        /// <summary>
        /// 发布公告
        /// </summary>
        /// <param name="userId"></param>
        public void Release(int userId)
        {
            ReleaseCheck(userId);
            //公告发布后同步报名时间和交易时间
            foreach (var item in this.Trades)
            {
                SetTrade(item);
            }
            this.IsRelease = true;
        }

        private void SetTrade(Trade trade)
        {
            trade.SignBeginTime = this.SignBeginTime;
            trade.SignEndTime = this.SignEndTime;
            trade.TradeBeginTime = this.TradeBeginTime;
            trade.TradeEndTime = this.TradeEndTime;
            trade.Land.SetLandPurpose();
        }

        /// <summary>
        /// 添加宗地
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="trade"></param>
        public void AddTrade(int userId, Trade trade)
        {
            if (userId != this.CreatorId) throw new DomainException("你不是公告创建者，无法添加宗地");
            trade.Affiche = this;
            trade.CreatorId = this.CreatorId;
            SetTrade(trade);
            SetTags(trade.Land);
            this.Trades.Add(trade);
        }

        /// <summary>
        /// 设置tags，以便在前台查询（首页标签查询）
        /// </summary>
        /// <param name="land"></param>
        private void SetTags(Land land)
        {
            foreach (var item in land.LandPurposes)
            {
                var purpose = item.Purpose;
                DoSetTags(purpose.PurposeName);
                while (purpose.ParentId.HasValue)
                {
                    purpose = purpose.Parent;
                    DoSetTags(purpose.PurposeName);
                }
            }
            this.Tags = this.Tags.Trim(',');
        }

        private void DoSetTags(string purposeName)
        {
            if (purposeName.Contains("工业用地"))
            {
                this.Tags += "工业用地,";
            }
            else if (purposeName.Contains("住宅用地") || purposeName.Contains("商服用地"))
            {
                this.Tags += "商住用地,";
            }
            else
            {
                this.Tags += "其他用地,";
            }
        }

        private void ReleaseCheck(int userId)
        {
            if (this.IsRelease)
            {
                throw new AfficheReleaseException("公告已经发布，不能再次发布");
            }
            if (userId != this.CreatorId)
            {
                throw new AfficheReleaseException("你不是此公告创建者，不能发布公告");
            }
            if (this.ParentId.HasValue)
            {
                //补充公告
                if (this.Trades.Count != this.Parent.Trades.Count)
                {
                    throw new AfficheReleaseException("补充公告不能删除或者增加宗地信息");
                }
                if (this.Parent.TradeBeginTime < DateTime.Now)
                {
                    throw new AfficheReleaseException("原公告交易时间已到，不能发布补充公告");
                }
                if (this.ReleaseTime <= this.Parent.ReleaseTime)
                {
                    throw new AfficheReleaseException("补充公告发布时间不能早于原公告发布时间");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(this.Notice))
                {
                    throw new AfficheReleaseException("交易须知不能为空");
                }
                if (this.Trades.Count == 0)
                {
                    throw new AfficheReleaseException("宗地信息未增加");
                }
            }
        }
    }
}
