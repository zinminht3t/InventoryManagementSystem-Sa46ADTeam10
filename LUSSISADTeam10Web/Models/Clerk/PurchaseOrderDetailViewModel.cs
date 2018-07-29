using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Clerk
{
    public class PurchaseOrderDetailViewModel
    {
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
        public List<string> SupplierNames { get; set; }
        public List<double> Prices { get; set; }
    }
}