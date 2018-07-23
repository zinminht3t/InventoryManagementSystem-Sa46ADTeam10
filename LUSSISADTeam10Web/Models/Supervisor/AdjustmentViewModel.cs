using LUSSISADTeam10Web.Models.APIModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Supervisor
{
    public class AdjustmentViewModel
    {
        public int Adjid { get; set; }
        public string Raisedbyname { get; set; }
        public int RaisedToRole { get; set; }
        public string RaisedTobyname { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? Issueddate { get; set; }
        public List<AdjustmentDetailViewModel> adjdvm { get; set; }
    }
    public class AdjustmentDetailViewModel
    {
        public int Adjid { get; set; }
        public string Itemdescription { get; set; }
        public string CategoryName { get; set; }
        public string UOM { get; set; }
        public int Adjustedqty { get; set; }
        public string Reason { get; set; }
        public double? Price { get; set; }
    }
}