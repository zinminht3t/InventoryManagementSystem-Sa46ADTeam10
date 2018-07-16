namespace LUSSISADTeam10Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserModel
    {
        public UserModel(int userid, string username, string email, string password, int role, string fullname, int deptid, string deptname)
        {
            this.Userid = userid;
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.Role = role;
            this.Fullname = fullname;
            this.Deptid = deptid;
            this.Deptname = deptname;
        }

        public UserModel(): this(0, "", "", "", 0, "", 0, "") { }
        public int Userid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string Fullname { get; set; }
        public int Deptid { get; set; }
        public string Deptname { get; set; }


    }
}
