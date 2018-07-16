using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class PurchaseOrderModel
    {
        public PurchaseOrderModel(int poId, int purchasedby, string fullname, int supid, string supName, DateTime? podate, int status, List<PurchaseOrderDetailModel> podms)
        {
            PoId = poId;
            Purchasedby = purchasedby;
            Fullname = fullname;
            Supid = supid;
            SupName = supName;
            Podate = podate;
            Status = status;
            this.podms = podms;
        }
        public PurchaseOrderModel() : this(0, 0, "", 0, "", new DateTime(), 0, new List<PurchaseOrderDetailModel>()) { }
        public int PoId { get; set; }
        public int Purchasedby { get; set; }
        public String Fullname { get; set; }
        public int Supid { get; set; }
        public String SupName { get; set; }
        public DateTime? Podate { get; set; }
        public int Status { get; set; }
        public List<PurchaseOrderDetailModel> podms { get; set; }
    }
}