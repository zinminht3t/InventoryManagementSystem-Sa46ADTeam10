using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class PurchaseOrderDetailModel
    {
        public PurchaseOrderDetailModel(int poId, int itemid, String itemDescription, int qty, int delivQty, string categoryname, string uom, double? p)
        {
            PoId = poId;
            Itemid = itemid;
            ItemDescription = itemDescription;
            Qty = qty;
            DelivQty = delivQty;
            CategoryName = categoryname;
            UOM = uom;
            Price = p;
        }

        public PurchaseOrderDetailModel() : this(0, 0, "", 0, 0, "", "", 0) { }

        public int PoId { get; set; }
        public int Itemid { get; set; }
        public String ItemDescription { get; set; }
        public String CategoryName { get; set; }
        public String UOM { get; set; }
        public int Qty { get; set; }
        public int DelivQty { get; set; }
        public double? Price { get; set; }
    }
}