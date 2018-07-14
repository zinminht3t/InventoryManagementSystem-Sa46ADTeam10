using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class ItemModel
    {
        public ItemModel(int itemid, int catid, string name, string description, string uom)
        {
            this.itemid = itemid;
            this.catid = catid;
            this.name = name;
            this.description = description;
            this.uom = uom;
        }
        public ItemModel():this(0, 0, "", "", "") { }
        public int itemid { get; set; }
        public int catid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string uom { get; set; }
    }
}