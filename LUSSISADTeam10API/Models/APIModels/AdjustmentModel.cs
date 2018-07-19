using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class AdjustmentModel
    {
        public AdjustmentModel(int adjid, int? raisedby,string raisedbyname, int? raisedto,string raisedtoname, DateTime? issueddate, int status, List<AdjustmentDetailModel> adjdms)
        {
            this.Adjid = adjid;
            this.Raisedby = raisedby;
            this.Raisedbyname = raisedbyname;
            this.Raisedto = raisedto;
            this.Raisedtoname = raisedtoname;
            this.Issueddate = issueddate;
            this.Status = status;
            this.Adjds = adjdms;
        }
        public AdjustmentModel() : this(0, 0, "", 0, "", new DateTime(), 0, new List<AdjustmentDetailModel>())
        {
        }
        public int Adjid { get; set; }
        public int? Raisedby { get; set; }
        public string Raisedbyname { get; set; }
        public int? Raisedto { get; set; }
        public string Raisedtoname { get; set; }
        public DateTime? Issueddate { get; set; }
        public int Status { get; set; } = 0;
        public List<AdjustmentDetailModel> Adjds { get; set; }
    }
}