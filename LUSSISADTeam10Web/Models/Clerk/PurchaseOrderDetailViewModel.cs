using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Clerk
{
    public class PurchaseOrderDetailViewModel
    {
        public PurchaseOrderDetailViewModel(int poId, int itemid, 
            String itemDescription, int qty, int delivQty, string categoryname, string uom, int s, double p, List<int> sids, List<double> ps)
        {
            PoId = poId;
            Itemid = itemid;
            ItemDescription = itemDescription;
            Qty = qty;
            DelivQty = delivQty;
            CategoryName = categoryname;
            UOM = uom;
            SupplierID = s;
            Price = p;
            SupplierIDs = sids;
            Prices = ps;
        }

        public PurchaseOrderDetailViewModel() : this(0, 0, "", 0, 0, "", "", 0, 0,  new List<int>(), new List<double>()) { }

        public int PoId { get; set; }
        public int Itemid { get; set; }
        public int SupplierID { get; set; }
        public double Price { get; set; }
        public double LowestPrice { get; set; }
        public String title { get; set; }
        public String ItemDescription { get; set; }
        public String CategoryName { get; set; }
        public String UOM { get; set; }
        public int Qty { get; set; }
        public int DelivQty { get; set; }
        public List<int> SupplierIDs { get; set; }
        public List<double> Prices { get; set; }
    }
}