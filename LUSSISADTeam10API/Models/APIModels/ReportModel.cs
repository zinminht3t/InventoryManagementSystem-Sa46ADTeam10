using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class ReportModel
    {
        public ReportModel(string description,string name, int qty, string uom)
        {
            this.Name = name;
            this.Description = description;
            this.Qty = qty;
            this.Uom = uom;
        }

        public string Description { get; set; }
        public string Name  {get;set; }

        public int Qty { get; set; }

        public string Uom { get; set; }
    }
}