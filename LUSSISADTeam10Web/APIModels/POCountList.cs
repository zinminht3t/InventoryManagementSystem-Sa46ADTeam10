using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class POCountList
    {
        public POCountList(string month, int total, int poCount)
        {
            Month = month;
            Total = total;
            PurchaseOrderCount = poCount;
        }
        public POCountList() : this("", 0, 0) { }
        public string Month { get; set; }
        public int Total { get; set; }
        public int PurchaseOrderCount { get; set; }
    }
}