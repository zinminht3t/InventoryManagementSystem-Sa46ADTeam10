using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class InventoryDetailModel
    {
        public InventoryDetailModel(int invid, int itemid, string itemDescription, int? stock, int? reorderLevel, int? reorderQty,
            int catid, string catName, string description, string uom, int? recommendedorderqty)
        {
            Invid = invid;
            Itemid = itemid;
            ItemDescription = itemDescription;
            Stock = stock;
            ReorderLevel = reorderLevel;
            ReorderQty = reorderQty;
            Catid = catid;
            CatName = catName;
            Description = description;
            Uom = uom;
            RecommendedOrderQty = recommendedorderqty;
        }
        public InventoryDetailModel() : this(0, 0, "", 0, 0, 0, 0, "", "", "", 0) { }
        public int Invid { get; set; }
        public int Itemid { get; set; }
        public string ItemDescription { get; set; }
        public int? Stock { get; set; }
        public int? ReorderLevel { get; set; }
        public int? ReorderQty { get; set; }
        public int Catid { get; set; }
        public string CatName { get; set; }
        public string Description { get; set; }
        public string Uom { get; set; }
        public int? RecommendedOrderQty { get; set; }
    }
}
