using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class DisbursementDetailsModel
    {
        public DisbursementDetailsModel(int disid , int itemid ,String itemname , int qty  ) {
            this.disid = disid;
            this.itemid = itemid;
            this.itemname = itemname;
            this.qty = qty;


        }
        public DisbursementDetailsModel() : this(0, 0, "", 0)
        {
        }

        public int disid { get; set;}
        public int itemid { get; set; }
        public String itemname { get; set; }
        public int qty { get; set; }



    }
}