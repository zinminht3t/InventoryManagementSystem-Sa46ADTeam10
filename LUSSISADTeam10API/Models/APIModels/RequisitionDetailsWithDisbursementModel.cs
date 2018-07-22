using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10API.Models.DBModels;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class RequisitionDetailsWithDisbursementModel
    {
        public RequisitionDetailsWithDisbursementModel(int reqid, int itemid, string itemname, int qty, string categoryname, string uom, int approvedqty)
        {
            this.Reqid = reqid;
            this.Itemid = itemid;
            this.Qty = qty;
            this.Itemname = itemname;
            this.CategoryName = categoryname;
            this.UOM = uom;
            this.ApprovedQty = approvedqty;

        }

        public RequisitionDetailsWithDisbursementModel() : this(0, 0, "", 0, "", "", 0)
        {
        }

        public int Reqid { get; set; }
        public int Itemid { get; set; }
        public int Qty { get; set; }
        public int ApprovedQty { get; set; }
        public String Itemname { get; set; }
        public String CategoryName { get; set; }
        public String UOM { get; set; }
    }
}