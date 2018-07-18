using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class AdjustmentDetailModel
    {
        public AdjustmentDetailModel(int adjid, int itemid, string itemdescription, int? adjustedqty, string reason)
        {
            this.adjid = adjid;
            this.itemid = itemid;
            this.itemdescription = itemdescription;
            this.adjustedqty = adjustedqty;
            this.reason = reason;
        }
        public AdjustmentDetailModel(): this(0, 0,"", 0, "")
        {
        }
        public int adjid { get; set; }
        public int itemid { get; set; }
        public string itemdescription { get; set; }
        public int? adjustedqty { get; set; }
        public string reason { get; set; }
    }
}