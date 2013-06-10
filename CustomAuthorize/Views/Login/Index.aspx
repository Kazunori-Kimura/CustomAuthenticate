<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE HTML>
<html lang="ja" >
<head id="Head1" runat="server">
    <link type="text/css" rel="Stylesheet" href="/Content/bootstrap.min.css" />
    <style type="text/css">
    body {
        padding-top: 40px;
        padding-bottom: 40px;
        background-color: #f5f5f5;
    }

    .form-signin {
        max-width: 400px;
        padding: 19px 29px 29px;
        margin: 0 auto 20px;
        background-color: #fff;
        border: 1px solid #e5e5e5;
        -webkit-border-radius: 5px;
        -moz-border-radius: 5px;
        border-radius: 5px;
        -webkit-box-shadow: 0 1px 2px rgba(0,0,0,.05);
        -moz-box-shadow: 0 1px 2px rgba(0,0,0,.05);
        box-shadow: 0 1px 2px rgba(0,0,0,.05);
    }
    .form-signin .form-signin-heading,
    .form-signin .checkbox {
        margin-bottom: 10px;
    }
    .form-signin input[type="text"],
    .form-signin input[type="password"] {
        font-size: 16px;
        height: auto;
        margin-bottom: 15px;
        padding: 7px 9px;
    }
    </style>
    <title>Login - CustomAuthorize</title>
</head>
<body>
    <div class="container">

        <form class="form-signin" onsubmit="return false;">
            <h1 class="form-signin-heading">CustomAuthorize</h1>
            <input type="text" id="txtSystemId" class="input-block-level" placeholder="System ID">
            <input type="password" id="txtPassword" class="input-block-level" placeholder="Password">
            <button id="btnLogin" class="btn btn-primary">LOGIN</button>
        </form>

        <div class="alert alert-error" id="alertLogin">
            ログインに失敗しました。<br />
            <span id="errorMessage">ログイン権限がありません。システム管理者にお問い合わせください。</span>
        </div>

    </div>

    <script type="text/javascript" src="/Scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="/Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#alertLogin").hide();

            /**
            * ログイン処理
            */
            $("#btnLogin").click(function () {
                authenticate();
            });
        });

        /**
         * 認証処理
         */
        function authenticate() {
            var id = $("#txtSystemId").val();
            var pwd = $("#txtPassword").val();

            $.post("/Login/Authenticate",
                { systemId: id, password: pwd },
                function (data) {
                    if (data.auth) {
                        //認証成功 -> Menuに遷移
                        window.location.href = "/Menu";
                        return false;
                    } else {
                        //認証失敗 -> alert表示
                        $("#alertLogin").show();
                        return false;
                    }
                } //end callback
            );
        }
    </script>
</body>
</html>
