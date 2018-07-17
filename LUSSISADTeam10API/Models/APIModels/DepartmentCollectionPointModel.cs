using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class DepartmentCollectionPointModel
    {

        public int DeptCpID { get; set; }
        public int DeptID { get; set; }
        public int CpID { get; set; }
        public int Active { get; set; }
    }
}