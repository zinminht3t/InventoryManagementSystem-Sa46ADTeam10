namespace LUSSISADTeam10API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class UserModel
    {
        public UserModel(int userid, string username, string email, string password, int role, string fullname, int deptid, string deptname)
        {
            this.userid = userid;
            this.username = username;
            this.email = email;
            this.password = password;
            this.role = role;
            this.fullname = fullname;
            this.deptid = deptid;
            this.deptname = deptname;
        }

        public int userid { get; set; }

        public string username { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public int role { get; set; }

        public string fullname { get; set; }

        public int deptid { get; set; }
        public string deptname { get; set; }


    }
}
