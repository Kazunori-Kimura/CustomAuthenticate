<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	メニュー
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="row-fluid">

    <div class="span2">
        <!--Sidebar content-->
        <div class="well sidebar-nav">
            <ul class="nav nav-list">
                <li class="active"><a href="#">メニュー</a></li>
                <li class="nav-header">カテゴリー</li>
                <li><a href="#">Category1</a></li>
                <li><a href="#">Category2</a></li>
                <li><a href="#">Category3</a></li>
                <li><a href="#">Category4</a></li>
                <li><a href="#">Category5</a></li>
                <li class="nav-header">データ取込み</li>
                <li><a href="#">取込処理</a></li>
                <li class="nav-header">管理者メニュー</li>
                <li><a href="#">ユーザー管理</a></li>
                <li><a href="#">操作ログ</a></li>
            </ul>
        </div>
    </div>

    <div class="span10">
        <!--Body content-->
        <p>左メニューより表示する開示情報を選択してください。</p>
    </div>

</div>
</asp:Content>
