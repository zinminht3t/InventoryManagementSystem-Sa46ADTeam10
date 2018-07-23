using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class ReportsModel
    {
        public ReportsModel (string name, string description, int qty , string uom,int deptid,string deptname)
        {
            this.Description = description;
            this.Name = name;
            this.Qty = qty;
            this.Uom = uom;
            this.Deptid = deptid;
            this.Deptname = deptname;
        }


        public string Description { get; set; }

        public string Name { get; set; }


        public string Deptname { get; set; }

        public int Deptid { get; set; }

        

      

        public int Qty { get; set; }

        public string Uom { get; set; }
    }
}