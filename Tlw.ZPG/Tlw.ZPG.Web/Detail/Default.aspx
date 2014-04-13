<%@ Page Title="{0}-福建省国有建设用地使用权出让网上交易系统" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tlw.ZPG.Web.Detail.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link type="text/css" href="../css/Index.css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <table width="769px" border="0" cellspacing="0" cellpadding="0" style="margin-top: 7px; margin-bottom: 5px;">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="background: #FFFFFF; height: 25px; font-size: 12px; background-image: url(../Resource/Css/style/ContentTitle.gif); background-repeat: no-repeat; background-position: left top; letter-spacing: 0px; word-spacing: 10px; font-weight: bold; text-align: left; vertical-align: middle; padding-left: 25px; color: black;"
                                        colspan="3"><%=newsType %>内容
                                    </td>
                                </tr>
                            </table>
                            <table style="background-color: #FFFFFF; border-left: #aeceea 1px solid; border-right: #aeceea 1px solid; border-bottom: #aeceea 1px solid;"
                                width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                            <tr>
                                                <td style="height: 30px; text-align: center; padding-top: 10px; font-weight: bold;">
                                                    <span id="_ctl0_ContentPlaceHolder1_txtTitle" style="color: Red; font-size: 16px; font-weight: bold;"><%=newsTitle %></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-weight: normal; font-size: 12px;" align="center">资讯类别：[&nbsp;<span><%=newsType %></span>&nbsp;]&nbsp;&nbsp;&nbsp;&nbsp;<span><%=createTime %></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; text-align: center; vertical-align: middle;">
                                                    <img style="width: 554px; height: 5px;" src="images/line_br.gif"
                                                        complete="complete" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 12px; text-align: left; line-height: 25px; padding-right: 15px; padding-left: 25px;">
                                                    <div>
                                                        <%=content %>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 30px;">
                                                    <br />
                                                    <div align="right">
                                                        <a href="javascript:window.print();"><font color="#ff0000">【打印】</font> </a><a href="javascript:window.close();">
                                                            <font color="#ff0000">【关闭】</font> </a>&nbsp;&nbsp;
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
