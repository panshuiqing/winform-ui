using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Teleware.ZPG.Client.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "liubiaocai" && txtPassword.Text == "123")
            {
                HttpCookie cookie = new HttpCookie("success","1");
                this.Response.Cookies.Add(cookie);
                Response.Write("success");
            }
        }
    }
}