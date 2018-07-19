using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class InventoryTransactionModel
    {
        public InventoryTransactionModel(int tranID, DateTime transDate, int invID, int itemID, string description, string uOM, string categoryName, int transType, int qty, string remark)
        {
            TranID = tranID;
            TransDate = transDate;
            InvID = invID;
            ItemID = itemID;
            Description = description;
            UOM = uOM;
            CategoryName = categoryName;
            TransType = transType;
            Qty = qty;
            Remark = remark;
        }

        public InventoryTransactionModel() : this(0, new DateTime(), 0, 0, "", "", "", 0, 0, "") { }

        public int TranID { get; set; }
        public DateTime TransDate { get; set; }
        public int InvID { get; set; }
        public int ItemID { get; set; }
        public string Description { get; set; }
        public string UOM { get; set; }
        public string CategoryName { get; set; }
        public int TransType { get; set; }
        public int Qty { get; set; }
        public string Remark { get; set; }

    }
}