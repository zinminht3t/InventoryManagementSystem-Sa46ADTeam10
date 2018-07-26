using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Clerk
{
    public class SupplierItemImportViewModel
    {
        public SupplierItemImportViewModel
           (int SupId, string SupName, int ItemId,
           string Description, double Price, string Uom, string category)
        {
            this.SupId = SupId;
            this.SupName = SupName;
            this.ItemId = ItemId;
            this.Description = Description;
            this.Price = Price;
            this.Uom = Uom;
            this.CategoryName = category;
        }

        public SupplierItemImportViewModel() :
            this(0, "", 0, "", 0.0, "", "")
        {
        }

        public int SupId { get; set; }

        public int ItemId { get; set; }

        public string SupName { get; set; }
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Uom { get; set; }
    }

}
