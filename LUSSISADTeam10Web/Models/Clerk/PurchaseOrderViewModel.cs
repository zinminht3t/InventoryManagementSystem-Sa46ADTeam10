using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Clerk
{
    public class PurchaseOrderViewModel
    {

        public PurchaseOrderViewModel(int poId, int purchasedby, string fullname, int supid, string supName, DateTime? podate, int status, List<PurchaseOrderDetailViewModel> podms)
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

        public PurchaseOrderViewModel() : this(0, 0, "", 0, "", new DateTime(), 0, new List<PurchaseOrderDetailViewModel>()) { }
        public int PoId { get; set; }
        public int Purchasedby { get; set; }
        public String Fullname { get; set; }
        public int Supid { get; set; }
        public String SupName { get; set; }
        public DateTime? Podate { get; set; }
        public int Status { get; set; }
        public List<PurchaseOrderDetailViewModel> podms { get; set; }
    }
}