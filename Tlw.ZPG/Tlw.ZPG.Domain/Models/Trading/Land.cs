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
            this.LandPurposes = new HashSet<LandPurpose>();
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
        public string LandPurpose { get; private set; }
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
        public virtual ICollection<LandPurpose> LandPurposes { get; internal set; }
        #endregion

        /// <summary>
        /// 把LandPurposes集合转化为字符串保存
        /// </summary>
        public void SetLandPurpose()
        {
            LandPurpose=string.Empty;
            foreach (var item in LandPurposes)
            {
                LandPurpose += string.Format("{0}：面积：{1}平方米、出让年限：{2}年;",item.Purpose.PurposeName,item.Area,item.Years);
            }
        }
    }
}
