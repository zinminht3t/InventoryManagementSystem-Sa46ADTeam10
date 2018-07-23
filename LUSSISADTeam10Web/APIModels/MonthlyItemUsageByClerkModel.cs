using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class MonthlyItemUsageByClerkModel
    {

        public MonthlyItemUsageByClerkModel(string description,int? qty, int? podate,string supname)
        {
            this.Description = description;
            this.Qty = qty;
            this.Podate = podate;
            this.Supname = supname;
        }
        public string Description { get; set; }
        public int? Qty { get; set; }

        public int? Podate { get; set; }

        public string Supname { get; set; }

    }
}