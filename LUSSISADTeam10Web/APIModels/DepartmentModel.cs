using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class DepartmentModel
    {
        public DepartmentModel(int deptid, string deptname, string deptcontactname, int? deptphone, string deptemail)
        {
            this.Deptid = deptid;
            this.Deptname = deptname;
            this.Deptcontactname = deptcontactname;
            this.Deptphone = deptphone;
            this.Deptemail = deptemail;
        }

        public DepartmentModel(): this(0, "", "", 0, "")
        {
        }

        public int Deptid { get; set; }

        public string Deptname { get; set; }

        public string Deptcontactname { get; set; }

        public int? Deptphone { get; set; }

        public string Deptemail { get; set; }

    }
}