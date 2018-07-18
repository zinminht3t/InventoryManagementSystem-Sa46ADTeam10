using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class AdjustmentModel
    {
        public AdjustmentModel(int adjid, int? raisedby,string raisedbyname, int? raisedto,string raisedtoname, DateTime? issueddate, int status, List<AdjustmentDetailModel> adjdms)
        {
            this.adjid = adjid;
            this.raisedby = raisedby;
            this.raisedbyname = raisedbyname;
            this.raisedto = raisedto;
            this.raisedtoname = raisedtoname;
            this.issueddate = issueddate;
            this.status = status;
            this.adjds = adjdms;
        }
        public AdjustmentModel() : this(0, 0, "", 0, "", new DateTime(), 0, new List<AdjustmentDetailModel>())
        {
        }
        public int adjid { get; set; }
        public int? raisedby { get; set; }
        public string raisedbyname { get; set; }
        public int? raisedto { get; set; }
        public string raisedtoname { get; set; }
        public DateTime? issueddate { get; set; }
        public int status { get; set; } = 0;
        public List<AdjustmentDetailModel> adjds { get; set; }
    }
}