namespace Tlw.ZPG.Domain.Models.Trading
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Domain.Enums;
    using Tlw.ZPG.Domain.Models.Admin;
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
        /// 公告编号（2014号）
        /// </summary>
        public string AfficheNumberShort
        {
            get
            {
                string shortNum = string.Empty;
                if (!string.IsNullOrEmpty(AfficheNumber))
                {
                    var index = AfficheNumber.IndexOf('[');
                    var length = AfficheNumber.IndexOf(']') - index + 1;
                    shortNum = AfficheNumber.Substring(index, length);
                }

                return shortNum;
            }
        }
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
            if (string.IsNullOrEmpty(this.Title))
            {
                yield return new BusinessRule("公告标题不能为空");
            }
            if (string.IsNullOrEmpty(this.AfficheNumber))
            {
                yield return new BusinessRule("公告编号不能为空");
            }
            if (string.IsNullOrEmpty(this.RatificationOrg))
            {
                yield return new BusinessRule("出让方案批准机关不能为空");
            }
            if (this.ReleaseTime < DateTime.Now)
            {
                yield return new BusinessRule("发布时间不能早于当前时间");
            }
            if (this.SignBeginTime < this.ReleaseTime)
            {
                yield return new BusinessRule("报名时间不能早于发布时间");
            }
            if (this.TradeEndTime < this.SignEndTime)
            {
                yield return new BusinessRule("交易截止时间不能早于报名截止时间");
            }
            //报名截止时间到交易截止时间最小差 3
            var days = Application.GetDictionaryValue("MinSE2TEDay", 3);
            if ((this.TradeEndTime - this.SignBeginTime).TotalDays < days)
            {
                yield return new BusinessRule(string.Format("报名截止时间必须在挂牌交易截止时间点前{0}日", days));
            }
            //公告发布时间到交易起始时间最小差 20
            days = Application.GetDictionaryValue("MinAfficheR2TSDay", 20);
            if ((this.TradeBeginTime - this.ReleaseTime).TotalDays < days)
            {
                yield return new BusinessRule(string.Format("公告发布时间到交易起始时间最小差{0}天", days));
            }
            //交易起始时间到交易结束时间最小差 10
            days = Application.GetDictionaryValue("MinTradeS2EDay", 10);
            if ((this.TradeEndTime - this.TradeBeginTime).TotalDays < days)
            {
                yield return new BusinessRule(string.Format("交易时间段必须大于{0}天", days));
            }
            //公告发布时间到报名截止时间最小差 28
            days = Application.GetDictionaryValue("MinAfficheR2SEDay", 28);
            if ((this.SignEndTime - this.ReleaseTime).TotalDays < days)
            {
                yield return new BusinessRule(string.Format("公告发布时间到报名截止时间最小差{0}天", days));
            }
        }

        public void SetContentByTemplete(string templete)
        {
            if (templete == null) throw new DomainException("templete不能为null");
            templete = templete.Replace("{Affiche_Org}", this.ComeForm);
            templete = templete.Replace("{Affiche_Number}", this.AfficheNumber);
            templete = templete.Replace("{RatificationOrg}", this.RatificationOrg);
            templete = templete.Replace("{Affiche_Number_Short}", this.AfficheNumberShort);
            templete = templete.Replace("{Affiche_QualificationRequire}", this.QualificationRequire);
            //templete = templete.Replace("{Affiche_HandModeAndBidMethod}", this.HandModeAndBidMethod);
            templete = templete.Replace("{Affiche_Sign_Time}", this.SignBeginTime.ToString("yyyy年MM月dd日HH点至") + this.SignEndTime.ToString("yyyy年MM月dd日HH点"));
            templete = templete.Replace("{Affiche_Trade_Time}", this.TradeBeginTime.ToString("yyyy年MM月dd日HH点至") + this.TradeEndTime.ToString("yyyy年MM月dd日HH点"));
            templete = templete.Replace("{Other_Content}", this.OtherContent);
            templete = templete.Replace("{Affiche_Org}", this.ComeForm);
            templete = templete.Replace("{Afiche_Release_Time}", StringUtil.DateToUpper(this.ReleaseTime));
            this.Content = templete;
        }

        /// <summary>
        /// 补充公告
        /// </summary>
        /// <param name="original">原公告</param>
        public void Replenish(Affiche original)
        {
            if (original == null) throw new DomainException("原公告不能为空");
            if (!original.IsRelease)
            {
                throw new DomainException("原公告没有发布之前不能补充公告");
            }
            if (original.ParentId.HasValue)
            {
                throw new DomainException("不能对补充公告进行再次补充");
            }
            this.Parent = original;
        }

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
        }

        public void AddTrade(int userId, Trade trade, Land land)
        {
            CheckThrow(trade, userId);
            trade.Affiche = this;
            trade.CreatorId = this.CreatorId;
            trade.Land = land;
            SetTrade(trade);
            SetTags(land);
            this.Trades.Add(trade);
        }

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
            this.Tags = this.Tags.TrimEnd(',').TrimStart(',');
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

        private void CheckThrow(Trade trade, int userId)
        {
            if (trade == null) throw new DomainException("交易信息不能为空");
            if (trade.Land == null) throw new DomainException("交易信息不能为空");
            if (userId != this.CreatorId) throw new DomainException("你不是公告创建者，无法添加宗地");
            if (string.IsNullOrEmpty(trade.Land.ProjectName))
            {
                throw new DomainException("宗地项目名称不能为空");
            }
            if (string.IsNullOrEmpty(trade.Land.LandNumber))
            {
                throw new DomainException("宗地号不能为空");
            }
            if (string.IsNullOrEmpty(trade.Land.Location))
            {
                throw new DomainException("宗地位置不能为空");
            }
            if (trade.Land.LandPurposes.Count == 0)
            {
                throw new DomainException("宗地用途及出让年限不能为空");
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
