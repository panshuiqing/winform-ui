using System.Web;
using System.Web.Mvc;

namespace Tlw.ZPG.AdminWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}