using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomAuthorize.Models
{
    [PetaPoco.TableName("users")]
    [PetaPoco.PrimaryKey("id")]
    public class user
    {
        public int id { get; set; }
        public string system_id { get; set; }
        public string name { get; set; }

        // TODO roleのデータを保持させる
        //[PetaPoco.Ignore]
        //public List<role> roles { get; set; }
    }
}