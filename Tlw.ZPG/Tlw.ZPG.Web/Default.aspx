<%@ Page Title="主页" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tlw.ZPG.Web._Default" %>

<%@ Register src="Controls/TopControl.ascx" tagname="TopControl" tagprefix="uc1" %>
<%@ Register src="Controls/FootterControl.ascx" tagname="FootterControl" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>福建省国有建设用地使用权出让网上交易系统</title>
    <style type="text/css">
        #glowtext {
            filter: glow(color=red,strength=2);
            width: 100%;
        }
    </style>
    <link href="css/tabStrip.css" rel="Stylesheet" type="text/css" />
    <link href="css/Index.css" type="text/css"rel="Stylesheet" />
    <script src="js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="js/TabStrip.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" action="/">
        <div class="divAll" style="text-align: left">
           <uc1:TopControl ID="TopControl1" runat="server" />
            <table style="margin: 6px 0px; width: 1000px" class="tableInfo" border="0" cellspacing="0"
                cellpadding="0" align="left">
                <tbody>
                    <tr>
                        <td>
                            <table border="0" cellspacing="0" cellpadding="0">
                                <tbody>
                                    <tr>
                                        <td class="left" width="185px">
                                            <table border="0" cellspacing="0" cellpadding="0" width="224" height="237">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <img border="0" src="images/Lm_bg.jpg" width="224" height="237" usemap="#Map">
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <map name="Map" id="Map">
                                                <area shape="rect" coords="42,12,194,45" href="affiche/" />
                                                <area shape="rect" coords="42,57,194,89" href="tdcrjg/" />
                                                <area shape="rect" coords="45,101,216,132" href="tdcrjg/?type=1" />
                                                <area shape="rect" coords="45,148,213,178" href="/jmsqcx/" target="_blank" />
                                                <area shape="rect" coords="44,194,180,224" href="cjwt/" />
                                            </map>
                                        </td>
                                        <td class="right" width="814px">
                                            <table border="0" cellspacing="0" width="780" align="center">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <div style="width: 100%" id="TabStrip1" class="TopGroup">
                                                                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <table id="TabStrip" border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <table style="padding-left: 0px; padding-right: 0px" class="DefaultTab" pageview="PageView1"
                                                                                                    border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="padding-bottom: 0px; padding-left: 0px; padding-right: 0px; padding-top: 0px"
                                                                                                                width="7">
                                                                                                                <img border="0" alt="" src="images/tabStrip/tab_left_icon.gif" width="7" height="29">
                                                                                                            </td>
                                                                                                            <td style="padding-bottom: 4px; padding-left: 10px; padding-right: 10px; padding-top: 5px"
                                                                                                                align="left">
                                                                                                                <nobr>各类用途土地挂牌出让公告（全部）</nobr>
                                                                                                            </td>
                                                                                                            <td style="padding-bottom: 0px; padding-left: 0px; padding-right: 0px; padding-top: 0px"
                                                                                                                width="7">
                                                                                                                <img border="0" alt="" src="images/tabStrip/tab_right_icon.gif" width="7" height="29">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </td>
                                                                                            <td>
                                                                                                <table style="padding-left: 0px; padding-right: 0px" pageview="PageView2" class="DefaultTab"
                                                                                                    border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="padding-bottom: 0px; padding-left: 0px; padding-right: 0px; padding-top: 0px"
                                                                                                                width="7">
                                                                                                                <img border="0" alt="" src="images/tabStrip/tab_left_icon.gif" width="7" height="29">
                                                                                                            </td>
                                                                                                            <td style="padding-bottom: 4px; padding-left: 10px; padding-right: 10px; padding-top: 5px"
                                                                                                                align="left">
                                                                                                                <nobr>商住用地挂牌出让公告</nobr>
                                                                                                            </td>
                                                                                                            <td style="padding-bottom: 0px; padding-left: 0px; padding-right: 0px; padding-top: 0px"
                                                                                                                width="7">
                                                                                                                <img border="0" alt="" src="images/tabStrip/tab_right_icon.gif" width="7" height="29">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </td>
                                                                                            <td>
                                                                                                <table style="padding-left: 0px; padding-right: 0px" pageview="PageView3" class="DefaultTab"
                                                                                                    border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="padding-bottom: 0px; padding-left: 0px; padding-right: 0px; padding-top: 0px"
                                                                                                                width="7">
                                                                                                                <img border="0" alt="" src="images/tabStrip/tab_left_icon.gif" width="7" height="29">
                                                                                                            </td>
                                                                                                            <td style="padding-bottom: 4px; padding-left: 10px; padding-right: 10px; padding-top: 5px"
                                                                                                                align="left">
                                                                                                                <nobr>工业用地挂牌出让公告</nobr>
                                                                                                            </td>
                                                                                                            <td style="padding-bottom: 0px; padding-left: 0px; padding-right: 0px; padding-top: 0px"
                                                                                                                width="7">
                                                                                                                <img border="0" alt="" src="images/tabStrip/tab_right_icon.gif" width="7" height="29">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </td>
                                                                                            <td>
                                                                                                <table style="padding-left: 0px; padding-right: 0px" pageview="PageView4" class="SelectedTab"
                                                                                                    border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" tabstate="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="padding-bottom: 0px; padding-left: 0px; padding-right: 0px; padding-top: 0px"
                                                                                                                width="7">
                                                                                                                <img border="0" alt="" src="images/tabStrip/selected_tab_left_icon.gif" width="7"
                                                                                                                    height="29">
                                                                                                            </td>
                                                                                                            <td style="padding-bottom: 4px; padding-left: 10px; padding-right: 10px; padding-top: 4px"
                                                                                                                align="left">
                                                                                                                <nobr>其它用地挂牌出让公告</nobr>
                                                                                                            </td>
                                                                                                            <td style="padding-bottom: 0px; padding-left: 0px; padding-right: 0px; padding-top: 0px"
                                                                                                                width="7">
                                                                                                                <img border="0" alt="" src="images/tabStrip/selected_tab_right_icon.gif" width="7"
                                                                                                                    height="29">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </td>
                                                                                            <td width="100%"></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                            <table id="MultiPage1" class="MultiPage" cellspacing="0" cellpadding="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 100%; height: 100%; vertical-align: top">
                                                                            <table style="width: 100%; display: none; height: 100%" id="PageView1" border="0"
                                                                                cellspacing="0" cellpadding="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="vertical-align: top">
                                                                                            <table class="TableList">
                                                                                                <tbody>
                                                                                                    <tr class="Header">
                                                                                                        <td style="width: 100px">
                                                                                                            <b>公告名称</b>
                                                                                                        </td>
                                                                                                        <td style="width: 100px">
                                                                                                            <b>所在区域</b>
                                                                                                        </td>
                                                                                                        <td style="width: 100px">
                                                                                                            <b>报名截止时间</b>
                                                                                                        </td>
                                                                                                        <td style="width: 120px">
                                                                                                            <b>挂牌交易截止时间</b>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <asp:Repeater ID="Repeater_all" runat="server">
                                                                                                        <ItemTemplate>
                                                                                                            <tr title="<%#Eval("Title") %>" class="<%#(Container.ItemIndex+2) % 2 == 0 ? "rowColor" : ""  %>">
                                                                                                                <td class="C1AItem2" nowrap>· <a href="Affiche/Detail.aspx?id=<%#Eval("ID") %>"><%#Eval("Title") %></a>
                                                                                                                </td>
                                                                                                                <td class="gridItem" align="middle">
                                                                                                                    <%#Eval("County.FullName") %>
                                                                                                                </td>
                                                                                                                <td class="gridItem" align="middle">
                                                                                                                    <font color="red"><strong><%#Eval("SignEndTime","{0:yyyy:MM:dd}") %></strong></font>
                                                                                                                </td>
                                                                                                                <td class="gridItem" align="middle">
                                                                                                                    <font color="blue"><strong><%#Eval("TradeEndTime","{0:yyyy:MM:dd}") %></strong></font>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:Repeater>
                                                                                                    <tr>
                                                                                                        <td style="text-align: right; background-color: white; height: 16px" class="gridItem"
                                                                                                            colspan="4">
                                                                                                            <a href="Affiche/">更多...</a>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                            <table style="width: 100%; display: none; height: 100%" id="PageView2" border="0"
                                                                                cellspacing="0" cellpadding="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="vertical-align: top">
                                                                                            <table class="TableList">
                                                                                                <tbody>
                                                                                                    <tr class="Header">
                                                                                                        <td class="gridItem">
                                                                                                            <b>公告名称</b>
                                                                                                        </td>
                                                                                                        <td class="gridItem">
                                                                                                            <b>所在区域</b>
                                                                                                        </td>
                                                                                                        <td class="gridItem">
                                                                                                            <b>报名截止时间</b>
                                                                                                        </td>
                                                                                                        <td class="gridItem">
                                                                                                            <b>挂牌交易截止时间</b>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                     <asp:Repeater ID="Repeater_szyd" runat="server">
                                                                                                        <ItemTemplate>
                                                                                                            <tr title="<%#Eval("Title") %>" class="<%#(Container.ItemIndex+2) % 2 == 0 ? "rowColor" : ""  %>">
                                                                                                                <td class="C1AItem2" nowrap>· <a href="Affiche/Detail.aspx?id=<%#Eval("ID") %>"><%#Eval("Title") %></a>
                                                                                                                </td>
                                                                                                                <td class="gridItem" align="middle">
                                                                                                                    <%#Eval("County.FullName") %>
                                                                                                                </td>
                                                                                                                <td class="gridItem" align="middle">
                                                                                                                    <font color="red"><strong><%#Eval("SignEndTime","{0:yyyy:MM:dd}") %></strong></font>
                                                                                                                </td>
                                                                                                                <td class="gridItem" align="middle">
                                                                                                                    <font color="blue"><strong><%#Eval("TradeEndTime","{0:yyyy:MM:dd}") %></strong></font>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:Repeater>
                                                                                                    <tr>
                                                                                                        <td style="text-align: right; background-color: white; height: 16px" class="gridItem"
                                                                                                            colspan="4">
                                                                                                            <a href="Afiche/?tag=商住用地">更多...</a>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                            <table style="width: 100%; display: none; height: 100%" id="PageView3" border="0"
                                                                                cellspacing="0" cellpadding="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="vertical-align: top">
                                                                                            <table class="TableList" border="0" cellspacing="0" cellpadding="0" width="100%">
                                                                                                <tbody>
                                                                                                    <tr class="Header">
                                                                                                        <td class="gridItem" height="206">
                                                                                                            <b>公告名称</b>
                                                                                                        </td>
                                                                                                        <td class="gridItem">
                                                                                                            <b>所在区域</b>
                                                                                                        </td>
                                                                                                        <td class="gridItem">
                                                                                                            <b>报名截止时间</b>
                                                                                                        </td>
                                                                                                        <td class="gridItem">
                                                                                                            <b>挂牌交易截止时间</b>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <asp:Repeater ID="Repeater_gyyd" runat="server">
                                                                                                        <ItemTemplate>
                                                                                                            <tr title="<%#Eval("Title") %>" class="<%#(Container.ItemIndex+2) % 2 == 0 ? "rowColor" : ""  %>">
                                                                                                                <td class="C1AItem2" nowrap>· <a href="Affiche/Detail.aspx?id=<%#Eval("ID") %>"><%#Eval("Title") %></a>
                                                                                                                </td>
                                                                                                                <td class="gridItem" align="middle">
                                                                                                                    <%#Eval("County.FullName") %>
                                                                                                                </td>
                                                                                                                <td class="gridItem" align="middle">
                                                                                                                    <font color="red"><strong><%#Eval("SignEndTime","{0:yyyy:MM:dd}") %></strong></font>
                                                                                                                </td>
                                                                                                                <td class="gridItem" align="middle">
                                                                                                                    <font color="blue"><strong><%#Eval("TradeEndTime","{0:yyyy:MM:dd}") %></strong></font>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:Repeater>
                                                                                                    <tr>
                                                                                                        <td style="text-align: right; background-color: white; height: 16px" class="gridItem"
                                                                                                            colspan="4">
                                                                                                            <a href="Affiche/tag=工业用地">更多...</a>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                            <table style="width: 100%; height: 100%" id="PageView4" border="0" cellspacing="0"
                                                                                cellpadding="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="vertical-align: top">
                                                                                            <table class="TableList" border="0" cellspacing="0" cellpadding="0" width="100%">
                                                                                                <tbody>
                                                                                                    <tr class="Header">
                                                                                                        <td class="gridItem">
                                                                                                            <b>公告名称</b>
                                                                                                        </td>
                                                                                                        <td class="gridItem">
                                                                                                            <b>所在区域</b>
                                                                                                        </td>
                                                                                                        <td class="gridItem">
                                                                                                            <b>报名截止时间</b>
                                                                                                        </td>
                                                                                                        <td class="gridItem">
                                                                                                            <b>挂牌交易截止时间</b>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <asp:Repeater ID="Repeater_other" runat="server">
                                                                                                        <ItemTemplate>
                                                                                                            <tr title="<%#Eval("Title") %>">
                                                                                                                <td class="C1AItem2" nowrap>· <a href="Affiche/Detail.aspx?id=<%#Eval("ID") %>"><%#Eval("Title") %></a>
                                                                                                                </td>
                                                                                                                <td class="gridItem" align="middle">
                                                                                                                    <%#Eval("County.FullName") %>
                                                                                                                </td>
                                                                                                                <td class="gridItem" align="middle">
                                                                                                                    <font color="red"><strong><%#Eval("SignEndTime","{0:yyyy:MM:dd}") %></strong></font>
                                                                                                                </td>
                                                                                                                <td class="gridItem" align="middle">
                                                                                                                    <font color="blue"><strong><%#Eval("TradeEndTime","{0:yyyy:MM:dd}") %></strong></font>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:Repeater>
                                                                                                    <tr>
                                                                                                        <td style="text-align: right; background-color: white; height: 16px" class="gridItem"
                                                                                                            colspan="4">
                                                                                                            <a href="Affiche/?tag=其他用地">更多...</a>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            <table border="0" cellspacing="0" cellpadding="0" width="1000">
                                <tbody>
                                    <tr>
                                        <td width="775" align="middle">
                                            <ul class="gpcr">
                                                <asp:Repeater ID="Repeater_pic" runat="server">
                                                    <ItemTemplate>
                                                        <li style="background: url(./images/city/福州.jpg) no-repeat right top" class="<%#Container.ItemIndex == 0 ? "first" : ""  %>">
                                                            <a style="text-decoration: none" title="点击查看详情...." href="Affiche/Detail.aspx?id=<%#Eval("ID") %>">
                                                                <span style="font-size: 14px" id="gpcrtime0"><%#Eval("SignBeginTime","{0:yy年MM月dd日}") %>至<%#Eval("SignEndTime","{0:yy年MM月dd日}") %></span><span
                                                                    class="city"><%#Eval("County.FullName") %><img style="border-bottom: medium none; border-left: medium none; border-top: medium none; border-right: medium none"
                                                                        src="./images/new.gif"></span><span
                                                                            class="info">挂牌出让<%#Eval("Trades.Count") %>宗国有土地使用权</span></a></li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </td>
                                        <td style="padding-top: 6px" align="right">
                                            <div class="LM">
                                                <table style="vertical-align: middle" border="0" cellspacing="0" cellpadding="0"
                                                    width="225" height="85">
                                                    <tbody>
                                                        <tr>
                                                            <td width="2"></td>
                                                            <td width="100" align="right">
                                                                <a href="zxly/"><span style="position: relative; font-size: 14px; top: 20px">&nbsp;在线留言</span></a>
                                                            </td>
                                                            <td width="2"></td>
                                                            <td width="110" align="middle">
                                                                <a href="download/"><span style="position: relative; font-size: 14px; top: 20px">&nbsp;&nbsp;&nbsp;&nbsp;竞买软件</span></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="2"></td>
                                                            <td width="100" align="right">
                                                                <a href="zxwd/"><span style="position: relative; font-size: 14px; top: 22px">&nbsp;知识问答</span></a>
                                                            </td>
                                                            <td width="2"></td>
                                                            <td width="110" align="middle">
                                                                <a href="zcfg/"><span style="position: relative; font-size: 14px; top: 22px">&nbsp;&nbsp;&nbsp;&nbsp;政策法规</span></a>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            <table border="0" cellspacing="0" cellpadding="0" width="1000px">
                                <tbody>
                                    <tr>
                                        <td width="765px">
                                            <div style="margin: 0px; width: 762px; float: none" class="divList">
                                                <div style="width: 762px" class="Header">
                                                    <div class="left">
                                                        <div class="write">
                                                            <a style="text-decoration: none" href="PublicSysMsg/TradeInfoQueryView.aspx" target="_self">
                                                                <span style="font-size: 14px">最新报价</span></a>
                                                        </div>
                                                    </div>
                                                    <div class="right">
                                                    </div>
                                                    <div class="more">
                                                        <a style="text-decoration: none" href="PublicSysMsg/TradeInfoQueryView.aspx" target="_self">更多...</a>
                                                    </div>
                                                </div>
                                                <table style="width: 762px; table-layout: fixed" class="TableList" border="0" cellspacing="0"
                                                    cellpadding="0">
                                                    <tbody>
                                                        <tr class="Header">
                                                            <td style="width: 210px;">宗地号
                                                            </td>
                                                            <td>所在区域
                                                            </td>
                                                            <td style="width: 180px">土地用途及出让年限
                                                            </td>
                                                            <td style="width: 102px">最高价
                                                            </td>
                                                            <td style="width: 140px">出价时间
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <marquee scrollamount="1" direction="up" id="Marqid" height="152" onmouseover="this.stop(); " onmouseout="this.start();">
                                                    <table style="width: 762px; table-layout: fixed" id="NewPriceList" class="TableList"
                                                    border="0" cellspacing="0" cellpadding="0">
                                                    <tbody>
                                                    <asp:Repeater ID="Repeater_price" runat="server">
                                                        <ItemTemplate>
                                                            <tr style="background-color: #f0f7fd">
                                                                <td style="width: 210px; white-space: nowrap; overflow: hidden" title="<%#Eval("Trade.Land.LandNumber") %>">
                                                                    <a href=""><%#Eval("Trade.Land.LandNumber") %></a>
                                                                </td>
                                                                <td><%#Eval("Trade.County.FullName") %>
                                                                </td>
                                                                <td style="width: 180px; white-space: nowrap; overflow: hidden" title="<%#Eval("Trade.Land.LandPurposeShort") %>">
                                                                    <%#Eval("Trade.Land.LandPurposeShort") %>
                                                                </td>
                                                                <td style="width: 102px;">￥<%#Eval("Price","{0:0.0}") %>万
                                                                </td>
                                                                <td style="width: 140px;"><%#Eval("CreateTime","{0:yyyy-MM-dd HH:mm:ss}") %>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    </tbody>
                                                </table>
                                                </marquee>
                                            </div>
                                        </td>
                                        <td style="text-align: right" width="235">
                                            <div class="jmrczbz">
                                                <ul>
                                                    <li><a href="demo/zc.html" target="_blank"><span style="font-size: 14px">注册演示</span></a></li>
                                                    <li><a href="demo/gpjy.html" target="_blank"><span style="font-size: 14px">挂牌交易演示</span></a></li>
                                                    <li><a href="demo/wspm.html" target="_blank"><span style="font-size: 14px">网上拍卖演示</span></a></li>
                                                    <li class="wu"><a href="download/竞买人操作手册.doc" target="_blank"><span
                                                        style="font-size: 14px">竞买人操作手册下载</span></a></li>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            <table border="0" cellspacing="0" cellpadding="0" width="1000">
                                <tbody>
                                    <tr>
                                        <td height="7"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img style="filter: blendTrans(duration=crossFadeDuration)" name="SlideShow" hspace="0"
                                                alt="" vspace="0" src="images/flash01.gif" width="1000" height="159">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="4"></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="2" align="left">
                            <table border="0" cellspacing="0" cellpadding="0" width="1000">
                                <tbody>
                                    <tr>
                                        <td style="float: left" valign="top" align="left">
                                            <table style="text-align: left; border-collapse: collapse; vertical-align: top" border="0"
                                                cellspacing="0" cellpadding="0">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <div style="margin: 0px; float: left" class="divList">
                                                                <div style="width: 720px" class="Header">
                                                                    <div class="left">
                                                                        <div class="write">
                                                                            <a style="text-decoration: none" href="PublicSysMsg/TradeResultListView.aspx"><span
                                                                                style="font-size: 14px">交易结果公示</span></a>
                                                                        </div>
                                                                    </div>
                                                                    <div class="right">
                                                                    </div>
                                                                    <div class="more">
                                                                        <a style="text-decoration: none" href="PublicSysMsg/TradeResultListView.aspx" target="_self">更多...</a>
                                                                    </div>
                                                                </div>
                                                                <table style="position: relative; width: 720px; border-collapse: collapse; top: -1px"
                                                                    id="dgrdList" class="TableList" border="1" rules="all" cellspacing="0" cellpadding="0">
                                                                    <tbody>
                                                                        <tr class="Header">
                                                                            <td style="width: 40px" nowrap>序号
                                                                            </td>
                                                                            <td style="width: 273px" nowrap>宗地号
                                                                            </td>
                                                                            <td style="width: 100px" nowrap align="middle">面积(平方米)
                                                                            </td>
                                                                            <td style="width: 100px" nowrap align="middle">成交价(万元)
                                                                            </td>
                                                                            <td style="width: 100px" nowrap align="middle">竞得人
                                                                            </td>
                                                                            <td style="width: 100px" nowrap align="middle">成交时间
                                                                            </td>
                                                                        </tr>
                                                                        <asp:Repeater ID="Repeater_result" runat="server">
                                                                            <ItemTemplate>
                                                                                <tr class="field_gridItem">
                                                                                    <td align="middle">
                                                                                        <%#Container.ItemIndex + 1 %>
                                                                                    </td>
                                                                                    <td class="field_gridCell" title="<%#Eval("LandNumber") %>" align="middle">
                                                                                        <a style="text-decoration: none" href="TradeResult/Detail.aspx?id=<%#Eval("ID") %>">福州鼓楼区-tesa</a>
                                                                                    </td>
                                                                                    <td class="field_gridCell" align="middle"><%#Eval("LandArea","{0:0.00}") %>
                                                                                    </td>
                                                                                    <td class="field_gridCell" align="middle"><%#Eval("DealPrice","{0:0.00}") %>
                                                                                    </td>
                                                                                    <td class="field_gridCell" align="middle"><%#Eval("DealUser") %>
                                                                                    </td>
                                                                                    <td align="middle"><%#Eval("DealTime","{0:yyyy-MM-dd}") %>
                                                                                    </td>
                                                                                </tr>
                                                                            </ItemTemplate>
                                                                        </asp:Repeater>
                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td valign="top" width="273" align="right">
                                            <div style="text-align: right; vertical-align: top">
                                                <table border="0" cellspacing="0" cellpadding="0" width="275">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <div class="Transaction">
                                                                    <div class="policy_contact">
                                                                        <div class="bg">
                                                                            <div class="left">
                                                                                <div class="write">
                                                                                    政策法规
                                                                                </div>
                                                                            </div>
                                                                            <div class="right">
                                                                            </div>
                                                                        </div>
                                                                        <table style="border-bottom: #c4d1dd 1px solid; border-left: #c4d1dd 1px solid; width: 272px; height: 137px; border-top: #c4d1dd 1px solid; border-right: #c4d1dd 1px solid"
                                                                            cellspacing="0" cellpadding="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td height="6"></td>
                                                                                </tr>
                                                                                <asp:Repeater ID="Repeater_zcfg" runat="server">
                                                                                    <ItemTemplate>
                                                                                        <tr>
                                                                                            <td style="text-align: left; padding-left: 8px">
                                                                                                <a style="text-decoration: none" href="News/Detail.aspx?id=<%#Eval("ID") %>">
                                                                                                    <span style="width: 200px; text-overflow: ellipsis; display: block; white-space: nowrap; overflow: hidden">·<%#Eval("Title") %></span> </a>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="9">
                                                                <div style="white-space: nowrap; font-size: 1px">
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div class="Transaction">
                                                                    <div class="policy_contact">
                                                                        <div class="bg">
                                                                            <div class="left">
                                                                                <div class="write">
                                                                                    行政区域
                                                                                </div>
                                                                            </div>
                                                                            <div class="right">
                                                                            </div>
                                                                        </div>
                                                                        <table style="border-bottom: #c4d1dd 1px solid; border-left: #c4d1dd 1px solid; width: 272px; height: 107px; border-top: #c4d1dd 1px solid; border-right: #c4d1dd 1px solid"
                                                                            cellspacing="0" cellpadding="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td height="92">
                                                                                        <div style="text-align: center; padding-left: 6px; width: 260px; padding-top: 6px">
                                                                                            <a class="address" href="PublicSysMsg/TradeAffiche.aspx?BigCountyId=2">福州市</a> <a
                                                                                                class="address" href="PublicSysMsg/TradeAffiche.aspx?BigCountyId=3">厦门市</a>
                                                                                            <a class="address" href="PublicSysMsg/TradeAffiche.aspx?BigCountyId=4">莆田市</a> <a
                                                                                                class="address" href="PublicSysMsg/TradeAffiche.aspx?BigCountyId=10">三明市</a>
                                                                                            <a class="address" href="PublicSysMsg/TradeAffiche.aspx?BigCountyId=5">泉州市</a> <a
                                                                                                class="address" href="PublicSysMsg/TradeAffiche.aspx?BigCountyId=6">漳州市</a>
                                                                                            <a class="address" href="PublicSysMsg/TradeAffiche.aspx?BigCountyId=7">南平市</a> <a
                                                                                                class="address" href="PublicSysMsg/TradeAffiche.aspx?BigCountyId=8">龙岩市</a>
                                                                                            <a class="address" href="PublicSysMsg/TradeAffiche.aspx?BigCountyId=9">宁德市</a>
                                                                                        </div>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            <div style="margin: 3px 0px; width: 1000px; height: 100%; overflow: hidden" id="demo44"
                                align="center">
                                <table border="0" cellpadding="0" align="left" cellspace="0">
                                    <tbody>
                                        <tr>
                                            <td id="demo441" valign="top">
                                                <table border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tbody>
                                                        <tr>
                                                            <td align="middle">
                                                                <a href="http://www.mlr.gov.cn/ " target="_blank">
                                                                    <img border="0" src="images/Links/2.jpg" width="161" height="51"></a>
                                                            </td>
                                                            <td align="middle">
                                                                <a href="http://www.fjgtzy.gov.cn/" target="_blank">
                                                                    <img border="0" src="images/Links/3.jpg" width="161" height="51"></a>
                                                            </td>
                                                            <td align="middle">
                                                                <a href="http://www.fjland.cn/" target="_blank">
                                                                    <img border="0" src="images/Links/4.jpg" width="161" height="51"></a>
                                                            </td>
                                                            <td align="middle">
                                                                <a href="http://www.landchina.com/" target="_blank">
                                                                    <img border="0" src="images/Links/5.jpg" width="161" height="51"></a>
                                                            </td>
                                                            <td align="middle">
                                                                <a href="http://www.chinazcpg.com/" target="_blank">
                                                                    <img border="0" src="images/Links/yqlj_bottom5.gif" width="161" height="51"></a>
                                                            </td>
                                                            <td align="right">
                                                                <a href="http://www.fujian.gov.cn/" target="_blank">
                                                                    <img border="0" src="images/Links/1.jpg" width="161" height="51"></a>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td id="demo442" valign="top">
                                                <table border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tbody>
                                                        <tr>
                                                            <td align="middle">
                                                                <a href="http://www.mlr.gov.cn/ " target="_blank">
                                                                    <img border="0" src="images/Links/2.jpg" width="161" height="51"></a>
                                                            </td>
                                                            <td align="middle">
                                                                <a href="http://www.fjgtzy.gov.cn/" target="_blank">
                                                                    <img border="0" src="images/Links/3.jpg" width="161" height="51"></a>
                                                            </td>
                                                            <td align="middle">
                                                                <a href="http://www.fjland.cn/" target="_blank">
                                                                    <img border="0" src="images/Links/4.jpg" width="161" height="51"></a>
                                                            </td>
                                                            <td align="middle">
                                                                <a href="http://www.landchina.com/" target="_blank">
                                                                    <img border="0" src="images/Links/5.jpg" width="161" height="51"></a>
                                                            </td>
                                                            <td align="middle">
                                                                <a href="http://www.chinazcpg.com/" target="_blank">
                                                                    <img border="0" src="images/Links/yqlj_bottom5.gif" width="161" height="51"></a>
                                                            </td>
                                                            <td align="right">
                                                                <a href="http://www.fujian.gov.cn/" target="_blank">
                                                                    <img border="0" src="images/Links/1.jpg" width="161" height="51"></a>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            <div style="text-align: center; width: 1000px; clear: both">
                                <uc2:FootterControl ID="FootterControl1" runat="server" />
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            
        </div>
    </form>
</body>
</html>