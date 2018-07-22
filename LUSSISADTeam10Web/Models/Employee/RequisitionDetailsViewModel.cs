using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Employee
{
    public class RequisitionDetailsViewModel
    {
        public RequisitionDetailsViewModel(int reqid, int itemid, string itemname, int qty, string categoryname, string uom, int stock)
        {
            this.Reqid = reqid;
            this.Itemid = itemid;
            this.Qty = qty;
            this.Itemname = itemname;
            this.CategoryName = categoryname;
            this.UOM = uom;
            this.Stock = stock;
        }

        public RequisitionDetailsViewModel() : this(0, 0, "", 0, "", "", 0)
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