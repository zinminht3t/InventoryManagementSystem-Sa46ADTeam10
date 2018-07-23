using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class OrderHistoryModel
    {
        public OrderHistoryModel (DateTime? reqdate,string deptname,string raisename,string status,int deptid,string cpname)
        {
            this.Reqdate = reqdate;
            this.Deptname = deptname;
            this.Raisename = raisename;
            this.Deptid = deptid;
            this.Status = status;
            this.Cpname = Cpname;
        }

        public OrderHistoryModel() :this (null,"","","",0,"")
        {

        }



        public DateTime? Reqdate { get; set; }
        public string Deptname { get; set; }

        public string Raisename { get; set; }

        public string Cpname { get; set; }
        

        public int Deptid { get; set; }

        public string Status { get; set; }
    }
}