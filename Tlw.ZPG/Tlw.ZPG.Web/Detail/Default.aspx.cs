using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tlw.ZPG.Web.Detail
{
    public partial class Default : System.Web.UI.Page
    {
        public string newsTitle;
        public string newsType;
        public string createTime;
        public string content;

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = int.Parse(Request["id"]);
            Tlw.ZPG.Services.Content.NewsService service = new Services.Content.NewsService();
            var news = service.FindById(id);
            newsTitle = news.Title;
            content = news.Content;
            createTime = news.CreateTime.ToString("yyyy-MM-dd");
            newsType = Tlw.ZPG.Infrastructure.Utils.EnumUtil.GetDescription(news.NewsType);
            this.Title = string.Format(newsType,this.Title);
        }
    }
}