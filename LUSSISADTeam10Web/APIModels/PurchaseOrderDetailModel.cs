using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class PurchaseOrderDetailModel
    {
        public PurchaseOrderDetailModel(int poId, int itemid, String itemDescription, int qty, int? delivQty)
        {
            PoId = poId;
            Itemid = itemid;
            ItemDescription = itemDescription;
            Qty = qty;
            DelivQty = delivQty;
        }

        public PurchaseOrderDetailModel() : this(0, 0, "", 0, 0) { }

        public int PoId { get; set; }
        public int Itemid { get; set; }
        public String ItemDescription { get; set; }
        public int Qty { get; set; }
        public int? DelivQty { get; set; }
    }
}