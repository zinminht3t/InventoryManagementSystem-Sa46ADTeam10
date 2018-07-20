using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Clerk
{
    public class ProcessRequisitionViewModel
    {
        public int ReqID { get; set; }

        public List<ReqItem> ReqItems{get;set;}
    }

    public class ReqItem
    {
        public int ItemID { get; set; }
        public int Qty { get; set; }
        public String CategoryName { get; set; }
        public String ItemName { get; set; }
        public int Stock { get; set; }
        public String UOM { get; set; }
        public int ApproveQty { get; set; }
    }
}