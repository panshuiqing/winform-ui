using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LogTools
{
    public partial class LogForm : SkinForm
    {
        public LogForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var url = "http://localhost:7259/Login.aspx";
            //var dataString = string.Format("__VIEWSTATE=%2FwEPDwUKMTMwOTMzNDM0NmQYAQUeX19Db250cm9sc1JlcXVpcmVQb3N0QmFja0tleV9fFgEFFUxvZ2luMSRjaGtTdG9yZUNvb2tpZU7A1wfUKmBniO2b9HZh%2B3dn5pG7h%2BuK%2FHvFNGHULiXr&__EVENTVALIDATION=%2FwEWBwKgpbVGAojs3tEGAv%2FWkYoIAtDZ5%2FsJAqXw4ZUHApzg45sIAvyK2LcKaNuHpTwkzCl09T5kuf%2BhgCPML5nPTL9sSR6YhdbF5AQ%3D&Login1%24txtLoginId=liubc&Login1%24txtPassword=liubc&Login1%24verifyCode%24txtInput=&Login1%24verifyCode%24txtCode=&Login1%24chkStoreCookie=on&Login1%24btnLogin=%B5%C7+%C2%BD");
            var dataString = "__VIEWSTATE=%2FwEPDwUKLTg0OTIzODQwNWRkrDSgvd5cTa%2FJkirzHFIr%2FZk5mpd7C06GtyDoL%2B%2FGzNE%3D&__EVENTVALIDATION=%2FwEdAAQawzyYJAEGcC70%2F27bwt4GozoJZpuXxkpOVJKRbHyuHnY2%2BMc6SrnAqio3oCKbxYbN%2BDvxnwFeFeJ9MIBWR693A%2FwQ5NQLOIDitrQxy%2Fn8RWGokKepU%2FvcZ4M7fDoieXY%3D&txtName=liubiaocai&txtPassword=123&Button1=Button";
            byte[] data = System.Text.Encoding.Default.GetBytes(dataString);
            var result = HttpRequestUtil.Post(url, data);
            string value = System.Text.Encoding.Default.GetString(result.Data);
        }
    }
}
