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
            this.deptid = deptid;
            this.deptname = deptname;
            this.deptcontactname = deptcontactname;
            this.deptphone = deptphone;
            this.deptemail = deptemail;
        }

        public DepartmentModel(): this(0, "", "", 0, "")
        {
        }

        public int deptid { get; set; }

        public string deptname { get; set; }

        public string deptcontactname { get; set; }

        public int? deptphone { get; set; }

        public string deptemail { get; set; }

    }
}