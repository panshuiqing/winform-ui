﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TradeResult.aspx.cs" Inherits="Teleware.ZPG.Client.Web.res.TradeResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>交易结果公示</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        td
        {
            text-align: center;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="content">
        <div class="search">
            <input type="text" name="kw" id="kw" maxlength="30" class="text" />
            <input type="submit" value="查 询" onmouseout="this.className='button'" onmouseover="this.className='button button-h'" class="button" />
        </div>
        <table class="table-grid" cellpadding="0" cellspacing="0">
            <thead>
                <tr class="Header">
                    <td style="width:6%;">序号</td>
                    <td style="width:20%">宗地号</td>
                    <td style="width:15%">面积（平方米）</td>
                    <td style="width:15%">成交价（万元）</td>
                    <td style="width:15%">竞得人</td>
                    <td style="width:20%">成交时间</td>
                    <td>状态</td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        1
                    </td>
                    <td>
                        福州市宗地001-111023
                    </td>
                    <td>
                        1234
                    </td>
                    <td>
                        43453
                    </td>
                    <td>
                        刘标才
                    </td>
                    <td>
                        2014-1-1
                    </td>
                    <td>
                        已成交
                    </td>
                </tr>
                <tr>
                    <td>
                        1
                    </td>
                    <td>
                        福州市宗地001-111023
                    </td>
                    <td>
                        1234
                    </td>
                    <td>
                        43453
                    </td>
                    <td>
                        刘标才
                    </td>
                    <td>
                        2014-1-1
                    </td>
                    <td>
                        已成交
                    </td>
                </tr>
                <tr>
                    <td>
                        1
                    </td>
                    <td>
                        福州市宗地001-111023
                    </td>
                    <td>
                        1234
                    </td>
                    <td>
                        43453
                    </td>
                    <td>
                        刘标才
                    </td>
                    <td>
                        2014-1-1
                    </td>
                    <td>
                        已成交
                    </td>
                </tr>
                <tr>
                    <td>
                        1
                    </td>
                    <td>
                        福州市宗地001-111023
                    </td>
                    <td>
                        1234
                    </td>
                    <td>
                        43453
                    </td>
                    <td>
                        刘标才
                    </td>
                    <td>
                        2014-1-1
                    </td>
                    <td>
                        已成交
                    </td>
                </tr>
                <tr>
                    <td>
                        1
                    </td>
                    <td>
                        福州市宗地001-111023
                    </td>
                    <td>
                        1234
                    </td>
                    <td>
                        43453
                    </td>
                    <td>
                        刘标才
                    </td>
                    <td>
                        2014-1-1
                    </td>
                    <td>
                        已成交
                    </td>
                </tr>
                <tr>
                    <td>
                        1
                    </td>
                    <td>
                        福州市宗地001-111023
                    </td>
                    <td>
                        1234
                    </td>
                    <td>
                        43453
                    </td>
                    <td>
                        刘标才
                    </td>
                    <td>
                        2014-1-1
                    </td>
                    <td>
                        已成交
                    </td>
                </tr>
                <tr>
                    <td>
                        1
                    </td>
                    <td>
                        福州市宗地001-111023
                    </td>
                    <td>
                        1234
                    </td>
                    <td>
                        43453
                    </td>
                    <td>
                        刘标才
                    </td>
                    <td>
                        2014-1-1
                    </td>
                    <td>
                        已成交
                    </td>
                </tr>
                <tr>
                    <td>
                        1
                    </td>
                    <td>
                        福州市宗地001-111023
                    </td>
                    <td>
                        1234
                    </td>
                    <td>
                        43453
                    </td>
                    <td>
                        刘标才
                    </td>
                    <td>
                        2014-1-1
                    </td>
                    <td>
                        已成交
                    </td>
                </tr>
                <tr>
                    <td>
                        1
                    </td>
                    <td>
                        福州市宗地001-111023
                    </td>
                    <td>
                        1234
                    </td>
                    <td>
                        43453
                    </td>
                    <td>
                        刘标才
                    </td>
                    <td>
                        2014-1-1
                    </td>
                    <td>
                        已成交
                    </td>
                </tr>
                <tr>
                    <td>
                        1
                    </td>
                    <td>
                        福州市宗地001-111023
                    </td>
                    <td>
                        1234
                    </td>
                    <td>
                        43453
                    </td>
                    <td>
                        刘标才
                    </td>
                    <td>
                        2014-1-1
                    </td>
                    <td>
                        已成交
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="pagination">
            <span class="disabled">< Prev</span><span class="current">1</span><a href="#">2</a><a
                href="#">3</a><a href="#">4</a><a href="#">5</a><a href="#">6</a><a href="#">7</a>...<a
                    href="#">199</a><a href="#">200</a><a href="#">Next > </a>
        </div>
        </div>
    </div>
    </form>
</body>
</html>
