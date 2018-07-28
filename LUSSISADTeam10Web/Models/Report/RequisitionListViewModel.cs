using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Report
{
    public class RequisitionListViewModel
    {

        public int deptid { get; set; }
        public string status { get; set; }

        public DateTime? reqdate { get; set; }

        public DateTime startdate { get; set; }

        public DateTime enddate { get; set; }

        public List<RequisitionDetailViewModel> rd { get; set; }

        
    }

    public class RequisitionDetailViewModel
    {
        public int deptid { get; set; }
        public string status { get; set; }

        public DateTime? reqdate { get; set; }

        public DateTime startdate { get; set; }

        public DateTime enddate { get; set; }

    }
}