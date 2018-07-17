using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LUSSISADTeam10Web.Models.APIModels
{
    public class RequisitionDetailsModel
    {
        public RequisitionDetailsModel(int reqid, int itemid, string itemname , int qty) {
            this.reqid = reqid;
            this.itemid = itemid;
            this.qty = qty;
            this.itemname = itemname;

        }

        public RequisitionDetailsModel() : this(0,  0, "",0) 
        {
        }

        public int reqid { get; set; }
        public int itemid { get; set; }
        public int qty { get; set; }
        public String itemname { get; set; }
    }
}