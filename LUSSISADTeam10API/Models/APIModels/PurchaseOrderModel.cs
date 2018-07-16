using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class PurchaseOrderModel
    {
        public int PoId { get; set; }
        public int Purchasedby { get; set; }
        public String Fullname { get; set; }
        public int Supid { get; set; }
        public String SupName { get; set; }
        public DateTime Podate { get; set; }
        public int Status { get; set; }
    }
}