using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class ItemModel
    {
        public ItemModel(int itemid, int catid, string name, string description, string uom)
        {
            this.Itemid = itemid;
            this.Catid = catid;
            this.CatName = name;
            this.Description = description;
            this.Uom = uom;
        }
        public ItemModel():this(0, 0, "", "", "") { }
        public int Itemid { get; set; }
        public int Catid { get; set; }
        public string CatName { get; set; }
        public string Description { get; set; }
        public string Uom { get; set; }
    }
}