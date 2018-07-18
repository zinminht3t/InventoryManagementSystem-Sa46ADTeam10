using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class SupplierItemModel
    {
        public SupplierItemModel
            (int SupId, string SupName, int ItemId,
            string Description, double Price, string Uom)
        {
            this.SupId = SupId;
            this.SupName = SupName;
            this.ItemId = ItemId;
            this.Description = Description;
            this.Price = Price;
            this.Uom = Uom;
        }

        public SupplierItemModel() :
            this(0, "", 0, "", 0.0, "")
        {
        }

        public int SupId { get; set; }

        public int ItemId { get; set; }

        public string SupName { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Uom { get; set; }
    }
}