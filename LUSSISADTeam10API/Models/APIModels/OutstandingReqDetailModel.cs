using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class OutstandingReqDetailModel
    {
        public OutstandingReqDetailModel
            (int OutReqId, int ReqId, int Qty)
        {
            this.OutReqId = OutReqId;
            this.ReqId = ReqId;
            this.Qty = Qty;
        }

        public OutstandingReqDetailModel()
            : this(0, 0, 0) { }

        public int OutReqId { get; set; }
        public int ReqId { get; set; }
        public int Qty { get; set; }
    }
}