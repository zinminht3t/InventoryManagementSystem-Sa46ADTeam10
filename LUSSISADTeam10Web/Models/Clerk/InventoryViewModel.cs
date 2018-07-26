using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Clerk
{
    public class InventoryViewModel
    {
        public int Invid { get; set; }
        public int Itemid { get; set; }
        public string ItemDescription { get; set; }
        public int Stock { get; set; }
        public int? ReorderLevel { get; set; }
        public int? ReorderQty { get; set; }
       
        public string UOM { get; set; }

        public int CatId { get; set; }
        public string CategoryName { get; set; }



    }


}