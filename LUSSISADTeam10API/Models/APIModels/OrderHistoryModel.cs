using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class OrderHistoryModel
    {
        public DateTime? reqdate { get; set; }
        public String deptname { get; set; }

        public String raisename { get; set; }

        public String approvename { get; set; }

        public int deptid { get; set; }

        public string status { get; set; }
    }
}