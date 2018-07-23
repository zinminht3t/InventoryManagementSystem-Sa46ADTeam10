using LUSSISADTeam10API.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class OutstandingItemModel
    {
        public OutstandingItemModel
            (int ItemId, string Description, string Uom,
            int CatId, string CatName, int Total, string shelflocation, string shelflevel)
        {
            this.ItemId = ItemId;
            this.Description = Description;
            this.Uom = Uom;
            this.CatId = CatId;
            this.CatName = CatName;
            this.ShelfLocaition = shelflocation;
            this.ShelfLevel = shelflevel;
            this.Total = Total;
        }

        public OutstandingItemModel() : this(0, "", "", 0, "", 0, "", "") { }

        public int ItemId { get; set; }
        public string Description { get; set; }
        public string Uom { get; set; }
        public int CatId { get; set; }
        public string CatName { get; set; }
        public string ShelfLocaition { get; set; }
        public string ShelfLevel { get; set; }
        public int Total { get; set; }
    }
}