using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tlw.ZPG.Web.zswd
{
    public partial class Default : NewsPage
    {
        protected override Domain.Enums.NewsType NewsType
        {
            get
            {
                return Domain.Enums.NewsType.QA;
            }
        }
    }
}