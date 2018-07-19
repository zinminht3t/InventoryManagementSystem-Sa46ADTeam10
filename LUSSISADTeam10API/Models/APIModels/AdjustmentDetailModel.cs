using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class AdjustmentDetailModel
    {
        public AdjustmentDetailModel(int adjid, int itemid, string itemdescription, int adjustedqty, string reason, string categoryname, string uom)
        {
            this.Adjid = adjid;
            this.Itemid = itemid;
            this.Itemdescription = itemdescription;
            this.Adjustedqty = adjustedqty;
            this.Reason = reason;
            this.CategoryName = categoryname;
            this.UOM = uom;
        }
        public AdjustmentDetailModel() : this(0, 0, "", 0, "", "", "")
        {
        }
        public int Adjid { get; set; }
        public int Itemid { get; set; }
        public string Itemdescription { get; set; }
        public string CategoryName { get; set; }
        public string UOM { get; set; }
        public int Adjustedqty { get; set; }
        public string Reason { get; set; }
    }
}