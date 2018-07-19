using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class DisbursementModel
    {
        public DisbursementModel(int disid, int reqid, int ackby, DateTime? reqdate,
            int status, String cpname, String username, String Departmentname, List<DisbursementDetailsModel> dbm )
        {
            this.Disid = disid;
            this.Reqid = reqid;
            this.Ackby = ackby;
            this.Reqdate = reqdate;
            this.Status = status;
            this.Cpname = cpname;
            this.Username = username;
            this.Departmentname = Departmentname;
            this.Disbursementlist = dbm;

        }
        public DisbursementModel() : this(0, 0, 0, null ,0,"","","",null)
        {
        }

        public int Disid { get; set; }
        public int Reqid { get; set; }
        public int Status { get; set; }
        
        public int Ackby { get; set; }
        public String Username { get; set; }
        public String Departmentname { get; set; }
        public String Cpname { get; set; }
        public DateTime? Reqdate { get; set; }

        public List<DisbursementDetailsModel> Disbursementlist { get; set; }



    }
}