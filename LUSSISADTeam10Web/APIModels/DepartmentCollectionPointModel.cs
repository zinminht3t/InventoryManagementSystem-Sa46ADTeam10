using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class DepartmentCollectionPointModel
    {
        public DepartmentCollectionPointModel(int deptCpID, int deptID, string deptName, int cpID, int status, string cpName, string cpLocation)
        {
            DeptCpID = deptCpID;
            DeptID = deptID;
            DeptName = deptName;
            CpID = cpID;
            Status = status;
            CpName = cpName;
            CpLocation = cpLocation;
        }

        public DepartmentCollectionPointModel() : this(0, 0, "", 0, 0, "", "") { }

        public int DeptCpID { get; set; }
        public int DeptID { get; set; }
        public String DeptName { get; set; }
        public int CpID { get; set; }
        public int Status { get; set; }
        public String CpName { get; set; }
        public String CpLocation { get; set; }


    }
}