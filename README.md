
[ASP.NET MVC] Authorizeフィルタのカスタマイズ
===

プロジェクトの作成
---

プロジェクト名： CustomAuthorize

NuGetで必要なパッケージを追加

- Npgsql
- PetaPoco.Core
- log4net
- Bootstrap
  - jQuery 1.9.1


log4net設定ファイル
---

- log4net.config


Global.asax.cs
---

1. 初期表示パスを /Login/Index に変更
2. Application_Start() にて設定ファイル読み込み

string config = Server.MapPath(@"~\log4net.config");
log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(config));


Controllerの作成
---

- LoginController  
とりあえず空っぽにしておく
- MenuController  
未認証ではアクセスできないように classに [Authorize] を設定


Viewの作成
---

### マスターページを作成

#### MVC2 ビューマスターページを Views/Shared に追加

- Site.Master

表示名は Session["USER_NAME"] から取得
ログアウトボタン押下で LoginController/Logoff に Ajax で問い合わせ
結果に関わらず Login画面に遷移


#### スタイルシートを Contents に追加

- style.css


### Login View を作成

- LoginController.csを開く
- Index Methodを右クリック → ビューの追加 を選択  
Login/IndexはSite.Masterを使用しない


- Login/Index.aspx


LOGINボタン押下で LoginController/Authenticate に Ajax で問い合わせ
認証結果を受けて、メニュー画面に遷移


### Menu View を作成


Modelの作成
---

### user.cs を作成


### AccountManager.cs を作成


LoginController 実装
---

### LoginController.cs

- LoginController/Authenticate : ログイン認証を行う
- LoginController/Logoff : ログオフ処理を行う

