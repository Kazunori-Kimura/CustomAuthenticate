using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace CustomAuthorize.Models
{
    public class AccountManager
    {
        /// <summary>
        /// logger
        /// </summary>
        readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Database Connection
        /// </summary>
        private PetaPoco.Database db = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AccountManager()
        {
            try
            {
                //Web.configからConnectionStringを取得
                string cs = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString();
                //PetaPoco.Database
                db = new PetaPoco.Database(cs, Npgsql.NpgsqlFactory.Instance);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// system_idを元にユーザー情報を取得する
        /// </summary>
        /// <param name="system_id"></param>
        /// <returns>user</returns>
        public user GetUserBySystemId(string system_id)
        {
            log.Debug(string.Format("GetUserBySystemId({0})", system_id));

            var sql = PetaPoco.Sql.Builder.Append("select id, system_id, name")
                .Append("from users")
                .Append("where system_id=@systemId", new { systemId = system_id });

            var users = db.Fetch<user>(sql);

            user u = null;
            if (users.Count > 0)
            {
                u = users[0];
                //TODO roleの情報を取得する
                log.Debug(string.Format("UserName= {0}", u.name));
            }

            return u;
        }


    }
}