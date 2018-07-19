using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10API.Models.DBModels;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class RequisitionDetailsModel
    {
        public RequisitionDetailsModel(int reqid, int itemid, string itemname , int qty) {
            this.Reqid = reqid;
            this.Itemid = itemid;
            this.Qty = qty;
            this.Itemname = itemname;

        }

        public RequisitionDetailsModel() : this(0,  0, "",0) 
        {
        }

        public int Reqid { get; set; }
        public int Itemid { get; set; }
        public int Qty { get; set; }
        public String Itemname { get; set; }
    }
}