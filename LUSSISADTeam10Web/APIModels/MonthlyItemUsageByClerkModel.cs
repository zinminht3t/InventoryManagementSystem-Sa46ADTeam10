using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class MonthlyItemUsageByClerkModel
    {
        public MonthlyItemUsageByClerkModel(string description, int? qty, int? podate, int? Year, string supname, int supid)
        {
            this.Item_ = description;
            this.UsageItem = qty;
            this.MonthName = podate;
            this.year = Year;
            this.supname = supname;
            this.supid = supid;
        }
        public MonthlyItemUsageByClerkModel() : this("", null, null, null, "", 0) { }

        public string Item_ { get; set; }

        public int? UsageItem { get; set; }

        public int? MonthName { get; set; }

        public int? year { get; set; }

        public string supname { get; set; }
        public int supid { get; set; }

    }
}