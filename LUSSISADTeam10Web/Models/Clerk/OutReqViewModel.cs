using LUSSISADTeam10Web.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Clerk
{
    public class OutReqViewModel
    {
        public OutReqViewModel(int outReqId, int reqId, int deptId, string deptName, DateTime reqDate, string reason, int status, List<OutstandingReqDetailModel> outReqDetails)
        {
            OutReqId = outReqId;
            ReqId = reqId;
            DeptId = deptId;
            DeptName = deptName;
            ReqDate = reqDate;
            Reason = reason;
            Status = status;
            OutReqDetails = outReqDetails;
        }

        public OutReqViewModel() { }

        public int OutReqId { get; set; }
        public int ReqId { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public DateTime ReqDate { get; set; }
        public string Reason { get; set; }
        public int Status { get; set; }
        public bool CanFullFill { get; set; }
        public List<OutstandingReqDetailModel> OutReqDetails { get; set; }
    }
}