using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class RequisitionDetailsModel
    {
        public RequisitionDetailsModel(int reqid, int itemid, string itemname, int qty, string categoryname, string uom)
        {
            this.Reqid = reqid;
            this.Itemid = itemid;
            this.Qty = qty;
            this.Itemname = itemname;
            this.CategoryName = categoryname;
            this.UOM = uom;

        }

        public RequisitionDetailsModel() : this(0, 0, "", 0, "", "")
        {
        }

        public int Reqid { get; set; }
        public int Itemid { get; set; }
        public int Qty { get; set; }
        public String Itemname { get; set; }
        public String CategoryName { get; set; }
        public String UOM { get; set; }
    }
}