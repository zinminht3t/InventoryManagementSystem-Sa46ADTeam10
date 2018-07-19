using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class DisbursementDetailsModel
    {
        public DisbursementDetailsModel(int disid , int itemid ,String itemname , int qty, string categoryname, string uom) {
            this.Disid = disid;
            this.Itemid = itemid;
            this.Itemname = itemname;
            this.Qty = qty;
            this.CategoryName = categoryname;
            this.UOM = uom;


        }
        public DisbursementDetailsModel() : this(0, 0, "", 0, "", "")
        {
        }

        public int Disid { get; set;}
        public int Itemid { get; set; }
        public String Itemname { get; set; }
        public String CategoryName { get; set; }
        public String UOM { get; set; }
        public int Qty { get; set; }



    }
}