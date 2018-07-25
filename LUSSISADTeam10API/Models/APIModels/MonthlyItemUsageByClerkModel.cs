using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class MonthlyItemUsageByClerkModel
    {

        public MonthlyItemUsageByClerkModel(string description,int? qty, int? podate,int? Year, string supname,int supid)
        {
            this.Description = description;
            this.Qty = qty;
            this.Podate = podate;
            this.Year = Year;
            this.Supname = supname;
            this.Supid = supid;
        }
        public string Description { get; set; }
        public int? Qty { get; set; }

        public int? Podate { get; set; }
        public int? Year { get; set; }
        public string Supname { get; set; }

        public int Supid { get; set; }

    }
}