using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10API.Models.DBModels;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class RequisitionDetailsModel
    {
        public RequisitionDetailsModel(int reqid, int itemid, string itemname, int qty, string categoryname, string uom, int stock)
        {
            this.Reqid = reqid;
            this.Itemid = itemid;
            this.Qty = qty;
            this.Itemname = itemname;
            this.CategoryName = categoryname;
            this.UOM = uom;
            this.Stock = stock;

        }

        public RequisitionDetailsModel() : this(0, 0, "", 0, "", "", 0)
        {
        }

        public int Reqid { get; set; }
        public int Itemid { get; set; }
        public int Qty { get; set; }
        public int Stock { get; set; }
        public String Itemname { get; set; }
        public String CategoryName { get; set; }
        public String UOM { get; set; }
    }
}