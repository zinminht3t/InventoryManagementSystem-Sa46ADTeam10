using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Clerk
{
    public class OutstandingReqDetailViewModel
    {
        public OutstandingReqDetailViewModel
            (int OutReqId, int ItemId, string Desc, int Qty, string categoryname, string uom)
        {
            this.OutReqId = OutReqId;
            this.ItemId = ItemId;
            this.Description = Desc;
            this.Qty = Qty;
            this.CategoryName = categoryname;
            this.UOM = uom;
        }

        public OutstandingReqDetailViewModel()
            : this(0, 0, "", 0, "", "") { }

        public int OutReqId { get; set; }
        public int ItemId { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string UOM { get; set; }
        public int Qty { get; set; }
    }
}