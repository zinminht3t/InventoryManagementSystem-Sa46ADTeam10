using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class PurchaseOrderFor5MonthModel
    {
        public string Month { get; set; }

        public double Total { get; set; }

        public int PurchaseOrderCount { get; set; }

    }
}