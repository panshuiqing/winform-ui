using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Tlw.ZPG.Web
{
    public class NewsPage : Page
    {
        public int pageNum = 0;
        protected System.Web.UI.WebControls.Repeater Repeater1;
        protected Wuqi.Webdiyer.AspNetPager AspNetPager1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            Tlw.ZPG.Services.Content.NewsService service = new Services.Content.NewsService();
            var pageSize = 15;
            var pageIndex = Utils.ToInt(Request["page"], 1);
            var keyword = Request["key"];
            var request = new Services.NewsRequest { Keyword = keyword, PageSize = pageSize, PageIndex = pageIndex, NewsType = NewsType };
            pageNum = (pageIndex - 1) * pageSize;
            Repeater1.DataSource = service.Find(request);
            Repeater1.DataBind();
            AspNetPager1.PageSize = 15;
            AspNetPager1.RecordCount = request.RowCount;
        }

        protected virtual Domain.Enums.NewsType NewsType
        {
            get
            {
                return Domain.Enums.NewsType.Info;
            }
        }
    }
}