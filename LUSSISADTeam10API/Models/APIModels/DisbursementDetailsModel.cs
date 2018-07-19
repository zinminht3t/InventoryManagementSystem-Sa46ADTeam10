using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class DisbursementDetailsModel
    {
        public DisbursementDetailsModel(int disid , int itemid ,String itemname , int qty  ) {
            this.Disid = disid;
            this.Itemid = itemid;
            this.Itemname = itemname;
            this.Qty = qty;


        }
        public DisbursementDetailsModel() : this(0, 0, "", 0)
        {
        }

        public int Disid { get; set;}
        public int Itemid { get; set; }
        public String Itemname { get; set; }
        public int Qty { get; set; }



    }
}