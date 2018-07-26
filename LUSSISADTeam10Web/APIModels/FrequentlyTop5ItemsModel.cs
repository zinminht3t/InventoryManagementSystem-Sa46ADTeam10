using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class FrequentlyTop5ItemsModel
    {
        public FrequentlyTop5ItemsModel(int itemid,string description,int? qty)
        {
            this.Itemid = itemid;
            this.Description = description;
            this.Qty = qty;

        }
        public FrequentlyTop5ItemsModel() : this(0, "", 0) { }
        public int Itemid { get; set; }

        public string Description { get; set; }

        public int? Qty { get; set; }

    }
}