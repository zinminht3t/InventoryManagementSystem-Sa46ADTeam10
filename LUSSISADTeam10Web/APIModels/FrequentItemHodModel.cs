using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class FrequentItemHodModel
    {
        public FrequentItemHodModel(int qty,string description)
        {
            Quantity = qty;
            this.description = description;

        }
        public FrequentItemHodModel() : this(0, "") { }
        public int Quantity { get; set; }
        public string description { get; set; }

    }
}