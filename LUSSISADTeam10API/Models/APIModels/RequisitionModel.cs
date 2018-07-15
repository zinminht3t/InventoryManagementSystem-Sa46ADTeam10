using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class RequisitionModel

    {
        public RequisitionModel(int reqid, int? rasiedby, String rasiedbyname, 
            int? approvedby, String approvedbyname, int cpid, string cpname,
            int depid, string depname, int status, DateTime? reqdate) {

            this.reqid = reqid;
            this.raisedby = rasiedby;
            this.rasiedbyname = rasiedbyname;
            this.approvedby = approvedby;
            this.approvedbyname = approvedbyname;
            this.cpid = cpid;
            this.cpname = cpname;
            this.depid = depid;
            this.depname = depname;
            this.status = status;
            this.reqdate = reqdate;

        }
        public RequisitionModel() : this(0, 0, "",0,"", 0, "", 0, "", 0, null)
        {
        }

        public int reqid { get; set; }

        public int? raisedby { get; set; }
        public String rasiedbyname { get; set; }

        public int? approvedby { get; set; }
        public String approvedbyname { get; set; }

        public int depid { get; set; }
        public String depname { get; set; }

        public int cpid { get; set; }
        public String cpname { get; set; }

        public int status { get; set; }

    
        public DateTime? reqdate { get; set; }


    }
}