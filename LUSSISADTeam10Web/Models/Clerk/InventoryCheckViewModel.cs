using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Clerk
{
    public class InventoryCheckViewModel
    {

        
        public List<Inventory> Invs { get; set; }

        public List<int> InvIDs { get; set; }
    }

    public class Inventory
    {
        public Inventory(int invtid, string cat, int itemID,string itemdes, int? qty, string uom, string shelf, string level)
        {
            InventoryId = invtid;
            Category = cat;
            ItemID = itemID;
            ItemDescription = itemdes;
            Shelf = shelf;
            Level = level;
            Stock = qty;
            UOM = uom;
            Current = 0;
        }
        public int InventoryId { get; set; }
        public string Category { get; set; }
        public int ItemID { get; set; }
        public string ItemDescription { get; set; }
        public string Shelf { get; set; }
        public string Level { get; set; }
        public int? Stock { get; set; }
        public string UOM { get; set; }
        public int Current { get; set; }
    }
}