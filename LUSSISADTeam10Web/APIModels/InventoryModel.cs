using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class InventoryModel
    {
        public InventoryModel(int invid, int itemid, string itemDescription, int stock, int? reorderLevel, int? reorderQty, string categoryname, string uom,int catid)
        {
            CatId = catid;
            Invid = invid;
            Itemid = itemid;
            ItemDescription = itemDescription;
            Stock = stock;
            ReorderLevel = reorderLevel;
            ReorderQty = reorderQty;
            CategoryName = categoryname;
            UOM = uom;
        }

        public InventoryModel() : this(0, 0, "", 0, 0, 0, "", "",0) { }
        public int Invid { get; set; }
        public int Itemid { get; set; }
        public string ItemDescription { get; set; }
        public string CategoryName { get; set; }
        public string UOM { get; set; }
        public int Stock { get; set; }
        public int? ReorderLevel { get; set; }
        public int? ReorderQty { get; set; }
        public int CatId { get; set; }
    }
}