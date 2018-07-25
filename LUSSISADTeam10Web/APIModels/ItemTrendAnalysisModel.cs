using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10web.Models.APIModels
{
    public class ItemTrendAnalysisModel
    {
        public ItemTrendAnalysisModel(string deptname, string description, int? qty, int deptid, int itemid, int? monofreq, int? yearofreq)
        {
            this.Deptname = deptname;
            this.Description = description;
            this.Qty = qty;
            this.Deptid = deptid;
            this.Itemid = itemid;
            this.Monthofreq = monofreq;
            this.Yearofreq = yearofreq;

        }

        public string Deptname { get; set; }
        public string Description { get; set; }
        public int? Qty { get; set; }
        public int Deptid { get; set; }

        public int Itemid { get; set; }

        public int? Monthofreq { get; set; }

        public int? Yearofreq { get; set; }


    }
}