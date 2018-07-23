using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class RequsitionListReportModel
    {
        public RequsitionListReportModel(DateTime? reqdate, string status, int deptid)
        {

            this.Reqdate = reqdate;
            this.Status = status;
            this.Deptid = deptid;
        }
        public DateTime? Reqdate { get; set; }

        public string Status { get; set; }

        public int Deptid { get; set; }





    }
}