using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class InventoryDetailWithStatus
    {
        public InventoryDetailWithStatus(int invid, int itemid, string itemDescription, int? stock, int? reorderLevel, int? reorderQty,
           int catid, string catName, string description, string uom, bool recommendedorderqty, string sl, string sle)
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
            IsPending = recommendedorderqty;
            ShelfLocation = sl;
            ShelfLevel = sle;
        }
        public InventoryDetailWithStatus() : this(0, 0, "", 0, 0, 0, 0, "", "", "", false, "", "") { }
        public int Invid { get; set; }
        public int Itemid { get; set; }
        public string ItemDescription { get; set; }
        public int? Stock { get; set; }
        public int? ReorderLevel { get; set; }
        public int? ReorderQty { get; set; }
        public int Catid { get; set; }
        public string CatName { get; set; }
        public string Description { get; set; }
        public string ShelfLocation { get; set; }
        public string ShelfLevel { get; set; }
        public string Uom { get; set; }
        public bool IsPending { get; set; }
    }
}
