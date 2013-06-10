using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using CustomAuthorize.Models;

namespace CustomAuthorize.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// logger
        /// </summary>
        readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Login/Authenticate

        /// <summary>
        /// ログイン認証処理
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult Authenticate(string systemId, string password)
        {
            AccountManager am = new AccountManager();
            user u = am.GetUserBySystemId(systemId);
            JsonResult jr = new JsonResult();

            if (u != null)
            {
                jr.Data = new { auth = true, user_name = u.name, system_id = u.system_id };
                //認証OK
                FormsAuthentication.SetAuthCookie(u.system_id, false);
                HttpContext.Session.Add("USER_NAME", u.name);

                log.InfoFormat("Login: {0}", u.system_id);
            }
            else
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    //ログオフ
                    SignOut();
                }
                jr.Data = new { auth = false };
            }

            return jr;
        }

        //
        // GET: /Login/Logoff

        /// <summary>
        /// Logoff処理
        /// </summary>
        /// <returns></returns>
        public ActionResult Logoff()
        {
            //認証済みの場合はサインアウト
            SignOut();

            return new EmptyResult();
        }

        /// <summary>
        /// サインアウト処理
        /// </summary>
        private void SignOut()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                string userName = HttpContext.User.Identity.Name;
                log.InfoFormat("Logoff: {0}", userName);

                FormsAuthentication.SignOut();
                //HttpContext.Session.Clear();
            }
        }

    }
}
