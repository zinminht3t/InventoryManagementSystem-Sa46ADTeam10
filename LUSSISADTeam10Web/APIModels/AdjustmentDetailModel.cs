using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class AdjustmentDetailModel
    {
        public AdjustmentDetailModel(int adjid, int itemid, string itemdescription, int adjustedqty, string reason, string categoryname, string uom)
        {
            this.Adjid = adjid;
            this.Itemid = itemid;
            this.Itemdescription = itemdescription;
            this.Adjustedqty = adjustedqty;
            this.Reason = reason;
            this.CategoryName = categoryname;
            this.UOM = uom;
        }
        public AdjustmentDetailModel(int itemid, int adjustedqty, string reason): this (0, itemid,"",adjustedqty, reason,"","")
        { }
        public AdjustmentDetailModel() : this(0, 0, "", 0, "", "", "")
        {
        }
        public int Adjid { get; set; }
        public int Itemid { get; set; }
        public string Itemdescription { get; set; }
        public string CategoryName { get; set; }
        public string UOM { get; set; }
        public int Adjustedqty { get; set; }
        public string Reason { get; set; }
        public int? Stock { get; set; } = 0;
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime IssueDate { get; set; } = new DateTime();
    }
}