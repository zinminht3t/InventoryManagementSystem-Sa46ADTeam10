using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class OutstandingReqDetailModel
    {
        public OutstandingReqDetailModel
            (int OutReqId, int ItemId, string Desc, int Qty)
        {
            this.OutReqId = OutReqId;
            this.ItemId = ItemId;
            this.Description = Desc;
            this.Qty = Qty;
        }

        public OutstandingReqDetailModel()
            : this(0, 0, "", 0) { }

        public int OutReqId { get; set; }
        public int ItemId { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
    }
}