using LUSSISADTeam10Web.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.HOD
{
    public class ApproveRequisitionViewModel
    {
        public int ReqID { get; set; }
        public string Remark { get; set; }
        public bool Approve { get; set; }
    }
}