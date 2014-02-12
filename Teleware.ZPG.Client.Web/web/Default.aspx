<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Teleware.ZPG.Client.Web.web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>福建省国有建设用地使用权出让网上交易系统 </title>
    <style type="text/css">
        #glowtext
        {
            filter: glow(color=red,strength=2);
            width: 100%;
        }
    </style>
    <link href="css/NewTabStyle.css" rel="Stylesheet" type="text/css" />
    <link type="text/css" href="css/Index.css" rel="Stylesheet" />
    <script src="js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        //选项卡js
        $(document).ready(function () {
            $('#TabStrip table').hover(function () {
                if (!$(this).hasClass('SelectedTab')) {
                    $(this).removeClass('DefaultTab').addClass('DefaultTabHover');
                    $('td:first img', this).attr('src', '/css/NewTabImages/hover_tab_left_icon.gif');
                    $('td:last img', this).attr('src', '/css/NewTabImages/hover_tab_right_icon.gif');
                }
            }, function () {
                if (!$(this).hasClass('SelectedTab')) {
                    $(this).removeClass('DefaultTabHover').addClass('DefaultTab');
                    $('td:first img', this).attr('src', '/css/NewTabImages/tab_left_icon.gif');
                    $('td:last img', this).attr('src', '/css/NewTabImages/tab_right_icon.gif');
                }
            }).click(function () {
                if (!$(this).hasClass('SelectedTab')) {
                    var selectedTab = $('table.SelectedTab');
                    $('td:first img', selectedTab).attr('src', '/css/NewTabImages/tab_left_icon.gif');
                    $('td:last img', selectedTab).attr('src', '/css/NewTabImages/tab_right_icon.gif');
                    $('table.SelectedTab').removeClass('SelectedTab').addClass('DefaultTab');
                    $(this).removeClass('DefaultTabHover').addClass('SelectedTab');
                    $('td:first img', this).attr('src', '/css/NewTabImages/selected_tab_left_icon.gif');
                    $('td:last img', this).attr('src', '/css/NewTabImages/selected_tab_right_icon.gif');
                    $('.MultiPage table').hide();
                    var id = $(this).attr('pageView');
                    $('.MultiPage #' + id).show();
                    $('.MultiPage #' + id + ' table').show();
                }
            });

            $('#NewPriceList').fadeOut(1500);
            $('#NewPriceList').fadeIn(1500);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="divAll" style="text-align: left">
        <div class="divLogo">
        </div>
        <div class="divMenu">
            <div class="left">
                <ul class="right">
                    <li><a id="http://localhost:7905/Tlw.ZPG.PublicWeb/Index.aspx" href="http://localhost:7905/Tlw.ZPG.PublicWeb/Index.aspx"
                        title="首 页">首 页 </a></li>
                    <li class='line'></li>
                    <li><a id="http://localhost:7905/Tlw.ZPG.PublicWeb/Index.aspx" href="http://localhost:7905/Tlw.ZPG.PublicWeb/PublicSysMsg/TradeRule.aspx"
                        title="交易规则" target="_blank">交易规则 </a></li>
                    <li class='line'></li>
                    <li><a id="http://localhost:7905/Tlw.ZPG.PublicWeb/Index.aspx" href="http://localhost:7905/Tlw.ZPG.PublicWeb/PublicSysMsg/TradeFlow.aspx"
                        title="交易流程" target="_blank">交易流程 </a></li>
                    <li class='line'></li>
                    <li><a id="http://localhost:7905/Tlw.ZPG.PublicWeb/Index.aspx" href="http://localhost:7905/Tlw.ZPG.PublicWeb/PublicSysMsg/ApplyInstruction.aspx"
                        title="竞买申请" target="_blank">竞买申请 </a></li>
                    <li class='line'></li>
                    <li><a id="http://localhost:7905/Tlw.ZPG.PublicWeb/Index.aspx" href="http://localhost:7905/Tlw.ZPG.PublicWeb/PublicSysMsg/TradeInfoQueryView.aspx"
                        title="出让宗地查询">出让宗地查询 </a></li>
                    <li class='line'></li>
                    <li><a id="http://localhost:7905/Tlw.ZPG.PublicWeb/Index.aspx" href="http://localhost:7905/Tlw.ZPG.PublicWeb/PublicSysMsg/InfomationQuery.aspx?InfomationBigTypeId=3"
                        title="政策法规资讯">政策法规资讯 </a></li>
                    <li class='line'></li>
                    <li><a id="http://localhost:7905/Tlw.ZPG.PublicWeb/Index.aspx" href="http://localhost:7905/Tlw.ZPG.PublicWeb/PublicSysMsg/FormatFileDownload.aspx"
                        title="格式文书下载">格式文书下载 </a></li>
                    <li class='line'></li>
                    <li><a id="http://localhost:7905/Tlw.ZPG.PublicWeb/Index.aspx" href="http://localhost:7905/Tlw.ZPG.PublicWeb/PublicSysMsg/FileDownload.aspx"
                        title="交易软件下载">交易软件下载 </a></li>
                    <li class='line'></li>
                </ul>
                <div style="font-size: 15px; color: #FF0000; font-weight: bold; text-align: center;">
                    竞买端软件升级，请各竞买人重新<a href="http://fjgpjy.fjgtzy.gov.cn/zpgpublicweb/Resource/ClientTool/福建省国有建设用地使用权出让网上交易系统(竞买软件)v1.011.exe"
                        style="font-size: 15px; color: #FF0000; font-weight: bold; text-align: center;
                        text-decoration: underline;">下载安装</a>(如已安装，请先卸载后再安装)。
                </div>
            </div>
        </div>
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
                                        <map id="Map" name="Map">
                                            <area href="PublicSysMsg/TradeAffiche.aspx?AfficheFashionId=53" shape="rect" coords="42,12,194,45">
                                            <area href="PublicSysMsg/TradeResultListView.aspx" shape="rect" coords="42,57,194,89">
                                            <area href="PublicSysMsg/TradeResultListView.aspx?ResultId=139" shape="rect" coords="45,101,216,132">
                                            <area href="PublicSysMsg/UserRegisterQuery.aspx" shape="rect" target="_blank" coords="45,148,213,178">
                                            <area href="PublicSysMsg/FamiliarQuestion.aspx" shape="rect" coords="44,194,180,224">
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
                                                                                                            <img border="0" alt="" src="css/NewTabImages/tab_left_icon.gif" width="7" height="29">
                                                                                                        </td>
                                                                                                        <td style="padding-bottom: 4px; padding-left: 10px; padding-right: 10px; padding-top: 5px"
                                                                                                            align="left">
                                                                                                            <nobr>各类用途土地挂牌出让公告（全部）</nobr>
                                                                                                        </td>
                                                                                                        <td style="padding-bottom: 0px; padding-left: 0px; padding-right: 0px; padding-top: 0px"
                                                                                                            width="7">
                                                                                                            <img border="0" alt="" src="css/NewTabImages/tab_right_icon.gif" width="7" height="29">
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
                                                                                                            <img border="0" alt="" src="css/NewTabImages/tab_left_icon.gif" width="7" height="29">
                                                                                                        </td>
                                                                                                        <td style="padding-bottom: 4px; padding-left: 10px; padding-right: 10px; padding-top: 5px"
                                                                                                            align="left">
                                                                                                            <nobr>商住用地挂牌出让公告</nobr>
                                                                                                        </td>
                                                                                                        <td style="padding-bottom: 0px; padding-left: 0px; padding-right: 0px; padding-top: 0px"
                                                                                                            width="7">
                                                                                                            <img border="0" alt="" src="css/NewTabImages/tab_right_icon.gif" width="7" height="29">
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
                                                                                                            <img border="0" alt="" src="css/NewTabImages/tab_left_icon.gif" width="7" height="29">
                                                                                                        </td>
                                                                                                        <td style="padding-bottom: 4px; padding-left: 10px; padding-right: 10px; padding-top: 5px"
                                                                                                            align="left">
                                                                                                            <nobr>工业用地挂牌出让公告</nobr>
                                                                                                        </td>
                                                                                                        <td style="padding-bottom: 0px; padding-left: 0px; padding-right: 0px; padding-top: 0px"
                                                                                                            width="7">
                                                                                                            <img border="0" alt="" src="css/NewTabImages/tab_right_icon.gif" width="7" height="29">
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
                                                                                                            <img border="0" alt="" src="css/NewTabImages/selected_tab_left_icon.gif" width="7"
                                                                                                                height="29">
                                                                                                        </td>
                                                                                                        <td style="padding-bottom: 4px; padding-left: 10px; padding-right: 10px; padding-top: 4px"
                                                                                                            align="left">
                                                                                                            <nobr>其它用地挂牌出让公告</nobr>
                                                                                                        </td>
                                                                                                        <td style="padding-bottom: 0px; padding-left: 0px; padding-right: 0px; padding-top: 0px"
                                                                                                            width="7">
                                                                                                            <img border="0" alt="" src="css/NewTabImages/selected_tab_right_icon.gif" width="7"
                                                                                                                height="29">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td width="100%">
                                                                                        </td>
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
                                                                                                <tr title="tesat">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1564&amp;TempId=0&amp;ViewId=1199',false,700,400,'NewWin');">
                                                                                                            tesat </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="red"><strong>2014-01-22 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2014-01-22 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr class="rowColor" title="bbb">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1563&amp;TempId=0&amp;ViewId=1198',false,700,400,'NewWin');">
                                                                                                            bbb </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="red"><strong>2014-01-21 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2014-01-21 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr title="2014年新">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1562&amp;TempId=0&amp;ViewId=1197',false,700,400,'NewWin');">
                                                                                                            2014年新 </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="red"><strong>2014-01-21 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2014-01-21 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr class="rowColor" title="aaa">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1561&amp;TempId=0&amp;ViewId=1196',false,700,400,'NewWin');">
                                                                                                            aaa </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="red"><strong>2014-01-14 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2014-01-14 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr title="ccc">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1560&amp;TempId=0&amp;ViewId=1195',false,700,400,'NewWin');">
                                                                                                            ccc </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="red"><strong>2014-01-14 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2014-01-14 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr class="rowColor" title="aaa">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1559&amp;TempId=0&amp;ViewId=1194',false,700,400,'NewWin');">
                                                                                                            aaa </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="red"><strong>2014-01-13 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2014-01-13 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="text-align: right; background-color: white; height: 16px" class="gridItem"
                                                                                                        colspan="4">
                                                                                                        <a href="PublicSysMsg/TradeAffiche.aspx?AfficheFashionId=53">更多...</a>
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
                                                                                                <tr title="aaa">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1561&amp;TempId=0&amp;ViewId=1196',false,700,400,'NewWin');">
                                                                                                            aaa </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="red"><strong>2014-01-14 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2014-01-14 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr class="rowColor" title="bbb">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1558&amp;TempId=0&amp;ViewId=1193',false,700,400,'NewWin');">
                                                                                                            bbb </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="red"><strong>2014-01-13 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2014-01-13 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr title="test0109-1">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1552&amp;TempId=0&amp;ViewId=1187',false,700,400,'NewWin');">
                                                                                                            test0109-1 </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="red"><strong>2014-01-09 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2014-01-09 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr class="rowColor" title="test11-1">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1551&amp;TempId=0&amp;ViewId=1186',false,700,400,'NewWin');">
                                                                                                            test11-1 </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="red"><strong>2014-01-08 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2014-01-08 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr title="test0108">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1550&amp;TempId=0&amp;ViewId=1185',false,700,400,'NewWin');">
                                                                                                            test0108 </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州仓山区
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="red"><strong>2014-01-08 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2014-01-08 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr class="rowColor" title="关于2012年第二十七次挂牌交易公告（测试）">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1532&amp;TempId=0&amp;ViewId=1165',false,700,400,'NewWin');">
                                                                                                            关于2012年第二十七次挂牌交易公告（测试） </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州闽清县
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="red"><strong>2012-10-22 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2012-10-22 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="text-align: right; background-color: white; height: 16px" class="gridItem"
                                                                                                        colspan="4">
                                                                                                        <a href="PublicSysMsg/TradeAffiche.aspx?AfficheFashionId=53">更多...</a>
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
                                                                                                <tr title="tesat">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1564&amp;TempId=0&amp;ViewId=1199',false,700,400,'NewWin');">
                                                                                                            tesat </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州
                                                                                                    </td>
                                                                                                    <td style="text-align: center" class="gridItem">
                                                                                                        <font color="red"><strong>2014-01-22 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2014-01-22 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr class="rowColor" title="bbb">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1563&amp;TempId=0&amp;ViewId=1198',false,700,400,'NewWin');">
                                                                                                            bbb </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州
                                                                                                    </td>
                                                                                                    <td style="text-align: center" class="gridItem">
                                                                                                        <font color="red"><strong>2014-01-21 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2014-01-21 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr title="2014年新">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1562&amp;TempId=0&amp;ViewId=1197',false,700,400,'NewWin');">
                                                                                                            2014年新 </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州
                                                                                                    </td>
                                                                                                    <td style="text-align: center" class="gridItem">
                                                                                                        <font color="red"><strong>2014-01-21 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2014-01-21 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr class="rowColor" title="ccc">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1560&amp;TempId=0&amp;ViewId=1195',false,700,400,'NewWin');">
                                                                                                            ccc </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州
                                                                                                    </td>
                                                                                                    <td style="text-align: center" class="gridItem">
                                                                                                        <font color="red"><strong>2014-01-14 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2014-01-14 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr title="aaa">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1559&amp;TempId=0&amp;ViewId=1194',false,700,400,'NewWin');">
                                                                                                            aaa </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州
                                                                                                    </td>
                                                                                                    <td style="text-align: center" class="gridItem">
                                                                                                        <font color="red"><strong>2014-01-13 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2014-01-13 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr class="rowColor" title="testa">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1557&amp;TempId=0&amp;ViewId=1192',false,700,400,'NewWin');">
                                                                                                            testa </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州
                                                                                                    </td>
                                                                                                    <td style="text-align: center" class="gridItem">
                                                                                                        <font color="red"><strong>2014-01-10 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2014-01-10 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="text-align: right; background-color: white; height: 16px" class="gridItem"
                                                                                                        colspan="4">
                                                                                                        <a href="PublicSysMsg/TradeAffiche.aspx?AfficheFashionId=53">更多...</a>
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
                                                                                                <tr title="关于2012年第二十五次挂牌交易公告（测试）">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1529&amp;TempId=0&amp;ViewId=1162',false,700,400,'NewWin');">
                                                                                                            关于2012年第二十五次挂牌交易公告（测试） </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州永泰县
                                                                                                    </td>
                                                                                                    <td style="text-align: center" class="gridItem">
                                                                                                        <font color="red"><strong>2012-09-14 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2012-09-14 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr class="rowColor" title="关于2012年第二十三次挂牌交易公告（测试）">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1528&amp;TempId=0&amp;ViewId=1161',false,700,400,'NewWin');">
                                                                                                            关于2012年第二十三次挂牌交易公告（测试） </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州连江县
                                                                                                    </td>
                                                                                                    <td style="text-align: center" class="gridItem">
                                                                                                        <font color="red"><strong>2012-09-14 </strong></font>
                                                                                                    </td>
                                                                                                    <td style="text-align: center" class="gridItem">
                                                                                                        <font color="blue"><strong>2012-09-14 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr title="关于2012年第二一次挂牌交易公告（测试）">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1526&amp;TempId=0&amp;ViewId=1159',false,700,400,'NewWin');">
                                                                                                            关于2012年第二一次挂牌交易公告（测试） </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州罗源县
                                                                                                    </td>
                                                                                                    <td style="text-align: center" class="gridItem">
                                                                                                        <font color="red"><strong>2012-09-15 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2012-09-15 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr class="rowColor" title="关于2012年第二十次挂牌交易公告（测试）">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1525&amp;TempId=0&amp;ViewId=1158',false,700,400,'NewWin');">
                                                                                                            关于2012年第二十次挂牌交易公告（测试） </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州福清市
                                                                                                    </td>
                                                                                                    <td style="text-align: center" class="gridItem">
                                                                                                        <font color="red"><strong>2012-09-13 </strong></font>
                                                                                                    </td>
                                                                                                    <td style="text-align: center" class="gridItem">
                                                                                                        <font color="blue"><strong>2012-09-13 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr title="福州市土地出让公告_20120223测试">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1489&amp;TempId=0&amp;ViewId=1117',false,700,400,'NewWin');">
                                                                                                            福州市土地出让公告_20120223测试 </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州
                                                                                                    </td>
                                                                                                    <td style="text-align: center" class="gridItem">
                                                                                                        <font color="red"><strong>2012-02-23 </strong></font>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        <font color="blue"><strong>2012-02-23 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr class="rowColor" title="测试_福州鼓楼_土地公告20120213_003">
                                                                                                    <td class="C1AItem2" nowrap>
                                                                                                        · <a href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1483&amp;TempId=0&amp;ViewId=1109',false,700,400,'NewWin');">
                                                                                                            测试_福州鼓楼_土地公告20120213_003 </a>
                                                                                                    </td>
                                                                                                    <td class="gridItem" align="middle">
                                                                                                        福州鼓楼区
                                                                                                    </td>
                                                                                                    <td style="text-align: center" class="gridItem">
                                                                                                        <font color="red"><strong>2012-02-13 </strong></font>
                                                                                                    </td>
                                                                                                    <td style="text-align: center" class="gridItem">
                                                                                                        <font color="blue"><strong>2012-02-13 </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="text-align: right; background-color: white; height: 16px" class="gridItem"
                                                                                                        colspan="4">
                                                                                                        <a href="PublicSysMsg/TradeAffiche.aspx?AfficheFashionId=53">更多...</a>
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
                                            <li style="background: url(./images/city/福州.jpg) no-repeat right top" class="first">
                                                <a style="text-decoration: none" title="点击查看详情...." href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1564&amp;TempId=0&amp;ViewId=1199')">
                                                    <span style="font-size: 14px" id="gpcrtime0">14年1月22日<font color="#ff2d2d">至1</font>4年1月22日</span><span
                                                        class="city">福州<img style="border-bottom: medium none; border-left: medium none;
                                                            border-top: medium none; border-right: medium none" src="./images/new.gif"></span><span
                                                                class="info">挂牌出让1宗国有土地使用权</span></a></li>
                                            <li style="background: url(./images/city/福州.jpg) no-repeat right top"><a style="text-decoration: none"
                                                title="点击查看详情...." href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1563&amp;TempId=0&amp;ViewId=1198')">
                                                <span style="font-size: 14px" id="gpcrtime1">14年1月21日<font color="#ff2d2d">至1</font>4年1月21日</span><span
                                                    class="city">福州<img style="border-bottom: medium none; border-left: medium none;
                                                        border-top: medium none; border-right: medium none" src="./images/new.gif"></span><span
                                                            class="info">挂牌出让1宗国有土地使用权</span></a></li>
                                            <li style="background: url(./images/city/福州.jpg) no-repeat right top"><a style="text-decoration: none"
                                                title="点击查看详情...." href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1562&amp;TempId=0&amp;ViewId=1197')">
                                                <span style="font-size: 14px" id="gpcrtime2">14年1月21日<font color="#ff2d2d">至1</font>4年1月21日</span><span
                                                    class="city">福州<img style="border-bottom: medium none; border-left: medium none;
                                                        border-top: medium none; border-right: medium none" src="./images/new.gif"></span><span
                                                            class="info">挂牌出让1宗国有土地使用权</span></a></li>
                                            <li style="background: url(./images/city/福州.jpg) no-repeat right top"><a style="text-decoration: none"
                                                title="点击查看详情...." href="javascript:OpenNewWindow('PublicSysMsg/TradeAffiche/AfficheView.aspx?AfficheId=1561&amp;TempId=0&amp;ViewId=1196')">
                                                <span style="font-size: 14px" id="gpcrtime3">14年1月14日<font color="#ff2d2d">至1</font>4年1月14日</span><span
                                                    class="city">福州<img style="border-bottom: medium none; border-left: medium none;
                                                        border-top: medium none; border-right: medium none" src="./images/new.gif"></span><span
                                                            class="info">挂牌出让1宗国有土地使用权</span></a></li></ul>
                                    </td>
                                    <td style="padding-top: 6px" align="right">
                                        <div class="LM">
                                            <table style="vertical-align: middle" border="0" cellspacing="0" cellpadding="0"
                                                width="225" height="85">
                                                <tbody>
                                                    <tr>
                                                        <td width="2">
                                                        </td>
                                                        <td width="100" align="right">
                                                            <a href="PublicSysMsg/OnlineQuestion.aspx"><span style="position: relative; font-size: 14px;
                                                                top: 20px">&nbsp;在线留言</span></a>
                                                        </td>
                                                        <td width="2">
                                                        </td>
                                                        <td width="110" align="middle">
                                                            <a href="Resource/ClientTool/福建省国有建设用地使用权出让网上交易系统(竞买软件).exe"><span style="position: relative;
                                                                font-size: 14px; top: 20px">&nbsp;&nbsp;&nbsp;&nbsp;竞买软件</span></a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="2">
                                                        </td>
                                                        <td width="100" align="right">
                                                            <a href="PublicSysMsg/InfomationQuery.aspx?InfomationBigTypeId=4"><span style="position: relative;
                                                                font-size: 14px; top: 22px">&nbsp;知识问答</span></a>
                                                        </td>
                                                        <td width="2">
                                                        </td>
                                                        <td width="110" align="middle">
                                                            <a href="PublicSysMsg/InfomationQuery.aspx?InfomationBigTypeId=3"><span style="position: relative;
                                                                font-size: 14px; top: 22px">&nbsp;&nbsp;&nbsp;&nbsp;政策法规</span></a>
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
                                                            <span style="font-size: 14px">最新报价</span></a></div>
                                                </div>
                                                <div class="right">
                                                </div>
                                                <div class="more">
                                                    <a style="text-decoration: none" href="PublicSysMsg/TradeInfoQueryView.aspx" target="_self">
                                                        更多...</a></div>
                                            </div>
                                            <table style="width: 762px; table-layout: fixed" class="TableList" border="0" cellspacing="0"
                                                cellpadding="0">
                                                <tbody>
                                                    <tr class="Header">
                                                        <td style="width: 210px;">
                                                            宗地号
                                                        </td>
                                                        <td>
                                                            所在区域
                                                        </td>
                                                        <td style="width: 180px">
                                                            土地用途及出让年限
                                                        </td>
                                                        <td style="width: 102px">
                                                            最高价
                                                        </td>
                                                        <td style="width: 140px">
                                                            出价时间
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <table style="width: 762px; table-layout: fixed" id="NewPriceList" class="TableList"
                                                border="0" cellspacing="0" cellpadding="0">
                                                <tbody>
                                                    <tr style="background-color: #f0f7fd">
                                                        <td style="width: 210px; white-space: nowrap; overflow: hidden" title="福州仓山区-福州2012年30次1号">
                                                            <a href="">福州仓山区福州仓山区福州仓山区福州仓山区</a>
                                                        </td>
                                                        <td>
                                                            福州仓山区
                                                        </td>
                                                        <td style="width: 180px; white-space: nowrap; overflow: hidden" title="工业用地(农副食品加工业：面积 5000平方米、出让年限 50年);">
                                                            工业用地(农副食品加工业：面积 5000平方米、出让年限 50年)
                                                        </td>
                                                        <td style="width: 102px;">
                                                            ￥2204900.0万
                                                        </td>
                                                        <td style="width: 140px;">
                                                            2014-1-23 9:27:46
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #f0f7fd">
                                                        <td style="width: 210px;" title="福州仓山区-福州2012年30次1号">
                                                            <a href="">福州仓山区</a>
                                                        </td>
                                                        <td style="width: 130px;">
                                                            福州仓山区
                                                        </td>
                                                        <td style="width: 180px;" title="工业用地(农副食品加工业：面积 5000平方米、出让年限 50年);">
                                                            工业用地
                                                        </td>
                                                        <td style="width: 100px;">
                                                            ￥2204900.0万
                                                        </td>
                                                        <td style="width: 140px;">
                                                            2014-1-23 9:27:46
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #f0f7fd">
                                                        <td style="width: 210px;" title="福州仓山区-福州2012年30次1号">
                                                            <a href="">福州仓山区</a>
                                                        </td>
                                                        <td style="width: 130px;">
                                                            福州仓山区
                                                        </td>
                                                        <td style="width: 180px;" title="工业用地(农副食品加工业：面积 5000平方米、出让年限 50年);">
                                                            工业用地
                                                        </td>
                                                        <td style="width: 100px;">
                                                            ￥2204900.0万
                                                        </td>
                                                        <td style="width: 140px;">
                                                            2014-1-23 9:27:46
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #f0f7fd">
                                                        <td style="width: 210px;" title="福州仓山区-福州2012年30次1号">
                                                            <a href="">福州仓山区</a>
                                                        </td>
                                                        <td style="width: 130px;">
                                                            福州仓山区
                                                        </td>
                                                        <td style="width: 180px;" title="工业用地(农副食品加工业：面积 5000平方米、出让年限 50年);">
                                                            工业用地
                                                        </td>
                                                        <td style="width: 100px;">
                                                            ￥2204900.0万
                                                        </td>
                                                        <td style="width: 140px;">
                                                            2014-1-23 9:27:46
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #f0f7fd">
                                                        <td style="width: 210px;" title="福州仓山区-福州2012年30次1号">
                                                            <a href="">福州仓山区</a>
                                                        </td>
                                                        <td style="width: 130px;">
                                                            福州仓山区
                                                        </td>
                                                        <td style="width: 180px;" title="工业用地(农副食品加工业：面积 5000平方米、出让年限 50年);">
                                                            工业用地
                                                        </td>
                                                        <td style="width: 100px;">
                                                            ￥2204900.0万
                                                        </td>
                                                        <td style="width: 140px;">
                                                            2014-1-23 9:27:46
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: #f0f7fd">
                                                        <td style="width: 210px;" title="福州仓山区-福州2012年30次1号">
                                                            <a href="">福州仓山区</a>
                                                        </td>
                                                        <td style="width: 130px;">
                                                            福州仓山区
                                                        </td>
                                                        <td style="width: 180px;" title="工业用地(农副食品加工业：面积 5000平方米、出让年限 50年);">
                                                            工业用地
                                                        </td>
                                                        <td style="width: 100px;">
                                                            ￥2204900.0万
                                                        </td>
                                                        <td style="width: 140px;">
                                                            2014-1-23 9:27:46
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </td>
                                    <td style="text-align: right" width="235">
                                        <div style="float: right" class="jmrczbz">
                                            <ul>
                                                <li><a href="resource/OnlineDemo/OnlineDemoBM/3.htm" target="_blank"><span style="font-size: 14px;
                                                    font-weight: bold">注册演示</span></a></li>
                                                <li><a href="resource/OnlineDemo/OnlineDemoPM/1.htm" target="_blank"><span style="font-size: 14px;
                                                    font-weight: bold">挂牌交易演示</span></a></li>
                                                <li><a href="resource/OnlineDemo/OnlineDemoGP/2.htm" target="_blank"><span style="font-size: 14px;
                                                    font-weight: bold">网上拍卖演示</span></a></li>
                                                <li class="wu"><a href="Resource/ClientTool/竞买软件操作手册.doc" target="_blank"><span style="font-size: 14px;
                                                    font-weight: bold">竞买人操作手册下载</span></a></li></ul>
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
                                    <td height="7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img style="filter: blendTrans(duration=crossFadeDuration)" name="SlideShow" hspace="0"
                                            alt="" vspace="0" src="images/flash01.gif" width="1000" height="159">
                                    </td>
                                </tr>
                                <tr>
                                    <td height="4">
                                    </td>
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
                                                                            style="font-size: 14px">交易结果公示</span></a></div>
                                                                </div>
                                                                <div class="right">
                                                                </div>
                                                                <div class="more">
                                                                    <a style="text-decoration: none" href="PublicSysMsg/TradeResultListView.aspx" target="_self">
                                                                        更多...</a></div>
                                                            </div>
                                                            <table style="position: relative; width: 720px; border-collapse: collapse; top: -1px"
                                                                id="dgrdList" class="TableList" border="1" rules="all" cellspacing="0" cellpadding="0">
                                                                <tbody>
                                                                    <tr class="Header">
                                                                        <td style="width: 40px" nowrap>
                                                                            序号
                                                                        </td>
                                                                        <td style="width: 273px" nowrap>
                                                                            宗地号
                                                                        </td>
                                                                        <td style="width: 100px" nowrap align="middle">
                                                                            面积(平方米)
                                                                        </td>
                                                                        <td style="width: 100px" nowrap align="middle">
                                                                            成交价(万元)
                                                                        </td>
                                                                        <td style="width: 100px" nowrap align="middle">
                                                                            竞得人
                                                                        </td>
                                                                        <td style="width: 100px" nowrap align="middle">
                                                                            成交时间
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="field_gridItem">
                                                                        <td align="middle">
                                                                            1
                                                                        </td>
                                                                        <td class="field_gridCell" title="福州鼓楼区-tesa" align="middle">
                                                                            <a style="text-decoration: none" href="javascript:OpenNewWindow('PublicSysMsg/TradeResult/TradeResultView.aspx?ResultinformationId=1609',false,700,400,'NewWin');">
                                                                                福州鼓楼区-tesa</a>
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            23.00
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            310.00
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            2
                                                                        </td>
                                                                        <td align="middle">
                                                                            2014-01-21
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="rowColor">
                                                                        <td align="middle">
                                                                            2
                                                                        </td>
                                                                        <td class="field_gridCell" title="福州鼓楼区-c" align="middle">
                                                                            <a style="text-decoration: none" href="javascript:OpenNewWindow('PublicSysMsg/TradeResult/TradeResultView.aspx?ResultinformationId=1608',false,700,400,'NewWin');">
                                                                                福州鼓楼区-c</a>
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            23.00
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td align="middle">
                                                                            (流拍)
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="field_gridItem">
                                                                        <td align="middle">
                                                                            3
                                                                        </td>
                                                                        <td class="field_gridCell" title="福州鼓楼区-cd" align="middle">
                                                                            <a style="text-decoration: none" href="javascript:OpenNewWindow('PublicSysMsg/TradeResult/TradeResultView.aspx?ResultinformationId=1607',false,700,400,'NewWin');">
                                                                                福州鼓楼区-cd</a>
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            23.00
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td align="middle">
                                                                            (流拍)
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="rowColor">
                                                                        <td align="middle">
                                                                            4
                                                                        </td>
                                                                        <td class="field_gridCell" title="福州鼓楼区-bbb" align="middle">
                                                                            <a style="text-decoration: none" href="javascript:OpenNewWindow('PublicSysMsg/TradeResult/TradeResultView.aspx?ResultinformationId=1606',false,700,400,'NewWin');">
                                                                                福州鼓楼区-bbb</a>
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            34.00
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td align="middle">
                                                                            (流拍)
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="field_gridItem">
                                                                        <td align="middle">
                                                                            5
                                                                        </td>
                                                                        <td class="field_gridCell" title="福州鼓楼区-cc" align="middle">
                                                                            <a style="text-decoration: none" href="javascript:OpenNewWindow('PublicSysMsg/TradeResult/TradeResultView.aspx?ResultinformationId=1605',false,700,400,'NewWin');">
                                                                                福州鼓楼区-cc</a>
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            3.00
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td align="middle">
                                                                            (流拍)
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="rowColor">
                                                                        <td align="middle">
                                                                            6
                                                                        </td>
                                                                        <td class="field_gridCell" title="福州鼓楼区-111" align="middle">
                                                                            <a style="text-decoration: none" href="javascript:OpenNewWindow('PublicSysMsg/TradeResult/TradeResultView.aspx?ResultinformationId=1604',false,700,400,'NewWin');">
                                                                                福州鼓楼区-111</a>
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            2.00
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            27.00
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            4
                                                                        </td>
                                                                        <td align="middle">
                                                                            2014-01-13
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="field_gridItem">
                                                                        <td align="middle">
                                                                            7
                                                                        </td>
                                                                        <td class="field_gridCell" title="福州鼓楼区-zxm1" align="middle">
                                                                            <a style="text-decoration: none" href="javascript:OpenNewWindow('PublicSysMsg/TradeResult/TradeResultView.aspx?ResultinformationId=1603',false,700,400,'NewWin');">
                                                                                福州鼓楼区-zxm1</a>
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            3.00
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            68.00
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            3
                                                                        </td>
                                                                        <td align="middle">
                                                                            2014-01-10
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="rowColor">
                                                                        <td align="middle">
                                                                            8
                                                                        </td>
                                                                        <td class="field_gridCell" title="福州鼓楼区-aaa" align="middle">
                                                                            <a style="text-decoration: none" href="javascript:OpenNewWindow('PublicSysMsg/TradeResult/TradeResultView.aspx?ResultinformationId=1602',false,700,400,'NewWin');">
                                                                                福州鼓楼区-aaa</a>
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            3.00
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td align="middle">
                                                                            (流拍)
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="field_gridItem">
                                                                        <td align="middle">
                                                                            9
                                                                        </td>
                                                                        <td class="field_gridCell" title="福州鼓楼区-bb" align="middle">
                                                                            <a style="text-decoration: none" href="javascript:OpenNewWindow('PublicSysMsg/TradeResult/TradeResultView.aspx?ResultinformationId=1601',false,700,400,'NewWin');">
                                                                                福州鼓楼区-bb</a>
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            45.00
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            12.00
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            a
                                                                        </td>
                                                                        <td align="middle">
                                                                            2014-01-10
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="rowColor">
                                                                        <td align="middle">
                                                                            10
                                                                        </td>
                                                                        <td class="field_gridCell" title="福州鼓楼区-aaa" align="middle">
                                                                            <a style="text-decoration: none" href="javascript:OpenNewWindow('PublicSysMsg/TradeResult/TradeResultView.aspx?ResultinformationId=1600',false,700,400,'NewWin');">
                                                                                福州鼓楼区-aaa</a>
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            2.00
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            12.00
                                                                        </td>
                                                                        <td class="field_gridCell" align="middle">
                                                                            w
                                                                        </td>
                                                                        <td align="middle">
                                                                            2014-01-10
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
                                                                    <table style="border-bottom: #c4d1dd 1px solid; border-left: #c4d1dd 1px solid; width: 272px;
                                                                        height: 137px; border-top: #c4d1dd 1px solid; border-right: #c4d1dd 1px solid"
                                                                        cellspacing="0" cellpadding="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td height="6">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; padding-left: 8px">
                                                                                    <a style="text-decoration: none" href="">
                                                                                        <span style="width: 200px; text-overflow: ellipsis; display: block; white-space: nowrap;
                                                                                            overflow: hidden">·中华人民共和国土地管理法</span> </a>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; padding-left: 8px">
                                                                                    <a style="text-decoration: none" href="">
                                                                                        <span style="width: 200px; text-overflow: ellipsis; display: block; white-space: nowrap;
                                                                                            overflow: hidden">·中华人民共和国城市房地产管理法</span> </a>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; padding-left: 8px">
                                                                                    <a style="text-decoration: none" href="">
                                                                                        <span style="width: 200px; text-overflow: ellipsis; display: block; white-space: nowrap;
                                                                                            overflow: hidden">·中华人民共和国物权法</span> </a>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; padding-left: 8px">
                                                                                    <a style="text-decoration: none" href="">
                                                                                        <span style="width: 200px; text-overflow: ellipsis; display: block; white-space: nowrap;
                                                                                            overflow: hidden">·中华人民共和国城乡规划法</span> </a>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left; padding-left: 8px">
                                                                                    <a style="text-decoration: none" href="">
                                                                                        <span style="width: 200px; text-overflow: ellipsis; display: block; white-space: nowrap;
                                                                                            overflow: hidden">·中华人民共和国行政许可法</span> </a>
                                                                                </td>
                                                                            </tr>
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
                                                                    <table style="border-bottom: #c4d1dd 1px solid; border-left: #c4d1dd 1px solid; width: 272px;
                                                                        height: 107px; border-top: #c4d1dd 1px solid; border-right: #c4d1dd 1px solid"
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
                            <div class="bottom_menu">
                                <div class="title1">
                                    <a href="http://localhost:7905/Tlw.ZPG.PublicWeb/Index.aspx">首 页</a> | <a href="http://localhost:7905/Tlw.ZPG.PublicWeb/PublicSysMsg/TradeRule.aspx"
                                        target="_blank">交易规则</a> | <a href="http://localhost:7905/Tlw.ZPG.PublicWeb/PublicSysMsg/TradeFlow.aspx"
                                            target="_blank">交易流程</a> | <a href="http://localhost:7905/Tlw.ZPG.PublicWeb/PublicSysMsg/ApplyInstruction.aspx"
                                                target="_blank">竞买申请</a> | <a href="http://localhost:7905/Tlw.ZPG.PublicWeb/PublicSysMsg/TradeInfoQueryView.aspx">
                                                    出让宗地查询</a> | <a href="http://localhost:7905/Tlw.ZPG.PublicWeb/PublicSysMsg/InfomationQuery.aspx?InfomationBigTypeId=3">
                                                        政策法规资讯</a> | <a href="http://localhost:7905/Tlw.ZPG.PublicWeb/PublicSysMsg/FormatFileDownload.aspx">
                                                            格式文书下载</a> | <a href="http://localhost:7905/Tlw.ZPG.PublicWeb/PublicSysMsg/FileDownload.aspx">
                                                                交易软件下载</a></div>
                            </div>
                            <div class="bottom_bg">
                                <div class="write">
                                    版权所有 @ 福建省国土资源厅&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;地址：福建省福州市金泉路38号&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;电话：<span
                                        style="color: red">0591-87660970 0591-87665795</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;备案序号：<span
                                            style="color: red">闽ICP备030063号</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 技术支持：福州特力惠电子有限公司&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;电话：0591-87541518</div>
                            </div>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
