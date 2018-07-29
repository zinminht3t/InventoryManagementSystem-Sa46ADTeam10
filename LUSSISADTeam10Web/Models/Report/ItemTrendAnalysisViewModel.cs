using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Report
{
    public class ItemTrendAnalysisViewModel
    {

        public string DepartmentName { get; set; }
        public string Item_Name { get; set; }
        public int? Item_Usage { get; set; }
        public int Deptid { get; set; }

        public int Itemid { get; set; }

        public int? Monthofreq { get; set; }

        public int? Yearofreq { get; set; }

        public int d1 { get; set; }

        public int d2 { get; set; }
        public int d3 { get; set; }

        public string d1Name { get; set; }

        public string d2Name { get; set; }

        public string d3Name { get; set; }


        public int month { get; set; }
        public List<ItemTrendDetailViewModel> itd { get; set; }



        public class ItemTrendDetailViewModel
        {
            public string DepartmentName { get; set; }
            public string Item_Name { get; set; }
            public int? Item_Usage { get; set; }
            public int Deptid { get; set; }

            public int Itemid { get; set; }

            public int? Monthofreq { get; set; }

            public int? Yearofreq { get; set; }
        }
    }
}