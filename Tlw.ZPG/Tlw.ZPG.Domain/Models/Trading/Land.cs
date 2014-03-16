namespace Tlw.ZPG.Domain.Models.Trading
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Domain.Models.Admin;
    using Tlw.ZPG.Infrastructure;

    public partial class Land : EntityBase
    {
        public Land()
        {
            this.LandAttaches = new HashSet<LandAttach>();
            this.Purposes = new HashSet<Purpose>();
        }

        #region 属性
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 宗地编号
        /// </summary>
        public string LandNumber { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 面积
        /// </summary>
        public decimal Area { get; set; }
        /// <summary>
        /// 土地用途（完整）
        /// </summary>
        public string LandPurpose { get; set; }
        /// <summary>
        /// 土地用途（只显示父级）
        /// </summary>
        public string LandPurposeShort { get; set; }
        /// <summary>
        /// 土地现状
        /// </summary>
        public int LandState { get; set; }
        /// <summary>
        /// 挂牌人电话
        /// </summary>
        public string Phones { get; set; }
        /// <summary>
        /// 竞价须知
        /// </summary>
        public string Notice { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 其他条件
        /// </summary>
        public string OtherCondition { get; set; }
        /// <summary>
        /// 容积率
        /// </summary>
        public decimal Capability { get; set; }
        /// <summary>
        /// 密度
        /// </summary>
        public decimal Density { get; set; }
        /// <summary>
        /// 绿地率
        /// </summary>
        public decimal GreenLandRate { get; set; }
        /// <summary>
        /// 履约保证金
        /// </summary>
        public decimal FulfilGuarantee { get; set; }
        /// <summary>
        /// 开竣工保证金
        /// </summary>
        public decimal CompletionGuarantee { get; set; }
        /// <summary>
        /// 宗地范围
        /// </summary>
        public string LandScope { get; set; }

        public virtual ICollection<LandAttach> LandAttaches { get; internal set; }
        public virtual ICollection<Purpose> Purposes { get; internal set; } 
        #endregion

        public override IEnumerable<BusinessRule> Validate()
        {
            if (string.IsNullOrEmpty(this.ProjectName))
            {
                yield return new BusinessRule("项目名称不能为空");
            }
            if (string.IsNullOrEmpty(this.LandNumber))
            {
                yield return new BusinessRule("宗地号不能为空");
            }
            if (string.IsNullOrEmpty(this.Location))
            {
                yield return new BusinessRule("位置不能为空");
            }
            if (this.Purposes.Count == 0)
            {
                yield return new BusinessRule("宗地用途及出让年限不能为空");
            }
        }
    }
}
