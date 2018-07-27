using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Report
{
    public class MonthlyItemUsageViewModel
    {
        public string Item { get; set; }

        public int? UsageItem { get; set; }

        public int? MonthName { get; set; }

        public int? year { get; set; }

        public string supname { get; set; }
        public int supid { get; set; }

        public int supplier1 { get; set; }

        public int supplier2 { get; set; }

        public int supplier3 { get; set; }

        public List<MonthlyItemResultUsageViewModel> mtu { get; set; }
    }

    public class MonthlyItemResultUsageViewModel
    {
        public string Item { get; set; }

        public int? UsageItem { get; set; }

        public int? MonthName { get; set; }

        public int? year { get; set; }

        public string supname { get; set; }
        public int supid { get; set; }
    }
}