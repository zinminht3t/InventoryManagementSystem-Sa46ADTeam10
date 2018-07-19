using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Clerk
{
    public class InventoryCheckViewModel
    {
        public InventoryCheckViewModel (int invtid, string cat, string itemdes, int? qty, string uom)
        {
            InventoryId = invtid;
            Category = cat;
            ItemDescription = itemdes;
            Stock = qty;
            UOM = uom;
        }
        public int InventoryId { get; set; }
        public string Category { get; set; }
        public string ItemDescription { get; set; }
        public int? Stock { get; set; }
        public string UOM { get; set; }
    }
}