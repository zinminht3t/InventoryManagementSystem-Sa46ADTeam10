using LUSSISADTeam10Web.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class OutstandingItem
    {
        public OutstandingItem
            (int ItemId, string Description, string Uom,
            int CatId, string CatName, int Total)
        {
            this.ItemId = ItemId;
            this.Description = Description;
            this.Uom = Uom;
            this.CatId = CatId;
            this.CatName = CatName;
            this.Total = Total;
        }

        public OutstandingItem() : this(0, "", "", 0, "", 0) { }

        public int ItemId { get; set; }
        public string Description { get; set; }
        public string Uom { get; set; }
        public int CatId { get; set; }
        public string CatName { get; set; }
        public int Total { get; set; }
    }
}