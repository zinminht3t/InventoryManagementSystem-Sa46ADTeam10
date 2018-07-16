using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class PurchaseOrderDetailModel
    {
        public int PoId { get; set; }
        public int Itemid { get; set; }
        public int ItemDescription { get; set; }
        public int Qty { get; set; }
        public int DelivQty { get; set; }
    }
}