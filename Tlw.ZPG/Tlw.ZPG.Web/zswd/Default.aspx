<%@ Page Title="知识问答-福建省国有建设用地使用权出让网上交易系统" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tlw.ZPG.Web.zswd.Default" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/index.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <table width="769px" border="0" cellspacing="0" cellpadding="0" align="right">
        <tr>
            <td>
                <ul class="divNavigation">
                    <li class="left"></li>
                    <li class="title">知识问答</li>
                    <li class="right"></li>
                </ul>
                <table class="TableBody">
                    <tr>
                        <td class="leftTd" width="15%" style="text-align: center;">标题 或 内容
                        </td>
                        <td colspan="3">
                            <input type="text" name="key" id="key" style="width: 98%;" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" class="buttonTd">
                            <input type="image" onclick="window.location.href = '?key='+document.getElementById('key').value; return false;" class="button_align" src="../images/btn_search.gif" style="border-width: 0px;" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" class="line" style="height: 10px;"></td>
        </tr>
        <tr>
            <td valign="top">
                <table class="TableList" cellspacing="0" cellpadding="0" rules="all" border="1"
                    style="border-width: 1px; border-style: solid; width: 100%; border-collapse: collapse;">
                    <tr class="Header">
                        <td style="width: 35px;">
                            序号
                        </td>
                        <td>
                            标题
                        </td>
                        <td style="width: 100px;">
                            更新时间
                        </td>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%# pageNum + Container.ItemIndex + 1 %>
                                </td>
                                <td align="left">
                                    <a href='/Detail/?id=<%#Eval("Id") %>' target="_blank"><%#Eval("Title") %></a>
                                </td>
                                <td align="center">
                                    <%#Eval("CreateTime","{0:yyyy-MM-dd}") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="line-height: 24px;">
                <webdiyer:AspNetPager ID="AspNetPager1" PageSize="15" HorizontalAlign="Right" CssClass="paginator" CurrentPageButtonClass="current" UrlPaging="true" runat="server">
                </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>
</asp:Content>
