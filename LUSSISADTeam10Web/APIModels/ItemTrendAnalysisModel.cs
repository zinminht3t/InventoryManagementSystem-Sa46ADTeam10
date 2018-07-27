using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class ItemTrendAnalysisModel
    {
        public ItemTrendAnalysisModel(string deptname, string description, int? qty, int deptid, int itemid, int? monofreq , int? yearofreq)
        {
            this.DepartmentName = deptname;
            this.Item_Name = description;
            this.Item_Usage = qty;
            this.Deptid = deptid;
            this.Itemid = itemid;
            this.Monthofreq = monofreq;
            this.Yearofreq = yearofreq;
    
        }

        public  ItemTrendAnalysisModel() :this("","",null,0,0,null,null) {}

        public string DepartmentName { get; set; }
        public string Item_Name { get; set; }
        public int? Item_Usage { get; set; }
        public int Deptid { get; set; }

        public int Itemid { get; set; }

        public int? Monthofreq { get; set; }

        public int? Yearofreq { get; set; }

        
    }
}