<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tlw.ZPG.Web._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>修改此模板以快速开始创建 ASP.NET 应用程序。</h2>
            </hgroup>
            <p>
                若要了解有关 ASP.NET 的详细信息，请访问 <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>。
                该页提供 <mark>视频、教程和示例</mark> 以帮助你充分利用 ASP.NET。
                如果你对 ASP.NET 有任何疑问，请访问
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">我们的论坛</a>。
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>下面是我们的建议:</h3>
    <ol class="round">
        <li class="one">
            <h5>开始使用</h5>
            通过 ASP.NET Web Forms，可以使用一种熟悉的、支持拖放操作的事件驱动模型生成动态网站。
            一个设计图面加上数百个控件和组件，使你能够快速生成复杂且功能强大的、带有数据访问功能的 UI 驱动站点。
            <a href="http://go.microsoft.com/fwlink/?LinkId=245146">了解详细信息...</a>
        </li>
        <li class="two">
            <h5>添加 NuGet 程序包并快速开始编码</h5>
            通过 NuGet，可以轻松地安装和更新免费的库和工具。
            <a href="http://go.microsoft.com/fwlink/?LinkId=245147">了解详细信息...</a>
        </li>
        <li class="three">
            <h5>查找 Web 宿主</h5>
            你可以轻松找到所提供的功能和价格都适合你应用程序的 Web 宿主公司。
            <a href="http://go.microsoft.com/fwlink/?LinkId=245143">了解详细信息...</a>
        </li>
    </ol>
</asp:Content>
