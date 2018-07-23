using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class OrderByDepartmentModel
    {
        public OrderByDepartmentModel(int? qty, string deptname)
        {
            this.Qty = qty;
            this.Departmentname = Departmentname;
        }

        public int? Qty { get; set; }
        public string Departmentname { get; set; }
    }
}