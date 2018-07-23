using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Clerk
{
    public class InventoryTransactionViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<InventoryTransactionResultViewModel> InvTrans {get;set;}

    }

    public class InventoryTransactionResultViewModel
    {
        public int Qty { get; set; }
        public string Remark { get; set; }
        public int ItemID { get; set; }
        public int Transtype { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string UOM { get; set; }
    }
}