namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Land
    {
        public Land()
        {
            this.LandAttaches = new HashSet<LandAttach>();
            this.Purposes = new HashSet<Purpose>();
        }
    
        public int LandId { get; set; }
        public int CountyId { get; set; }
        public int CretorId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string ProjectName { get; set; }
        public string LandNumber { get; set; }
        public string Location { get; set; }
        public decimal Area { get; set; }
        public string LandPurpose { get; set; }
        public int LandState { get; set; }
        public string Phones { get; set; }
        public string Notice { get; set; }
        public string Remark { get; set; }
        public string OtherCondition { get; set; }
        public decimal Capability { get; set; }
        public decimal Density { get; set; }
        public decimal GreenLandRate { get; set; }
        public decimal FulfilGuarantee { get; set; }
        public decimal CompletionGuarantee { get; set; }
        public string LandScope { get; set; }
    
        public virtual County County { get; set; }
        public virtual ICollection<LandAttach> LandAttaches { get; set; }
        public virtual ICollection<Purpose> Purposes { get; set; }
    }
}
