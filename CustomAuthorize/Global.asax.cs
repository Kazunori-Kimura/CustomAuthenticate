﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomAuthorize
{
    // メモ: IIS6 または IIS7 のクラシック モードの詳細については、
    // http://go.microsoft.com/?LinkId=9394801 を参照してください

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // ルート名
                "{controller}/{action}/{id}", // パラメーター付きの URL
                new { controller = "Login", action = "Index", id = UrlParameter.Optional } // パラメーターの既定値
                //new { controller = "Home", action = "Index", id = UrlParameter.Optional } // パラメーターの既定値
            );

        }

        protected void Application_Start()
        {
            //log4net設定ファイル読み込み
            string config = Server.MapPath(@"~\log4net.config");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(config));

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}