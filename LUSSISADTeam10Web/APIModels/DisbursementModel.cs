using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class DisbursementModel
    {
        public DisbursementModel(int disid, int reqid, int ackby, DateTime? reqdate,
            int status, String cpname, String username, String Departmentname, List<DisbursementDetailsModel> dbm )
        {
            this.disid = disid;
            this.reqid = reqid;
            this.ackby = ackby;
            this.reqdate = reqdate;
            this.status = status;
            this.cpname = cpname;
            this.username = username;
            this.Departmentname = Departmentname;
            this.disbursementlist = dbm;

        }
        public DisbursementModel() : this(0, 0, 0, null ,0,"","","",null)
        {
        }

        public int disid { get; set; }
        public int reqid { get; set; }
        public int status { get; set; }
        
        public int ackby { get; set; }
        public String username { get; set; }
        public String Departmentname { get; set; }
        public String cpname { get; set; }
        public DateTime? reqdate { get; set; }

        public List<DisbursementDetailsModel> disbursementlist { get; set; }



    }
}