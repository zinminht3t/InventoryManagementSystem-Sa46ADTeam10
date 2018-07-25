using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Clerk
{
    public class OutReqDetailViewModel
    {
        public OutReqDetailViewModel(int outReqId, int itemId, string description, string categoryName, string uOM, int qty)
        {
            OutReqId = outReqId;
            ItemId = itemId;
            Description = description;
            CategoryName = categoryName;
            UOM = uOM;
            Qty = qty;
        }

        public OutReqDetailViewModel() { }
        public int OutReqId { get; set; }
        public int ItemId { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string UOM { get; set; }
        public int Qty { get; set; }
    }
}