using LUSSISADTeam10API.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class BreakdownByDepartmentModel
    {
        public int ItemID { get; set; }

        public string ItemDescription { get; set; }
        public List<BreakDown> BDList { get; set; }

    }

    public class BreakDown
    {
        public int DeptID;

        public string DeptName;

        public int Qty;
    }
}