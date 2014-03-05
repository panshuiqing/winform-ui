namespace Tlw.ZPG.Domain.Models.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// ÕË»§×´Ì¬
    /// </summary>
    public enum AccountStatus
    {
        /// <summary>
        /// Î´ÉóºË
        /// </summary>
        [Description("Î´ÉóºË")]
        UnVerified,
        /// <summary>
        /// Õý³£
        /// </summary>
        [Description("Õý³£")]
        Normal,
        /// <summary>
        /// ¹ÒÊ§
        /// </summary>
        [Description("¹ÒÊ§")]
        Loss,
        /// <summary>
        /// ¶³½á
        /// </summary>
        [Description("¶³½á")]
        Froze
    }
}
