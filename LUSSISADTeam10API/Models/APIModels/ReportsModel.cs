using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class ReportsModel
    {
        public ReportsModel (string name, string description, int qty , string uom)
        {
            this.Description = description;
            this.Name = name;
            this.Qty = qty;
            this.Uom = uom;
            //this.Reqdate = reqdate;
            //this.Status = status;
            //this.Deptid = deptid;
        }


        public string Description { get; set; }

        public string Name;


    

        public int Qty { get; set; }

        public string Uom { get; set; }
    }
}