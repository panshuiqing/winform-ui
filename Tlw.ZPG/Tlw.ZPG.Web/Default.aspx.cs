using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tlw.ZPG.Services.Trading;

namespace Tlw.ZPG.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            BindAffiche();
            BindPrice();
            BindResult();
            BindNews();
        }

        private void BindNews()
        {
            var list_news = new Tlw.ZPG.Services.Content.NewsService().Find(new Services.PageRequest() { PageSize = 5 });
            this.Repeater_zcfg.DataSource = list_news;
            this.Repeater_zcfg.DataBind();
        }

        private void BindResult()
        {
            var list_result = new TradeResultService().FindNewList();
            this.Repeater_result.DataSource = list_result;
            this.Repeater_result.DataBind();
        }

        private void BindPrice()
        {
            var list_price = new TradeService().FindNewDetails(20);
            this.Repeater_price.DataSource = list_price;
            this.Repeater_price.DataBind();
        }

        private void BindAffiche()
        {
            AfficheService afficheService = new AfficheService();
            var list_all = afficheService.Find(new AfficheRequest() { PageSize = 6 });
            this.Repeater_all.DataSource = list_all;
            this.Repeater_all.DataBind();
            var list_szyd = afficheService.Find(new AfficheRequest() { Tag = "商住用地", PageSize = 6 });
            this.Repeater_szyd.DataSource = list_szyd;
            this.Repeater_szyd.DataBind();
            var list_gyyd = afficheService.Find(new AfficheRequest() { Tag = "工业用地", PageSize = 6 });
            this.Repeater_gyyd.DataSource = list_szyd;
            this.Repeater_gyyd.DataBind();
            var list_other = afficheService.Find(new AfficheRequest() { Tag = "其他用地", PageSize = 6 });
            this.Repeater_other.DataSource = list_szyd;
            this.Repeater_other.DataBind();

            var list_pic = list_all.Take(4);
            this.Repeater_pic.DataSource = list_pic;
            this.Repeater_pic.DataBind();
        }
    }
}