﻿using LUSSISADTeam10Web.Constants;
using LUSSISADTeam10Web.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Clerk
{

    public class OutstandingRequisitonViewModel
    {
        public OutstandingRequisitonViewModel(
                int OutReqId, int ReqId, string Reason, int Status)
        {
            this.OutReqId = OutReqId;
            this.ReqId = ReqId;
            this.Reason = Reason;
            this.Status = Status;
            this.OutReqDetails = new List<OutstandingReqDetailModel>();
        }

        public OutstandingRequisitonViewModel() :
            this(0, 0, "", ConOutstandingsRequisition.Status.PENDING)
        { }

        public int OutReqId { get; set; }
        public int ReqId { get; set; }
        public string Reason { get; set; }
        public int Status { get; set; }
        public List<OutstandingReqDetailModel> OutReqDetails { get; set; }
    }
}